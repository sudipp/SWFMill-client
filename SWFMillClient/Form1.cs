using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;


namespace SWFMillUtility
{
    public partial class Form1 : Form
    {
        private Process m_Process;
        private Thread m_OutputThread;
        private Thread m_ErrorThread;
        private string m_TextToAdd;

        private delegate void delAddTextToTextBox();
        private delAddTextToTextBox del;

        private bool conversionStarted=false;
        private int totalFinishedJobs = 0;
        private delegate void delBatchFinished();
        private event delBatchFinished delBF;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try{
                cboSel.SelectedIndex = 0;

                del = new delAddTextToTextBox(AddTextToTextBox);
                delBF +=new delBatchFinished(delBatchFinishedHandler);

                m_Process = new Process();
                m_Process.StartInfo.FileName = "cmd";
                m_Process.StartInfo.UseShellExecute = false;
                m_Process.StartInfo.CreateNoWindow = true;

                m_Process.StartInfo.RedirectStandardOutput = true;
                m_Process.StartInfo.RedirectStandardError = true;
                m_Process.StartInfo.RedirectStandardInput = true;
                m_Process.Start();
                
                m_OutputThread = new Thread(StreamOutput);
                m_OutputThread.IsBackground = true;
                m_OutputThread.Start();
                
                m_ErrorThread = new Thread(StreamError);
                m_ErrorThread.IsBackground = true;
                m_ErrorThread.Start();
            }
            catch(Exception ex)
            {
                AddText(String.Format("{0}", ex.Message));  
            }
        }

        private string ConvertFromOem(string txt)
        {
            return Encoding.GetEncoding(CultureInfo.InstalledUICulture.TextInfo.OEMCodePage).GetString(Encoding.Default.GetBytes(txt));
        }

        private void StreamOutput()
        {
            string mLine = m_Process.StandardOutput.ReadLine();
            try{
                while(mLine.Length>=0)
                {
                    if (mLine.Length > 0) AddText(ConvertFromOem(mLine));
                    mLine = m_Process.StandardOutput.ReadLine();

                    if(conversionStarted==true && mLine.Length==0){
                        totalFinishedJobs += 1;


                        //If all file conversion finished
                        if(totalFinishedJobs==cDirectory.getAllValidFilesInsideDirectory().Count){
                            delBF.Invoke();
                        }
                    }
                }
            }
            catch(Exception e)
            {
                AddText(String.Format("{0}", m_Process.StartInfo.FileName));  
            }
        }
        private void StreamError()
        {
            string mLine = m_Process.StandardError.ReadLine();
            try{
                while(mLine.Length>=0)
                {
                    mLine = m_Process.StandardError.ReadLine();
                    if (mLine.Length > 0) AddText(ConvertFromOem(mLine));
                }
            }
            catch(Exception e)
            {
                AddText(String.Format("{0}", m_Process.StartInfo.FileName));  
            }
        }

        private void StreamInput(string Txt)
        {
            m_Process.StandardInput.WriteLine(Txt);
            m_Process.StandardInput.Flush();
        }

        private void AddText(string txt)
        {
            m_TextToAdd = txt;
            //this.Invoke(this.AddTextToTextBox));
            //MethodInvoker()
            this.Invoke(del);
        }
        
        private void AddTextToTextBox()
        {
            if(m_TextToAdd.IndexOf("Conversion finished")>-1)
            {
                this.cmdStart.Enabled = true;
                this.cmdBrowseFolder.Enabled = true;
            }

            this.txtConsole.AppendText(m_TextToAdd + Environment.NewLine);
            this.txtConsole.SelectionStart = this.txtConsole.Text.Length;
        }

        private void MainForm_Closing(object sender, CancelEventArgs e)
        {
            if (m_Process.HasExited==false) m_Process.Kill();

            m_Process.Close();
        }

        private void cmedBrowseFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txtSrcFolder.Text = folderBrowserDialog1.SelectedPath;

            this.UseWaitCursor = true;

            string SrcFileExt = isFolderValid();
            lblInfo.Text = String.Format("There are {0} {1} file(s) found on source directory.", cDirectory.getAllValidFilesInsideDirectory().Count, SrcFileExt);
            //isFolderValid();
            //lblInfo.Text = String.Format("There are {0} files found on source directory.", cDirectory.getAllValidFilesInsideDirectory().Count);
            if(cDirectory.getAllValidFilesInsideDirectory().Count==0) cmdStart.Enabled = false;
            else cmdStart.Enabled = true;
            this.UseWaitCursor = false;
        }

        private void txtSrcFolder_TextChanged(object sender, EventArgs e)
        {
            if(txtSrcFolder.Text.Length<1) cmdStart.Enabled = false;
            else cmdStart.Enabled = true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //swfmill swf2xml foo.swf bar.xml
            

            /*
            string fileEXT = "";
            switch(cboSel.SelectedIndex)
            {
                case 0:
                    fileEXT = ".SWF";
                    break;
                case 1:
                    fileEXT = ".XML";
                    break;
                default:
                    fileEXT = ".SWF";
                    break;
            }

            if (cDirectory.isDirectoryPathValid(txtSrcFolder.Text, fileEXT) == false)
            {
                MessageBox.Show("Invalid source folder entered.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.UseWaitCursor = false;
                return; 
            }            

            AddText(String.Format("There are {0} files found on source directory.", cDirectory.getAllValidFilesInsideDirectory().Count));
            if (cDirectory.getAllValidFilesInsideDirectory().Count==0) return;
            */

            this.UseWaitCursor = true;
            this.txtConsole.Clear();
            AddText(String.Format("Conversion started @ {0}", DateTime.Now.ToString()));
            AddText("-----------------------------------------------------");
            
            cmdStart.Enabled = false;
            cmdBrowseFolder.Enabled = false;
            string command = "";
            foreach (ConversionFileHelper files in cDirectory.getAllValidFilesInsideDirectory())
            {
                command = "swfmill " + cboSel.Text + " \"" + files.srcFile + "\" \"" + files.destFile + "\"";
                command = command.ToLower();
                
                StreamInput(ConvertFromOem(command));
                conversionStarted = true;
            }
            
        }

        private void delBatchFinishedHandler()
        {
            AddText("-----------------------------------------------------");
            AddText(String.Format("Conversion finished @ {0}", DateTime.Now.ToString()));

            conversionStarted = false;
            totalFinishedJobs = 0;
            this.UseWaitCursor = false;
        }


        private string isFolderValid()
        {
            string fileEXT = "";
            switch (cboSel.SelectedIndex)
            {
                case 0:
                    fileEXT = ".SWF";
                    break;
                case 1:
                    fileEXT = ".XML";
                    break;
                default:
                    fileEXT = ".SWF";
                    break;
            }
            cDirectory.isDirectoryPathValid(txtSrcFolder.Text, fileEXT);
            return fileEXT;
        }

        private void txtSrcFolder_Leave(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;
            
            string SrcFileExt=isFolderValid();
            lblInfo.Text = String.Format("There are {0} {1} file(s) found on source directory.", cDirectory.getAllValidFilesInsideDirectory().Count, SrcFileExt);
            if (cDirectory.getAllValidFilesInsideDirectory().Count == 0) cmdStart.Enabled = false;
            else cmdStart.Enabled = true;
            this.UseWaitCursor = false;
        }
    }

}