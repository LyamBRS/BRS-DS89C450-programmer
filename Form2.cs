﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using BRS;
using cls;

namespace BRS_Dallas_Programmer
{
    public partial class MainMenu : Form
    {
        Form1 programming = new Form1();
        SerialConsole serialConsole = new SerialConsole();
        public MainMenu()
        {
            BRS.Debug.Header(true);

            BRS.Debug.Comment("Inializing components of form 2");
            InitializeComponent();
            Debug.Success("");

            BRS.Debug.Comment("Setting FTDI port to new default serial port");
            BRS.FTDI.FTDIPort = serialPort1;
            BRS.Debug.Success("");

            BRS.Debug.Comment("Setting Console port to new default serial port");
            BRS.ComPort.Port = serialPort2;
            BRS.Debug.Success("");

            BRS.Debug.Header(false);
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            BRS.Debug.Header(true);
            BRS.Debug.Comment("Closing the application...");
            programming.Close();
            this.Close();
            BRS.Debug.Header(false);
        }

        private void Programmer_Click(object sender, EventArgs e)
        {
            BRS.Debug.Header(true);
            BRS.Debug.Comment("Calling Programmer form...");
            programming = new Form1();
            programming.Show();

            BRS.Debug.Header(false);
        }

        private void CheckFormsFlags_Tick(object sender, EventArgs e)
        {
            //Update FTDI specs
            if (!BRS.FTDI.FTDIComName.Equals("No Device"))
            {
                //Check if serialport is opened
                if (!BRS.FTDI.FTDIPort.IsOpen)
                {
                    if (!BRS.FTDI.FTDIPort.PortName.Equals(BRS.FTDI.FTDIComName) && !BRS.FTDI.FTDIComName.Equals("No Device"))
                    {
                        BRS.Debug.Comment("SETTING NEW FTDI PORT NAME");
                        BRS.FTDI.FTDIPort.PortName = BRS.FTDI.FTDIComName;
                    }
                }
            }
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            BRS.FTDI.startFTDIUpdater();
            BRS.FTDI.LookForFTDI();
        }


        private void Quit_MouseHover(object sender, EventArgs e)
        {
            ButtonText.Text = "Quit";
            ButtonText.ForeColor = Color.FromArgb(255, 100, 100);
        }

        private void Console_MouseHover(object sender, EventArgs e)
        {
            ButtonText.Text = "Serial Terminal";
            ButtonText.ForeColor = Color.FromArgb(255,255,255);
        }

        private void Programmer_MouseHover(object sender, EventArgs e)
        {
            ButtonText.Text = "Dallas Programmer";
            ButtonText.ForeColor = Color.FromArgb(90, 190, 255);
        }

        private void flowLayoutPanel1_MouseLeave(object sender, EventArgs e)
        {
            ButtonText.Text = "";
            ButtonText.ForeColor = Color.FromArgb(100, 100, 100);
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            ButtonText.Text = "Lyam.BRS@gmail.com";
            ButtonText.ForeColor = Color.FromArgb(100, 100, 100);
        }

        private void Console_Click(object sender, EventArgs e)
        {
            BRS.Debug.Header(true);
            BRS.Debug.Comment("Opening console viewer...");
            serialConsole = new SerialConsole();
            serialConsole.Show();

            BRS.Debug.Header(false);
        }
    }
}
