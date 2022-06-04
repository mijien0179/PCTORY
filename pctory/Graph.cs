using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pctory.design;

namespace pctory
{
    public partial class Graph : pctoryForm
    {
        ProcessInfoList info;

        /// <summary>
        /// ProcessInfoList와 Title을 기준으로 해당 데이터를 읽어들여 통계자료로 보여주는 함수
        /// </summary>
        /// <param name="info">읽어들일 PCB </param>
        /// <param name="title">창의 제목 </param>
        /// <returns>통계 자료 창</returns>
        public Graph(ProcessInfoList info,string title)
        {
            InitializeComponent();
            setText(title);
            this.info = info;
            loadData();
        }

        private void setText(string title) {
            this.Text = title;
            if (title == "일간그래프") title = "일간";
            if (title == "주간그래프") title = "주간";
            if (title == "월간그래프") title = "월간";
            chart1.Titles[0].Text = title + " 사용 횟수";
            chart2.Titles[0].Text = title + " 사용 횟수";
            chart3.Titles[0].Text = title + " 사용 시간";
            chart4.Titles[0].Text = title + " 사용 시간";
        }
        private  SortedList< double, string> data =new SortedList< double,string>();
        private  SortedList< string,double> data_frequency =new SortedList< string,double>();

        private void loadData() {
            chart1.Series[0].Points.Clear();
            chart2.Series[0].Points.Clear();
            chart3.Series[0].Points.Clear();
            chart4.Series[0].Points.Clear();
            foreach (var key in info.GetKeys())
            {
                var item = info.GetData(key);
                var cnt = 0;
                TimeSpan? t= ApiHelper.SumTotalSpanTime(info.GetData(key));
                if(t!=null)
                    data.Add( t.Value.TotalSeconds, key);
                foreach (var i in item)
                {
                    cnt += i.CaptionCount();
                }
                data_frequency.Add(key,cnt);
            }



            #region 값들을 집어 넣는 함수
            //변수
            double etc_time = 0;
            double etc_frequency = 0;
            var key_time = data.Values;
            var key_frequency = data_frequency.Values; // key값에 따른 빈도수  
            var value_frequency = data_frequency.Keys; // key값
            //사용 횟수 넣기
            if (data_frequency.Count > 4)
            {
                for (int i = data_frequency.Count; i > data_frequency.Count - 4; i--)
                {
                    chart1.Series[0].Points.AddXY(System.IO.Path.GetFileName(value_frequency[i - 1]), key_frequency[i - 1]);
                    chart2.Series[0].Points.AddXY(System.IO.Path.GetFileName(value_frequency[i - 1]), key_frequency[i - 1]);
                }
                for (int i = 0; i < data_frequency.Count - 4; i++)
                {
                    etc_frequency += key_frequency[i];
                }
                chart1.Series[0].Points.AddXY("기타", etc_frequency);
                chart2.Series[0].Points.AddXY("기타", etc_frequency);
                

            }
            else
            {
                for (int i = 0; i < data_frequency.Count; i++)
                {
                    chart1.Series[0].Points.AddXY(System.IO.Path.GetFileName(value_frequency[i]), key_frequency[i]);
                    chart2.Series[0].Points.AddXY(System.IO.Path.GetFileName(value_frequency[i]), key_frequency[i]);
                }
            }

            //시간 data 넣기
            var timeslice = 1;
            timelabel.Text = "1 초";
            if (data.Count >= 1) { 
                if (ApiHelper.SumTotalSpanTime(info.GetData(key_time[key_time.Count - 1])).Value.TotalSeconds > 3600)
                {
                    timelabel.Text = "1 시간";
                    timeslice = 3600;
                }
                else if (ApiHelper.SumTotalSpanTime(info.GetData(key_time[key_time.Count - 1])).Value.TotalSeconds > 60)
                {
                    timelabel.Text = "1 분";
                    timeslice = 60;
                }
              
            }

            if (data.Count > 4)
            {
                for (int i = data.Count; i > data.Count-4; i--)
                {
                    chart3.Series[0].Points.AddXY(System.IO.Path.GetFileName(key_time[i-1]), ApiHelper.SumTotalSpanTime(info.GetData(key_time[i-1])).Value.TotalSeconds/timeslice);
                    chart4.Series[0].Points.AddXY(System.IO.Path.GetFileName(key_time[i-1]), ApiHelper.SumTotalSpanTime(info.GetData(key_time[i-1])).Value.TotalSeconds/timeslice);
                }
                for (int i = 0; i < data.Count - 4; i++)
                {
                    etc_time += ApiHelper.SumTotalSpanTime(info.GetData(key_time[i])).Value.TotalSeconds/timeslice;
                   
                }
                chart3.Series[0].Points.AddXY("기타", etc_time);
                chart4.Series[0].Points.AddXY("기타", etc_time);
            }
            else
            {
                for (int i = 0; i < data.Count; i++)
                {
                    chart3.Series[0].Points.AddXY(System.IO.Path.GetFileName(key_time[i]), ApiHelper.SumTotalSpanTime(info.GetData(key_time[i])).Value.TotalSeconds/timeslice);
                    chart4.Series[0].Points.AddXY(System.IO.Path.GetFileName(key_time[i]), ApiHelper.SumTotalSpanTime(info.GetData(key_time[i])).Value.TotalSeconds/timeslice);
                }
            }
        }
        #endregion
    }
}
