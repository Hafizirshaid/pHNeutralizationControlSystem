/*
     pH Control System
 Master Program Arduino Uno 
 Najah National University 
 Computer Engineering 
 Hardware Graduation Project 
 
 note that there are some chars used in this program, if you do not understand them, go to the first file 
 that i have created it and you will find what you want 
 TODO :
 implement a protocol to communicate through I2C
 
 */

#include <Wire.h>

//#include <SoftwareSerial.h>
//SoftwareSerial Debug(11, 12); // RX, TX

#define TANK1_ADDRESS 0x10   //tank 1 address on I2C bus 0x10 in pic
#define TANK2_ADDRESS 0x08   //tank 2 address on I2C bus 0x15 in pic

//####### these data types for packet type feild in the struct ######
#define TYPE_PACKET_HANDSHAKE_PC  0x00 //to handshake with the computer 
#define TYPE_HANDSHAKE_TANKS      0x01 //to hanshake with the PIC (Tank)
#define TYPE_DISCONNECT_PC        0x02 //to disconnect the program 
#define TYPE_ACK                  0x03 //acknolgment 
#define TYPE_NACK                 0x04 //negative ack 
#define TYPE_REQUEST_FLOW         0x05 //to request the flow sensor 
#define TYPE_REQUEST_LEVEL        0x06 //to reqest the level sensor 
#define TYPE_REQUEST_GAS          0x07 //to request the gas sensor 
#define TYPE_REQUEST_pH           0x08 //to requst the pH sensor 
#define TYPE_REQUEST_TEMP         0x09 // to requset the temp sensor
#define TYPE_BAD_PACKET           0xFF //packet that has error in it's check sum 
#define TYPE_REQUEST_ALL_SENSORS  0x12 //type to request all sensors in the system at all 
#define TYPE_SET_PUMP_SPEED       0x13 //to set the pump speed
#define TYPE_REQUEST_SCAN_I2C     0x14 //to scan i2c Bus 
#define TYPE_REQUEST_LAST_SENT_PACKET 0x15

//##### PROGRAM STATES ###########
#define PROGRAM_CONNECT           0x0A //the program is connected 
#define PROGRAM_DISCONNECT        0x0B //the program is disconnected 
#define MIXER_ON                  0x0C //Mixer on, turn mixer on 
#define MIXER_OFF                 0x0D //Mixer off, turn mixer off
#define STATE_TANK1_CONNECT       0x0E //tank 1 status connect
#define STATE_TANK1_DISCONNECT    0x0F //tank 1 status disconnect
#define STATE_TANK2_CONNECT       0x10 //tank 2 connect 
#define STATE_TANK2_DISCONNECT    0x11 //tank 2 disconnect

int program_state = PROGRAM_DISCONNECT;

const int delay_time = 20;

/******************* ports analog and digital names **********/
const int pH_Sensor = A0;       //pH sensor at analog port A0
const int Mixer = 13;           // mixer output on PIN 13
const int Gas_Sensor = A1;      // gas sensor on port A1;
const int Temp_Sensor = A2;     //temperature sensor on port A2

/********************** global variables ********************/
int pH_value;                               //the pH value wanted to start the process 
int tank1_status = STATE_TANK1_DISCONNECT;  //this variable holds the status of the Tank 1
int tank2_status = STATE_TANK2_DISCONNECT;  //this variable holds the status of the Tank 2



//int delay_time = 10;

//we have 6 bytes in a struct 
#define NUMBER_OF_BYTES_IN_STRUCT 6



//this variable will hold the number of bytes in the packet 
#define NUMBER_OF_BYTES_IN_PACKET 6

//the structure of the i2c packet that will be sent and receved throght i2c bus
struct i2c_packet
{
  byte packet_type;
  byte data_1;
  byte data_2;
  byte data_3;
  byte data_4;
  byte checksum;
};

/*
 * this function is going to receive a packet from i2c bus
 */
struct i2c_packet recevie_i2c_packet(int address)
{
  //byte packet_type, data_1, data_2, data_3, data_4, checksum;

  //request from the address 
  Wire.requestFrom(address, NUMBER_OF_BYTES_IN_PACKET);

  //to hold the bytes received from i2c bus 
  byte received_bytes_buffer[6];  
  int i = 0;

  //store all bytes in the buffer 
  while(Wire.available())
  {
    received_bytes_buffer[i++] = Wire.read();
  }

