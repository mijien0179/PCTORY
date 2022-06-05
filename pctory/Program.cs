using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using System.Threading;
using System.Diagnostics;
using System.Text;

namespace pctory
{
    internal static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            bool isFirst = false;

            Mutex vMutex = new Mutex(true, Application.ProductName + " view", out isFirst);
            if (args.Length != 0 && args[0] != "--autorun")
            {
                FileInfo f = new FileInfo(args[0]);
                if (f.Exists && LogFileInfo.Extension.Contains(f.Extension.Split('.').Last()))
                {
                    if (isFirst)
                    {
                        Application.Run(new fViewer(new string[] {f.FullName}));
                    }
                    else
                    {
                        WinApi.COPYDATASTRUCT cds = new WinApi.COPYDATASTRUCT();
                        cds.dwData = IntPtr.Zero;
                        cds.cbData = Encoding.Default.GetByteCount(args[0]) + 1;
                        cds.lpData = args[0];

                        WinApi.SendMessage(WinApi.FindWindow(null, "Log View"), WinApi.Message.WM_COPYDATA , 0, ref cds);
                    }

                }else if (args[0] == "--view")
                {
                    Application.Run(new fViewer(null));
                }
                vMutex.Close();
                return;
            }
            vMutex.Close();

            Mutex mutex = new Mutex(true, Application.ProductName, out isFirst);
            if (!isFirst)
            {
                MessageBox.Show(
                    "이미 메인 PCTORY가 실행중입니다.\r\n" +
                    "메인 PCTORY는 하나만 실행할 수 있습니다.", "안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mutex.Close();
                return;
            }

            Form frm = new Form1();
            if(args.Length > 0 && args[0] == "--autorun")
            {
                Application.Run();
            }
            else
            {
                Application.Run(frm);
            }

            mutex.Close();

        }

        
    }
}
