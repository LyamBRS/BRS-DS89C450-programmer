
namespace BRS_Dallas_Programmer
{
    partial class ConsoleSetting
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
            this.BRSLogo = new System.Windows.Forms.Button();
            this.AcceptButton = new System.Windows.Forms.Button();
            this.BaudRateBox = new System.Windows.Forms.ComboBox();
            this.BaudRateText = new System.Windows.Forms.Button();
            this.DataBitsText = new System.Windows.Forms.Button();
            this.DataBitBox = new System.Windows.Forms.ComboBox();
            this.StopBitsText = new System.Windows.Forms.Button();
            this.StopBitBox = new System.Windows.Forms.ComboBox();
            this.ParityText = new System.Windows.Forms.Button();
            this.ParityBox = new System.Windows.Forms.ComboBox();
            this.TXTimeOutText = new System.Windows.Forms.Button();
            this.RXTimeOutText = new System.Windows.Forms.Button();
            this.RXTimeOutBox = new System.Windows.Forms.TextBox();
            this.TXTimeOutBox = new System.Windows.Forms.TextBox();
            this.FlowControlText = new System.Windows.Forms.Button();
            this.FlowControlBox = new System.Windows.Forms.ComboBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SerialPortText = new System.Windows.Forms.Button();
            this.PortBox1 = new System.Windows.Forms.ComboBox();
            this.UpdatePortList = new System.Windows.Forms.Timer(this.components);
            this.ShowUserTxLabel = new System.Windows.Forms.Button();
            this.ParseReturnsLabel = new System.Windows.Forms.Button();
            this.UserTXCheckBox = new System.Windows.Forms.Button();
            this.ParseReturnCheckBox = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BRSLogo
            // 
            this.BRSLogo.BackgroundImage = global::BRS_Dallas_Programmer.Properties.Resources.BRS_Header;
            this.BRSLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BRSLogo.Enabled = false;
            this.BRSLogo.FlatAppearance.BorderSize = 0;
            this.BRSLogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BRSLogo.Location = new System.Drawing.Point(12, 12);
            this.BRSLogo.Name = "BRSLogo";
            this.BRSLogo.Size = new System.Drawing.Size(271, 50);
            this.BRSLogo.TabIndex = 2;
            this.BRSLogo.UseVisualStyleBackColor = true;
            // 
            // AcceptButton
            // 
            this.AcceptButton.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.AcceptButton.BackgroundImage = global::BRS_Dallas_Programmer.Properties.Resources.icons8_ok_100__1_;
            this.AcceptButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AcceptButton.FlatAppearance.BorderSize = 0;
            this.AcceptButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.AcceptButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(128)))), ((int)(((byte)(64)))));
            this.AcceptButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AcceptButton.Location = new System.Drawing.Point(181, 438);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(102, 87);
            this.AcceptButton.TabIndex = 4;
            this.AcceptButton.UseVisualStyleBackColor = true;
            this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // BaudRateBox
            // 
            this.BaudRateBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BaudRateBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BaudRateBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BaudRateBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BaudRateBox.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.BaudRateBox.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400",
            "460800",
            "921600"});
            this.BaudRateBox.Location = new System.Drawing.Point(152, 129);
            this.BaudRateBox.Name = "BaudRateBox";
            this.BaudRateBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BaudRateBox.Size = new System.Drawing.Size(131, 27);
            this.BaudRateBox.TabIndex = 6;
            // 
            // BaudRateText
            // 
            this.BaudRateText.FlatAppearance.BorderSize = 0;
            this.BaudRateText.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BaudRateText.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BaudRateText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BaudRateText.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.BaudRateText.Location = new System.Drawing.Point(12, 129);
            this.BaudRateText.Name = "BaudRateText";
            this.BaudRateText.Size = new System.Drawing.Size(134, 27);
            this.BaudRateText.TabIndex = 7;
            this.BaudRateText.Text = "BaudRate:";
            this.BaudRateText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BaudRateText.UseVisualStyleBackColor = true;
            // 
            // DataBitsText
            // 
            this.DataBitsText.FlatAppearance.BorderSize = 0;
            this.DataBitsText.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.DataBitsText.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.DataBitsText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DataBitsText.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.DataBitsText.Location = new System.Drawing.Point(12, 162);
            this.DataBitsText.Name = "DataBitsText";
            this.DataBitsText.Size = new System.Drawing.Size(134, 27);
            this.DataBitsText.TabIndex = 9;
            this.DataBitsText.Text = "Data Bits:";
            this.DataBitsText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DataBitsText.UseVisualStyleBackColor = true;
            // 
            // DataBitBox
            // 
            this.DataBitBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DataBitBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DataBitBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DataBitBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DataBitBox.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.DataBitBox.FormattingEnabled = true;
            this.DataBitBox.Items.AddRange(new object[] {
            "7",
            "8"});
            this.DataBitBox.Location = new System.Drawing.Point(152, 162);
            this.DataBitBox.Name = "DataBitBox";
            this.DataBitBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DataBitBox.Size = new System.Drawing.Size(131, 27);
            this.DataBitBox.TabIndex = 8;
            // 
            // StopBitsText
            // 
            this.StopBitsText.FlatAppearance.BorderSize = 0;
            this.StopBitsText.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.StopBitsText.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.StopBitsText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StopBitsText.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.StopBitsText.Location = new System.Drawing.Point(11, 195);
            this.StopBitsText.Name = "StopBitsText";
            this.StopBitsText.Size = new System.Drawing.Size(134, 27);
            this.StopBitsText.TabIndex = 11;
            this.StopBitsText.Text = "Stop Bits:";
            this.StopBitsText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.StopBitsText.UseVisualStyleBackColor = true;
            // 
            // StopBitBox
            // 
            this.StopBitBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StopBitBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.StopBitBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StopBitBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StopBitBox.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.StopBitBox.FormattingEnabled = true;
            this.StopBitBox.Location = new System.Drawing.Point(151, 195);
            this.StopBitBox.Name = "StopBitBox";
            this.StopBitBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StopBitBox.Size = new System.Drawing.Size(131, 27);
            this.StopBitBox.TabIndex = 10;
            // 
            // ParityText
            // 
            this.ParityText.FlatAppearance.BorderSize = 0;
            this.ParityText.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ParityText.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ParityText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ParityText.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.ParityText.Location = new System.Drawing.Point(11, 228);
            this.ParityText.Name = "ParityText";
            this.ParityText.Size = new System.Drawing.Size(134, 27);
            this.ParityText.TabIndex = 13;
            this.ParityText.Text = "Parity:";
            this.ParityText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ParityText.UseVisualStyleBackColor = true;
            // 
            // ParityBox
            // 
            this.ParityBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ParityBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ParityBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ParityBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ParityBox.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.ParityBox.FormattingEnabled = true;
            this.ParityBox.Location = new System.Drawing.Point(151, 228);
            this.ParityBox.Name = "ParityBox";
            this.ParityBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ParityBox.Size = new System.Drawing.Size(131, 27);
            this.ParityBox.TabIndex = 12;
            // 
            // TXTimeOutText
            // 
            this.TXTimeOutText.FlatAppearance.BorderSize = 0;
            this.TXTimeOutText.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.TXTimeOutText.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.TXTimeOutText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TXTimeOutText.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.TXTimeOutText.Location = new System.Drawing.Point(11, 328);
            this.TXTimeOutText.Name = "TXTimeOutText";
            this.TXTimeOutText.Size = new System.Drawing.Size(134, 27);
            this.TXTimeOutText.TabIndex = 17;
            this.TXTimeOutText.Text = "TX (ms):";
            this.TXTimeOutText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TXTimeOutText.UseVisualStyleBackColor = true;
            // 
            // RXTimeOutText
            // 
            this.RXTimeOutText.FlatAppearance.BorderSize = 0;
            this.RXTimeOutText.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.RXTimeOutText.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.RXTimeOutText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RXTimeOutText.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.RXTimeOutText.Location = new System.Drawing.Point(11, 295);
            this.RXTimeOutText.Name = "RXTimeOutText";
            this.RXTimeOutText.Size = new System.Drawing.Size(134, 27);
            this.RXTimeOutText.TabIndex = 15;
            this.RXTimeOutText.Text = "RX (ms):";
            this.RXTimeOutText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RXTimeOutText.UseVisualStyleBackColor = true;
            // 
            // RXTimeOutBox
            // 
            this.RXTimeOutBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.RXTimeOutBox.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.RXTimeOutBox.Location = new System.Drawing.Point(151, 295);
            this.RXTimeOutBox.Name = "RXTimeOutBox";
            this.RXTimeOutBox.Size = new System.Drawing.Size(131, 26);
            this.RXTimeOutBox.TabIndex = 18;
            this.RXTimeOutBox.Text = "300";
            // 
            // TXTimeOutBox
            // 
            this.TXTimeOutBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TXTimeOutBox.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.TXTimeOutBox.Location = new System.Drawing.Point(151, 329);
            this.TXTimeOutBox.Name = "TXTimeOutBox";
            this.TXTimeOutBox.Size = new System.Drawing.Size(131, 26);
            this.TXTimeOutBox.TabIndex = 19;
            this.TXTimeOutBox.Text = "300";
            // 
            // FlowControlText
            // 
            this.FlowControlText.FlatAppearance.BorderSize = 0;
            this.FlowControlText.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.FlowControlText.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.FlowControlText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FlowControlText.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.FlowControlText.Location = new System.Drawing.Point(11, 261);
            this.FlowControlText.Name = "FlowControlText";
            this.FlowControlText.Size = new System.Drawing.Size(134, 27);
            this.FlowControlText.TabIndex = 21;
            this.FlowControlText.Text = "Flow Control:";
            this.FlowControlText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FlowControlText.UseVisualStyleBackColor = true;
            // 
            // FlowControlBox
            // 
            this.FlowControlBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FlowControlBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FlowControlBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FlowControlBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FlowControlBox.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.FlowControlBox.FormattingEnabled = true;
            this.FlowControlBox.Location = new System.Drawing.Point(151, 262);
            this.FlowControlBox.Name = "FlowControlBox";
            this.FlowControlBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.FlowControlBox.Size = new System.Drawing.Size(131, 27);
            this.FlowControlBox.TabIndex = 20;
            // 
            // CancelButton
            // 
            this.CancelButton.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.CancelButton.BackgroundImage = global::BRS_Dallas_Programmer.Properties.Resources.icons8_cancel_100;
            this.CancelButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.FlatAppearance.BorderSize = 0;
            this.CancelButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.CancelButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButton.Location = new System.Drawing.Point(11, 438);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(102, 87);
            this.CancelButton.TabIndex = 22;
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SerialPortText
            // 
            this.SerialPortText.FlatAppearance.BorderSize = 0;
            this.SerialPortText.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.SerialPortText.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.SerialPortText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SerialPortText.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.SerialPortText.Location = new System.Drawing.Point(13, 83);
            this.SerialPortText.Name = "SerialPortText";
            this.SerialPortText.Size = new System.Drawing.Size(134, 27);
            this.SerialPortText.TabIndex = 24;
            this.SerialPortText.Text = "Port:";
            this.SerialPortText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SerialPortText.UseVisualStyleBackColor = true;
            // 
            // PortBox1
            // 
            this.PortBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PortBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PortBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PortBox1.DropDownHeight = 1000;
            this.PortBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PortBox1.DropDownWidth = 1000;
            this.PortBox1.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.PortBox1.FormattingEnabled = true;
            this.PortBox1.IntegralHeight = false;
            this.PortBox1.Location = new System.Drawing.Point(153, 83);
            this.PortBox1.Name = "PortBox1";
            this.PortBox1.Size = new System.Drawing.Size(131, 27);
            this.PortBox1.Sorted = true;
            this.PortBox1.TabIndex = 23;
            // 
            // UpdatePortList
            // 
            this.UpdatePortList.Enabled = true;
            this.UpdatePortList.Interval = 500;
            this.UpdatePortList.Tick += new System.EventHandler(this.UpdatePortList_Tick);
            // 
            // ShowUserTxLabel
            // 
            this.ShowUserTxLabel.FlatAppearance.BorderSize = 0;
            this.ShowUserTxLabel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ShowUserTxLabel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ShowUserTxLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowUserTxLabel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.ShowUserTxLabel.Location = new System.Drawing.Point(13, 361);
            this.ShowUserTxLabel.Name = "ShowUserTxLabel";
            this.ShowUserTxLabel.Size = new System.Drawing.Size(134, 27);
            this.ShowUserTxLabel.TabIndex = 25;
            this.ShowUserTxLabel.Text = "Show User TX";
            this.ShowUserTxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ShowUserTxLabel.UseVisualStyleBackColor = true;
            // 
            // ParseReturnsLabel
            // 
            this.ParseReturnsLabel.FlatAppearance.BorderSize = 0;
            this.ParseReturnsLabel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ParseReturnsLabel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ParseReturnsLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ParseReturnsLabel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.ParseReturnsLabel.Location = new System.Drawing.Point(13, 394);
            this.ParseReturnsLabel.Name = "ParseReturnsLabel";
            this.ParseReturnsLabel.Size = new System.Drawing.Size(134, 27);
            this.ParseReturnsLabel.TabIndex = 26;
            this.ParseReturnsLabel.Text = "Parse \'\\r\'";
            this.ParseReturnsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ParseReturnsLabel.UseVisualStyleBackColor = true;
            // 
            // UserTXCheckBox
            // 
            this.UserTXCheckBox.BackgroundImage = global::BRS_Dallas_Programmer.Properties.Resources.icons8_unchecked_checkbox_100;
            this.UserTXCheckBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UserTXCheckBox.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.UserTXCheckBox.FlatAppearance.BorderSize = 0;
            this.UserTXCheckBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.UserTXCheckBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.UserTXCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.UserTXCheckBox.Location = new System.Drawing.Point(151, 365);
            this.UserTXCheckBox.Name = "UserTXCheckBox";
            this.UserTXCheckBox.Size = new System.Drawing.Size(27, 23);
            this.UserTXCheckBox.TabIndex = 27;
            this.UserTXCheckBox.UseVisualStyleBackColor = true;
            // 
            // ParseReturnCheckBox
            // 
            this.ParseReturnCheckBox.BackgroundImage = global::BRS_Dallas_Programmer.Properties.Resources.icons8_unchecked_checkbox_100;
            this.ParseReturnCheckBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ParseReturnCheckBox.FlatAppearance.BorderSize = 0;
            this.ParseReturnCheckBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ParseReturnCheckBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ParseReturnCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ParseReturnCheckBox.Location = new System.Drawing.Point(151, 394);
            this.ParseReturnCheckBox.Name = "ParseReturnCheckBox";
            this.ParseReturnCheckBox.Size = new System.Drawing.Size(27, 23);
            this.ParseReturnCheckBox.TabIndex = 28;
            this.ParseReturnCheckBox.UseVisualStyleBackColor = true;
            // 
            // ConsoleSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(296, 537);
            this.Controls.Add(this.ParseReturnCheckBox);
            this.Controls.Add(this.UserTXCheckBox);
            this.Controls.Add(this.ParseReturnsLabel);
            this.Controls.Add(this.ShowUserTxLabel);
            this.Controls.Add(this.SerialPortText);
            this.Controls.Add(this.PortBox1);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.FlowControlText);
            this.Controls.Add(this.FlowControlBox);
            this.Controls.Add(this.TXTimeOutBox);
            this.Controls.Add(this.RXTimeOutBox);
            this.Controls.Add(this.TXTimeOutText);
            this.Controls.Add(this.RXTimeOutText);
            this.Controls.Add(this.ParityText);
            this.Controls.Add(this.ParityBox);
            this.Controls.Add(this.StopBitsText);
            this.Controls.Add(this.StopBitBox);
            this.Controls.Add(this.DataBitsText);
            this.Controls.Add(this.DataBitBox);
            this.Controls.Add(this.BaudRateText);
            this.Controls.Add(this.BaudRateBox);
            this.Controls.Add(this.AcceptButton);
            this.Controls.Add(this.BRSLogo);
            this.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ConsoleSetting";
            this.Tag = "";
            this.Text = "[BRS]: Console Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BRSLogo;
        private System.Windows.Forms.Button AcceptButton;
        private System.Windows.Forms.ComboBox BaudRateBox;
        private System.Windows.Forms.Button BaudRateText;
        private System.Windows.Forms.Button DataBitsText;
        private System.Windows.Forms.ComboBox DataBitBox;
        private System.Windows.Forms.Button StopBitsText;
        private System.Windows.Forms.ComboBox StopBitBox;
        private System.Windows.Forms.Button ParityText;
        private System.Windows.Forms.ComboBox ParityBox;
        private System.Windows.Forms.Button TXTimeOutText;
        private System.Windows.Forms.Button RXTimeOutText;
        private System.Windows.Forms.TextBox RXTimeOutBox;
        private System.Windows.Forms.TextBox TXTimeOutBox;
        private System.Windows.Forms.Button FlowControlText;
        private System.Windows.Forms.ComboBox FlowControlBox;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SerialPortText;
        private System.Windows.Forms.ComboBox PortBox1;
        private System.Windows.Forms.Timer UpdatePortList;
        private System.Windows.Forms.Button ShowUserTxLabel;
        private System.Windows.Forms.Button ParseReturnsLabel;
        private System.Windows.Forms.Button UserTXCheckBox;
        private System.Windows.Forms.Button ParseReturnCheckBox;
    }
}