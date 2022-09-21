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
using System.IO;
using System.Media;
using BRS;
using cls;
using BRS_Dallas_Programmer;
using System.Runtime.InteropServices;
using System.Threading;
using System.Collections.ObjectModel;

namespace BRS_Dallas_Programmer
{
    public partial class ConsoleSetting : Form
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        SerialConsole console;

        public static string SelectedComFullName = "No Device";
        public static string SelectedComName = "No Device";
        public static bool UpdateDropDown = false;

        SerialPort OldSettings;
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public ConsoleSetting(SerialConsole refConsole)
        {
            BRS.Debug.Header(true);

            BRS.Debug.Comment("Initializing setting's components");
            InitializeComponent();
            Debug.Success("");

            BRS.Debug.Comment("Creating list changes handler");
            BRS.ComPort.ListOfPortChanged.CollectionChanged += ListChanged;
            BRS.ComPort.StoreAllAvailableComs();

            BRS.Debug.Comment("Refering console form:");
            console = refConsole;
            Debug.Success("");

            BRS.Debug.Comment("Creating setting variables...");
            OldSettings = BRS.ComPort.Port;
            Debug.Success("");

            BRS.Debug.Comment("Changing setting boxes variables.");
            InnitComDropDown();
            InnitBaudRateBox();
            InnitStopBit();
            InnitParity();
            InnitFlowControl();
            InnitDataBit();
            Debug.Success("");

            BRS.Debug.Header(false);
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void InnitComDropDown()
        {
            PortBox1.Items.Clear();
            foreach (string name in BRS.ComPort.AvailableComsFullName)
            PortBox1.Items.Add(name);
        }
        
        private void InnitBaudRateBox()
        {
            BaudRateBox.Text = OldSettings.BaudRate.ToString();
        }
        private void InnitStopBit()
        {
            foreach (string name in Enum.GetNames(typeof(StopBits)))
                if (!name.Equals("None"))
                {
                    StopBitBox.Items.Add(name);
                    StopBitBox.Text = OldSettings.StopBits.ToString();
                }
        }
        private void InnitParity()
        {
            foreach (string name in Enum.GetNames(typeof(Parity)))
            ParityBox.Items.Add(name);
            ParityBox.Text = OldSettings.Parity.ToString();
        }
        private void InnitFlowControl()
        {
            foreach (string name in Enum.GetNames(typeof(Handshake)))
            FlowControlBox.Items.Add(name);
            FlowControlBox.Text = OldSettings.Handshake.ToString();
        }
        private void InnitDataBit()
        {
            DataBitBox.Text = OldSettings.DataBits.ToString();
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //#############################################################//
        //#############################################################//
        private void CancelButton_Click(object sender, EventArgs e)
        {
            BRS.Debug.Header(true);
            BRS.Debug.Comment("Canceling changes");
            BRS.Debug.Header(false);
        }
        //#############################################################//
        //#############################################################//
        private void AcceptButton_Click(object sender, EventArgs e)
        {
            BRS.Debug.Header(true);

            BRS.Debug.Comment("Porting changes to ComPort...");
            BRS.ComPort.Port.BaudRate = Convert.ToInt32(BaudRateBox.Text);
            BRS.ComPort.Port.Parity = (Parity)ParityBox.SelectedIndex;
            BRS.ComPort.Port.Handshake = (Handshake)FlowControlBox.SelectedIndex;
            BRS.ComPort.Port.DataBits = Convert.ToInt32(DataBitBox.Text);

            BRS.ComPort.Port.StopBits = (StopBits)StopBitBox.SelectedIndex+1;

            try
            {
                BRS.ComPort.Port.PortName = PortBox1.Text.Split('(', ')')[1];
            }
            catch
            {
                BRS.ComPort.Port.PortName = "No Device";
            }

            BRS.Debug.Comment("Port name: " + PortBox1.SelectedIndex.ToString() + ": " + BRS.ComPort.Port.PortName.ToString());
            BRS.Debug.Comment("BaudRate:  " + BaudRateBox.SelectedIndex.ToString() + ": " + BRS.ComPort.Port.BaudRate.ToString());
            BRS.Debug.Comment("DataBits:  " + DataBitBox.SelectedIndex.ToString() + ": " + BRS.ComPort.Port.DataBits.ToString());
            BRS.Debug.Comment("StopBits:  " + StopBitBox.SelectedIndex.ToString() + ": " + BRS.ComPort.Port.StopBits.ToString());
            BRS.Debug.Comment("Parity:    " + ParityBox.SelectedIndex.ToString() + ": " + BRS.ComPort.Port.Parity.ToString());
            BRS.Debug.Comment("HandShake: " + FlowControlBox.SelectedIndex.ToString() + ": " + BRS.ComPort.Port.Handshake.ToString());

            Debug.Success("Closing setting form");
            BRS.Debug.Header(false);

            this.Close();
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ListChanged(object sender, EventArgs e)
        {
            BRS.Debug.Comment("Putting out of focus dropdown");
            BRS.Debug.Comment("Setting flag");
            UpdateDropDown = true;
            Debug.Success("");
        }

        private void UpdatePortList_Tick(object sender, EventArgs e)
        {
            if (UpdateDropDown)
            {
                Thread.Sleep(2000);
                InnitComDropDown();
                UpdateDropDown = false;
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    }
}
