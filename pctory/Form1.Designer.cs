﻿namespace pctory
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.파일ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveLogFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveAsLogFile = new System.Windows.Forms.ToolStripMenuItem();
            this.통계ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.주간그래프ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.월간그래프ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.월간그래프ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.창WToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.로그뷰어VToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.도구TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTracerRun = new System.Windows.Forms.ToolStripMenuItem();
            this.현재통계보기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.설정OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.noti = new System.Windows.Forms.NotifyIcon(this.components);
            this.notiContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.열기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.notiContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일ToolStripMenuItem,
            this.통계ToolStripMenuItem,
            this.창WToolStripMenuItem,
            this.도구TToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(4, 40);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(849, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 파일ToolStripMenuItem
            // 
            this.파일ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSaveLogFile,
            this.tsmiSaveAsLogFile});
            this.파일ToolStripMenuItem.Name = "파일ToolStripMenuItem";
            this.파일ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.파일ToolStripMenuItem.Text = "파일";
            // 
            // tsmiSaveLogFile
            // 
            this.tsmiSaveLogFile.Name = "tsmiSaveLogFile";
            this.tsmiSaveLogFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmiSaveLogFile.ShowShortcutKeys = false;
            this.tsmiSaveLogFile.Size = new System.Drawing.Size(178, 22);
            this.tsmiSaveLogFile.Text = "저장(&S)";
            this.tsmiSaveLogFile.Click += new System.EventHandler(this.tsmiSaveLogFile_Click);
            // 
            // tsmiSaveAsLogFile
            // 
            this.tsmiSaveAsLogFile.Name = "tsmiSaveAsLogFile";
            this.tsmiSaveAsLogFile.Size = new System.Drawing.Size(178, 22);
            this.tsmiSaveAsLogFile.Text = "다른 이름으로 저장";
            this.tsmiSaveAsLogFile.Click += new System.EventHandler(this.tsmiSaveAsLogFile_Click);
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
            this.주간그래프ToolStripMenuItem.Click += new System.EventHandler(this.통계ToolStripMenuItem_Click);
            // 
            // 월간그래프ToolStripMenuItem
            // 
            this.월간그래프ToolStripMenuItem.Name = "월간그래프ToolStripMenuItem";
            this.월간그래프ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.월간그래프ToolStripMenuItem.Text = "주간그래프";
            this.월간그래프ToolStripMenuItem.Click += new System.EventHandler(this.통계ToolStripMenuItem_Click);
            // 
            // 월간그래프ToolStripMenuItem1
            // 
            this.월간그래프ToolStripMenuItem1.Name = "월간그래프ToolStripMenuItem1";
            this.월간그래프ToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.월간그래프ToolStripMenuItem1.Text = "월간그래프";
            this.월간그래프ToolStripMenuItem1.Click += new System.EventHandler(this.통계ToolStripMenuItem_Click);
            // 
            // 창WToolStripMenuItem
            // 
            this.창WToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.로그뷰어VToolStripMenuItem});
            this.창WToolStripMenuItem.Name = "창WToolStripMenuItem";
            this.창WToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.창WToolStripMenuItem.Text = "창(&W)";
            // 
            // 로그뷰어VToolStripMenuItem
            // 
            this.로그뷰어VToolStripMenuItem.Name = "로그뷰어VToolStripMenuItem";
            this.로그뷰어VToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.로그뷰어VToolStripMenuItem.Text = "로그 뷰어(&V)";
            this.로그뷰어VToolStripMenuItem.Click += new System.EventHandler(this.로그뷰어VToolStripMenuItem_Click);
            // 
            // 도구TToolStripMenuItem
            // 
            this.도구TToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTracerRun,
            this.현재통계보기ToolStripMenuItem,
            this.toolStripSeparator2,
            this.설정OToolStripMenuItem});
            this.도구TToolStripMenuItem.Name = "도구TToolStripMenuItem";
            this.도구TToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.도구TToolStripMenuItem.Text = "도구(T&)";
            // 
            // tsmiTracerRun
            // 
            this.tsmiTracerRun.Name = "tsmiTracerRun";
            this.tsmiTracerRun.Size = new System.Drawing.Size(180, 22);
            this.tsmiTracerRun.Text = "트레이서 일시중지";
            this.tsmiTracerRun.Click += new System.EventHandler(this.tsmiTracerRun_Click);
            // 
            // 현재통계보기ToolStripMenuItem
            // 
            this.현재통계보기ToolStripMenuItem.Name = "현재통계보기ToolStripMenuItem";
            this.현재통계보기ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.현재통계보기ToolStripMenuItem.Text = "현재 통계 보기";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // 설정OToolStripMenuItem
            // 
            this.설정OToolStripMenuItem.Name = "설정OToolStripMenuItem";
            this.설정OToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.설정OToolStripMenuItem.Text = "설정(&O)";
            this.설정OToolStripMenuItem.Click += new System.EventHandler(this.설정OToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(95, 6);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(4, 64);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(849, 509);
            this.dataGridView1.TabIndex = 1;
            // 
            // noti
            // 
            this.noti.ContextMenuStrip = this.notiContextMenu;
            this.noti.Icon = ((System.Drawing.Icon)(resources.GetObject("noti.Icon")));
            this.noti.Text = "PCTORY";
            this.noti.Visible = true;
            this.noti.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.noti_MouseDoubleClick);
            // 
            // notiContextMenu
            // 
            this.notiContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.notiContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.열기ToolStripMenuItem,
            this.toolStripSeparator1,
            this.종료ToolStripMenuItem});
            this.notiContextMenu.Name = "notiContextMenu";
            this.notiContextMenu.Size = new System.Drawing.Size(99, 54);
            // 
            // 열기ToolStripMenuItem
            // 
            this.열기ToolStripMenuItem.Name = "열기ToolStripMenuItem";
            this.열기ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.열기ToolStripMenuItem.Text = "열기";
            this.열기ToolStripMenuItem.Click += new System.EventHandler(this.열기ToolStripMenuItem_Click);
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.종료ToolStripMenuItem.Text = "종료";
            this.종료ToolStripMenuItem.Click += new System.EventHandler(this.종료ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 577);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "PCTORY";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.notiContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem 도구TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 설정OToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiTracerRun;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 파일ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveLogFile;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveAsLogFile;
        private System.Windows.Forms.NotifyIcon noti;
        private System.Windows.Forms.ContextMenuStrip notiContextMenu;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 열기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 통계ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 주간그래프ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 월간그래프ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 월간그래프ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 현재통계보기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 창WToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 로그뷰어VToolStripMenuItem;
    }
}