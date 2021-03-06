
/********************************
   pH control system 
   Najah National University 
   Computer Engineering 
   Hardware Graduation Project 
   Tank Controller 
   Author: Hafiz K.Irshaid
   
   TODO :
      implement the following functions : 
      int Send_Packet(struct Packet px)
      struct Packet Receive_Packet()
   
   *******  Code Table Used in this Program and the Description **********
   a--->the sent char to the master to tell him i'm alive man
         used in handshake to give an ack
         note that a used to send ack to other commands 
   h--->the readed char from the master to check the connectivity,handshake issue
   L--->read level sensor
   F--->read flow sensor
   d--->disconnect the program

   note that 
//for firas the address is 0x15 
//for hafiz the address is 0x10

************* includes ********************/

#include <first_tank.h>

/*************** Deveices ****************/

//this is for Serial port configarations 
#use rs232(baud=9600,parity=N,xmit=PIN_C6,rcv=PIN_C7,bits=8,stream=PORT1,restart_wdt)

#define DEVICE_ADDRESS 0x15

//this is for I2C configarations 
#use i2c(Slave,Fast,sda=PIN_C4,scl=PIN_C3,address=DEVICE_ADDRESS)

/**************** System variables *********/
#define SYSTEM_OFF 0   //system is off 
#define SYSTEM_ON 1    //system is on 
#define NOTHING 5
#define SEND_FLOW 6
#define SEND_LEVEL 7
#define SET_PUMP_SPEED 8
#define DISCONNECT_PROGRAM 9
#define SEND_ACK 10

/**** THIS VARIABLE SHOUD HOLDS THE VALUE OF THE STATUS OF THE SYSTEM ****/
unsigned int8 status = SYSTEM_OFF;     //the status of the system 
unsigned int8 hanshake_variable = 0;    //used in handshake process 
unsigned int8 current_state = NOTHING;  //the current state of the state machine, used in intrrupts 

enum packet_types
{
   HANDSHAKE = 0x01,
   SEND_FLOW_l = 0x02,
   
} Types;

//this is the structure of the packet that we wanna use it to communicate in I2C Bus
struct packet
{
  unsigned int8 Packet_Num;
  unsigned int8 Packet_Type;
  unsigned int8 Data_1;
  unsigned int8 Data_2;
  unsigned int8 Data_3;
  unsigned int8 Chech_Sum;
};

void send_packet(struct packet px)
{
//px.Packet_Type = Types.HANDSHAKE;
  //write all structure memeber to the bus
  i2c_write(px.Packet_Num);
  i2c_write(px.Packet_Type);
  i2c_write(px.Data_1);
  i2c_write(px.Data_2);
  i2c_write(px.Data_3);
  i2c_write(px.Chech_Sum);
}

//this function is going to receive the packet 
struct packet Receive_Packet()
{
   struct packet Received;
   Received.Packet_Num = i2c_read();
   Received.Packet_Type = i2c_read();
   Received.Data_1 = i2c_read();
   Received.Data_2 = i2c_read();
   Received.Data_3 = i2c_read();
   Received.Chech_Sum = i2c_read();
   return Received;
}


/*** this function is gonna control the speed of the Pump ***/
void set_PWM_PUMP_Speed(int8 speed)
{
  // set_pwm2_duty(speed);
  // printf("the speed of the pump is %u \n\r",speed);
}

/*** this function is going to read the value of the flow sensor ***/
int8 read_flow_sensor()
{
   int8 value = 14;
   //printf("the value of flow sensor is %u \n\r",value);
   return value;
}

/***** this function is going to return the value of the level sensor *****/ 
int8 read_level_sensor()
{
   int8 value = 20;
  // printf("the value of level sensor is %u \n\r",value);
   return value;
}

/***** this fucntion prints the system status variables *****/
void print_system_state()
{

   printf("Program state is %u \n\r",status);
   printf("current state is %u \n\r",current_state);
   printf("handshake state is %u \n\r",hanshake_variable);
}

