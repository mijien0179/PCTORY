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
    public partial class Form2 : Form
    {

        public event EventHandler loadData;

        public Form2() 
        {
            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(Form2_KeyPress);
        }

        public Form2(List<PCB> data) : this()
        {
            InitializeComponent();
            DataGridView dv = dataGridView1;

            DataGridViewColumn[] col = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "접근 시작 일자",
                    Width = 200
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "접근 종료 일자",
                    Width =200
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "지속 시간",
                    Width = 200
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "제목",
                    Width = 250
                }

            };

            dv.Columns.AddRange(col);

            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            DataGridViewRow row;
            foreach (var item in data)
            {
                row = new DataGridViewRow();
                if (item.GetWindowCount() > 0)
                {

                    row.Cells.AddRange(
                        new DataGridViewTextBoxCell()
                        {
                            Value = item.StartTime
                        },
                        new DataGridViewTextBoxCell()
                        {
                            Value = item.EndTime
                        },
                        new DataGridViewTextBoxCell()
                        {
                            Value = item.EndTime - item.StartTime
                        },
                        new DataGridViewTextBoxCell()
                        {
                            Value = "-"
                        }
                    );

                    rows.Add(row);

                    for (int i = 0; i < item.GetWindowCount(); i++)
                    {
                        row = new DataGridViewRow();
                        row.Cells.AddRange(
                            new DataGridViewTextBoxCell()
                            {
                                Value = item.GetWindowTitle(i).Item1
                            },
                            new DataGridViewTextBoxCell()
                            {
                                Value = "-"
                            },
                            new DataGridViewTextBoxCell()
                            {
                                Value = i+1 < item.GetWindowCount() ?
                                    (item.GetWindowTitle(i + 1).Item1 - item.GetWindowTitle(i).Item1).ToString() :
                                    (item.EndTime - item.GetWindowTitle(i).Item1).ToString()
                            },
                            new DataGridViewTextBoxCell()
                            {
                                Value = item.GetWindowTitle(i).Item2
                            }
                        );
                        rows.Add(row);
                    }
                }
                else
                {
                    row = new DataGridViewRow();
                    row.Cells.AddRange(
                        new DataGridViewTextBoxCell()
                        {
                            Value = item.StartTime
                        },
                        new DataGridViewTextBoxCell()
                        {
                            Value = item.EndTime
                        },
                        new DataGridViewTextBoxCell()
                        {
                            Value = item.EndTime != DateTime.MinValue ? (item.EndTime - item.StartTime).ToString() : "-"
                        },
                        new DataGridViewTextBoxCell()
                        {
                            Value = "-"
                        }
                    );

                    rows.Add(row);
                }

            }

            dv.Rows.AddRange(rows.ToArray());

        }

        private void Form2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                Close();
            }
        }


    }

}
