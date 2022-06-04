namespace pctory
{
    partial class fViewer
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("노드0");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("노드1");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("노드2");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("노드3");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("노드4");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("노드5");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("노드6");
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblstatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.파일FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.열기OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.체크된항목삭제ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.선택된항목삭제ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.보기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiViewHorizental = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiViewVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAnalysisSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAnalysisChecked = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.trvFile = new System.Windows.Forms.TreeView();
            this.cms4trvFile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.전체선택ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.선택해제ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.선택한항목삭제ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.선택된항목삭제ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.cms4trvFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(762, 251);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblstatus});
            this.statusStrip1.Location = new System.Drawing.Point(4, 595);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(958, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "상태 창";
            // 
            // lblstatus
            // 
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(191, 17);
            this.lblstatus.Text = "                                              ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일FToolStripMenuItem,
            this.보기ToolStripMenuItem,
            this.toolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(4, 40);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(958, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 파일FToolStripMenuItem
            // 
            this.파일FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.열기OToolStripMenuItem,
            this.toolStripSeparator1,
            this.체크된항목삭제ToolStripMenuItem,
            this.선택된항목삭제ToolStripMenuItem1});
            this.파일FToolStripMenuItem.Name = "파일FToolStripMenuItem";
            this.파일FToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.파일FToolStripMenuItem.Text = "파일(&F)";
            // 
            // 열기OToolStripMenuItem
            // 
            this.열기OToolStripMenuItem.Name = "열기OToolStripMenuItem";
            this.열기OToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.열기OToolStripMenuItem.Text = "추가(&A)";
            this.열기OToolStripMenuItem.Click += new System.EventHandler(this.열기OToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // 체크된항목삭제ToolStripMenuItem
            // 
            this.체크된항목삭제ToolStripMenuItem.Name = "체크된항목삭제ToolStripMenuItem";
            this.체크된항목삭제ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.체크된항목삭제ToolStripMenuItem.Text = "체크된 항목 삭제";
            this.체크된항목삭제ToolStripMenuItem.Click += new System.EventHandler(this.체크한항목삭제ToolStripMenuItem_Click);
            // 
            // 선택된항목삭제ToolStripMenuItem1
            // 
            this.선택된항목삭제ToolStripMenuItem1.Name = "선택된항목삭제ToolStripMenuItem1";
            this.선택된항목삭제ToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.선택된항목삭제ToolStripMenuItem1.Text = "선택된 항목 삭제";
            this.선택된항목삭제ToolStripMenuItem1.Click += new System.EventHandler(this.선택된항목삭제ToolStripMenuItem_Click);
            // 
            // 보기ToolStripMenuItem
            // 
            this.보기ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiViewHorizental,
            this.tsmiViewVertical});
            this.보기ToolStripMenuItem.Name = "보기ToolStripMenuItem";
            this.보기ToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.보기ToolStripMenuItem.Text = "보기(&V)";
            // 
            // tsmiViewHorizental
            // 
            this.tsmiViewHorizental.Name = "tsmiViewHorizental";
            this.tsmiViewHorizental.Size = new System.Drawing.Size(122, 22);
            this.tsmiViewHorizental.Tag = "0";
            this.tsmiViewHorizental.Text = "가로보기";
            this.tsmiViewHorizental.Click += new System.EventHandler(this.ViewTypeChange);
            // 
            // tsmiViewVertical
            // 
            this.tsmiViewVertical.Name = "tsmiViewVertical";
            this.tsmiViewVertical.Size = new System.Drawing.Size(122, 22);
            this.tsmiViewVertical.Text = "세로보기";
            this.tsmiViewVertical.Click += new System.EventHandler(this.ViewTypeChange);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAnalysisSelected,
            this.tsmiAnalysisChecked});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(43, 20);
            this.toolStripMenuItem2.Text = "통계";
            // 
            // tsmiAnalysisSelected
            // 
            this.tsmiAnalysisSelected.Name = "tsmiAnalysisSelected";
            this.tsmiAnalysisSelected.Size = new System.Drawing.Size(166, 22);
            this.tsmiAnalysisSelected.Text = "선택한 항목 통계";
            this.tsmiAnalysisSelected.Click += new System.EventHandler(this.tsmiAnalysisSelected_Click);
            // 
            // tsmiAnalysisChecked
            // 
            this.tsmiAnalysisChecked.Name = "tsmiAnalysisChecked";
            this.tsmiAnalysisChecked.Size = new System.Drawing.Size(166, 22);
            this.tsmiAnalysisChecked.Text = "체크된 항목 통계";
            this.tsmiAnalysisChecked.Click += new System.EventHandler(this.tsmiAnalysisChecked_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView2);
            this.splitContainer1.Size = new System.Drawing.Size(762, 531);
            this.splitContainer1.SplitterDistance = 251;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 6;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.ShowEditingIcon = false;
            this.dataGridView2.Size = new System.Drawing.Size(762, 275);
            this.dataGridView2.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(4, 64);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.trvFile);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(958, 531);
            this.splitContainer2.SplitterDistance = 192;
            this.splitContainer2.TabIndex = 7;
            // 
            // trvFile
            // 
            this.trvFile.CheckBoxes = true;
            this.trvFile.ContextMenuStrip = this.cms4trvFile;
            this.trvFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvFile.Location = new System.Drawing.Point(0, 0);
            this.trvFile.Name = "trvFile";
            treeNode1.Name = "노드0";
            treeNode1.Text = "노드0";
            treeNode2.Name = "노드1";
            treeNode2.Text = "노드1";
            treeNode3.Name = "노드2";
            treeNode3.Text = "노드2";
            treeNode4.Name = "노드3";
            treeNode4.Text = "노드3";
            treeNode5.Name = "노드4";
            treeNode5.Text = "노드4";
            treeNode6.Name = "노드5";
            treeNode6.Text = "노드5";
            treeNode7.Name = "노드6";
            treeNode7.Text = "노드6";
            this.trvFile.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7});
            this.trvFile.Size = new System.Drawing.Size(192, 531);
            this.trvFile.TabIndex = 11;
            this.trvFile.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvFile_AfterSelect);
            // 
            // cms4trvFile
            // 
            this.cms4trvFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.전체선택ToolStripMenuItem,
            this.선택해제ToolStripMenuItem,
            this.toolStripSeparator2,
            this.선택한항목삭제ToolStripMenuItem,
            this.선택된항목삭제ToolStripMenuItem});
            this.cms4trvFile.Name = "cms4clstFile";
            this.cms4trvFile.Size = new System.Drawing.Size(167, 98);
            // 
            // 전체선택ToolStripMenuItem
            // 
            this.전체선택ToolStripMenuItem.Name = "전체선택ToolStripMenuItem";
            this.전체선택ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.전체선택ToolStripMenuItem.Text = "전체 선택";
            this.전체선택ToolStripMenuItem.Click += new System.EventHandler(this.전체선택ToolStripMenuItem_Click);
            // 
            // 선택해제ToolStripMenuItem
            // 
            this.선택해제ToolStripMenuItem.Name = "선택해제ToolStripMenuItem";
            this.선택해제ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.선택해제ToolStripMenuItem.Text = "선택 해제";
            this.선택해제ToolStripMenuItem.Click += new System.EventHandler(this.선택해제ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(163, 6);
            // 
            // 선택한항목삭제ToolStripMenuItem
            // 
            this.선택한항목삭제ToolStripMenuItem.Name = "선택한항목삭제ToolStripMenuItem";
            this.선택한항목삭제ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.선택한항목삭제ToolStripMenuItem.Text = "체크된 항목 삭제";
            this.선택한항목삭제ToolStripMenuItem.Click += new System.EventHandler(this.체크한항목삭제ToolStripMenuItem_Click);
            // 
            // 선택된항목삭제ToolStripMenuItem
            // 
            this.선택된항목삭제ToolStripMenuItem.Name = "선택된항목삭제ToolStripMenuItem";
            this.선택된항목삭제ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.선택된항목삭제ToolStripMenuItem.Text = "선택된 항목 삭제";
            this.선택된항목삭제ToolStripMenuItem.Click += new System.EventHandler(this.선택된항목삭제ToolStripMenuItem_Click);
            // 
            // fViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(966, 621);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "fViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.Text = "Log View";
            this.Load += new System.EventHandler(this.fViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.cms4trvFile.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblstatus;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ToolStripMenuItem 보기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewHorizental;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewVertical;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStripMenuItem 파일FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 열기OToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cms4trvFile;
        private System.Windows.Forms.ToolStripMenuItem 전체선택ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 선택한항목삭제ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tsmiAnalysisSelected;
        private System.Windows.Forms.TreeView trvFile;
        private System.Windows.Forms.ToolStripMenuItem 선택해제ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 선택된항목삭제ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 체크된항목삭제ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 선택된항목삭제ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiAnalysisChecked;
    }
}
