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

namespace BRS_Dallas_Programmer
{
    public partial class UDPNetwork : Form
    {
        TriStateButton ClearTX;
        TriStateButton ClearRX;
        TriStateButton SendText;
        TriStateButton Connect;

        UdpClient UDP_RX;
        UdpClient UDP_TX;
        IPEndPoint endPoint;

        string HostName = "";
        bool oldNetworkState = false;
        //#############################################################//
        //#############################################################//
        public UDPNetwork()
        {
            InitializeComponent();

            ClearTX = new TriStateButton(ClearSendingWindow);
            ClearRX = new TriStateButton(ClearReceivedWindow);
            SendText = new TriStateButton(SendToAddress);
            Connect = new TriStateButton(UDP_Link);

            ClearTX.SetAllBitmaps(Properties.Resources.icons8_delete_history_100, Properties.Resources.icons8_delete_history_100, Properties.Resources.icons8_delete_history_100);
            ClearRX.SetAllBitmaps(Properties.Resources.icons8_delete_history_100, Properties.Resources.icons8_delete_history_100, Properties.Resources.icons8_delete_history_100);
            SendText.SetAllBitmaps(Properties.Resources.icons8_file_100, Properties.Resources.icons8_file_download_100, Properties.Resources.icons8_error_file_100);
            Connect.SetAllBitmaps(Properties.Resources.icons8_disconnected_100, Properties.Resources.icons8_connected_100, Properties.Resources.icons8_disconnected_100);


            ClearRX.Animated = true;
            ClearTX.Animated = true;
            SendText.Animated = true;
            Connect.Animated = true;

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

            if(IP_LIST.Text != "" && SenderPort.Text != "" && ReceiverPort.Text != "" && ReceiverIP.Text != "")
            {
                SendText.Enable();
                SendText.state = true;
            }
            else
            {
                SendText.Disable();
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

                if(address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    BRS.Debug.Success("Adding: " + addressName);
                    IP_LIST.Items.Add(addressName);
                }
            }
        }

        private void NetWorkUpdater_Tick(object sender, EventArgs e)
        {
            if (oldNetworkState != NetworkInterface.GetIsNetworkAvailable())
            {
                oldNetworkState = NetworkInterface.GetIsNetworkAvailable();
                if (oldNetworkState)
                {
                    ComputerNetworkType.BackgroundImage = Properties.Resources.icons8_wired_network_connection_100;
                }
                else
                {
                    ComputerNetworkType.BackgroundImage = Properties.Resources.icons8_no_network_100;
                }
            }
        }

        private void IP_LIST_TextChanged(object sender, EventArgs e)
        {
            UDP_RX = new UdpClient();
        }

        private void UDP_Link_Click(object sender, EventArgs e)
        {
            UDP_TX = new UdpClient();

            IPAddress address;
            if (IPAddress.TryParse(ReceiverIP.Text, out address))
            {
                BRS.Debug.Success("Address valid");
                if(ReceiverPort.Text.All(char.IsDigit))
                {
                    BRS.Debug.Success("Port valid");
                    endPoint = new IPEndPoint(address, Convert.ToInt32(ReceiverPort.Text));
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

        private void SendToAddress_Click(object sender, EventArgs e)
        {
            BRS.Debug.Comment("Sending Text Box");
            byte[] bytes = Encoding.ASCII.GetBytes(ToSendTextBox.Text);
            UDP_TX.Send(bytes, bytes.Length, endPoint);
        }
    }
}
