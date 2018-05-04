using RabbitMQDemo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsTest1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void thtest()
        {
            MessageBox.Show("Test");
            Thread.Sleep(10000000);
        }
        private void btnsend_Click(object sender, EventArgs e)
        {

            Send send = new Send();
            send.SendMsg(this.txtSendMsg.Text);

        }
        Receive receive;
        private void btnreceive_Click(object sender, EventArgs e)
        {
           
                receive = new Receive();
                receive.ReceiveMsg((msg) =>
                {
                    this.Invoke(new EventHandler((obj, args) =>
                    {
                        this.txtreceivemsg.Text += "\n" + msg;
                    }));
                });
       
            
        }
        public void add() { }

        private void btnclose_Click(object sender, EventArgs e)
        {
            if (receive != null)
                receive.Dispose();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (receive != null)
            //    receive.Dispose();
        }
    }
}
