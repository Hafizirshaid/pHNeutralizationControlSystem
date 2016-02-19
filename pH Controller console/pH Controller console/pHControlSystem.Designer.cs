namespace pH_Controller_console
{
    partial class pHControlSystem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ConnectToArduino = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SerialPortsList = new System.Windows.Forms.ComboBox();
            this.BaudRateList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DisconnectArduino = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ProgramStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.ScanI2CBus = new System.Windows.Forms.Button();
            this.StartMonitoringpH = new System.Windows.Forms.Button();
            this.ReadFlowLevelSensorsTank1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.AcidTankAddress = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.PumpSpeedTank1 = new System.Windows.Forms.TextBox();
            this.SetPumpSpeedTank1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.LevelSensorTank1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.FlowSensorTank1 = new System.Windows.Forms.TextBox();
            this.StopProcess = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BaseTankAddress = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.PumpSpeedTank2 = new System.Windows.Forms.TextBox();
            this.SetPumpSpeedTank2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.LevelSensorTank2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.FlowSensorTank2 = new System.Windows.Forms.TextBox();
            this.ReadFlowLevelSensorsTank2 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pHValue = new System.Windows.Forms.TextBox();
            this.StartpHProcess = new System.Windows.Forms.Button();
            this.Tank1HandShake = new System.Windows.Forms.Button();
            this.ReadFlowSensorTank1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConnectToArduino
            // 
            this.ConnectToArduino.Location = new System.Drawing.Point(124, 74);
            this.ConnectToArduino.Name = "ConnectToArduino";
            this.ConnectToArduino.Size = new System.Drawing.Size(121, 24);
            this.ConnectToArduino.TabIndex = 0;
            this.ConnectToArduino.Text = "Connect";
            this.ConnectToArduino.UseVisualStyleBackColor = true;
            this.ConnectToArduino.Click += new System.EventHandler(this.ConnectToArduino_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1006, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // SerialPortsList
            // 
            this.SerialPortsList.FormattingEnabled = true;
            this.SerialPortsList.Location = new System.Drawing.Point(124, 16);
            this.SerialPortsList.Name = "SerialPortsList";
            this.SerialPortsList.Size = new System.Drawing.Size(121, 21);
            this.SerialPortsList.TabIndex = 2;
            // 
            // BaudRateList
            // 
            this.BaudRateList.FormattingEnabled = true;
            this.BaudRateList.Location = new System.Drawing.Point(124, 43);
            this.BaudRateList.Name = "BaudRateList";
            this.BaudRateList.Size = new System.Drawing.Size(121, 21);
            this.BaudRateList.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Arduino Serial Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Baud Rate";
            // 
            // DisconnectArduino
            // 
            this.DisconnectArduino.Location = new System.Drawing.Point(124, 102);
            this.DisconnectArduino.Name = "DisconnectArduino";
            this.DisconnectArduino.Size = new System.Drawing.Size(121, 25);
            this.DisconnectArduino.TabIndex = 6;
            this.DisconnectArduino.Text = "Disconnect";
            this.DisconnectArduino.UseVisualStyleBackColor = true;
            this.DisconnectArduino.Click += new System.EventHandler(this.DisconnectArduino_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DisconnectArduino);
            this.groupBox1.Controls.Add(this.ConnectToArduino);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.SerialPortsList);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.BaudRateList);
            this.groupBox1.Location = new System.Drawing.Point(743, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(251, 151);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProgramStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 396);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1006, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ProgramStatus
            // 
            this.ProgramStatus.Name = "ProgramStatus";
            this.ProgramStatus.Size = new System.Drawing.Size(41, 17);
            this.ProgramStatus.Text = "Hello !";
            // 
            // ScanI2CBus
            // 
            this.ScanI2CBus.Location = new System.Drawing.Point(12, 46);
            this.ScanI2CBus.Name = "ScanI2CBus";
            this.ScanI2CBus.Size = new System.Drawing.Size(167, 23);
            this.ScanI2CBus.TabIndex = 9;
            this.ScanI2CBus.Text = "Scan I2C Bus";
            this.ScanI2CBus.UseVisualStyleBackColor = true;
            this.ScanI2CBus.Click += new System.EventHandler(this.ScanI2CBus_Click);
            // 
            // StartMonitoringpH
            // 
            this.StartMonitoringpH.Location = new System.Drawing.Point(12, 81);
            this.StartMonitoringpH.Name = "StartMonitoringpH";
            this.StartMonitoringpH.Size = new System.Drawing.Size(167, 23);
            this.StartMonitoringpH.TabIndex = 10;
            this.StartMonitoringpH.Text = "Start Monitoring";
            this.StartMonitoringpH.UseVisualStyleBackColor = true;
            // 
            // ReadFlowLevelSensorsTank1
            // 
            this.ReadFlowLevelSensorsTank1.Location = new System.Drawing.Point(15, 128);
            this.ReadFlowLevelSensorsTank1.Name = "ReadFlowLevelSensorsTank1";
            this.ReadFlowLevelSensorsTank1.Size = new System.Drawing.Size(168, 23);
            this.ReadFlowLevelSensorsTank1.TabIndex = 11;
            this.ReadFlowLevelSensorsTank1.Text = "Read Level Sensors";
            this.ReadFlowLevelSensorsTank1.UseVisualStyleBackColor = true;
            this.ReadFlowLevelSensorsTank1.Click += new System.EventHandler(this.ReadFlowLevelSensors_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ReadFlowSensorTank1);
            this.groupBox2.Controls.Add(this.AcidTankAddress);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.PumpSpeedTank1);
            this.groupBox2.Controls.Add(this.SetPumpSpeedTank1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.LevelSensorTank1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.FlowSensorTank1);
            this.groupBox2.Controls.Add(this.ReadFlowLevelSensorsTank1);
            this.groupBox2.Location = new System.Drawing.Point(199, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(358, 164);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "First Tank (Acid)";
            // 
            // AcidTankAddress
            // 
            this.AcidTankAddress.AutoSize = true;
            this.AcidTankAddress.Location = new System.Drawing.Point(117, 28);
            this.AcidTankAddress.Name = "AcidTankAddress";
            this.AcidTankAddress.Size = new System.Drawing.Size(0, 13);
            this.AcidTankAddress.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Acid Tank Address";
            // 
            // PumpSpeedTank1
            // 
            this.PumpSpeedTank1.Location = new System.Drawing.Point(226, 66);
            this.PumpSpeedTank1.Name = "PumpSpeedTank1";
            this.PumpSpeedTank1.Size = new System.Drawing.Size(121, 20);
            this.PumpSpeedTank1.TabIndex = 17;
            // 
            // SetPumpSpeedTank1
            // 
            this.SetPumpSpeedTank1.Location = new System.Drawing.Point(226, 87);
            this.SetPumpSpeedTank1.Name = "SetPumpSpeedTank1";
            this.SetPumpSpeedTank1.Size = new System.Drawing.Size(121, 23);
            this.SetPumpSpeedTank1.TabIndex = 16;
            this.SetPumpSpeedTank1.Text = "Set Pump Speed";
            this.SetPumpSpeedTank1.UseVisualStyleBackColor = true;
            this.SetPumpSpeedTank1.Click += new System.EventHandler(this.SetPumpSpeed_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Level Sensor";
            // 
            // LevelSensorTank1
            // 
            this.LevelSensorTank1.Location = new System.Drawing.Point(83, 90);
            this.LevelSensorTank1.Name = "LevelSensorTank1";
            this.LevelSensorTank1.Size = new System.Drawing.Size(100, 20);
            this.LevelSensorTank1.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Flow Sensor";
            // 
            // FlowSensorTank1
            // 
            this.FlowSensorTank1.Location = new System.Drawing.Point(83, 66);
            this.FlowSensorTank1.Name = "FlowSensorTank1";
            this.FlowSensorTank1.Size = new System.Drawing.Size(100, 20);
            this.FlowSensorTank1.TabIndex = 12;
            // 
            // StopProcess
            // 
            this.StopProcess.Location = new System.Drawing.Point(25, 107);
            this.StopProcess.Name = "StopProcess";
            this.StopProcess.Size = new System.Drawing.Size(127, 24);
            this.StopProcess.TabIndex = 13;
            this.StopProcess.Text = "Stop Process";
            this.StopProcess.UseVisualStyleBackColor = true;
            this.StopProcess.Click += new System.EventHandler(this.StopProcess_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BaseTankAddress);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.PumpSpeedTank2);
            this.groupBox3.Controls.Add(this.SetPumpSpeedTank2);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.LevelSensorTank2);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.FlowSensorTank2);
            this.groupBox3.Controls.Add(this.ReadFlowLevelSensorsTank2);
            this.groupBox3.Location = new System.Drawing.Point(199, 212);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(358, 172);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Second Tank (Base)";
            // 
            // BaseTankAddress
            // 
            this.BaseTankAddress.AutoSize = true;
            this.BaseTankAddress.Location = new System.Drawing.Point(117, 25);
            this.BaseTankAddress.Name = "BaseTankAddress";
            this.BaseTankAddress.Size = new System.Drawing.Size(0, 13);
            this.BaseTankAddress.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Base Tank Address";
            // 
            // PumpSpeedTank2
            // 
            this.PumpSpeedTank2.Location = new System.Drawing.Point(226, 57);
            this.PumpSpeedTank2.Name = "PumpSpeedTank2";
            this.PumpSpeedTank2.Size = new System.Drawing.Size(121, 20);
            this.PumpSpeedTank2.TabIndex = 24;
            // 
            // SetPumpSpeedTank2
            // 
            this.SetPumpSpeedTank2.Location = new System.Drawing.Point(226, 78);
            this.SetPumpSpeedTank2.Name = "SetPumpSpeedTank2";
            this.SetPumpSpeedTank2.Size = new System.Drawing.Size(121, 23);
            this.SetPumpSpeedTank2.TabIndex = 23;
            this.SetPumpSpeedTank2.Text = "Set Pump Speed";
            this.SetPumpSpeedTank2.UseVisualStyleBackColor = true;
            this.SetPumpSpeedTank2.Click += new System.EventHandler(this.SetPumpSpeedTank2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Level Sensor";
            // 
            // LevelSensorTank2
            // 
            this.LevelSensorTank2.Location = new System.Drawing.Point(83, 81);
            this.LevelSensorTank2.Name = "LevelSensorTank2";
            this.LevelSensorTank2.Size = new System.Drawing.Size(100, 20);
            this.LevelSensorTank2.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Flow Sensor";
            // 
            // FlowSensorTank2
            // 
            this.FlowSensorTank2.Location = new System.Drawing.Point(83, 57);
            this.FlowSensorTank2.Name = "FlowSensorTank2";
            this.FlowSensorTank2.Size = new System.Drawing.Size(100, 20);
            this.FlowSensorTank2.TabIndex = 19;
            // 
            // ReadFlowLevelSensorsTank2
            // 
            this.ReadFlowLevelSensorsTank2.Location = new System.Drawing.Point(15, 119);
            this.ReadFlowLevelSensorsTank2.Name = "ReadFlowLevelSensorsTank2";
            this.ReadFlowLevelSensorsTank2.Size = new System.Drawing.Size(168, 23);
            this.ReadFlowLevelSensorsTank2.TabIndex = 18;
            this.ReadFlowLevelSensorsTank2.Text = "Read Flow Level Sensors";
            this.ReadFlowLevelSensorsTank2.UseVisualStyleBackColor = true;
            this.ReadFlowLevelSensorsTank2.Click += new System.EventHandler(this.ReadFlowLevelSensorsTank2_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.pHValue);
            this.groupBox4.Controls.Add(this.StartpHProcess);
            this.groupBox4.Controls.Add(this.StopProcess);
            this.groupBox4.Location = new System.Drawing.Point(563, 27);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(174, 151);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "pH Control";
            // 
            // pHValue
            // 
            this.pHValue.Location = new System.Drawing.Point(25, 42);
            this.pHValue.Name = "pHValue";
            this.pHValue.Size = new System.Drawing.Size(100, 20);
            this.pHValue.TabIndex = 1;
            // 
            // StartpHProcess
            // 
            this.StartpHProcess.Location = new System.Drawing.Point(25, 78);
            this.StartpHProcess.Name = "StartpHProcess";
            this.StartpHProcess.Size = new System.Drawing.Size(127, 23);
            this.StartpHProcess.TabIndex = 0;
            this.StartpHProcess.Text = "Start pH Process";
            this.StartpHProcess.UseVisualStyleBackColor = true;
            this.StartpHProcess.Click += new System.EventHandler(this.StartpHProcess_Click);
            // 
            // Tank1HandShake
            // 
            this.Tank1HandShake.Location = new System.Drawing.Point(12, 148);
            this.Tank1HandShake.Name = "Tank1HandShake";
            this.Tank1HandShake.Size = new System.Drawing.Size(115, 30);
            this.Tank1HandShake.TabIndex = 16;
            this.Tank1HandShake.Text = "Tank 1 Handshake";
            this.Tank1HandShake.UseVisualStyleBackColor = true;
            this.Tank1HandShake.Click += new System.EventHandler(this.Tank1HandShake_Click);
            // 
            // ReadFlowSensorTank1
            // 
            this.ReadFlowSensorTank1.Location = new System.Drawing.Point(203, 128);
            this.ReadFlowSensorTank1.Name = "ReadFlowSensorTank1";
            this.ReadFlowSensorTank1.Size = new System.Drawing.Size(122, 23);
            this.ReadFlowSensorTank1.TabIndex = 20;
            this.ReadFlowSensorTank1.Text = "ReadFlowSensorTank1";
            this.ReadFlowSensorTank1.UseVisualStyleBackColor = true;
            this.ReadFlowSensorTank1.Click += new System.EventHandler(this.ReadFlowSensorTank1_Click);
            // 
            // pHControlSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 418);
            this.Controls.Add(this.Tank1HandShake);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.StartMonitoringpH);
            this.Controls.Add(this.ScanI2CBus);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "pHControlSystem";
            this.Text = "pH Control System";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.pHControlSystem_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConnectToArduino;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ComboBox SerialPortsList;
        private System.Windows.Forms.ComboBox BaudRateList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button DisconnectArduino;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ProgramStatus;
        private System.Windows.Forms.Button ScanI2CBus;
        private System.Windows.Forms.Button StartMonitoringpH;
        private System.Windows.Forms.Button ReadFlowLevelSensorsTank1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox LevelSensorTank1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox FlowSensorTank1;
        private System.Windows.Forms.TextBox PumpSpeedTank1;
        private System.Windows.Forms.Button SetPumpSpeedTank1;
        private System.Windows.Forms.Button StopProcess;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox PumpSpeedTank2;
        private System.Windows.Forms.Button SetPumpSpeedTank2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox LevelSensorTank2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox FlowSensorTank2;
        private System.Windows.Forms.Button ReadFlowLevelSensorsTank2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox pHValue;
        private System.Windows.Forms.Button StartpHProcess;
        private System.Windows.Forms.Label AcidTankAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label BaseTankAddress;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button Tank1HandShake;
        private System.Windows.Forms.Button ReadFlowSensorTank1;
    }
}