  //store all bytes in the packet 
  struct i2c_packet received_packet;
  received_packet.packet_type = received_bytes_buffer[0];
  received_packet.data_1 = received_bytes_buffer[1];
  received_packet.data_2 = received_bytes_buffer[2];
  received_packet.data_3 = received_bytes_buffer[3];
  received_packet.data_4 = received_bytes_buffer[4];
  received_packet.checksum = received_bytes_buffer[5];

  //return the packet 
  return received_packet;
}

/*
 * this function is going to send a packet throught i2c bus 
 */
int send_i2c_packet(byte address,byte packet_type, byte data_1,byte data_2,byte data_3,byte data_4)
{
  byte check_sum = 0;

  check_sum = check_sum ^ packet_type;
  check_sum = check_sum ^ data_1;
  check_sum = check_sum ^ data_2;
  check_sum = check_sum ^ data_3;
  check_sum = check_sum ^ data_4;

  //begin transmittion to the given address 
  Wire.beginTransmission(address); 

  //write all data on the bus 
  Wire.write(packet_type);
  Wire.write(data_1);
  Wire.write(data_2);
  Wire.write(data_3);
  Wire.write(data_4);
  Wire.write(check_sum);

  //end the transmition and return the error code 
  int error = Wire.endTransmission(); 
  return error;
}




//struct of a serial packet that always should send to the computer 
struct serial_packet
{
  byte packet_type;
  byte data_1;
  byte data_2;
  byte data_3;
  byte data_4;
  byte checksum;
};

struct serial_packet last_sent_packet;

//this function is going to receive a packet from the serial port 
struct serial_packet receive_packet()
{
  //Serial.flush();
  //wait until data come to serial buffer 
  while(!Serial.available());

  struct serial_packet received_packet;

  //read all packet member data 
  received_packet.packet_type = Serial.read();
  while(!Serial.available());

  received_packet.data_1 = Serial.read();
  while(!Serial.available());

  received_packet.data_2 = Serial.read();
  while(!Serial.available());

  received_packet.data_3 = Serial.read();
  while(!Serial.available());

  received_packet.data_4 = Serial.read();
  while(!Serial.available());

  received_packet.checksum = Serial.read();

  //check checksum
  byte check_sum = 0x00;

  //do xor for all members 
  check_sum = check_sum ^ received_packet.packet_type;
  check_sum = check_sum ^ received_packet.data_1;
  check_sum = check_sum ^ received_packet.data_2;
  check_sum = check_sum ^ received_packet.data_3;
  check_sum = check_sum ^ received_packet.data_4;

  //if the packet is corrupted then make it's type BAD_PACKET 
  if(check_sum != received_packet.checksum)
  {
    received_packet.packet_type = TYPE_BAD_PACKET;
  }
  return received_packet;
}

//this function is going to create a packet 
struct serial_packet create_packet(byte packet_type, byte data_1, byte data_2, byte data_3, byte data_4)
{
  //packet object 
  struct serial_packet created_packet;

  //assign all parameters to the struct 
  created_packet.packet_type = packet_type;
  created_packet.data_1 = data_1;
  created_packet.data_2 = data_2;
  created_packet.data_3 = data_3;
  created_packet.data_4 = data_4;

  //calculate check sum
  byte check_sum = 0x00;

  check_sum = check_sum ^ packet_type;
  check_sum = check_sum ^ data_1;
  check_sum = check_sum ^ data_2;
  check_sum = check_sum ^ data_3;
  check_sum = check_sum ^ data_4;

  created_packet.checksum = check_sum;
  return created_packet;
}

//this function shoud send the given packet throuht the serial port 
void send_packet(struct serial_packet sent_packet)
{
  //Serial.flush();
  //delay(50);

  Serial.write(sent_packet.packet_type);
  //delay(10);
  Serial.write(sent_packet.data_1);
  //delay(10);
  Serial.write(sent_packet.data_2);
  //delay(10);
  Serial.write(sent_packet.data_3);
  //delay(10);
  Serial.write(sent_packet.data_4);
  //delay(10);
  Serial.write(sent_packet.checksum);

  last_sent_packet = sent_packet;

  //Serial.flush();
}


//this function is going to read the flow sensor from the given tank 
byte read_flow_sensor_from_tank(int TANK_ADDRESS)
{
  send_i2c_packet(TANK_ADDRESS, TYPE_REQUEST_FLOW,0,0,0,0);
  delay(delay_time);
  struct i2c_packet flow_sensor_response ;
  flow_sensor_response = recevie_i2c_packet(TANK_ADDRESS);
  return flow_sensor_response.data_1;
}

