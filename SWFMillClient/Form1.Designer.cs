namespace SWFMillUtility
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cmdStart = new System.Windows.Forms.Button();
            this.process1 = new System.Diagnostics.Process();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSrcFolder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdBrowseFolder = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.cboSel = new System.Windows.Forms.ComboBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdStart
            // 
            this.cmdStart.Enabled = false;
            this.cmdStart.Location = new System.Drawing.Point(616, 80);
            this.cmdStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(100, 28);
            this.cmdStart.TabIndex = 3;
            this.cmdStart.Text = "Start";
            this.cmdStart.UseVisualStyleBackColor = true;
            this.cmdStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // process1
            // 
            this.process1.StartInfo.Domain = "";
            this.process1.StartInfo.FileName = "C:\\Documents and Settings\\purkasud\\Desktop\\WindowsApplication1\\WindowsApplication" +
    "1\\bin\\Debug\\swfmill.exe";
            this.process1.StartInfo.LoadUserProfile = false;
            this.process1.StartInfo.Password = null;
            this.process1.StartInfo.RedirectStandardOutput = true;
            this.process1.StartInfo.StandardErrorEncoding = null;
            this.process1.StartInfo.StandardOutputEncoding = null;
            this.process1.StartInfo.UserName = "";
            this.process1.StartInfo.UseShellExecute = false;
            this.process1.StartInfo.Verb = "runas";
            this.process1.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized;
            this.process1.SynchronizingObject = this;
            // 
            // txtConsole
            // 
            this.txtConsole.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtConsole.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtConsole.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsole.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.txtConsole.Location = new System.Drawing.Point(0, 119);
            this.txtConsole.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtConsole.ShortcutsEnabled = false;
            this.txtConsole.Size = new System.Drawing.Size(732, 260);
            this.txtConsole.TabIndex = 1;
            this.txtConsole.TabStop = false;
            this.txtConsole.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Conversion Type";
            // 
            // txtSrcFolder
            // 
            this.txtSrcFolder.Location = new System.Drawing.Point(141, 46);
            this.txtSrcFolder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSrcFolder.Name = "txtSrcFolder";
            this.txtSrcFolder.Size = new System.Drawing.Size(541, 22);
            this.txtSrcFolder.TabIndex = 1;
            this.txtSrcFolder.TextChanged += new System.EventHandler(this.txtSrcFolder_TextChanged);
            this.txtSrcFolder.Leave += new System.EventHandler(this.txtSrcFolder_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Source Folder";
            // 
            // cmdBrowseFolder
            // 
            this.cmdBrowseFolder.Location = new System.Drawing.Point(683, 46);
            this.cmdBrowseFolder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdBrowseFolder.Name = "cmdBrowseFolder";
            this.cmdBrowseFolder.Size = new System.Drawing.Size(33, 27);
            this.cmdBrowseFolder.TabIndex = 2;
            this.cmdBrowseFolder.Text = "...";
            this.cmdBrowseFolder.UseVisualStyleBackColor = true;
            this.cmdBrowseFolder.Click += new System.EventHandler(this.cmedBrowseFolder_Click);
            // 
            // cboSel
            // 
            this.cboSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSel.FormattingEnabled = true;
            this.cboSel.Items.AddRange(new object[] {
            "SWF2XML",
            "XML2SWF"});
            this.cboSel.Location = new System.Drawing.Point(143, 15);
            this.cboSel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboSel.Name = "cboSel";
            this.cboSel.Size = new System.Drawing.Size(160, 24);
            this.cboSel.TabIndex = 7;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(17, 80);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 17);
            this.lblInfo.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 379);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.cboSel);
            this.Controls.Add(this.cmdBrowseFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSrcFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.cmdStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SWFMill Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdStart;
        private System.Diagnostics.Process process1;
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.Button cmdBrowseFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSrcFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ComboBox cboSel;
        private System.Windows.Forms.Label lblInfo;
    }
}

