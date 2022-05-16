using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using pctory.design;
namespace pctory
{
    public partial class Form1 : pctoryForm
    {
        Tracer tracer = null;
        Thread thread;

        private bool running = false;

        private void textUpdate()
        {
            List<DataGridViewRow> row = new List<DataGridViewRow>();
            while (running)
            {
                row.Clear();
                foreach (var key in tracer.ProcInfoList.GetKeys())
                {
                    var value = tracer.ProcInfoList.GetData(key).Last();

                    DataGridViewRow temp = new DataGridViewRow();
                    temp.Cells.AddRange(
                        new DataGridViewTextBoxCell()
                        {
                            Value = Path.GetFileName(key)
                        },
                        new DataGridViewTextBoxCell()
                        {
                            Value = value.ForegroundTime.ToString()
                        },
                        new DataGridViewTextBoxCell()
                        {
                            Value = value.BackgroundTime == DateTime.MinValue ? "-" : value.BackgroundTime.ToString()
                        },
                        new DataGridViewTextBoxCell()
                        {
                            Value = tracer.ProcInfoList.GetData(key).Last().GetCaptionData()
                        }
                       
                    ) ;

                    row.Add(temp);
                }

                if (dataGridView1.InvokeRequired)
                {
                    dataGridView1.Invoke(new MethodInvoker(() =>
                    {
                        InvalidateText(ref row);
                    }));

                }
                else
                {
                    InvalidateText(ref row);
                }

                Thread.Sleep(3000);
            }
        }

        private void InvalidateText(ref List<DataGridViewRow> data)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.AddRange(data.ToArray());
        }
        public Form1()
        {
            InitializeComponent();

            //tracer.RunTrace();
        }

      
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            running = false;
            tracer.StopTrace();

            if (thread == null) return;
        }

        private void tsmiStart_Click(object sender, EventArgs e)
        {
            tracer = new Tracer(true).RunTrace();

            running = true;
            thread = new Thread(textUpdate);
            thread.Start();

            DataGridView dv = this.dataGridView1;

            DataGridViewColumn[] col = new DataGridViewColumn[]{
                new DataGridViewTextBoxColumn(){
                    HeaderText = "프로그램",
                    Name = "dvgColProgram",
                    CellTemplate = new DataGridViewTextBoxCell(),
                    Width= 200
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "최근 접근 시작 기록",
                    Name = "dvgColRecentAccess",
                    CellTemplate = new DataGridViewTextBoxCell(),
                    Width = 250
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "최근 접근 종료 기록",
                    Name = "dvgColRecentExit",
                    CellTemplate = new DataGridViewTextBoxCell(),
                    Width = 250
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "최근 제목",
                    Name = "dvgColRecentText",
                    CellTemplate = new DataGridViewTextBoxCell(),
                    Width = 250
                }
            };

            dv.Columns.AddRange(col);
        }

        private void tsmiStop_Click(object sender, EventArgs e)
        {
            running = false;
            tracer.StopTrace();
        }
    }
}
