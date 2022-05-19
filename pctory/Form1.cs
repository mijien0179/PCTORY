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
using System.Runtime.Serialization.Formatters.Binary;

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
                    var LastnameValue = tracer.ProcInfoList.GetData(key).Last();

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
                            Value = LastnameValue.GetCaptionData().Value.Item2
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
            InitializeFileDialog();

            //tracer.RunTrace();
            tracer = new Tracer(true).RunTrace();

            running = true;
            thread = new Thread(textUpdate);
            thread.Start();

            DataGridView dv = this.dataGridView1;
            dv.ReadOnly = true;

            DataGridViewColumn[] col = new DataGridViewColumn[]{
                new DataGridViewTextBoxColumn(){
                    HeaderText = "프로그램",
                    Name = "dvgColProgram",
                    CellTemplate = new DataGridViewTextBoxCell(),
                    Width= 150
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "최근 접근 시작 기록",
                    Name = "dvgColRecentAccess",
                    CellTemplate = new DataGridViewTextBoxCell(),
                    Width = 200
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "최근 접근 종료 기록",
                    Name = "dvgColRecentExit",
                    CellTemplate = new DataGridViewTextBoxCell(),
                    Width = 200
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

      
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            running = false;
            tracer.StopTrace();

            if (thread == null) return;
        }

        private void tsmiStop_Click(object sender, EventArgs e)
        {

            running = false;
            tracer.StopTrace();

            if (thread == null) return;
        }
        
        private void InitializeFileDialog()
        {
            
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ofd.Filter = $"PCtory (*.{LogFileInfo.Extension})|*.{LogFileInfo.Extension}";
            ofd.FileName = "";

            sfd.InitialDirectory = ofd.InitialDirectory;
            sfd.Filter = ofd.Filter;
            sfd.FileName = $"*.{LogFileInfo.Extension}";
        }

        private void tsmiOpenLogFile_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileIO.FileInput(ofd.FileName);
            }
        }

        private void tsmiSaveLogFile_Click(object sender, EventArgs e)
        {
            if (ofd.FileName == "")
            {
                tsmiSaveAsLogFile_Click(tsmiSaveAsLogFile, EventArgs.Empty);
                return;
            }
            sfd.FileName = ofd.FileName;
            FileIO.FileOutput(tracer.ProcInfoList, sfd.FileName);
        }

        private void tsmiSaveAsLogFile_Click(object sender, EventArgs e)
        {
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ofd.FileName = sfd.FileName;
                tsmiSaveLogFile_Click(tsmiSaveLogFile, EventArgs.Empty);
            }
        }
    }
}