namespace WindowsFormsTest1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSendMsg = new System.Windows.Forms.TextBox();
            this.txtreceivemsg = new System.Windows.Forms.RichTextBox();
            this.btnsend = new System.Windows.Forms.Button();
            this.btnallquenes = new System.Windows.Forms.Button();
            this.btndirect = new System.Windows.Forms.Button();
            this.btnfanout = new System.Windows.Forms.Button();
            this.btnheaders = new System.Windows.Forms.Button();
            this.btntopic = new System.Windows.Forms.Button();
            this.btnrpc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtreplay = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtSendMsg
            // 
            this.txtSendMsg.Location = new System.Drawing.Point(12, 26);
            this.txtSendMsg.Name = "txtSendMsg";
            this.txtSendMsg.Size = new System.Drawing.Size(166, 21);
            this.txtSendMsg.TabIndex = 0;
            // 
            // txtreceivemsg
            // 
            this.txtreceivemsg.Location = new System.Drawing.Point(302, 43);
            this.txtreceivemsg.Name = "txtreceivemsg";
            this.txtreceivemsg.Size = new System.Drawing.Size(267, 425);
            this.txtreceivemsg.TabIndex = 1;
            this.txtreceivemsg.Text = "";
            // 
            // btnsend
            // 
            this.btnsend.Location = new System.Drawing.Point(12, 59);
            this.btnsend.Name = "btnsend";
            this.btnsend.Size = new System.Drawing.Size(116, 23);
            this.btnsend.TabIndex = 2;
            this.btnsend.Text = "发送数据";
            this.btnsend.UseVisualStyleBackColor = true;
            this.btnsend.Click += new System.EventHandler(this.btnsend_Click);
            // 
            // btnallquenes
            // 
            this.btnallquenes.Location = new System.Drawing.Point(12, 264);
            this.btnallquenes.Name = "btnallquenes";
            this.btnallquenes.Size = new System.Drawing.Size(116, 23);
            this.btnallquenes.TabIndex = 2;
            this.btnallquenes.Text = "获取所有队列";
            this.btnallquenes.UseVisualStyleBackColor = true;
            this.btnallquenes.Click += new System.EventHandler(this.btnallquenes_Click);
            // 
            // btndirect
            // 
            this.btndirect.Location = new System.Drawing.Point(12, 99);
            this.btndirect.Name = "btndirect";
            this.btndirect.Size = new System.Drawing.Size(116, 23);
            this.btndirect.TabIndex = 2;
            this.btndirect.Text = "发送数据Direct";
            this.btndirect.UseVisualStyleBackColor = true;
            this.btndirect.Click += new System.EventHandler(this.btndirect_Click);
            // 
            // btnfanout
            // 
            this.btnfanout.Location = new System.Drawing.Point(12, 137);
            this.btnfanout.Name = "btnfanout";
            this.btnfanout.Size = new System.Drawing.Size(116, 23);
            this.btnfanout.TabIndex = 2;
            this.btnfanout.Text = "发送数据Fanout";
            this.btnfanout.UseVisualStyleBackColor = true;
            this.btnfanout.Click += new System.EventHandler(this.btnfanout_Click);
            // 
            // btnheaders
            // 
            this.btnheaders.Location = new System.Drawing.Point(12, 177);
            this.btnheaders.Name = "btnheaders";
            this.btnheaders.Size = new System.Drawing.Size(116, 23);
            this.btnheaders.TabIndex = 2;
            this.btnheaders.Text = "发送数据Headers";
            this.btnheaders.UseVisualStyleBackColor = true;
            this.btnheaders.Click += new System.EventHandler(this.btnheaders_Click);
            // 
            // btntopic
            // 
            this.btntopic.Location = new System.Drawing.Point(12, 220);
            this.btntopic.Name = "btntopic";
            this.btntopic.Size = new System.Drawing.Size(116, 23);
            this.btntopic.TabIndex = 2;
            this.btntopic.Text = "发送数据Topic";
            this.btntopic.UseVisualStyleBackColor = true;
            this.btntopic.Click += new System.EventHandler(this.btntopic_Click);
            // 
            // btnrpc
            // 
            this.btnrpc.Location = new System.Drawing.Point(12, 308);
            this.btnrpc.Name = "btnrpc";
            this.btnrpc.Size = new System.Drawing.Size(116, 23);
            this.btnrpc.TabIndex = 2;
            this.btnrpc.Text = "发送Rpc消息";
            this.btnrpc.UseVisualStyleBackColor = true;
            this.btnrpc.Click += new System.EventHandler(this.btnrpc_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 345);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "接收rpc回复";
            // 
            // txtreplay
            // 
            this.txtreplay.Location = new System.Drawing.Point(13, 360);
            this.txtreplay.Name = "txtreplay";
            this.txtreplay.Size = new System.Drawing.Size(249, 108);
            this.txtreplay.TabIndex = 4;
            this.txtreplay.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 480);
            this.Controls.Add(this.txtreplay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnallquenes);
            this.Controls.Add(this.btntopic);
            this.Controls.Add(this.btnheaders);
            this.Controls.Add(this.btnfanout);
            this.Controls.Add(this.btndirect);
            this.Controls.Add(this.btnrpc);
            this.Controls.Add(this.btnsend);
            this.Controls.Add(this.txtreceivemsg);
            this.Controls.Add(this.txtSendMsg);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSendMsg;
        private System.Windows.Forms.RichTextBox txtreceivemsg;
        private System.Windows.Forms.Button btnsend;
        private System.Windows.Forms.Button btnallquenes;
        private System.Windows.Forms.Button btndirect;
        private System.Windows.Forms.Button btnfanout;
        private System.Windows.Forms.Button btnheaders;
        private System.Windows.Forms.Button btntopic;
        private System.Windows.Forms.Button btnrpc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtreplay;
    }
}

