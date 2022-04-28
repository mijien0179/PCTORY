using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wa = pctory.WinApi;
using wae = pctory.WinApi.EventCode;

/// <summary>
/// 본 코드는 실제 PC 상태를 분석하는 코드가 아닌,
/// 이벤트 후킹을 위해 사용하는 API 후킹을 위한 별도의 처리를 하지 않아도 되도록 구성한
/// Helper, 즉 Toolkit입니다.
/// </summary>

namespace pctory
{
    internal static class ApiHelper
    {
        
        public static uint SetHook(wae EventCode, wa.WinEventProc WndProc)
        {
            return wa.SetWinEventHook(EventCode, EventCode,
                IntPtr.Zero, WndProc, 0, 0,
                wa.SetWinEventHookFlags.WINEVENT_OUTOFCONTEXT | wa.SetWinEventHookFlags.WINEVENT_SKIPOWNPROCESS);
        }

        public static bool EndHook(uint handle)
        {
            if (handle <= 0) return false;
            return wa.UnhookWinEvent(handle);
        }

    }
}
