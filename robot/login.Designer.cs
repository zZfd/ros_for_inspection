namespace Intelligent_robot_patrol
{
    partial class FormLogin
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
            this.btnLogin = new System.Windows.Forms.Button();
            this.tBoxAccount = new System.Windows.Forms.TextBox();
            this.tBoxpassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(221, 224);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(116, 38);
            this.btnLogin.TabIndex = 13;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // tBoxAccount
            // 
            this.tBoxAccount.Location = new System.Drawing.Point(167, 111);
            this.tBoxAccount.Margin = new System.Windows.Forms.Padding(4);
            this.tBoxAccount.Name = "tBoxAccount";
            this.tBoxAccount.Size = new System.Drawing.Size(304, 25);
            this.tBoxAccount.TabIndex = 10;
            this.tBoxAccount.Text = "zfd";
            // 
            // tBoxpassword
            // 
            this.tBoxpassword.Location = new System.Drawing.Point(167, 168);
            this.tBoxpassword.Margin = new System.Windows.Forms.Padding(4);
            this.tBoxpassword.Name = "tBoxpassword";
            this.tBoxpassword.PasswordChar = '*';
            this.tBoxpassword.Size = new System.Drawing.Size(304, 25);
            this.tBoxpassword.TabIndex = 12;
            this.tBoxpassword.Text = "123";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 172);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "密码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 115);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "账号：";
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 366);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.tBoxAccount);
            this.Controls.Add(this.tBoxpassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormLogin";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.Load += new System.EventHandler(this.formLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox tBoxAccount;
        private System.Windows.Forms.TextBox tBoxpassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}