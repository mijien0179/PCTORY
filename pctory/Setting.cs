using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using System.Diagnostics;

namespace pctory
{
    internal class Setting
    {
        public static void SetStartup()
        {

            Process.Start("cmd",$"/c schtasks -create /sc onlogon /tn \"\\pctory\\autorun\" /tr \"{Application.ExecutablePath}\" /RL HIGHEST");

        }

        public static void ResetStartup()
        {
            Process.Start("cmd", $"/c schtasks -delete /tn \"\\pctory\\autorun\" /f");
            Process.Start("cmd", $"/c schtasks -delete /tn \"\\pctory\" /f");
        }

    }

}
