﻿using System;
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
        string[] args;

        bool closer = false;

        Tracer tracer = null;
        Thread thread;
        DayTrace daytrace=null;
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
                            Value = LastnameValue.GetCaptionData().HasValue ? LastnameValue.GetCaptionData().Value.Item2 : "-" 
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
        public Form1(string[] args)
        {
            InitializeComponent();
            InitializeFileDialog();
            //tracer.RunTrace();
            tracer = new Tracer(true).RunTrace();
            daytrace = new DayTrace(FileAutoOutput_DayChange);
            this.args = args;

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
            FileAutoOutput_Closing(sender, e);
            Hide();
            if(!closer) e.Cancel = true;

            running = false;
            tracer.StopTrace();
            thread.Join();
        }

        private void tsmiStop_Click(object sender, EventArgs e)
        {
            running = false;

            tracer.StopTrace();

            MessageBox.Show("실행이 종료되었습니다.", "",MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void 설정OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fSetting fsetting = new fSetting();
            fsetting.Owner = this;
            fsetting.ShowDialog();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            running = true;
            thread = new Thread(textUpdate);
            thread.Start();

            if (args.Contains("--autorun"))
            {
                Visible = false;
                ShowInTaskbar = false;

                args = (from d in args
                       where d != "--autorun"
                       select d).ToArray();
            }
            
        }
        
        private void InitializeFileDialog()
        {
            DateTime now = DateTime.Now;
            
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ofd.Filter = $"PCtory (*.{LogFileInfo.Extension})| *.{LogFileInfo.Extension}";
            ofd.FileName = "";

            sfd.InitialDirectory = ofd.InitialDirectory;
            sfd.Filter = ofd.Filter;
            sfd.FileName = $"{now.ToString().Substring(0,10)}.{LogFileInfo.Extension}";
        }

        private void tsmiOpenLogFile_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                new fViewer(ofd.FileName).Show();
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

        private void tsmiRestart_Click(object sender, EventArgs e)
        {
            if(running == true)
                MessageBox.Show("프로그램이 실행 중 입니다.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                running = true;
                tracer.RunTrace();
                thread = new Thread(textUpdate);
                thread.Start();
            }

        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closer = true;
            Close();
        }

        private void noti_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenForm();
        }

        private void OpenForm()
        {
            Show();
        }

        private void 열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm();
        }


        
      

        private void 통계ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graph grep = new Graph(ReadData(sender.ToString()), sender.ToString());
            grep.Owner = this;
            grep.ShowDialog();
            
        }
        public ProcessInfoList ReadData(String time) {
            DateTime day= DateTime.Now;
            ProcessInfoList data = tracer.ProcInfoList;
            String path = "";
            if (time == "월간그래프")
            {
                for (int i = 0; i < 30; i++)
                {
                    day = DateTime.Now.AddDays(-i);
                    path = Setting.LogSaveLoc + "\\" + day.Year.ToString();
                    if (day.Month <= 9)
                    { 
                        path +="-0" + day.Month.ToString();
                    }else path += "-" + day.Month.ToString();
                    if (day.Day <= 9) { 
                        path +="-0" + day.Day.ToString() +".pctory";
                    }else path += "-" + day.Day.ToString() + ".pctory";
                    
                    FileInfo datafile = new FileInfo(path);
                    if (datafile.Exists) {
                       ProcessInfoList newdata = FileIO.FileInput(path);
                       data= ApiHelper.CombineProcessInfoList(data, newdata);
                    }
                }
                return data;
            }
            else if (time == "주간그래프")
            {
                for (int i = 0; i < 7; i++)
                {
                    day = DateTime.Now.AddDays(-i);
                    path = Setting.LogSaveLoc + "\\" + day.Year.ToString();
                    if (day.Month <= 9)
                    {
                        path += "-0" + day.Month.ToString();
                    }
                    else path += "-" + day.Month.ToString();
                    if (day.Day <= 9)
                    {
                        path += "-0" + day.Day.ToString() + ".pctory";
                    }
                    else path += "-" + day.Day.ToString() + ".pctory";

                    FileInfo datafile = new FileInfo(path);
                    if (datafile.Exists)
                    {
                        ProcessInfoList newdata = FileIO.FileInput(path);
                        data = ApiHelper.CombineProcessInfoList(data, newdata);
                    }
                }
                return data;
            }
            else
                return data;
        }
        public void FileAutoOutput_DayChange(object sender, EventArgs e)
        {
            DateTime d = daytrace.bDate;
            DirectoryInfo di = new DirectoryInfo(Setting.LogSaveLoc);
            string path = Setting.LogSaveLoc + "\\" + d.ToString().Substring(0, 10) + "." + LogFileInfo.Extension;
            if (di.Exists == false)
                di.Create();

            Stream wstream = new FileStream(path, FileMode.Create);
            BinaryFormatter serial = new BinaryFormatter();
            serial.Serialize(wstream, tracer.ProcInfoList);
            wstream.Close();
        }
        public void FileAutoOutput_Closing(object sender, EventArgs e)
        {
            DateTime d = DateTime.Today;
            DirectoryInfo di = new DirectoryInfo(Setting.LogSaveLoc);
            string path = Setting.LogSaveLoc + "\\" + d.ToString().Substring(0, 10) + "." + LogFileInfo.Extension;
            if (di.Exists == false)
                di.Create();

            Stream wstream = new FileStream(path, FileMode.Create);
            BinaryFormatter serial = new BinaryFormatter();
            serial.Serialize(wstream, tracer.ProcInfoList);
            wstream.Close();
        }
    }
}