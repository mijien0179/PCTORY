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

    }
}
