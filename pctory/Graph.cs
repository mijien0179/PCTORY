﻿using System;
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
        private void loadData() {
            chart1.Series[0].Points.Clear();
            chart2.Series[0].Points.Clear();
            foreach (var key in info.GetKeys())
            {
                var item = info.GetData(key);
                var cnt = 0;
                TimeSpan? t= ApiHelper.SumTotalSpanTime(info.GetData(key));
                foreach (var i in item)
                {
                    cnt += i.CaptionCount();
                }
                chart1.Series[0].Points.AddXY(System.IO.Path.GetFileName(key),cnt); 
                chart2.Series[0].Points.AddXY(System.IO.Path.GetFileName(key),cnt);
                chart3.Series[0].Points.AddXY(System.IO.Path.GetFileName(key),t.HasValue ? t.Value.TotalSeconds : 0);
                chart4.Series[0].Points.AddXY(System.IO.Path.GetFileName(key),t.HasValue ? t.Value.TotalSeconds : 0);
            }
        }  
       

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void chart4_Click(object sender, EventArgs e)
        {
            
        }

        private void Graph_Load(object sender, EventArgs e)
        {

        }
    }
}
