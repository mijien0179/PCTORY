namespace pctory
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.시작ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStop = new System.Windows.Forms.ToolStripMenuItem();
            this.통계ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.주간그래프ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.월간그래프ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.월간그래프ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.파일ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenLogFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveLogFile = new System.Windows.Forms.ToolStripMenuItem();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.tsmiSaveAsLogFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일ToolStripMenuItem,
            this.시작ToolStripMenuItem,
            this.통계ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(1, 40);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(977, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 시작ToolStripMenuItem
            // 
            this.시작ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiStop});
            this.시작ToolStripMenuItem.Name = "시작ToolStripMenuItem";
            this.시작ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.시작ToolStripMenuItem.Text = "설정";
            // 
            // tsmiStop
            // 
            this.tsmiStop.Name = "tsmiStop";
            this.tsmiStop.Size = new System.Drawing.Size(224, 26);
            this.tsmiStop.Text = "중지";
            this.tsmiStop.Click += new System.EventHandler(this.tsmiStop_Click);
            // 
            // 통계ToolStripMenuItem
            // 
            this.통계ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.주간그래프ToolStripMenuItem,
            this.월간그래프ToolStripMenuItem,
            this.월간그래프ToolStripMenuItem1});
            this.통계ToolStripMenuItem.Name = "통계ToolStripMenuItem";
            this.통계ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.통계ToolStripMenuItem.Text = "통계";
            // 
            // 주간그래프ToolStripMenuItem
            // 
            this.주간그래프ToolStripMenuItem.Name = "주간그래프ToolStripMenuItem";
            this.주간그래프ToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.주간그래프ToolStripMenuItem.Text = "일간그래프";
            // 
            // 월간그래프ToolStripMenuItem
            // 
            this.월간그래프ToolStripMenuItem.Name = "월간그래프ToolStripMenuItem";
            this.월간그래프ToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.월간그래프ToolStripMenuItem.Text = "주간그래프";
            // 
            // 월간그래프ToolStripMenuItem1
            // 
            this.월간그래프ToolStripMenuItem1.Name = "월간그래프ToolStripMenuItem1";
            this.월간그래프ToolStripMenuItem1.Size = new System.Drawing.Size(167, 26);
            this.월간그래프ToolStripMenuItem1.Text = "월간그래프";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(1, 68);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(977, 652);
            this.dataGridView1.TabIndex = 1;
            // 
            // 파일ToolStripMenuItem
            // 
            this.파일ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpenLogFile,
            this.tsmiSaveLogFile,
            this.tsmiSaveAsLogFile});
            this.파일ToolStripMenuItem.Name = "파일ToolStripMenuItem";
            this.파일ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.파일ToolStripMenuItem.Text = "파일";
            // 
            // tsmiOpenLogFile
            // 
            this.tsmiOpenLogFile.Name = "tsmiOpenLogFile";
            this.tsmiOpenLogFile.Size = new System.Drawing.Size(224, 26);
            this.tsmiOpenLogFile.Text = "열기(&O)";
            this.tsmiOpenLogFile.Click += new System.EventHandler(this.tsmiOpenLogFile_Click);
            // 
            // tsmiSaveLogFile
            // 
            this.tsmiSaveLogFile.Name = "tsmiSaveLogFile";
            this.tsmiSaveLogFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmiSaveLogFile.ShowShortcutKeys = false;
            this.tsmiSaveLogFile.Size = new System.Drawing.Size(224, 26);
            this.tsmiSaveLogFile.Text = "저장(&S)";
            this.tsmiSaveLogFile.Click += new System.EventHandler(this.tsmiSaveLogFile_Click);
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // tsmiSaveAsLogFile
            // 
            this.tsmiSaveAsLogFile.Name = "tsmiSaveAsLogFile";
            this.tsmiSaveAsLogFile.Size = new System.Drawing.Size(224, 26);
            this.tsmiSaveAsLogFile.Text = "다른 이름으로 저장";
            this.tsmiSaveAsLogFile.Click += new System.EventHandler(this.tsmiSaveAsLogFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 721);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "PCTORY";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 통계ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 주간그래프ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 월간그래프ToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem 월간그래프ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 시작ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiStop;
        private System.Windows.Forms.ToolStripMenuItem 파일ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenLogFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveLogFile;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveAsLogFile;
    }
}