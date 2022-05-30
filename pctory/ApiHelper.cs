using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 본 코드는 실제 PC 상태를 분석하는 코드가 아닌,
/// 이벤트 후킹을 위해 사용하는 API 후킹을 위한 별도의 처리를 하지 않아도 되도록 구성한
/// Helper, 즉 Toolkit입니다.
/// </summary>

namespace pctory
{
    internal static class ApiHelper
    {
         
        public static int SetHook(WinApi.EventCode EventCode, WinApi.WinEventProc WndProc, int procId = 0)
        {
            return WinApi.SetWinEventHook(EventCode, EventCode, 0, WndProc, procId, 0, WinApi.SetWinEventHookFlags.WINEVENT_OUTOFCONTEXT | WinApi.SetWinEventHookFlags.WINEVENT_SKIPOWNPROCESS);
        }

        public static bool EndHook(int handle)
        {
            if (handle <= 0) return false;
            return WinApi.UnhookWinEvent(handle);
        }

        /// <summary>
        /// PCB 리스트의 지속 시간 계산
        /// </summary>
        /// <param name="data">게산할 PCB 리스트</param>
        /// <returns>지속시간</returns>
        public static TimeSpan? SumTotalSpanTime(List<PCB> data)
        {
            TimeSpan? result = TimeSpan.Zero;

            for (int i = 0; i < data.Count(); ++i)
            {
                result += CalculateSpanTime(data[i]);
            }

            return result;

        }
        
        /// <summary>
        /// PCB의 지속 시간 계산
        /// </summary>
        /// <param name="data">계산할 PCB 블럭</param>
        /// <returns>지속시간</returns>
        public static TimeSpan? CalculateSpanTime(PCB data)
        {
            return data.BackgroundTime - data.ForegroundTime;
        }

        /// <summary>
        /// ProcessInfoList 두 개를 입력받아 하나로 합칩니다.
        /// </summary>
        /// <param name="p1">선행하는 데이터</param>
        /// <param name="p2">추가할 데이터</param>
        /// <returns>합쳐진 결과</returns>
        public static ProcessInfoList CombineProcessInfoList(ProcessInfoList p1, ProcessInfoList p2)
        {
            ProcessInfoList result = new ProcessInfoList();

            foreach (var p1key in p1.GetKeys())
            {
                result.ReplaceList(p1key, p1[p1key]);
            }

            foreach(var p2key in p2.GetKeys())
            {
                if (result.ContainsKey(p2key)) result[p2key].AddRange(p2[p2key]);
                else
                {
                    result.ReplaceList(p2key, p2[p2key]);
                }
            }

            return result;
        }

    }
}
