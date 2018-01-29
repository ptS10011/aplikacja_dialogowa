using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace MySQL_Test
{
    public partial class Form1 : Form
    { 
        private Thread appThread = null;
        private Control label;
        public Form1()
        {
            InitializeComponent();
            label = Controls.Find("promptLabel", true)[0];
        }

        public void SetAppThread(Thread t)
        {
            this.appThread = t;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        delegate void SetTextCallback(string text);

        private void SetText(string text)
        {
            if (label.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                label.Text = text;
            }

        }
        public void SetView(string header, List<string> prompts)
        {
            if (prompts != null && prompts.Count > 0)
            {
                header += ": ";
                for (int i = 0; i < prompts.Count; i++)
                {
                    header += Environment.NewLine + prompts[i];
                }
            }
            SetText(header);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var dbCon = new DBConnect();
            //dbCon.InsertLot("warszawa", "londyn", "styczen");
            if (appThread != null && !appThread.IsAlive)
                appThread.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