//this function is going to read the level sensor from the given tank 
byte read_level_sensor_from_tank(int TANK_ADDRESS)
{
  send_i2c_packet(TANK_ADDRESS, TYPE_REQUEST_LEVEL,0,0,0,0);
  delay(delay_time);
  struct i2c_packet level_sensor_response ;
  level_sensor_response = recevie_i2c_packet(TANK_ADDRESS);
  return level_sensor_response.data_1;
}

//this function is going to set the pump speed 
byte set_pump_speed_tank(int TANK_ADDRESS, byte pump_speed)
{
  //send a packet to set the pump speed 
  send_i2c_packet(TANK_ADDRESS, TYPE_SET_PUMP_SPEED,pump_speed,0,0,0);
  
  //wait few ms 
  delay(delay_time);
  
  //get the ack 
  struct i2c_packet ack;
  ack = recevie_i2c_packet(TANK_ADDRESS);
  
  //if ack is received return the ack else return nack 
  if(ack.packet_type == TYPE_ACK)
  {
   return TYPE_ACK;
  }
  else 
  {
    return TYPE_NACK;
  }
}

//this function is going to read pH sensor value from ADC
byte read_pH_sensor()
{
  //for test here return 10;
  return 19;
}

//this function is going to read temperature from the environment 
byte read_temp_sensor()
{
  return 10; 
}

//read gas sensor 
byte read_gas_sensor()
{
  return 7;
}

//this function is going to set mixer on or off 
void Set_Mixer_State(int state)
{
  if(state == MIXER_ON)
  {
    //turn mixer on 
  }
  else if(state == MIXER_OFF)
  {
    // turn  mixer off 
  }
}

//this function have to scan i2c bus and check two tanks are connected or not 
void scan_I2C_Bus()
{
  //array contains all devices 
  int devices[4];

  for(int i = 0 ; i < 4; i++)
  {
    devices[i] = 0;
  }
  //index of the array 
  int device_index = 0;

  //check all addresses from 1 to 127
  for(int i = 1; i < 127; i++)
  {
    //begin and end transmittion 
    Wire.beginTransmission(i); 
    int error = Wire.endTransmission();

    //if the error is 0 then this address is vali
    if(error == 0)
    {
      //this is a valid device address 
      devices[device_index++] = i;
    } 
  }

  //here send all devices in the packet to the PC
  struct serial_packet devices_packet;
  devices_packet = create_packet(TYPE_REQUEST_SCAN_I2C,devices[0],devices[1],devices[2],devices[3]);

  //send the packet ot the computer 
  send_packet(devices_packet);
}

//this function is going to do handshake with the given tank 
byte handshake_with_tank(int TANK_ADDRESS)
{

  send_i2c_packet(0x0A,TYPE_HANDSHAKE_TANKS,0,0,0,0);
  //Serial.println(ee);
  delay(delay_time);


  struct i2c_packet ack ;
  ack = recevie_i2c_packet(0x0A);
  if(ack.packet_type == TYPE_ACK)
  {
    //struct serial_packet ack = create_packet(TYPE_ACK,0,0,0,0);
    //send_packet(ack);
    return TYPE_ACK;
  }
  else
  {
    return TYPE_NACK;
    //struct serial_packet nack = create_packet(TYPE_NACK,0,0,0,0);
    //send_packet(nack);

  }

}

//setup function 
void setup()
{
  Serial.begin(9600); 
  Wire.begin();
  //Debug.begin(9600);
}


/*void print_packet(struct serial_packet p)
 {
 Debug.println("****************");
 Debug.println(p.packet_type);
 Debug.println(p.data_1);
 Debug.println(p.data_2);
 Debug.println(p.data_3);
 Debug.println(p.data_4);
 Debug.println(p.checksum);
 
 }*/
