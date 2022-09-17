
namespace BRS_Dallas_Programmer
{
    partial class Form1
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
            this.FTDI_Search_Timer = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ConnectionStatusButton = new System.Windows.Forms.Button();
            this.FolderButton = new System.Windows.Forms.Button();
            this.UploadCodeButton = new System.Windows.Forms.Button();
            this.ProgrammerSettings = new System.Windows.Forms.Button();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.AutoProgEnterCheck = new System.Windows.Forms.Timer(this.components);
            this.ProgrammingProgress = new System.Windows.Forms.ProgressBar();
            this.UserTextInfo = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FTDI_Search_Timer
            // 
            this.FTDI_Search_Timer.Enabled = true;
            this.FTDI_Search_Timer.Tick += new System.EventHandler(this.FTDI_Search_Timer_Tick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.ConnectionStatusButton);
            this.flowLayoutPanel1.Controls.Add(this.FolderButton);
            this.flowLayoutPanel1.Controls.Add(this.UploadCodeButton);
            this.flowLayoutPanel1.Controls.Add(this.ProgrammerSettings);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(13, 13);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(716, 141);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // ConnectionStatusButton
            // 
            this.ConnectionStatusButton.BackColor = System.Drawing.Color.Transparent;
            this.ConnectionStatusButton.BackgroundImage = global::BRS_Dallas_Programmer.Properties.Resources.icons8_usb_disconnected_100;
            this.ConnectionStatusButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ConnectionStatusButton.Enabled = false;
            this.ConnectionStatusButton.FlatAppearance.BorderSize = 0;
            this.ConnectionStatusButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConnectionStatusButton.ForeColor = System.Drawing.Color.Transparent;
            this.ConnectionStatusButton.Location = new System.Drawing.Point(4, 4);
            this.ConnectionStatusButton.Margin = new System.Windows.Forms.Padding(4);
            this.ConnectionStatusButton.Name = "ConnectionStatusButton";
            this.ConnectionStatusButton.Size = new System.Drawing.Size(171, 146);
            this.ConnectionStatusButton.TabIndex = 0;
            this.ConnectionStatusButton.UseVisualStyleBackColor = true;
            // 
            // FolderButton
            // 
            this.FolderButton.BackColor = System.Drawing.Color.Transparent;
            this.FolderButton.BackgroundImage = global::BRS_Dallas_Programmer.Properties.Resources.icons8_opened_folder_100;
            this.FolderButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.FolderButton.FlatAppearance.BorderSize = 0;
            this.FolderButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.FolderButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FolderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FolderButton.ForeColor = System.Drawing.Color.Transparent;
            this.FolderButton.Location = new System.Drawing.Point(183, 4);
            this.FolderButton.Margin = new System.Windows.Forms.Padding(4);
            this.FolderButton.Name = "FolderButton";
            this.FolderButton.Size = new System.Drawing.Size(171, 146);
            this.FolderButton.TabIndex = 1;
            this.FolderButton.UseVisualStyleBackColor = false;
            this.FolderButton.Click += new System.EventHandler(this.FolderButton_Click);
            // 
            // UploadCodeButton
            // 
            this.UploadCodeButton.BackColor = System.Drawing.Color.Transparent;
            this.UploadCodeButton.BackgroundImage = global::BRS_Dallas_Programmer.Properties.Resources.icons8_fileLoading_100;
            this.UploadCodeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.UploadCodeButton.FlatAppearance.BorderSize = 0;
            this.UploadCodeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.UploadCodeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.UploadCodeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UploadCodeButton.ForeColor = System.Drawing.Color.Transparent;
            this.UploadCodeButton.Location = new System.Drawing.Point(362, 4);
            this.UploadCodeButton.Margin = new System.Windows.Forms.Padding(4);
            this.UploadCodeButton.Name = "UploadCodeButton";
            this.UploadCodeButton.Size = new System.Drawing.Size(171, 146);
            this.UploadCodeButton.TabIndex = 2;
            this.UploadCodeButton.UseVisualStyleBackColor = false;
            this.UploadCodeButton.Click += new System.EventHandler(this.UploadCodeButton_Click);
            // 
            // ProgrammerSettings
            // 
            this.ProgrammerSettings.BackColor = System.Drawing.Color.Transparent;
            this.ProgrammerSettings.BackgroundImage = global::BRS_Dallas_Programmer.Properties.Resources.icons8_settings_100;
            this.ProgrammerSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ProgrammerSettings.FlatAppearance.BorderSize = 0;
            this.ProgrammerSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.ProgrammerSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ProgrammerSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProgrammerSettings.ForeColor = System.Drawing.Color.Transparent;
            this.ProgrammerSettings.Location = new System.Drawing.Point(541, 4);
            this.ProgrammerSettings.Margin = new System.Windows.Forms.Padding(4);
            this.ProgrammerSettings.Name = "ProgrammerSettings";
            this.ProgrammerSettings.Size = new System.Drawing.Size(171, 146);
            this.ProgrammerSettings.TabIndex = 5;
            this.ProgrammerSettings.UseVisualStyleBackColor = false;
            this.ProgrammerSettings.Click += new System.EventHandler(this.ProgrammerSettings_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::BRS_Dallas_Programmer.Properties.Resources.icons8_opened_folder_100;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::BRS_Dallas_Programmer.Properties.Resources.icons8_delete_folder_100;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::BRS_Dallas_Programmer.Properties.Resources.icons8_usb_disconnected_100;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::BRS_Dallas_Programmer.Properties.Resources.icons8_console_100;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "toolStripButton4";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.BackgroundImage = global::BRS_Dallas_Programmer.Properties.Resources.black_square;
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.Image = global::BRS_Dallas_Programmer.Properties.Resources.icons8_more_100;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // AutoProgEnterCheck
            // 
            this.AutoProgEnterCheck.Enabled = true;
            this.AutoProgEnterCheck.Interval = 1000;
            this.AutoProgEnterCheck.Tick += new System.EventHandler(this.AutoProgEnterCheck_Tick);
            // 
            // ProgrammingProgress
            // 
            this.ProgrammingProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ProgrammingProgress.Location = new System.Drawing.Point(0, 304);
            this.ProgrammingProgress.Name = "ProgrammingProgress";
            this.ProgrammingProgress.Size = new System.Drawing.Size(742, 23);
            this.ProgrammingProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ProgrammingProgress.TabIndex = 1;
            // 
            // UserTextInfo
            // 
            this.UserTextInfo.BackColor = System.Drawing.SystemColors.InfoText;
            this.UserTextInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UserTextInfo.Cursor = System.Windows.Forms.Cursors.No;
            this.UserTextInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.UserTextInfo.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserTextInfo.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.UserTextInfo.Location = new System.Drawing.Point(0, 267);
            this.UserTextInfo.Name = "UserTextInfo";
            this.UserTextInfo.ReadOnly = true;
            this.UserTextInfo.Size = new System.Drawing.Size(742, 37);
            this.UserTextInfo.TabIndex = 2;
            this.UserTextInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(742, 327);
            this.Controls.Add(this.UserTextInfo);
            this.Controls.Add(this.ProgrammingProgress);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer FTDI_Search_Timer;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button ConnectionStatusButton;
        private System.Windows.Forms.Button FolderButton;
        private System.Windows.Forms.Button UploadCodeButton;
        private System.Windows.Forms.Button ProgrammerSettings;
        private System.Windows.Forms.Timer AutoProgEnterCheck;
        private System.Windows.Forms.ProgressBar ProgrammingProgress;
        private System.Windows.Forms.TextBox UserTextInfo;
    }
}

