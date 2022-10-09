using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BRS;
using BRS.Buttons;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Text;
using BRS_Dallas_Programmer.Properties;
using BRS_Dallas_Programmer_Icons;
using System.Media;

namespace BRS_Dallas_Programmer
{
    public partial class UDPNetwork : Form
    {
        BRS.Buttons.GenericButton ClearTX;
        BRS.Buttons.GenericButton ClearRX;
        BRS.Buttons.GenericButton SendText;
        BRS.Buttons.GenericButton Connect;

        System.Threading.Thread thread;

        UdpClient UDP_TX;
        IPEndPoint endPoint;
        IPEndPoint RXendpoint;

        string HostName = "";
        string IP_Address = "";
        string IP_Port = "";
        string RXtext = "";

        bool TXportIsGood = false;
        bool RXipIsGood = false;

        double radianCounter = 0;
        //#############################################################//
        //#############################################################//
        public UDPNetwork()
        {
            InitializeComponent();

            ClearTX = new GenericButton(ClearSendingWindow, ClearConsolButton.GetStatesColors(), ClearConsolButton.GetStatesBitmaps());
            ClearRX = new GenericButton(ClearReceivedWindow, ClearConsolButton.GetStatesColors(), ClearConsolButton.GetStatesBitmaps());
            SendText = new GenericButton(SendToAddress, fileButtons.GetStatesColors(), fileButtons.GetStatesBitmaps());
            Connect = new GenericButton(UDP_Link, connectButton.GetStatesColors(), connectButton.GetStatesBitmaps());

            // Specifying the buttons as animated.
            ClearRX.Animated = true;
            ClearTX.Animated = true;
            SendText.Animated = true;
            Connect.Animated = true;

            SendText.State = ControlState.Disabled;
            UpdatePCInfo();
        }
        //#############################################################//
        /// <summary>
        /// Prints out all the computer's IP informations, and saves
        /// the host name in a global variable of this form.
        /// </summary>
        //#############################################################//
        private void UpdatePCInfo()
        {
            HostName = Dns.GetHostName();
            BRS.Debug.Comment("HostName:" + HostName);

            IPAddress[] addresses = Dns.GetHostAddresses(HostName);
            foreach (IPAddress address in addresses)
            {
                string addressName = address.ToString();

                BRS.Debug.Comment(HostName + "\t" + addressName + "\t\t" + address.AddressFamily.ToString());
            }
        }
        //#############################################################//
        /// <summary>
        /// Updater function for button animations and colour shifting
        /// animations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //#############################################################//
        private void ButtonUpdater_Tick(object sender, EventArgs e)
        {
            // Update buttons
            ClearTX.Update();
            ClearRX.Update();
            SendText.Update();
            Connect.Update();

            //Save received text in a textbox, then delete text.
            if (RXtext.Length > 0)
            {
                ReceivingTextBox.Text = ReceivingTextBox.Text + RXtext;
                RXtext = "";
            }
            //For pulsating animations of text colours
            radianCounter = radianCounter + 0.08f;
            if(radianCounter > 6.28){radianCounter = 0;}

            //If we are connected, enable file send.
            if (Connect.State != ControlState.Active)
            {
                SendText.State = ControlState.Disabled;
            }
            else
            {
                if (ToSendTextBox.Text.Equals(""))
                {
                    SendText.State = ControlState.Warning;
                }
                else
                {
                    SendText.State = ControlState.Active;
                }
            }

            //Check textboxes texts to error or activate clear buttons
            if(ToSendTextBox.Text.Equals(""))
            {
                ClearTX.State = ControlState.Error;
            }
            else
            {
                ClearTX.State = ControlState.Active;
            }
            if (ReceivingTextBox.Text.Equals(""))
            {
                ClearRX.State = ControlState.Error;
            }
            else
            {
                ClearRX.State = ControlState.Active;
            }

            ///////////////////////////////////
            double multiplier = Math.Pow(Math.Sin(radianCounter),20);

            if(RXipIsGood)
            {
                ReceiverIP.ForeColor = Color.LimeGreen;
            }
            else
            {
                ReceiverIP.ForeColor = Color.FromArgb(255, (int)(multiplier * 255), (int)((1 - multiplier) * 255), 0);
            }

            if (TXportIsGood)
            {
                SenderPort.ForeColor = Color.LightBlue;
            }
            else
            {
                SenderPort.ForeColor = Color.FromArgb(255, (int)(multiplier * 255), (int)((1 - multiplier) * 255), (int)((1 - multiplier) * 255));
            }
        }
        //#############################################################//
        /// <summary>
        /// Event occuring when the dropdown list for IP addresses is
        /// clicked on. This updates the available IP addresses.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //#############################################################//
        private void IP_LIST_DropDown(object sender, EventArgs e)
        {
            IP_LIST.Items.Clear();

            IPAddress[] addresses = Dns.GetHostAddresses(HostName);
            foreach (IPAddress address in addresses)
            {
                string addressName = address.ToString();

                if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    BRS.Debug.Success("Adding: " + addressName);
                    IP_LIST.Items.Add(addressName);
                }
            }
        }
        //#############################################################//
        /// <summary>
        /// Function enabling and disabling textbox and dropdowns to
        /// avoid people from changing text once a connection has been
        /// established.
        /// </summary>
        //#############################################################//
        private void updateTextBox()
        {
            if(Connect.State != ControlState.Inactive)
            {
                IP_LIST.Enabled = false;
                ReceiverIP.Enabled = false;
                SenderPort.Enabled = false;
            }
            else
            {
                IP_LIST.Enabled = true;
                ReceiverIP.Enabled = true;
                SenderPort.Enabled = true;
            }
        }
        //#############################################################//
        /// <summary>
        /// Function executed when attempting to establish a connection
        /// to the UDP address.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //#############################################################//
        private void UDP_Link_Click(object sender, EventArgs e)
        {
            //-------------------------------------------[Declaration]-//
              IPAddress address;
            bool Error = false;
            //---------------------------------------------------------//
            BRS.Debug.Header(true);

            BRS.Debug.Comment("Verifying link state...");
            if (Connect.State == ControlState.Inactive)
            {
                Debug.Success("No link established, attempting connection...");
                if (IPAddress.TryParse(ReceiverIP.Text, out address))
                {
                    Debug.Success("Address valid!");
                    if (SenderPort.Text.All(char.IsDigit))
                    {
                        Debug.Success("Port valid!");

                        BRS.Debug.Comment("Overwritting UDP client...");
                        try
                        {
                            UDP_TX = new UdpClient(Convert.ToInt32(SenderPort.Text));
                            endPoint = new IPEndPoint(address, Convert.ToInt32(SenderPort.Text));
                        }
                        catch
                        {
                            Debug.Error("FATAL ERROR WHEN ATTEMPTING TO LINK");
                            Error = true;
                        }

                        if (Error == false)
                        {
                            IP_Address = IP_LIST.Text;
                            IP_Port = SenderPort.Text;

                            BRS.Debug.Comment("Creating new UDP RX thread");
                            thread = new System.Threading.Thread(ReceiveUDP_Thread);
                            thread.Start();
                            Debug.Success("UDP RX Thread started!");

                            Connect.State = ControlState.Active;
                            SystemSounds.Asterisk.Play();
                        }
                    }
                    else
                    {
                        Debug.Aborted("Port Invalid");
                        SystemSounds.Hand.Play();
                    }
                }
                else
                {
                    Debug.Aborted("Address Invalid");
                    SystemSounds.Hand.Play();
                }
            }
            else
            {
                BRS.Debug.Success("Link found! Closing link...");
                try
                {
                    thread.Abort();
                    UDP_TX.Dispose();
                    Connect.State = ControlState.Inactive;
                    SystemSounds.Asterisk.Play();
                }
                catch
                {
                    BRS.Debug.Error("Could not dispose of UDP TX");
                    SystemSounds.Hand.Play();
                }
            }

            updateTextBox();
            BRS.Debug.Header(false);
        }
        //#############################################################//
        /// <summary>
        /// Event occuring when attempting to send text held in TX
        /// textbox to a specific IP address
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //#############################################################//
        private void SendToAddress_Click(object sender, EventArgs e)
        {
            //-------------------------------------------[Declaration]-//
              byte[] bytes;
            //-------------------------------------------[Declaration]-//
            BRS.Debug.Header(true);

            BRS.Debug.Comment("Attempting to send text box...");
            try
            {
                bytes = Encoding.ASCII.GetBytes(ToSendTextBox.Text);
                if (UDP_TX != null)
                {
                    BRS.Debug.Comment("Sending on UDP...");
                    UDP_TX.Send(bytes, bytes.Length, endPoint);
                    Debug.Success("");
                }
                else
                {
                    BRS.PopUp.Error("ERROR occured when attempting to send data on UDP", "SENDING ERROR :(");
                }
            }
            catch
            {
                BRS.Debug.Error("ERROR WHILE SENDING DATA ON UDP");
                BRS.PopUp.Error("ERROR occured when attempting to send data on UDP", "SENDING ERROR :(");
            }
            BRS.Debug.Header(false);
        }
        //#############################################################//
        /// <summary>
        /// Event occuring when text changes for the sender port.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //#############################################################//
        private void SenderPort_TextChanged(object sender, EventArgs e)
        {
            if (SenderPort.Text.All(char.IsDigit))
            {
                long number = -1;
                try
                {
                    number = Convert.ToInt64(SenderPort.Text);
                }
                catch
                {
                    BRS.Debug.Error("COULD NOT PARSE PORT TEXT");
                    TXportIsGood = false;
                }

                // Check if entered port is within available ports.
                if (number > 65535 || number <= 0)
                {
                    TXportIsGood = false;
                }
                else
                {
                    TXportIsGood = true;
                }
            }
        }
        //#############################################################//
        /// <summary>
        /// Function automatically checking the validity of an entered
        /// receiver port.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //#############################################################//
        private void ReceiverIP_TextChanged(object sender, EventArgs e)
        {
            IPAddress address;
            if (IPAddress.TryParse(ReceiverIP.Text, out address))
            {
                // IS GOOD
                RXipIsGood = true;
            }
            else
            {
                RXipIsGood = false;
            }
        }
        //#############################################################//
        /// <summary>
        /// Clears the RX receiver informations textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //#############################################################//
        private void ClearSendingWindow_Click(object sender, EventArgs e)
        {
            BRS.Debug.Header(true);

            BRS.Debug.Comment("Clearing TX textbox.");
            ToSendTextBox.Text = "";
            if (ClearTX.State != ControlState.Active)
            {
                SystemSounds.Hand.Play();
            }
            else
            {
                SystemSounds.Asterisk.Play();
            }
            Debug.Success("");

            BRS.Debug.Header(false);
        }
        //#############################################################//
        /// <summary>
        /// Clears the TX information to send textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //#############################################################//
        private void ClearReceivedWindow_Click(object sender, EventArgs e)
        {
            BRS.Debug.Header(true);

            BRS.Debug.Comment("Clearing RX textbox.");
            ReceivingTextBox.Text = "";
            if (ClearTX.State != ControlState.Active)
            {
                SystemSounds.Hand.Play();
            }
            else
            {
                SystemSounds.Asterisk.Play();
            }
            Debug.Success("");

            BRS.Debug.Header(false);
        }
        //#############################################################//
        /// <summary>
        /// Thread to parse UDP received informations
        /// </summary>
        //#############################################################//
        private void ReceiveUDP_Thread()
        {
            //-------------------------------------------[Declaration]-//
              IPAddress address;
              byte[] receivedBytes;
            //---------------------------------------------------------//


            if (IPAddress.TryParse(IP_Address, out address))
            {
                RXendpoint = new IPEndPoint(address, Convert.ToInt32(IP_Port));
            }

            while (thread.IsAlive)
            {
                receivedBytes = UDP_TX.Receive(ref RXendpoint);
                RXtext = RXtext + System.Text.Encoding.ASCII.GetString(receivedBytes);
            }
        }
    }
}