//main loop function 
void loop()
{
  //check the program state 
  //if the progream disconnect 
  if(program_state == PROGRAM_DISCONNECT)
  {
    //wait until a packet come from serial port 
    struct serial_packet handshake_packet;
    handshake_packet = receive_packet();
    //print_packet(handshake_packet);
    //check what is the packet 
    if(handshake_packet.packet_type == TYPE_PACKET_HANDSHAKE_PC)
    {
      //send ack 
      struct serial_packet ack = create_packet(TYPE_ACK,0,0,0,0);
      send_packet(ack);

      //make the program running
      program_state = PROGRAM_CONNECT;
    }
    else if(handshake_packet.packet_type == TYPE_BAD_PACKET)
    {
      //send NACK if the packet corrupted 
      struct serial_packet nack = create_packet(TYPE_NACK,0,0,0,0);
      send_packet(nack);
    }
  }
  else
  {
    //wait until a packet come from serial port 
    struct serial_packet command_packet;
    command_packet = receive_packet();
    //print_packet(command_packet);
    //check what packet it is and then do it's action 
    if(command_packet.packet_type == TYPE_BAD_PACKET)
    {
      //send NACK if the packet corrupted 
      struct serial_packet nack = create_packet(TYPE_NACK,0,0,0,0);
      send_packet(nack);
    }
    else if(command_packet.packet_type == TYPE_HANDSHAKE_TANKS)
    {
      int Tank_Address = (int)command_packet.data_1;

      byte Ack = handshake_with_tank(Tank_Address);

      if(Ack == TYPE_ACK)
      {
        struct serial_packet ack = create_packet(TYPE_ACK,0,0,0,0);
        send_packet(ack);

      }
      else
      {
        //send NACK if the packet corrupted 
        struct serial_packet nack = create_packet(TYPE_NACK,0,0,0,0);
        send_packet(nack);

      }
    }
    else if(command_packet.packet_type == TYPE_DISCONNECT_PC)
    {

    }
    else if(command_packet.packet_type == TYPE_REQUEST_FLOW)
    {
      byte flow_value = read_flow_sensor_from_tank(command_packet.data_1);
      struct serial_packet flow_response;
      flow_response = create_packet(TYPE_REQUEST_FLOW,flow_value,0,0,0);
      send_packet(flow_response);

    }
    else if(command_packet.packet_type == TYPE_REQUEST_LEVEL)
    {
      byte level_value = read_level_sensor_from_tank(command_packet.data_1);
      struct serial_packet level_response;
      level_response = create_packet(TYPE_REQUEST_LEVEL,level_value,0,0,0);
      send_packet(level_response);

    }
    else if(command_packet.packet_type == TYPE_REQUEST_GAS)
    {
      //read gas sensor 
      byte gas_sensor_value = read_gas_sensor();

      //send the response packet 
      struct serial_packet gas_response;
      gas_response = create_packet(TYPE_REQUEST_GAS,gas_sensor_value,0,0,0);
      send_packet(gas_response);
    }
    else if(command_packet.packet_type == TYPE_REQUEST_pH)
    {
      //read gas sensor 
      byte pH_sensor_value = read_pH_sensor();

      //send the response packet 
      struct serial_packet pH_response;
      pH_response = create_packet(TYPE_REQUEST_pH,pH_sensor_value,0,0,0);
      send_packet(pH_response);

    }
    else if(command_packet.packet_type == TYPE_REQUEST_TEMP)
    {

      //read gas sensor 
      byte Temp_sensor_value = read_temp_sensor();

      //send the response packet 
      struct serial_packet temp_response;
      temp_response = create_packet(TYPE_REQUEST_TEMP,Temp_sensor_value,0,0,0);
      send_packet(temp_response);

    }
    else if(command_packet.packet_type == TYPE_REQUEST_ALL_SENSORS)
    {

    }
    else if(command_packet.packet_type == TYPE_SET_PUMP_SPEED)
    {
      int ack = set_pump_speed_tank(command_packet.data_1, command_packet.data_2);
      if(ack == TYPE_ACK)
      {
        //send ack 
        struct serial_packet ack = create_packet(TYPE_ACK,0,0,0,0);
        send_packet(ack);

      }
      else
      {

        //send ack 
        struct serial_packet nack = create_packet(TYPE_NACK,0,0,0,0);
        send_packet(nack);
      }
    }
    else if(command_packet.packet_type == TYPE_REQUEST_SCAN_I2C)
    {
      scan_I2C_Bus();
    }

    else if(command_packet.packet_type == TYPE_PACKET_HANDSHAKE_PC)
    {
      //send ack 
      struct serial_packet ack = create_packet(TYPE_ACK,0,0,0,0);
      send_packet(ack);
    }
    else if(command_packet.packet_type == TYPE_REQUEST_LAST_SENT_PACKET)
    {
      send_packet(last_sent_packet);
    }
  }
}

