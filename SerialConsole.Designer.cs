
namespace BRS_Dallas_Programmer
{
    partial class SerialConsole
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ConsoleArea = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.UserInfo = new System.Windows.Forms.TextBox();
            this.Periodic100msTimer = new System.Windows.Forms.Timer(this.components);
            this.SerialLinkButon = new System.Windows.Forms.ToolStripButton();
            this.SelectFileButton = new System.Windows.Forms.ToolStripButton();
            this.FileButton = new System.Windows.Forms.ToolStripButton();
            this.ClearConsoleButton = new System.Windows.Forms.ToolStripButton();
            this.SettingsButton = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.5F));
            this.tableLayoutPanel1.Controls.Add(this.ConsoleArea, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 58);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 541F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 541);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // ConsoleArea
            // 
            this.ConsoleArea.AcceptsTab = true;
            this.ConsoleArea.AutoWordSelection = true;
            this.ConsoleArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ConsoleArea.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ConsoleArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConsoleArea.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.ConsoleArea.Location = new System.Drawing.Point(111, 3);
            this.ConsoleArea.Name = "ConsoleArea";
            this.ConsoleArea.ShortcutsEnabled = false;
            this.ConsoleArea.Size = new System.Drawing.Size(686, 535);
            this.ConsoleArea.TabIndex = 6;
            this.ConsoleArea.Text = "";
            this.ConsoleArea.WordWrap = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.toolStrip1.AllowItemReorder = true;
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlText;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SerialLinkButon,
            this.SelectFileButton,
            this.FileButton,
            this.ClearConsoleButton,
            this.SettingsButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(108, 541);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "Console Strip";
            // 
            // UserInfo
            // 
            this.UserInfo.BackColor = System.Drawing.Color.Black;
            this.UserInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UserInfo.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserInfo.ForeColor = System.Drawing.Color.Gray;
            this.UserInfo.Location = new System.Drawing.Point(114, 12);
            this.UserInfo.Name = "UserInfo";
            this.UserInfo.ReadOnly = true;
            this.UserInfo.ShortcutsEnabled = false;
            this.UserInfo.Size = new System.Drawing.Size(686, 38);
            this.UserInfo.TabIndex = 4;
            this.UserInfo.Text = "Console";
            this.UserInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Periodic100msTimer
            // 
            this.Periodic100msTimer.Enabled = true;
            this.Periodic100msTimer.Tick += new System.EventHandler(this.Periodic100msTimer_Tick);
            // 
            // SerialLinkButon
            // 
            this.SerialLinkButon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SerialLinkButon.Image = global::BRS_Dallas_Programmer.Properties.Resources.icons8_broken_link_100__2_;
            this.SerialLinkButon.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SerialLinkButon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SerialLinkButon.Name = "SerialLinkButon";
            this.SerialLinkButon.Size = new System.Drawing.Size(107, 104);
            this.SerialLinkButon.Text = "LinkToSerial";
            this.SerialLinkButon.ToolTipText = "Connect to selected Serial Port";
            // 
            // SelectFileButton
            // 
            this.SelectFileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SelectFileButton.Image = global::BRS_Dallas_Programmer.Properties.Resources.icons8_opened_folder_100;
            this.SelectFileButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SelectFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SelectFileButton.Name = "SelectFileButton";
            this.SelectFileButton.Size = new System.Drawing.Size(107, 104);
            this.SelectFileButton.Text = "File";
            this.SelectFileButton.ToolTipText = "Select a file to send over opened port";
            // 
            // FileButton
            // 
            this.FileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.FileButton.Enabled = false;
            this.FileButton.Image = global::BRS_Dallas_Programmer.Properties.Resources.icons8_file_100;
            this.FileButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.FileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FileButton.Name = "FileButton";
            this.FileButton.Size = new System.Drawing.Size(107, 104);
            this.FileButton.Text = "File";
            this.FileButton.ToolTipText = "Send selected file over serial";
            // 
            // ClearConsoleButton
            // 
            this.ClearConsoleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ClearConsoleButton.Image = global::BRS_Dallas_Programmer.Properties.Resources.icons8_delete_history_100;
            this.ClearConsoleButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ClearConsoleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ClearConsoleButton.Name = "ClearConsoleButton";
            this.ClearConsoleButton.Size = new System.Drawing.Size(107, 104);
            this.ClearConsoleButton.Text = "Clear Console";
            this.ClearConsoleButton.ToolTipText = "Clear console text area";
            // 
            // SettingsButton
            // 
            this.SettingsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SettingsButton.Image = global::BRS_Dallas_Programmer.Properties.Resources.icons8_settings_disabled_100__1_;
            this.SettingsButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SettingsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(107, 104);
            this.SettingsButton.Text = "toolStripButton1";
            // 
            // SerialConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(804, 611);
            this.Controls.Add(this.UserInfo);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpButton = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SerialConsole";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[BRS]: Console";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox ConsoleArea;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton SerialLinkButon;
        private System.Windows.Forms.ToolStripButton SelectFileButton;
        private System.Windows.Forms.ToolStripButton FileButton;
        private System.Windows.Forms.ToolStripButton ClearConsoleButton;
        private System.Windows.Forms.ToolStripButton SettingsButton;
        private System.Windows.Forms.TextBox UserInfo;
        private System.Windows.Forms.Timer Periodic100msTimer;
    }
}