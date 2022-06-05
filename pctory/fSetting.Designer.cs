namespace pctory
{
    partial class fSetting
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlSaveLoc = new System.Windows.Forms.Panel();
            this.btnFindLogSaveLoc = new System.Windows.Forms.Button();
            this.tbxLogSaveLoc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkOverrideLogSaveLoc = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkStartup = new System.Windows.Forms.CheckBox();
            this.tt = new System.Windows.Forms.ToolTip(this.components);
            this.chkShellConnection = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.pnlSaveLoc.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnlSaveLoc);
            this.groupBox1.Controls.Add(this.chkOverrideLogSaveLoc);
            this.groupBox1.Location = new System.Drawing.Point(4, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(545, 189);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "파일";
            // 
            // pnlSaveLoc
            // 
            this.pnlSaveLoc.Controls.Add(this.btnFindLogSaveLoc);
            this.pnlSaveLoc.Controls.Add(this.tbxLogSaveLoc);
            this.pnlSaveLoc.Controls.Add(this.label1);
            this.pnlSaveLoc.Location = new System.Drawing.Point(6, 42);
            this.pnlSaveLoc.Name = "pnlSaveLoc";
            this.pnlSaveLoc.Size = new System.Drawing.Size(533, 77);
            this.pnlSaveLoc.TabIndex = 1;
            // 
            // btnFindLogSaveLoc
            // 
            this.btnFindLogSaveLoc.Location = new System.Drawing.Point(414, 42);
            this.btnFindLogSaveLoc.Name = "btnFindLogSaveLoc";
            this.btnFindLogSaveLoc.Size = new System.Drawing.Size(116, 32);
            this.btnFindLogSaveLoc.TabIndex = 2;
            this.btnFindLogSaveLoc.Text = "찾아보기";
            this.btnFindLogSaveLoc.UseVisualStyleBackColor = true;
            this.btnFindLogSaveLoc.Click += new System.EventHandler(this.btnFindLogSaveLoc_Click);
            // 
            // tbxLogSaveLoc
            // 
            this.tbxLogSaveLoc.BackColor = System.Drawing.Color.White;
            this.tbxLogSaveLoc.Location = new System.Drawing.Point(5, 15);
            this.tbxLogSaveLoc.Name = "tbxLogSaveLoc";
            this.tbxLogSaveLoc.ReadOnly = true;
            this.tbxLogSaveLoc.Size = new System.Drawing.Size(525, 21);
            this.tbxLogSaveLoc.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "저장 위치";
            // 
            // chkOverrideLogSaveLoc
            // 
            this.chkOverrideLogSaveLoc.AutoSize = true;
            this.chkOverrideLogSaveLoc.Location = new System.Drawing.Point(6, 20);
            this.chkOverrideLogSaveLoc.Name = "chkOverrideLogSaveLoc";
            this.chkOverrideLogSaveLoc.Size = new System.Drawing.Size(172, 16);
            this.chkOverrideLogSaveLoc.TabIndex = 0;
            this.chkOverrideLogSaveLoc.Text = "로그 저장 위치 덮어쓰기(?)";
            this.tt.SetToolTip(this.chkOverrideLogSaveLoc, "체크하면 로그 저장 위치가 아래 설정한 위치로 변경됩니다.\r\n체크를 해제하면 프로그램이 존재하는 위치로 설정됩니다.");
            this.chkOverrideLogSaveLoc.UseVisualStyleBackColor = true;
            this.chkOverrideLogSaveLoc.CheckedChanged += new System.EventHandler(this.chkOverrideLogSaveLoc_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkShellConnection);
            this.groupBox2.Controls.Add(this.chkStartup);
            this.groupBox2.Location = new System.Drawing.Point(4, 238);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(545, 156);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "프로그램";
            // 
            // chkStartup
            // 
            this.chkStartup.AutoSize = true;
            this.chkStartup.Location = new System.Drawing.Point(6, 20);
            this.chkStartup.Name = "chkStartup";
            this.chkStartup.Size = new System.Drawing.Size(128, 16);
            this.chkStartup.TabIndex = 0;
            this.chkStartup.Text = "시작 프로그램 등록";
            this.tt.SetToolTip(this.chkStartup, "Windows 작업 스케줄러에 등록됩니다.");
            this.chkStartup.UseVisualStyleBackColor = true;
            this.chkStartup.CheckedChanged += new System.EventHandler(this.chkStartup_CheckedChanged);
            // 
            // tt
            // 
            this.tt.AutoPopDelay = 7000;
            this.tt.InitialDelay = 500;
            this.tt.ReshowDelay = 100;
            this.tt.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // chkShellConnection
            // 
            this.chkShellConnection.AutoSize = true;
            this.chkShellConnection.Location = new System.Drawing.Point(6, 42);
            this.chkShellConnection.Name = "chkShellConnection";
            this.chkShellConnection.Size = new System.Drawing.Size(76, 16);
            this.chkShellConnection.TabIndex = 1;
            this.chkShellConnection.Text = "파일 연결";
            this.chkShellConnection.UseVisualStyleBackColor = true;
            this.chkShellConnection.CheckedChanged += new System.EventHandler(this.chkShellConnection_CheckedChanged);
            // 
            // fSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(553, 398);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fSetting";
            this.Text = "설정";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlSaveLoc.ResumeLayout(false);
            this.pnlSaveLoc.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkStartup;
        private System.Windows.Forms.CheckBox chkOverrideLogSaveLoc;
        private System.Windows.Forms.ToolTip tt;
        private System.Windows.Forms.Panel pnlSaveLoc;
        private System.Windows.Forms.Button btnFindLogSaveLoc;
        private System.Windows.Forms.TextBox tbxLogSaveLoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkShellConnection;
    }
}
