﻿namespace 服务端
{
    partial class formRec_zfd
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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tBoxProType = new System.Windows.Forms.TextBox();
            this.tBoxQrPos = new System.Windows.Forms.TextBox();
            this.openBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tBoxImgPath = new System.Windows.Forms.TextBox();
            this.closeBtn = new System.Windows.Forms.Button();
            this.btnImgPth = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "收到的图片：";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(24, 68);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(569, 471);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(599, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "项目类型ID：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(605, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "二维码位置：";
            // 
            // tBoxProType
            // 
            this.tBoxProType.Location = new System.Drawing.Point(690, 123);
            this.tBoxProType.Name = "tBoxProType";
            this.tBoxProType.Size = new System.Drawing.Size(100, 25);
            this.tBoxProType.TabIndex = 5;
            // 
            // tBoxQrPos
            // 
            this.tBoxQrPos.Location = new System.Drawing.Point(693, 198);
            this.tBoxQrPos.Name = "tBoxQrPos";
            this.tBoxQrPos.Size = new System.Drawing.Size(180, 25);
            this.tBoxQrPos.TabIndex = 6;
            // 
            // openBtn
            // 
            this.openBtn.Location = new System.Drawing.Point(654, 279);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(114, 33);
            this.openBtn.TabIndex = 7;
            this.openBtn.Text = "打开Server";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(690, 406);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "保存";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tBoxImgPath
            // 
            this.tBoxImgPath.Location = new System.Drawing.Point(143, 28);
            this.tBoxImgPath.Name = "tBoxImgPath";
            this.tBoxImgPath.Size = new System.Drawing.Size(413, 25);
            this.tBoxImgPath.TabIndex = 9;
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(654, 337);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(114, 33);
            this.closeBtn.TabIndex = 10;
            this.closeBtn.Text = "关闭Server";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // btnImgPth
            // 
            this.btnImgPth.Location = new System.Drawing.Point(632, 29);
            this.btnImgPth.Name = "btnImgPth";
            this.btnImgPth.Size = new System.Drawing.Size(111, 41);
            this.btnImgPth.TabIndex = 11;
            this.btnImgPth.Text = "图片路径";
            this.btnImgPth.UseVisualStyleBackColor = true;
            this.btnImgPth.Click += new System.EventHandler(this.btnImgPth_Click);
            // 
            // formRec_zfd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 565);
            this.Controls.Add(this.btnImgPth);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.tBoxImgPath);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.openBtn);
            this.Controls.Add(this.tBoxQrPos);
            this.Controls.Add(this.tBoxProType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "formRec_zfd";
            this.Text = "项目识别";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.newRecon_zfd_FormClosing);
            this.Load += new System.EventHandler(this.newRecon_zfd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tBoxProType;
        private System.Windows.Forms.TextBox tBoxQrPos;
        private System.Windows.Forms.Button openBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tBoxImgPath;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button btnImgPth;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}