/*** INTURRUPT FUNCTION ROTINE ***/
#int_SSP
void SSP_isr(void) 
{
  printf("**************New Inturrpt**************\n\r");
   
   //delay_ms(100);
  // print_system_state();
   
   //get the state of I2C Bus
   int8 state = i2c_isr_state();
   
   //printf("The State of I2C Bus is %u\n\r",state);
   
   if(state >= 0x80)//Master is requesting data
   {
      //printf("Master is requesting data \n\r");
      if(status == SYSTEM_ON)
      {
         //printf("System is ON, checking the current state!\n\r");
         switch(current_state)
         {
            
            case SEND_LEVEL:
             //  printf("Sending the value of level sensor to the master %u \n\r",read_level_sensor());
               //i2c_write('l');
               i2c_write(read_level_sensor());
               break;
               
            case SEND_FLOW:
              // printf("Sending the value of flow sensor to the master %u \n\r",read_flow_sensor());
               // i2c_write('f');
               i2c_write(read_flow_sensor());
               
               break;
               
            case SEND_ACK:
               //printf("Sending ACK to Master. \n\r");
               i2c_write('a');
               break;
               
            case SET_PUMP_SPEED:
               //printf("Sending SET_PUMP_SPEED ACK. \n\r");
               i2c_write('a');
               break;
         }
         
         current_state = NOTHING;
      }
      else if(status == SYSTEM_OFF)
      {
         //two way handshake
         if(hanshake_variable == 1)
         {
            //printf("Send char 'a' to master\n\r");
            
            //send char a to the master,this is the ACK
            //printf("the status of read is %u \n\r",i2c_write('a'));
            
            //i2c_write('a');
            //make the program on
            status = SYSTEM_ON;
         }
      }
   }
   else if(state < 0x80)//Master is sending data
   {
      //check system state
      delay_ms(50);
     // printf("Master is sending data\n\r");
      if(status == SYSTEM_ON)
      {
         i2c_read();
         delay_ms(50);
         //printf("fisrt byte is the address %x\n\r",i2c_read());
         char command = (char)i2c_read();
         
         //printf("the command is %c \n\r",command);
         switch(command)
         {
            case 'L':
             //  printf("Reading Level Sensor\r\n");
               current_state = SEND_LEVEL;
               break;
               
            case 'F':
               //printf("Reading flow sensor \r\n");
               current_state = SEND_FLOW;
               break;
               
            case 'd':
               status = SYSTEM_OFF;
               hanshake_variable = 0;
              // printf("System Disconnected \n\r");
               break;
               
            case 'h':
            
               //this is if the master request another handshake,send it or it go in deep loop
               //wait for ever LMFAO
               current_state = SEND_ACK;
               break;
               
            case 'P':
               //set the current state to set pump state to send an ack to the master 
               current_state = SET_PUMP_SPEED;
               delay_ms(50);
               //read the value 
               int8 Pump_Speed = i2c_read();
               
               //pass it to this fucntion to change the speed of the pump
               set_PWM_PUMP_Speed(Pump_Speed);
               break;
               
            default:
            
              // printf("UnKnown Command!\n\r");
         }
      }
      else if(status == SYSTEM_OFF)
      {
         //printf("reading char h from mastert \n\r");
         delay_ms(50);
         i2c_read();
         //fisrt byte is the address
        // printf("fisrt byte is the address%x\n\r",);
         delay_ms(50);
         char read_char = i2c_read();
         
        // printf("I Just received the char%c\n\r",read_char);
         
         //if the system received 'h' then this is for handshake
         if(read_char == 'h')
         {
            //set handshake variable to 1
            //printf("OK \n\r");
            hanshake_variable = 1;
            //here do not make the program on,make it above when you send the char a
         }
         else
         {
           // printf("Not OK \n\r");
         }
      }
   }
}

/*********** Main Function ***********/
void main()
{
   //enable I2C Inturrept
   enable_interrupts(int_SSP);
   enable_interrupts(GLOBAL);
   
   //setup_timer_1(T1_INTERNAL|T1_DIV_BY_1);      //65.5 ms overflow
   //setup_timer_2(T2_DIV_BY_4,511,1);      //1.0 ms overflow, 1.0 ms interrupt

   setup_ccp2(CCP_PWM);
   //set_pwm2_duty(0);
   
   printf("***************Start of the Program*****************\n\r");
   while(TRUE)
   {
      //TODO: User Code
   }
}

