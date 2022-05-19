using System;
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
        public Graph(ProcessInfoList info)
        {
            InitializeComponent();

            this.info = info;
            loadData();
        }

        private void loadData() {
            chart1.Series[0].Points.Clear();
            chart2.Series[0].Points.Clear();
            foreach (var key in info.GetKeys())
            {
                var item = info.GetData(key);
                var cnt = 0;
                foreach (var i in item)
                {
                    cnt += i.CaptionCount();
                }
                chart1.Series[0].Points.AddXY(System.IO.Path.GetFileName(key),cnt); 
                chart2.Series[0].Points.AddXY(System.IO.Path.GetFileName(key),cnt);
            }
        }  
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
