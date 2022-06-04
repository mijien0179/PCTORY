using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;


namespace pctory
{
    internal static class viewInitializer
    {
        public static void ProcInfoListDVGHeaderInitializer(ref DataGridView dv)
        {
            dv.Rows.Clear();
            dv.Columns.Clear();

            dv.Columns.AddRange(new DataGridViewColumn[]{
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "key",
                    Name = "dvgColkey",
                    CellTemplate = new DataGridViewTextBoxCell(),
                    Width = 150,
                    Visible = false
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "프로그램",
                    Name = "dvgColProgram",
                    CellTemplate = new DataGridViewTextBoxCell(),
                    Width = 150
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
                    HeaderText = "마지막 제목",
                    Name = "dvgColRecentText",
                    CellTemplate = new DataGridViewTextBoxCell(),
                    Width = 250
                }
            });

        }

        public static void InputDataProcInfoListDVG(ref DataGridView dv, in ProcessInfoList inform)
        {
            var rows = new List<DataGridViewRow>();

            foreach (var key in inform.GetKeys())
            {
                var item = inform[key];
                var row = new DataGridViewRow();
                row.Cells.AddRange(
                    new DataGridViewTextBoxCell()
                    {
                        Value = key
                    },
                    new DataGridViewTextBoxCell()
                    {
                        Value = key.Split('\\').Last()
                    },
                    new DataGridViewTextBoxCell()
                    {
                        Value = item.Last().ForegroundTime
                    },
                    new DataGridViewTextBoxCell()
                    {
                        Value = item.Last().BackgroundTime.HasValue ? item.Last().BackgroundTime.Value.ToString() : "-"
                    },
                    new DataGridViewTextBoxCell()
                    {
                        Value = item.Last().GetCaptionData().Value.Item2
                    }
                ); ;
                rows.Add(row);
            }

            dv.Rows.AddRange(rows.ToArray());
        }

        public static void PcbDVGHeaderInitializer(ref DataGridView dv)
        {
            dv.Rows.Clear();
            dv.Columns.Clear();

            dv.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "접근 시작",
                    Name = "dvgColForegroundTime",
                    CellTemplate = new DataGridViewTextBoxCell(),
                    Width = 200
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "접근 종료(지속시간)",
                    Name = "dvgColBackgroundTime",
                    CellTemplate = new DataGridViewTextBoxCell(),
                    Width = 200
                },
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "제목",
                    Name = "dvgColText",
                    CellTemplate = new DataGridViewTextBoxCell(),
                    Width = 400
                },

            });
        }

        public static void InputDataPcbDVG(ref DataGridView dv, List<PCB> inform)
        {
            var rows = new List<DataGridViewRow>();
            for(int i = 0; i< inform.Count; ++i)
            {
                var row = new DataGridViewRow();
                var item = inform[i];

                row.Cells.AddRange(new DataGridViewCell[]
                {
                    new DataGridViewTextBoxCell()
                    {
                        Value = item.ForegroundTime.HasValue ? item.ForegroundTime.ToString() : "-"
                    },
                    new DataGridViewTextBoxCell()
                    {
                        Value = item.BackgroundTime.HasValue ? item.BackgroundTime.ToString() : "-"
                    },
                    new DataGridViewTextBoxCell()
                    {
                        Value = "-"
                    }
                });
                rows.Add(row);

                for(int k = 0; k< item.CaptionCount(); ++k)
                {
                    row = new DataGridViewRow();
                    TimeSpan? presistTime = null;
                    if(k + 1 == item.CaptionCount())
                    {
                        if (item.BackgroundTime.HasValue)
                        {
                            presistTime = ApiHelper.CalculateSpanTime(item);
                        }
                    }
                    else
                    {
                        presistTime = item[k + 1].Value.Item1 - item[k].Value.Item1;
                    }
                    row.Cells.AddRange(new DataGridViewCell[]
                    {
                        new DataGridViewTextBoxCell()
                        {
                            Value = item[k].HasValue ? item[k].Value.Item1.ToString() : "-"
                        },
                        new DataGridViewTextBoxCell()
                        {
                            Value = presistTime.HasValue ? presistTime.ToString() : "-"
                        },
                        new DataGridViewTextBoxCell()
                        {
                            Value = item[k].HasValue ? item[k].Value.Item2.ToString() : "-"
                        }
                    });
                    rows.Add(row);

                }
            }
            dv.Rows.AddRange(rows.ToArray());
        }
    }
}
