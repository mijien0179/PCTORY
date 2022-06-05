using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Linq;
using System.Diagnostics;

namespace pctory
{
    public partial class fViewer : pctory.design.pctoryForm
    {
        ProcessInfoList inform;
        Dictionary<string, bool> checker = new Dictionary<string,bool>();
        public fViewer(string path)
        {
            InitializeComponent();

            viewInitializer.ProcInfoListDVGHeaderInitializer(dataGridView1);
            viewInitializer.PcbDVGHeaderInitializer(dataGridView2);

            tsmiViewHorizental.Tag = Orientation.Horizontal;
            tsmiViewVertical.Tag = Orientation.Vertical;

            trvFile.Nodes.Clear();

            ViewTypeChange(tsmiViewHorizental, new EventArgs());

        }

        private void fViewer_Load(object sender, EventArgs e)
        {
                dataGridView1.ClearSelection();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex > dataGridView1.Rows.Count) return;

            dataGridView2.Rows.Clear();
            dataGridView2.Rows.AddRange(viewInitializer.PCB2DVGRows(inform[dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()]));
            dataGridView2.ClearSelection();


        }

        private void ViewTypeChange(object sender, EventArgs e)
        {
            ToolStripMenuItem[] itemList =
            {
                tsmiViewHorizental,
                tsmiViewVertical
            };

            var target = sender as ToolStripMenuItem;

            foreach(var item in itemList) item.Checked = false;


            splitContainer1.Orientation = (Orientation)target.Tag;

            int size = 0;
            switch (splitContainer1.Orientation)
            {
                case Orientation.Horizontal:
                    size = splitContainer1.Height / 2;
                    break;
                case Orientation.Vertical:
                    size = splitContainer1.Width / 2;
                    break;
            }
            splitContainer1.SplitterDistance = size;

            target.Checked = true;

        }

        private void tsmiAnalysisSelected_Click(object sender, EventArgs e)
        {
            // TODO: 김명석
            // 일단 오류가 잡히지 않도록 "일일"로 퉁쳐놨는데,
            // 전달되는 특성이 뭔지 정확히 파악할 수 있게 enum 등으로 표현하면 좋을것 같습니다..
            if(trvFile.SelectedNode != null)
            {
                Graph grep = new Graph(inform, "일일");
                grep.Owner = this;
                grep.ShowDialog();
            }
            else
            {
                MessageBox.Show("왼쪽 트리에서 파일을 선택해주세요.", "안내",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsmiAnalysisChecked_Click(object sender, EventArgs e)
        {
            List<string> path = new List<string>();
            foreach(TreeNode node in trvFile.Nodes)
            {
                if(node.Checked == true)
                {
                    path.Add(node.Tag as string);
                }
            }

            if(path.Count > 1)
            {
                ProcessInfoList info = FileIO.FileInput(path[0]);
                for(int i = 1; i < path.Count;++i)
                {
                    info = ApiHelper.CombineProcessInfoList(info, FileIO.FileInput(path[i]));
                }

                Graph grep = new Graph(info, "일일");
                grep.Owner = this;
                grep.ShowDialog();

            }
            else
            {
                MessageBox.Show("하나 이상의 항목을 체크해주세요.", "안내",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void 체크한항목삭제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<TreeNode> nodes = new List<TreeNode>();
            foreach(TreeNode node in trvFile.Nodes)
            {
                if (node.Checked)
                    nodes.Add(node);
            }

            foreach(var nod in nodes)
            {
                RemoveNode(nod);
            }
        }

        private void 선택된항목삭제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trvFile.SelectedNode != null)
            {
                RemoveNode(trvFile.SelectedNode);
            }
        }

        private void RemoveNode(TreeNode node)
        {
            if (checker.ContainsKey(node.Tag as string))
                checker.Remove(node.Tag as string);
            trvFile.Nodes.Remove(node);
        }

        private void 전체선택ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(TreeNode node in trvFile.Nodes)
            {
                node.Checked = true;
            }
        }

        private void 선택해제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(TreeNode node in trvFile.Nodes)
            {
                node.Checked = false;
            }
        }

        private void 열기OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Multiselect = true,
                Title = "파일 추가하기",
                Filter = $"PCTORY(*.{LogFileInfo.Extension})|*.{LogFileInfo.Extension}|모든 파일(*.*)|*.*",
                FilterIndex =0
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                bool alert = false;
                foreach(string file in ofd.FileNames)
                {
                    if (!checker.ContainsKey(file) || !checker[file])
                    {
                        AddFilePath2List(file);
                    }
                    else if(!alert)
                    {
                        MessageBox.Show("이미 존재하는 항목은 제외됩니다.", "안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        alert = true;
                    }
                }
            }


        }

        public void AddFilePath2List(string path, bool select = false)
        {
            if (checker.ContainsKey(path) && checker[path]) return;

            TreeNode node = trvFile.Nodes.Add(path.Split('\\').Last());
            node.Tag = path;
            
            checker.Add(path, true);
            if (select) trvFile.SelectedNode = node;
        }

        private void trvFile_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                dataGridView2.Rows.Clear();

                string path = e.Node.Tag.ToString();
                inform = FileIO.FileInput(path);
                lblstatus.Text = path;

                dataGridView1.Rows.AddRange(viewInitializer.ProcInfoList2DVGRows(inform));

                dataGridView1.ClearSelection();
                dataGridView2.ClearSelection();
            }
            catch (System.Runtime.Serialization.SerializationException)
            {
                MessageBox.Show(
                    "올바르지 않은 파일 형식입니다.\r\n" +
                    "아마도 PCTORY에서 작성한 로그 파일이 아닌 것 같습니다.\r\n" +
                    "메시지를 닫으면 해당 항목이 삭제됩니다.",
                    "안내", MessageBoxButtons.OK, MessageBoxIcon.Error);
                trvFile.Nodes.Remove(e.Node);
            }
            catch (Exception ex)
            {
                MessageBox.Show("예기치 않은 오류입니다.\r\n" +
                    "자세한 오류는 클립보드에 복사됩니다.",
                    "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Clipboard.SetText(ex.ToString());
            }

        }
    }
}
