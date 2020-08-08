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
       
        private void btnsend_Click(object sender, EventArgs e)
        {
            Consumer receive = new Consumer();
            receive.ReceiveMsg(ShowReceiveMsg);

            Publisher send = new Publisher();
            send.SendMsg(this.txtSendMsg.Text);
        }

        private void btnallquenes_Click(object sender, EventArgs e)
        {
            MessageBox.Show(new RabbitMQHelper().GetAllQuenes());
        }

        private void btndirect_Click(object sender, EventArgs e)
        {
            LogDirectConsumer receive = new LogDirectConsumer();
            receive.ReceiveMsg(ShowReceiveMsg);

            LogDirectPub send = new LogDirectPub();
            send.SendMsg(this.txtSendMsg.Text);
        }

        private void btnfanout_Click(object sender, EventArgs e)
        {
            LogFanoutConsumer receive = new LogFanoutConsumer();
            receive.ReceiveMsg(ShowReceiveMsg);

            LogFanoutPub send = new LogFanoutPub();
            send.SendMsg(this.txtSendMsg.Text);
        }

        private void btnheaders_Click(object sender, EventArgs e)
        {
            LogHeadersConsumer receive = new LogHeadersConsumer();
            receive.ReceiveMsg(ShowReceiveMsg);

            LogHeadersPub send = new LogHeadersPub();
            send.SendMsg(this.txtSendMsg.Text);
        }

        private void btntopic_Click(object sender, EventArgs e)
        {
            LogTopicConsumer receive = new LogTopicConsumer();
            receive.ReceiveMsg(ShowReceiveMsg);

            LogTopicPub send = new LogTopicPub();
            send.SendMsg(this.txtSendMsg.Text);
        }

        private async void btnrpc_Click(object sender, EventArgs e)
        {
            RpcConsumer receive = new RpcConsumer();
            receive.ReceiveMsg(ShowReceiveMsg);

            RpcPub send = new RpcPub();
            string result = await send.SendMsg(this.txtSendMsg.Text);
            ShowReplayMsg(result);
        }

        private void ShowReceiveMsg(string msg)
        {
            this.Invoke(new EventHandler((obj, args) =>
            {
                this.txtreceivemsg.Text += "\n" + msg;
            }));
        }

        private void ShowReplayMsg(string msg)
        {
            txtreplay.Text += "\n" + msg;
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

    }
}
