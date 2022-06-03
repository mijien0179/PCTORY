using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Linq;


namespace pctory
{
    public partial class fViewer : pctory.design.pctoryForm
    {
        ProcessInfoList inform;
        public fViewer(string path)
        {
            InitializeComponent();

            viewInitializer.ProcInfoListDVGHeaderInitializer(ref dataGridView1);
            viewInitializer.PcbDVGHeaderInitializer(ref dataGridView2);

            tsmiViewHorizental.Tag = Orientation.Horizontal;
            tsmiViewVertical.Tag = Orientation.Vertical;

            ViewTypeChange(tsmiViewHorizental, new EventArgs());

            try
            {
                inform = FileIO.FileInput(path);
                Text = path.Split('\\').Last().Split('.').First();
                viewInitializer.InputDataProcInfoListDVG(ref dataGridView1, inform);

            }
            catch (Exception ex)
            {
                TitleBarColor = new Color[]{
                        Color.FromArgb(255,95,95),
                        Color.FromArgb(180, 43,48)
                };
                Text = "데이터 로드 실패";
                Clipboard.SetText(ex.ToString());
                lblstatus.Text = "올바르지 않은 파일을 로드했습니다. 자세한 정보는 클립보드에 복사되었습니다.";
            }



        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex > dataGridView1.Rows.Count) return;

            dataGridView2.Rows.Clear();
            viewInitializer.InputDataPcbDVG(ref dataGridView2, inform[dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()]);

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

        private void 통계ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graph grep = new Graph(inform, "일일");
            grep.Owner = this;
            grep.ShowDialog();
        }
    }
}
