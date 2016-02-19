/**
 * pH control system Monitoring Program 
 * Hafiz K.Irshaid
 * hkmmi.2010@gmail.com
 * Description : this is a DLL like middleware between MatLab and Arduino Microcontroller to hanle the communcations.
 */


/***********  Code Table Used in this Program and the Description ********
 *          C ---> connect
 *          D ---> disconnect 
 *          Y ---> Handshake with tank one is OK(yes)
 *          N ---> Handshake with tank two is not OK (NO)
 *          f ---> read flow sensor
 *          l ---> read level sensor 
 *          
***************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace pH_Controller_console
{
    public partial class pHControlSystem : Form
    {
        //this is the structure of the packet that we wanna use it to communicate in I2C Bus
        struct Packet
        {
            public byte Packet_Type;
            public byte Data1;
            public byte Data2;
            public byte Chech_Sum;
        };


        int Send_Packet(Packet px)
        {
            return 1;
        }

        Packet Receive_Packet()
        {
            Packet c = new Packet();

            c.Packet_Type = 10;
            c.Data1 = 10;
            c.Data2 = 10;
            c.Chech_Sum = 20;
            return c;
        }


        /// <summary>
        /// 
        /// </summary>
        private SerialPort serialPort;

        /// <summary>
        /// 
        /// </summary>
        private string[] PortsArray;

        /// <summary>
        /// 
        /// </summary>
        private int[] BaudRatesArray = { 2400, 4800, 9600, 19200 };

        /// <summary>
        /// 
        /// </summary>
        public pHControlSystem()
        {
            InitializeComponent();

            //disable all buttons in the GUI
            ScanI2CBus.Enabled = false;
            StartMonitoringpH.Enabled = false;
            ReadFlowLevelSensorsTank1.Enabled = false;
            ReadFlowLevelSensorsTank2.Enabled = false;
            SetPumpSpeedTank1.Enabled = false;
            SetPumpSpeedTank2.Enabled = false;
            StartpHProcess.Enabled = false;
            StopProcess.Enabled = false;
            ReadFlowSensorTank1.Enabled = false;
            Tank1HandShake.Enabled = false;

            //get all available ports in this machine
            PortsArray = SerialPort.GetPortNames();

            //add all serial ports available in this computer to the compobox 
            foreach (string port in PortsArray)
            {
                SerialPortsList.Items.Add(port);
            }

            //add all baud rates in the array to the combobox 
            foreach (int BaudRate in BaudRatesArray)
            {
                BaudRateList.Items.Add(BaudRate);
            }

            //set first one selected in serial port combobox
            //SerialPortsList.SelectedIndex = 0;

            //set 9600 kbps baud rate in baud rate compobox 
            BaudRateList.SelectedIndex = 2;

            //disable disconnect button
            DisconnectArduino.Enabled = false;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectToArduino_Click(object sender, EventArgs e)
        {
            string PortName = SerialPortsList.SelectedItem.ToString();
            int baudrate = Int32.Parse(BaudRateList.SelectedItem.ToString());
            try
            {
                serialPort = new SerialPort(PortName, baudrate, Parity.None);
                serialPort.ReadTimeout = 10000;
                serialPort.Open();


                //here do hand shake 

                serialPort.Write("C");

                char ack = (char)serialPort.ReadChar();

                //if char C received then all thing is good 
                if (ack == 'C')
                {
                    ConnectToArduino.Enabled = false;
                    DisconnectArduino.Enabled = true;
                    Tank1HandShake.Enabled = true;
                    //disable all buttons in the GUI
                    
                }
                else
                {
                    MessageBox.Show("Error, Restart Arduino Please!");
                    serialPort.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisconnectArduino_Click(object sender, EventArgs e)
        {
            try
            {
                //send char D to disconnect 
                serialPort.Write("D");

                //wait the ack if the char is D then the Arduino disconnected sucessfully 
                char ack = (char)serialPort.ReadChar();

                if (ack == 'D')
                {

                    //disable all buttons in the GUI
                    ScanI2CBus.Enabled = false;
                    StartMonitoringpH.Enabled = false;
                    ReadFlowLevelSensorsTank1.Enabled = false;
                    ReadFlowLevelSensorsTank2.Enabled = false;
                    SetPumpSpeedTank1.Enabled = false;
                    SetPumpSpeedTank2.Enabled = false;
                    StartpHProcess.Enabled = false;
                    StopProcess.Enabled = false;
                    ReadFlowSensorTank1.Enabled = false;
                    //MessageBox.Show("Disconneted");
                }
                else
                {
                    MessageBox.Show("Problem, Restart Arduino Please");
                }

                serialPort.Close();
                ConnectToArduino.Enabled = true;
                DisconnectArduino.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("pH Control System\nThis program is designed by Firas Dweekat and Eng.Hafiz K.Irshaid");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisconnectSerialPort();
            System.Environment.Exit(0);
        }

        private void ScanI2CBus_Click(object sender, EventArgs e)
        {
            

        }

        private void ReadFlowLevelSensors_Click(object sender, EventArgs e)
        {
            string message = "";
            //fisrt do level 
            //serialPort.DiscardInBuffer();
            serialPort.Write("l");
            message += serialPort.ReadByte();
            //int value2 = serialPort.ReadChar();
            //message += "  ";
            //serialPort.Write("f");
            // message += serialPort.ReadExisting();

            MessageBox.Show("Value is " + message);
        }

        private void SetPumpSpeed_Click(object sender, EventArgs e)
        {
            int speed = Int32.Parse(PumpSpeedTank1.Text);
            serialPort.Write("p");
            byte[] speed_in_bytes = new byte[1];
            speed_in_bytes[0] = Byte.Parse("" + speed);

            serialPort.Write("" + speed);


            char ack = (char)serialPort.ReadChar();

            if (ack == 'Y')
            {
                MessageBox.Show(String.Format("{0}", speed_in_bytes[0]));
            }
            else
            {
                MessageBox.Show(String.Format("Problem !"));

            }
        }

        private void StopProcess_Click(object sender, EventArgs e)
        {

        }

        private void SetPumpSpeedTank2_Click(object sender, EventArgs e)
        {

        }

        private void ReadFlowLevelSensorsTank2_Click(object sender, EventArgs e)
        {

        }

        private void StartpHProcess_Click(object sender, EventArgs e)
        {

        }

        private void pHControlSystem_FormClosed(object sender, FormClosedEventArgs e)
        {
            DisconnectSerialPort();
        }

        private void DisconnectSerialPort()
        {


            try
            {
                serialPort.Write("D");
                serialPort.Close();
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
            }
        }

        private void Tank1HandShake_Click(object sender, EventArgs e)
        {

            //this fucntion to hanshake with Tank 1
            serialPort.Write("H");

            char ack = (char)serialPort.ReadChar();

            if (ack == 'Y')
            {
                MessageBox.Show("OK " + ack);

                ScanI2CBus.Enabled = true;
                StartMonitoringpH.Enabled = true;
                ReadFlowLevelSensorsTank1.Enabled = true;
                ReadFlowLevelSensorsTank2.Enabled = true;
                ReadFlowSensorTank1.Enabled = true;
                SetPumpSpeedTank1.Enabled = true;
                SetPumpSpeedTank2.Enabled = true;

                StartpHProcess.Enabled = true;
                StopProcess.Enabled = true;

            }
            else if (ack == 'N')
            {
                MessageBox.Show("Not OK " + ack);
            }
        }

        private void ReadFlowSensorTank1_Click(object sender, EventArgs e)
        {
            serialPort.Write("f");
            serialPort.DiscardInBuffer();
            var message1 = serialPort.ReadByte();
            // var message2 = (char)serialPort.ReadChar();
            //var message3 = (char)serialPort.ReadChar();

            MessageBox.Show("Value is " + message1);
        }
    }
}