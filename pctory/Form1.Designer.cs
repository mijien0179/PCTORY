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
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.시작프로그램등록ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.시작프로그램해제ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.통계ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.주간그래프ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.월간그래프ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.월간그래프ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.시작ToolStripMenuItem,
            this.통계ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(1, 32);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(855, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 시작ToolStripMenuItem
            // 
            this.시작ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiStop,
            this.tsmiSave,
            this.시작프로그램등록ToolStripMenuItem,
            this.시작프로그램해제ToolStripMenuItem});
            this.시작ToolStripMenuItem.Name = "시작ToolStripMenuItem";
            this.시작ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.시작ToolStripMenuItem.Text = "설정";
            // 
            // tsmiStop
            // 
            this.tsmiStop.Name = "tsmiStop";
            this.tsmiStop.Size = new System.Drawing.Size(178, 22);
            this.tsmiStop.Text = "중지";
            this.tsmiStop.Click += new System.EventHandler(this.tsmiStop_Click);
            // 
            // tsmiSave
            // 
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.Size = new System.Drawing.Size(178, 22);
            this.tsmiSave.Text = "불러오기";
            // 
            // 시작프로그램등록ToolStripMenuItem
            // 
            this.시작프로그램등록ToolStripMenuItem.Name = "시작프로그램등록ToolStripMenuItem";
            this.시작프로그램등록ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.시작프로그램등록ToolStripMenuItem.Text = "시작 프로그램 등록";
            this.시작프로그램등록ToolStripMenuItem.Click += new System.EventHandler(this.시작프로그램등록ToolStripMenuItem_Click);
            // 
            // 시작프로그램해제ToolStripMenuItem
            // 
            this.시작프로그램해제ToolStripMenuItem.Name = "시작프로그램해제ToolStripMenuItem";
            this.시작프로그램해제ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.시작프로그램해제ToolStripMenuItem.Text = "시작 프로그램 해제";
            this.시작프로그램해제ToolStripMenuItem.Click += new System.EventHandler(this.시작프로그램해제ToolStripMenuItem_Click);
            // 
            // 통계ToolStripMenuItem
            // 
            this.통계ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.주간그래프ToolStripMenuItem,
            this.월간그래프ToolStripMenuItem,
            this.월간그래프ToolStripMenuItem1});
            this.통계ToolStripMenuItem.Name = "통계ToolStripMenuItem";
            this.통계ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.통계ToolStripMenuItem.Text = "통계";
            // 
            // 주간그래프ToolStripMenuItem
            // 
            this.주간그래프ToolStripMenuItem.Name = "주간그래프ToolStripMenuItem";
            this.주간그래프ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.주간그래프ToolStripMenuItem.Text = "일간그래프";
            // 
            // 월간그래프ToolStripMenuItem
            // 
            this.월간그래프ToolStripMenuItem.Name = "월간그래프ToolStripMenuItem";
            this.월간그래프ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.월간그래프ToolStripMenuItem.Text = "주간그래프";
            // 
            // 월간그래프ToolStripMenuItem1
            // 
            this.월간그래프ToolStripMenuItem1.Name = "월간그래프ToolStripMenuItem1";
            this.월간그래프ToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.월간그래프ToolStripMenuItem1.Text = "월간그래프";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(1, 56);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(855, 520);
            this.dataGridView1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 577);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(1, 32, 1, 1);
            this.Text = "PCTORY";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private System.Windows.Forms.ToolStripMenuItem 시작프로그램등록ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 시작프로그램해제ToolStripMenuItem;
    }
}