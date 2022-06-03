using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace pctory
{
    public partial class fSetting : pctory.design.pctoryForm
    {
        public fSetting()
        {
            InitializeComponent();
            InitializeSettingView();

            // 크기 고정
            MinimumSize = MaximumSize = Size;
        }

        private void InitializeSettingView()
        {
            chkOverrideLogSaveLoc.Checked = Setting.OverrideLogSaveLoc;
            tbxLogSaveLoc.Text = Setting.LogSaveLoc;

            pnlSaveLoc.Enabled = chkOverrideLogSaveLoc.Checked;

        }

        private void chkOverrideLogSaveLoc_CheckedChanged(object sender, EventArgs e)
        {
            pnlSaveLoc.Enabled = chkOverrideLogSaveLoc.Checked;
            Setting.OverrideLogSaveLoc = chkOverrideLogSaveLoc.Checked;

        }

        private void chkStartup_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStartup.Checked)
            {
                Setting.SetStartup();
            }
            else
            {
                Setting.ResetStartup();
            }
        }

        private void btnFindLogSaveLoc_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog()
            {
                ShowNewFolderButton = true,
                Description = "로그를 저장할 위치를 선택합니다."
            };
            
            if(fbd.ShowDialog() == DialogResult.OK)
            {
                tbxLogSaveLoc.Text = fbd.SelectedPath;
                Setting.LogSaveLoc = tbxLogSaveLoc.Text;
                MessageBox.Show("경로 설정이 완료되었습니다.", "경로 설정 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
    }
}
