namespace Intelligent_robot_patrol
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tableMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableRight = new System.Windows.Forms.TableLayoutPanel();
            this.gBoxMap = new System.Windows.Forms.GroupBox();
            this.cBoxMap = new System.Windows.Forms.ComboBox();
            this.gBoxRobot = new System.Windows.Forms.GroupBox();
            this.cBoxRobot = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.gBoxRoute = new System.Windows.Forms.GroupBox();
            this.cBoxRoute = new System.Windows.Forms.ComboBox();
            this.tableLeft = new System.Windows.Forms.TableLayoutPanel();
            this.tBoxDetail = new System.Windows.Forms.TextBox();
            this.panelRoute = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.PanelChrome = new System.Windows.Forms.Panel();
            this.panelBtn = new System.Windows.Forms.Panel();
            this.btnControl = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.gBoxInfo = new System.Windows.Forms.GroupBox();
            this.lbName = new System.Windows.Forms.Label();
            this.lbId = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableMain.SuspendLayout();
            this.tableRight.SuspendLayout();
            this.gBoxMap.SuspendLayout();
            this.gBoxRobot.SuspendLayout();
            this.gBoxRoute.SuspendLayout();
            this.tableLeft.SuspendLayout();
            this.panelRoute.SuspendLayout();
            this.panelBtn.SuspendLayout();
            this.gBoxInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableMain
            // 
            this.tableMain.ColumnCount = 2;
            this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.635F));
            this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.36499F));
            this.tableMain.Controls.Add(this.tableRight, 1, 1);
            this.tableMain.Controls.Add(this.tableLeft, 0, 1);
            this.tableMain.Controls.Add(this.panelBtn, 0, 0);
            this.tableMain.Controls.Add(this.gBoxInfo, 1, 0);
            this.tableMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableMain.Location = new System.Drawing.Point(0, 0);
            this.tableMain.Name = "tableMain";
            this.tableMain.RowCount = 2;
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.88889F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.11111F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableMain.Size = new System.Drawing.Size(1098, 777);
            this.tableMain.TabIndex = 0;
            // 
            // tableRight
            // 
            this.tableRight.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tableRight.ColumnCount = 1;
            this.tableRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableRight.Controls.Add(this.gBoxMap, 0, 2);
            this.tableRight.Controls.Add(this.gBoxRobot, 0, 1);
            this.tableRight.Controls.Add(this.btnStart, 0, 0);
            this.tableRight.Controls.Add(this.btnContinue, 0, 4);
            this.tableRight.Controls.Add(this.label2, 0, 5);
            this.tableRight.Controls.Add(this.gBoxRoute, 0, 3);
            this.tableRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableRight.Location = new System.Drawing.Point(723, 149);
            this.tableRight.Name = "tableRight";
            this.tableRight.RowCount = 6;
            this.tableRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableRight.Size = new System.Drawing.Size(372, 625);
            this.tableRight.TabIndex = 1;
            // 
            // gBoxMap
            // 
            this.gBoxMap.Controls.Add(this.cBoxMap);
            this.gBoxMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBoxMap.Location = new System.Drawing.Point(3, 153);
            this.gBoxMap.Name = "gBoxMap";
            this.gBoxMap.Size = new System.Drawing.Size(366, 69);
            this.gBoxMap.TabIndex = 5;
            this.gBoxMap.TabStop = false;
            this.gBoxMap.Text = "地图";
            // 
            // cBoxMap
            // 
            this.cBoxMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cBoxMap.FormattingEnabled = true;
            this.cBoxMap.Location = new System.Drawing.Point(3, 21);
            this.cBoxMap.Name = "cBoxMap";
            this.cBoxMap.Size = new System.Drawing.Size(360, 23);
            this.cBoxMap.TabIndex = 0;
            this.cBoxMap.SelectedIndexChanged += new System.EventHandler(this.cBoxMap_SelectedIndexChanged);
            // 
            // gBoxRobot
            // 
            this.gBoxRobot.Controls.Add(this.cBoxRobot);
            this.gBoxRobot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBoxRobot.Location = new System.Drawing.Point(3, 78);
            this.gBoxRobot.Name = "gBoxRobot";
            this.gBoxRobot.Size = new System.Drawing.Size(366, 69);
            this.gBoxRobot.TabIndex = 6;
            this.gBoxRobot.TabStop = false;
            this.gBoxRobot.Text = "机器人";
            // 
            // cBoxRobot
            // 
            this.cBoxRobot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cBoxRobot.FormattingEnabled = true;
            this.cBoxRobot.Location = new System.Drawing.Point(3, 21);
            this.cBoxRobot.Name = "cBoxRobot";
            this.cBoxRobot.Size = new System.Drawing.Size(360, 23);
            this.cBoxRobot.TabIndex = 0;
            this.cBoxRobot.SelectedIndexChanged += new System.EventHandler(this.cBoxRobot_SelectedIndexChanged);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnStart.Location = new System.Drawing.Point(121, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(129, 69);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnContinue.Enabled = false;
            this.btnContinue.Location = new System.Drawing.Point(115, 303);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(142, 69);
            this.btnContinue.TabIndex = 8;
            this.btnContinue.Text = "暂停";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 375);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "最后一此识别图";
            // 
            // gBoxRoute
            // 
            this.gBoxRoute.Controls.Add(this.cBoxRoute);
            this.gBoxRoute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBoxRoute.Location = new System.Drawing.Point(3, 228);
            this.gBoxRoute.Name = "gBoxRoute";
            this.gBoxRoute.Size = new System.Drawing.Size(366, 69);
            this.gBoxRoute.TabIndex = 9;
            this.gBoxRoute.TabStop = false;
            this.gBoxRoute.Text = "路线";
            // 
            // cBoxRoute
            // 
            this.cBoxRoute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cBoxRoute.FormattingEnabled = true;
            this.cBoxRoute.Location = new System.Drawing.Point(3, 21);
            this.cBoxRoute.Name = "cBoxRoute";
            this.cBoxRoute.Size = new System.Drawing.Size(360, 23);
            this.cBoxRoute.TabIndex = 0;
            this.cBoxRoute.SelectedIndexChanged += new System.EventHandler(this.cBoxRoute_SelectedIndexChanged);
            // 
            // tableLeft
            // 
            this.tableLeft.ColumnCount = 1;
            this.tableLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLeft.Controls.Add(this.tBoxDetail, 0, 2);
            this.tableLeft.Controls.Add(this.panelRoute, 0, 1);
            this.tableLeft.Controls.Add(this.PanelChrome, 0, 0);
            this.tableLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLeft.Location = new System.Drawing.Point(3, 149);
            this.tableLeft.Name = "tableLeft";
            this.tableLeft.RowCount = 3;
            this.tableLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLeft.Size = new System.Drawing.Size(714, 625);
            this.tableLeft.TabIndex = 2;
            // 
            // tBoxDetail
            // 
            this.tBoxDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tBoxDetail.Location = new System.Drawing.Point(3, 471);
            this.tBoxDetail.Multiline = true;
            this.tBoxDetail.Name = "tBoxDetail";
            this.tBoxDetail.Size = new System.Drawing.Size(708, 151);
            this.tBoxDetail.TabIndex = 3;
            this.tBoxDetail.Text = "输出机器人导航，作业事件，tableLayout只能存放一个组件，可以在上添加容器，容器内多组件";
            // 
            // panelRoute
            // 
            this.panelRoute.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelRoute.Controls.Add(this.label8);
            this.panelRoute.Controls.Add(this.label7);
            this.panelRoute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRoute.Location = new System.Drawing.Point(3, 378);
            this.panelRoute.Name = "panelRoute";
            this.panelRoute.Size = new System.Drawing.Size(708, 87);
            this.panelRoute.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(397, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 15);
            this.label8.TabIndex = 1;
            this.label8.Text = "坐标点";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "进行点";
            // 
            // PanelChrome
            // 
            this.PanelChrome.Location = new System.Drawing.Point(3, 3);
            this.PanelChrome.Name = "PanelChrome";
            this.PanelChrome.Size = new System.Drawing.Size(708, 369);
            this.PanelChrome.TabIndex = 5;
            // 
            // panelBtn
            // 
            this.panelBtn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelBtn.Controls.Add(this.btnControl);
            this.panelBtn.Controls.Add(this.button3);
            this.panelBtn.Controls.Add(this.button2);
            this.panelBtn.Controls.Add(this.button1);
            this.panelBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBtn.Location = new System.Drawing.Point(3, 3);
            this.panelBtn.Name = "panelBtn";
            this.panelBtn.Size = new System.Drawing.Size(714, 140);
            this.panelBtn.TabIndex = 5;
            // 
            // btnControl
            // 
            this.btnControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnControl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnControl.Image = ((System.Drawing.Image)(resources.GetObject("btnControl.Image")));
            this.btnControl.Location = new System.Drawing.Point(397, 3);
            this.btnControl.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.btnControl.Name = "btnControl";
            this.btnControl.Size = new System.Drawing.Size(93, 133);
            this.btnControl.TabIndex = 3;
            this.btnControl.UseVisualStyleBackColor = true;
            this.btnControl.Click += new System.EventHandler(this.btnControl_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(267, 3);
            this.button3.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(101, 133);
            this.button3.TabIndex = 2;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(137, 3);
            this.button2.Margin = new System.Windows.Forms.Padding(100, 3, 100, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 133);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(6, 3);
            this.button1.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 133);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // gBoxInfo
            // 
            this.gBoxInfo.Controls.Add(this.lbName);
            this.gBoxInfo.Controls.Add(this.lbId);
            this.gBoxInfo.Controls.Add(this.label3);
            this.gBoxInfo.Controls.Add(this.label1);
            this.gBoxInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBoxInfo.Location = new System.Drawing.Point(723, 3);
            this.gBoxInfo.Name = "gBoxInfo";
            this.gBoxInfo.Size = new System.Drawing.Size(372, 140);
            this.gBoxInfo.TabIndex = 6;
            this.gBoxInfo.TabStop = false;
            this.gBoxInfo.Text = "巡检员信息";
            // 
            // lbName
            // 
            this.lbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbName.Location = new System.Drawing.Point(84, 60);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(39, 20);
            this.lbName.TabIndex = 4;
            this.lbName.Text = "zfd";
            // 
            // lbId
            // 
            this.lbId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbId.AutoSize = true;
            this.lbId.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbId.Location = new System.Drawing.Point(84, 23);
            this.lbId.Name = "lbId";
            this.lbId.Size = new System.Drawing.Size(19, 20);
            this.lbId.TabIndex = 3;
            this.lbId.Text = "1";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(17, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "姓名：";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(37, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID：";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 777);
            this.Controls.Add(this.tableMain);
            this.MinimumSize = new System.Drawing.Size(1116, 824);
            this.Name = "FormMain";
            this.Text = "主界面";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.formMain_Load);
            this.tableMain.ResumeLayout(false);
            this.tableRight.ResumeLayout(false);
            this.tableRight.PerformLayout();
            this.gBoxMap.ResumeLayout(false);
            this.gBoxRobot.ResumeLayout(false);
            this.gBoxRoute.ResumeLayout(false);
            this.tableLeft.ResumeLayout(false);
            this.tableLeft.PerformLayout();
            this.panelRoute.ResumeLayout(false);
            this.panelRoute.PerformLayout();
            this.panelBtn.ResumeLayout(false);
            this.gBoxInfo.ResumeLayout(false);
            this.gBoxInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableMain;
        private System.Windows.Forms.TableLayoutPanel tableLeft;
        private System.Windows.Forms.TableLayoutPanel tableRight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tBoxDetail;
        private System.Windows.Forms.Panel panelRoute;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panelBtn;
        private System.Windows.Forms.Button btnControl;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox gBoxMap;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cBoxMap;
        private System.Windows.Forms.GroupBox gBoxRobot;
        private System.Windows.Forms.ComboBox cBoxRobot;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.GroupBox gBoxRoute;
        private System.Windows.Forms.ComboBox cBoxRoute;
        private System.Windows.Forms.GroupBox gBoxInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbId;
        private System.Windows.Forms.Panel PanelChrome;
    }
}

