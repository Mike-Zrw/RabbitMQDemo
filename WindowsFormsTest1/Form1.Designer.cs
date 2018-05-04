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
            this.btnreceive = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSendMsg
            // 
            this.txtSendMsg.Location = new System.Drawing.Point(46, 52);
            this.txtSendMsg.Name = "txtSendMsg";
            this.txtSendMsg.Size = new System.Drawing.Size(166, 21);
            this.txtSendMsg.TabIndex = 0;
            // 
            // txtreceivemsg
            // 
            this.txtreceivemsg.Location = new System.Drawing.Point(429, 52);
            this.txtreceivemsg.Name = "txtreceivemsg";
            this.txtreceivemsg.Size = new System.Drawing.Size(267, 230);
            this.txtreceivemsg.TabIndex = 1;
            this.txtreceivemsg.Text = "";
            // 
            // btnsend
            // 
            this.btnsend.Location = new System.Drawing.Point(46, 23);
            this.btnsend.Name = "btnsend";
            this.btnsend.Size = new System.Drawing.Size(75, 23);
            this.btnsend.TabIndex = 2;
            this.btnsend.Text = "发送数据";
            this.btnsend.UseVisualStyleBackColor = true;
            this.btnsend.Click += new System.EventHandler(this.btnsend_Click);
            // 
            // btnreceive
            // 
            this.btnreceive.Location = new System.Drawing.Point(429, 23);
            this.btnreceive.Name = "btnreceive";
            this.btnreceive.Size = new System.Drawing.Size(75, 23);
            this.btnreceive.TabIndex = 2;
            this.btnreceive.Text = "接收数据";
            this.btnreceive.UseVisualStyleBackColor = true;
            this.btnreceive.Click += new System.EventHandler(this.btnreceive_Click);
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(577, 22);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 23);
            this.btnclose.TabIndex = 3;
            this.btnclose.Text = "关闭接收";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 480);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnreceive);
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
        private System.Windows.Forms.Button btnreceive;
        private System.Windows.Forms.Button btnclose;
    }
}

