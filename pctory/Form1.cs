using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pctory
{
    public partial class Form1 : Form
    {
        Tracer tracer = new Tracer(true);
        public Form1()
        {
            InitializeComponent();

            tracer.RunTrace();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graph grap = new Graph(tracer.ProcInfoList);
            grap.Owner = this;
            grap.Show();
        }
    }
}
