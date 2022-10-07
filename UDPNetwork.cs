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
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Text;

namespace BRS_Dallas_Programmer
{
    public partial class UDPNetwork : Form
    {
        TriStateButton ClearTX;
        TriStateButton ClearRX;
        TriStateButton SendText;
        TriStateButton Connect;

        System.Threading.Thread thread;

        UdpClient UDP_RX;
        UdpClient UDP_TX;
        IPEndPoint endPoint;
        IPEndPoint RXendpoint;

        string HostName = "";
        string IP_Address = "";
        string IP_Port = "";
        string RXtext = "";
        bool oldNetworkState = false;

        bool RXportIsGood = false;
        bool TXportIsGood = false;
        bool RXipIsGood = false;

        double radianCounter = 0;
        //#############################################################//
        //#############################################################//
        public UDPNetwork()
        {
            InitializeComponent();

            ClearTX = new TriStateButton(ClearSendingWindow);
            ClearRX = new TriStateButton(ClearReceivedWindow);
            SendText = new TriStateButton(SendToAddress);
            Connect = new TriStateButton(UDP_Link);

            ButtonColors clearConsolColor = new ButtonColors(Color.Empty, Color.Black, Color.Black, Color.FromArgb(255, 128, 0, 0));
            ButtonColors regularColor = new ButtonColors(Color.Empty, Color.Black, Color.Black, Color.Black);

            ClearTX.SetAllBitmaps(Properties.Resources.icons8_delete_history_100, Properties.Resources.icons8_delete_history_100, Properties.Resources.icons8_delete_history_100);
            ClearRX.SetAllBitmaps(Properties.Resources.icons8_delete_history_100, Properties.Resources.icons8_delete_history_100, Properties.Resources.icons8_delete_history_100);
            SendText.SetAllBitmaps(Properties.Resources.icons8_file_100, Properties.Resources.icons8_file_download_100, Properties.Resources.icons8_error_file_100);
            Connect.SetAllBitmaps(Properties.Resources.icons8_disconnected_100, Properties.Resources.icons8_connected_100, Properties.Resources.icons8_disconnected_100);

            ClearRX.Animated = true;
            ClearTX.Animated = true;
            SendText.Animated = true;
            Connect.Animated = true;

            ClearTX.SetAllColors(clearConsolColor);
            ClearRX.SetAllColors(clearConsolColor);

            Connect.SetAllColors(regularColor);
            SendText.SetAllColors(regularColor);

            SendText.Disable();
            UpdatePCInfo();
        }
        //#############################################################//
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
        //#############################################################//
        private void ButtonUpdater_Tick(object sender, EventArgs e)
        {
            ClearTX.Update();
            ClearRX.Update();
            SendText.Update();
            Connect.Update();

            ReceivingTextBox.Text = ReceivingTextBox.Text + RXtext;
            RXtext = "";

            //For pulsating animations of text colours
            radianCounter = radianCounter + 0.08f;
            if(radianCounter > 6.28)
            {
                radianCounter = 0;
            }

            if (IP_LIST.Text != "" && SenderPort.Text != "" && ReceiverPort.Text != "" && ReceiverIP.Text != "")
            {
                SendText.Enable();
                SendText.state = true;
            }
            else
            {
                SendText.Disable();
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

            if (RXportIsGood)
            {
                ReceiverPort.ForeColor = Color.LimeGreen;
            }
            else
            {
                ReceiverPort.ForeColor = Color.FromArgb(255, (int)(multiplier * 255), (int)((1 - multiplier) * 255), 0);
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
        //#############################################################//
        private void NetWorkUpdater_Tick(object sender, EventArgs e)
        {
        }
        //#############################################################//
        //#############################################################//
        private void IP_LIST_TextChanged(object sender, EventArgs e)
        {
            
        }
        //#############################################################//
        //#############################################################//
        private void updateTextBox()
        {
            if(Connect.state)
            {
                IP_LIST.Enabled = false;
                ReceiverPort.Enabled = false;
                ReceiverIP.Enabled = false;
                SenderPort.Enabled = false;
            }
            else
            {
                IP_LIST.Enabled = true;
                ReceiverPort.Enabled = true;
                ReceiverIP.Enabled = true;
                SenderPort.Enabled = true;
            }
        }
        //#############################################################//
        //#############################################################//
        private void UDP_Link_Click(object sender, EventArgs e)
        {
            BRS.Debug.Header(true);

            if (Connect.state != true)
            {
                IPAddress address;
                if (IPAddress.TryParse(ReceiverIP.Text, out address))
                {
                    BRS.Debug.Success("Address valid");
                    if (ReceiverPort.Text.All(char.IsDigit))
                    {
                        BRS.Debug.Success("Port valid");

                        BRS.Debug.Comment("Overwritting UDP client");
                        UDP_TX = new UdpClient(Convert.ToInt32(ReceiverPort.Text));
                        endPoint = new IPEndPoint(address, Convert.ToInt32(ReceiverPort.Text));

                        IP_Address = IP_LIST.Text;
                        IP_Port = SenderPort.Text;
                        thread = new System.Threading.Thread(ReceiveUDP_Thread);
                        thread.Start();

                        Connect.state = true;
                    }
                    else
                    {
                        BRS.Debug.Aborted("Port Invalid");
                    }
                }
                else
                {
                    BRS.Debug.Aborted("Address Invalid");
                }
            }
            else
            {
                BRS.Debug.Comment("Closing UDP");
                Connect.state = false;

                try
                {
                    thread.Abort();
                    UDP_TX.Dispose();
                }
                catch
                {
                    BRS.Debug.Error("Could not dispose of UDP TX");
                }
            }

            updateTextBox();
            BRS.Debug.Header(false);
        }
        //#############################################################//
        //#############################################################//
        private void SendToAddress_Click(object sender, EventArgs e)
        {
            BRS.Debug.Header(true);

            BRS.Debug.Comment("Sending Text Box");

            try
            {
                byte[] bytes = Encoding.ASCII.GetBytes(ToSendTextBox.Text);
                if (UDP_TX != null)
                {
                    UDP_TX.Send(bytes, bytes.Length, endPoint);
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
        //#############################################################//
        //#############################################################//
        //#############################################################//
        private void ReceiverPort_TextChanged(object sender, EventArgs e)
        {
            if (ReceiverPort.Text.All(char.IsDigit))
            {
                long number = -1;
                try
                {
                    number = Convert.ToInt64(ReceiverPort.Text);
                }
                catch
                {
                    BRS.Debug.Error("COULD NOT PARSE PORT TEXT");
                    RXportIsGood = false;
                }

                if(number > 65535 || number <= 0)
                {
                    RXportIsGood = false;
                }
                else
                {
                    RXportIsGood = true;
                }
            }
        }

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
        //#############################################################//
        private void ClearSendingWindow_Click(object sender, EventArgs e)
        {
            BRS.Debug.Header(true);
            ToSendTextBox.Text = "";
            BRS.Debug.Header(false);
        }
        //#############################################################//
        //#############################################################//
        private void ClearReceivedWindow_Click(object sender, EventArgs e)
        {
            BRS.Debug.Header(true);
            ReceivingTextBox.Text = "";
            BRS.Debug.Header(false);
        }
        //#############################################################//        //#############################################################//
        //#############################################################//        //#############################################################//
        private void ReceiveUDP_Thread()
        {
            IPAddress address;
            if (IPAddress.TryParse(IP_Address, out address))
            {
                RXendpoint = new IPEndPoint(address, Convert.ToInt32(IP_Port));
            }
            else
            {
            }

            byte[] receivedBytes;

            while(true)
            {
                receivedBytes = UDP_TX.Receive(ref RXendpoint);
                
                //foreach(byte Char in receivedBytes)
                //{
                    RXtext = RXtext + System.Text.Encoding.ASCII.GetString(receivedBytes);
                //}
            }
        }
    }
}
