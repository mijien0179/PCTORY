using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using Microsoft.Win32;
using System.Diagnostics;

namespace pctory
{
    internal class Setting
    {
        public static class RegKey
        {
            public static string overrideLogSaveLoc 
                // 로그 데이터의 저장을 새 위치로 저장할지 여부를 결정하는 데이터 // bool
            {
                get => "overrideLogSaveLoc";
            }
            public static string LogSaveLoc
            {
                // 로그 데이터를 저장할 위치
                get => "logSaveLocation";
            }

        }

        private const string rKeyDefaultLoc = @"SOFTWARE\PCTORY";
        private static RegistryKey GetSettingKey()
        {
            RegistryKey rKey = Registry.CurrentUser.OpenSubKey(rKeyDefaultLoc, true);
            if (rKey == null)
            {
                rKey = Registry.CurrentUser.CreateSubKey(rKeyDefaultLoc, true);
            }
            return rKey;
        }

        /// <summary>
        /// 로그의 저장 위치 override 여부를 결정합니다.
        /// </summary>
        public static bool OverrideLogSaveLoc
        {
            get
            {
                RegistryKey rKey = GetSettingKey();
                bool value = false;

                if (rKey.GetValueNames().Contains(RegKey.overrideLogSaveLoc))
                     value = Convert.ToInt32(rKey.GetValue(RegKey.overrideLogSaveLoc)) == 0 ? false : true ;

                rKey.Close();
                return value;
            }
            set
            {
                RegistryKey rKey = GetSettingKey();
                rKey.SetValue(RegKey.overrideLogSaveLoc, (bool)value, RegistryValueKind.DWord);
                rKey.Close();
            }
        }

            
        /// <summary>
        /// <para>로그 데이터를 쓸 위치입니다.</para>
        /// <para>기본 위치: 프로그램 실행 위치\Log</para>
        /// </summary>
        public static string LogSaveLoc
        {
            get
            {
                RegistryKey rKey = GetSettingKey();

                string value = Application.StartupPath + "\\Log";
                if (rKey.GetValueNames().Contains(RegKey.LogSaveLoc))
                    rKey.GetValue(RegKey.LogSaveLoc);

                rKey.Close();
                return value;
            }
            set
            {
                RegistryKey rKey = GetSettingKey();
                rKey.SetValue(RegKey.LogSaveLoc, value, RegistryValueKind.String);
            }
        }
        public static void SetStartup()
        {

            Process.Start("cmd",$"/c schtasks -create /sc onlogon /tn \"\\pctory\\autorun\" /tr \"{Application.ExecutablePath} --autorun\" /RL HIGHEST");

        }

        public static void ResetStartup()
        {
            Process.Start("cmd", $"/c schtasks -delete /tn \"\\pctory\\autorun\" /f");
            Process.Start("cmd", $"/c schtasks -delete /tn \"\\pctory\" /f");
        }

        public void FileConnectProgram()
        { 
            string path = @"C:\Users\김수연\source\repos\mijien0179\PCTORY\pctory\bin\Debug\pctory.exe";
            object ob = 
            using (RegistryKey ckey = Registry.CurrentUser.OpenSubKey(@"Software\Classes", true))
            {
                using(RegistryKey fkey = ckey.CreateSubKey(".pctory"))
                {
                    fkey.SetValue(null,filetype)
                }
                using(RegistryKey ftkey = ckey.CreateSubKey(fileType))
                {
                    ftkey.SetValue(null, fileDescription);
                    using(RegistryKey skey = ftkey.CreateSubKey("shell"))
                    {
                        using(RegistryKey okey = skey.CreateSubKey("open"))
                        {
                            using(RegistryKey comkey = skey.CreateSubKey("command"))
                            {
                                string command = string.Format("\"{0}\"\"%1\"", path);
                                comkey.SetValue(null, command);
                            }
                        }
                    }
                }
            }
        }
    }

}
