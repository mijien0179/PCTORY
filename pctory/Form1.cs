using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace pctory
{
    public partial class Form1 : Form
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
                            Value = value.StartTime.ToString()
                        },
                        new DataGridViewTextBoxCell()
                        {
                            Value = value.EndTime == DateTime.MinValue ? "-" : value.EndTime.ToString()
                        },
                        new DataGridViewTextBoxCell()
                        {
                            Value = tracer.ProcInfoList.GetData(key).Last().GetWindowTitle().Item2
                        },
                        new DataGridViewTextBoxCell()
                        {
                            Value = tracer.ProcInfoList.GetData(key).Count()
                        }
                    );

                    row.Add(temp);
                }

                if (dataGridView1.InvokeRequired)
                {
                    dataGridView1.Invoke(new MethodInvoker( () =>
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
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "count",
                    Name = "dvgColAccessCount",
                    CellTemplate = new DataGridViewTextBoxCell(),
                    Width = 40
                }
            };

            dv.Columns.AddRange(col);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            running = false;
            tracer.StopTrace();

            if (thread == null) return;

            if (thread.Join(3000)) MessageBox.Show("스레드 정상 종료");
            else
            {
                MessageBox.Show("스레드 종료 대기 만료");
                thread.Abort();
                MessageBox.Show("스레드 강제 종료");
            }
        }
    }
}
