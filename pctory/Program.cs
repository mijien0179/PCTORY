using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using System.Threading;

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

            if (args.Length != 0)
            {
                FileInfo f = new FileInfo(args[0]);
                if (f.Exists && LogFileInfo.Extension.Contains(f.Extension.Split('.').Last()))
                {
                    Application.Run(new fViewer(new string[] {f.FullName}));
                    return;
                }
            }

            bool isFirst = false;
            Mutex mutex = new Mutex(true, Application.ProductName, out isFirst);
            if (!isFirst)
            {
                MessageBox.Show(
                    "이미 메인 PCTORY가 실행중입니다.\r\n" +
                    "메인 PCTORY는 하나만 실행할 수 있습니다.", "안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mutex.Close();
                return;
            }

            Application.Run(new Form1(args));
            mutex.Close();

        }

        
    }
}
