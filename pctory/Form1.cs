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
        string[] args;

        bool closer = false;

        Tracer tracer = null;
        Thread thread;
        DayTrace daytrace=null;
        private bool running = false;

        private void textUpdate()
        {

            while (running)
            {
                InvalidateText();
                Thread.Sleep(3000);
            }
        }

        private void InvalidateText()
        {
            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.Invoke(new MethodInvoker(InvalidateText));
                return;

            }

            dataGridView1.Rows.Clear();
            dataGridView1.Rows.AddRange(viewInitializer.ProcInfoList2DVGRows(tracer.ProcInfoList));
        }
        public Form1(string[] args)
        {
            InitializeComponent();
            InitializeFileDialog();
 

            Tag = TitleBarColor;

            this.args = args;

            tracer = new Tracer(true);

            viewInitializer.ProcInfoListDVGHeaderInitializer(dataGridView1);        
            tsmiTracerRun_Click(null, null);
            daytrace = new DayTrace(FileAutoOutput_DayChange);

        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileAutoOutput_Closing(sender, e);
            Hide();
            if (!closer) e.Cancel = true;

            running = false;
            tracer.StopTrace();
            thread.Join();
        }

        private void tsmiTracerRun_Click(object sender, EventArgs e)
        {
            if (tracer.Status) // 정지 상태로 변경할 것
            {
                tsmiTracerRun.Text = "트레이서 재동작";

                running = false;
                tracer.StopTrace();


                Tag = TitleBarColor;

                TitleBarColor = new Color[]
{
                    Color.FromArgb(204,140,43),
                    Color.FromArgb(204,126,43)
};



                if (sender != null) MessageBox.Show("트레이서가 정지되었습니다.", "안내", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else // 활성 상태로 변경할 것
            {
                tsmiTracerRun.Text = "트레이서 일시정지";

                tracer.RunTrace();

                running = true;
                thread = new Thread(textUpdate);
                thread.Start();

                TitleBarColor = (Color[])Tag;


                if (sender != null) MessageBox.Show("트레이서가 시작되었습니다.", "안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

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

            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            sfd.Filter = $"PCtory (*.{LogFileInfo.Extension})| *.{LogFileInfo.Extension}";
            sfd.FileName = $"{now.ToString().Substring(0, 10)}.{LogFileInfo.Extension}";
        }

        private void tsmiSaveLogFile_Click(object sender, EventArgs e)
        {
            if (sfd.FileName == null)
            {
                tsmiSaveAsLogFile_Click(tsmiSaveAsLogFile, EventArgs.Empty);
                return;
            }

            FileIO.FileOutput(tracer.ProcInfoList, sfd.FileName);
        }

        private void tsmiSaveAsLogFile_Click(object sender, EventArgs e)
        {
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                tsmiSaveLogFile_Click(tsmiSaveLogFile, EventArgs.Empty);
            }
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closer = true;
            Application.Exit();
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
        public ProcessInfoList ReadData(String time)
        {
            DateTime day = DateTime.Now;
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

        private void 로그뷰어VToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fViewer view = new fViewer(null);
            view.Owner = this;
            view.ShowDialog();
        }
    }
}