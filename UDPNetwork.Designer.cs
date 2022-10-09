
namespace BRS_Dallas_Programmer
{
    partial class UDPNetwork
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UDPNetwork));
            this.ToSendTextBox = new System.Windows.Forms.RichTextBox();
            this.ReceivingTextBox = new System.Windows.Forms.RichTextBox();
            this.ReceiverIP = new System.Windows.Forms.TextBox();
            this.UserTextInfo = new System.Windows.Forms.TextBox();
            this.SenderPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ButtonUpdater = new System.Windows.Forms.Timer(this.components);
            this.IP_LIST = new System.Windows.Forms.ComboBox();
            this.NetWorkUpdater = new System.Windows.Forms.Timer(this.components);
            this.ClearReceivedWindow = new System.Windows.Forms.Button();
            this.SendToAddress = new System.Windows.Forms.Button();
            this.UDP_Link = new System.Windows.Forms.Button();
            this.ClearSendingWindow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ToSendTextBox
            // 
            this.ToSendTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ToSendTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ToSendTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ToSendTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ToSendTextBox.Location = new System.Drawing.Point(12, 80);
            this.ToSendTextBox.Name = "ToSendTextBox";
            this.ToSendTextBox.Size = new System.Drawing.Size(351, 364);
            this.ToSendTextBox.TabIndex = 1;
            this.ToSendTextBox.Text = "";
            // 
            // ReceivingTextBox
            // 
            this.ReceivingTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ReceivingTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ReceivingTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ReceivingTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ReceivingTextBox.Location = new System.Drawing.Point(372, 80);
            this.ReceivingTextBox.Name = "ReceivingTextBox";
            this.ReceivingTextBox.ReadOnly = true;
            this.ReceivingTextBox.Size = new System.Drawing.Size(351, 364);
            this.ReceivingTextBox.TabIndex = 2;
            this.ReceivingTextBox.Text = "";
            // 
            // ReceiverIP
            // 
            this.ReceiverIP.BackColor = System.Drawing.SystemColors.MenuText;
            this.ReceiverIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReceiverIP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ReceiverIP.Location = new System.Drawing.Point(465, 45);
            this.ReceiverIP.Name = "ReceiverIP";
            this.ReceiverIP.Size = new System.Drawing.Size(258, 29);
            this.ReceiverIP.TabIndex = 8;
            this.ReceiverIP.TextChanged += new System.EventHandler(this.ReceiverIP_TextChanged);
            // 
            // UserTextInfo
            // 
            this.UserTextInfo.BackColor = System.Drawing.SystemColors.InfoText;
            this.UserTextInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UserTextInfo.Cursor = System.Windows.Forms.Cursors.No;
            this.UserTextInfo.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserTextInfo.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.UserTextInfo.Location = new System.Drawing.Point(204, 678);
            this.UserTextInfo.Multiline = true;
            this.UserTextInfo.Name = "UserTextInfo";
            this.UserTextInfo.ReadOnly = true;
            this.UserTextInfo.Size = new System.Drawing.Size(327, 78);
            this.UserTextInfo.TabIndex = 9;
            this.UserTextInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SenderPort
            // 
            this.SenderPort.BackColor = System.Drawing.SystemColors.MenuText;
            this.SenderPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SenderPort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.SenderPort.Location = new System.Drawing.Point(105, 10);
            this.SenderPort.Name = "SenderPort";
            this.SenderPort.Size = new System.Drawing.Size(258, 29);
            this.SenderPort.TabIndex = 13;
            this.SenderPort.TextChanged += new System.EventHandler(this.SenderPort_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 21);
            this.label1.TabIndex = 14;
            this.label1.Text = "Port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 21);
            this.label2.TabIndex = 15;
            this.label2.Text = "TX IP:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(369, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 21);
            this.label3.TabIndex = 17;
            this.label3.Text = "RX IP:";
            // 
            // ButtonUpdater
            // 
            this.ButtonUpdater.Enabled = true;
            this.ButtonUpdater.Interval = 10;
            this.ButtonUpdater.Tick += new System.EventHandler(this.ButtonUpdater_Tick);
            // 
            // IP_LIST
            // 
            this.IP_LIST.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IP_LIST.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.IP_LIST.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IP_LIST.DropDownHeight = 1000;
            this.IP_LIST.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.IP_LIST.DropDownWidth = 1000;
            this.IP_LIST.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.IP_LIST.FormattingEnabled = true;
            this.IP_LIST.IntegralHeight = false;
            this.IP_LIST.Location = new System.Drawing.Point(108, 45);
            this.IP_LIST.Name = "IP_LIST";
            this.IP_LIST.Size = new System.Drawing.Size(255, 29);
            this.IP_LIST.Sorted = true;
            this.IP_LIST.TabIndex = 24;
            this.IP_LIST.DropDown += new System.EventHandler(this.IP_LIST_DropDown);
            // 
            // NetWorkUpdater
            // 
            this.NetWorkUpdater.Enabled = true;
            this.NetWorkUpdater.Interval = 1000;
            // 
            // ClearReceivedWindow
            // 
            this.ClearReceivedWindow.BackgroundImage = global::BRS_Dallas_Programmer.Properties.Resources.icons8_delete_history_100;
            this.ClearReceivedWindow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClearReceivedWindow.FlatAppearance.BorderSize = 0;
            this.ClearReceivedWindow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearReceivedWindow.Location = new System.Drawing.Point(537, 453);
            this.ClearReceivedWindow.Name = "ClearReceivedWindow";
            this.ClearReceivedWindow.Size = new System.Drawing.Size(90, 90);
            this.ClearReceivedWindow.TabIndex = 6;
            this.ClearReceivedWindow.UseVisualStyleBackColor = true;
            this.ClearReceivedWindow.Click += new System.EventHandler(this.ClearReceivedWindow_Click);
            // 
            // SendToAddress
            // 
            this.SendToAddress.BackgroundImage = global::BRS_Dallas_Programmer.Properties.Resources.icons8_file_download_100;
            this.SendToAddress.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SendToAddress.FlatAppearance.BorderSize = 0;
            this.SendToAddress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SendToAddress.Location = new System.Drawing.Point(12, 453);
            this.SendToAddress.Name = "SendToAddress";
            this.SendToAddress.Size = new System.Drawing.Size(90, 90);
            this.SendToAddress.TabIndex = 5;
            this.SendToAddress.UseVisualStyleBackColor = true;
            this.SendToAddress.Click += new System.EventHandler(this.SendToAddress_Click);
            // 
            // UDP_Link
            // 
            this.UDP_Link.BackgroundImage = global::BRS_Dallas_Programmer.Properties.Resources.icons8_disconnected_100;
            this.UDP_Link.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UDP_Link.FlatAppearance.BorderSize = 0;
            this.UDP_Link.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.UDP_Link.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.UDP_Link.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UDP_Link.Location = new System.Drawing.Point(633, 453);
            this.UDP_Link.Name = "UDP_Link";
            this.UDP_Link.Size = new System.Drawing.Size(90, 90);
            this.UDP_Link.TabIndex = 4;
            this.UDP_Link.UseVisualStyleBackColor = true;
            this.UDP_Link.Click += new System.EventHandler(this.UDP_Link_Click);
            // 
            // ClearSendingWindow
            // 
            this.ClearSendingWindow.BackgroundImage = global::BRS_Dallas_Programmer.Properties.Resources.icons8_delete_history_100;
            this.ClearSendingWindow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClearSendingWindow.FlatAppearance.BorderSize = 0;
            this.ClearSendingWindow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearSendingWindow.Location = new System.Drawing.Point(108, 453);
            this.ClearSendingWindow.Name = "ClearSendingWindow";
            this.ClearSendingWindow.Size = new System.Drawing.Size(90, 90);
            this.ClearSendingWindow.TabIndex = 3;
            this.ClearSendingWindow.UseVisualStyleBackColor = true;
            this.ClearSendingWindow.Click += new System.EventHandler(this.ClearSendingWindow_Click);
            // 
            // UDPNetwork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(735, 555);
            this.Controls.Add(this.IP_LIST);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SenderPort);
            this.Controls.Add(this.UserTextInfo);
            this.Controls.Add(this.ReceiverIP);
            this.Controls.Add(this.ClearReceivedWindow);
            this.Controls.Add(this.SendToAddress);
            this.Controls.Add(this.UDP_Link);
            this.Controls.Add(this.ClearSendingWindow);
            this.Controls.Add(this.ReceivingTextBox);
            this.Controls.Add(this.ToSendTextBox);
            this.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "UDPNetwork";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "UDP Receiver & Transmitter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox ToSendTextBox;
        private System.Windows.Forms.RichTextBox ReceivingTextBox;
        private System.Windows.Forms.Button ClearSendingWindow;
        private System.Windows.Forms.Button UDP_Link;
        private System.Windows.Forms.Button SendToAddress;
        private System.Windows.Forms.Button ClearReceivedWindow;
        private System.Windows.Forms.TextBox ReceiverIP;
        private System.Windows.Forms.TextBox UserTextInfo;
        private System.Windows.Forms.TextBox SenderPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer ButtonUpdater;
        private System.Windows.Forms.ComboBox IP_LIST;
        private System.Windows.Forms.Timer NetWorkUpdater;
    }
}