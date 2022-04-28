using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace pctory
{
    internal class WinApi
    {
        public enum EventCode : uint
        {
            EVENT_SYSTEM_FOREGROUND = 0x0003,
            EVENT_OBJECT_NAMECHANGE = 0x800C
        }
        
        /// <summary>
        /// hWnd 핸들의 윈도우 타이틀 가져오기
        /// </summary>
        /// <param name="hWnd">찾을 윈도우 핸들</param>
        /// <param name="lpText">저장할 곳</param>
        /// <param name="maxCount">최대 길이</param>
        /// <returns>성공시 타이틀 길이</returns>
        [DllImport("user32.dll", SetLastError = false)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpText, in int maxCount = 256);

        /// <summary>
        /// 현재 활성 윈도우 핸들 로드
        /// </summary>
        /// <returns>활성 윈도우 핸들</returns>
        [DllImport("user32.dll", SetLastError = false)]
        public static extern IntPtr GetForegroundWindow();

        /// <summary>
        /// hWnd 핸들을 가지는 윈도우의 프로세스 ID
        /// </summary>
        /// <param name="hWnd">PID를 찾을 윈도우 한들</param>
        /// <param name="wThreadProcessId">찾은 PID를 복사할 변수</param>
        /// <returns>스레드를 생성한 윈도우 핸들</returns>
        [DllImport("user32.dll", SetLastError = false)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint wThreadProcessId);


        /// <summary>
        /// WndProc 타입
        /// </summary>
        /// <param name="hWinEventHook"></param>
        /// <param name="iEvent"></param>
        /// <param name="hWnd"></param>
        /// <param name="idObject"></param>
        /// <param name="idChild"></param>
        /// <param name="dwEventThread"></param>
        /// <param name="dwmsEventTime"></param>
        public delegate void WinEventProc(IntPtr hWinEventHook, int iEvent, IntPtr hWnd, int idObject, int idChild, int dwEventThread, int dwmsEventTime);

        /// <summary>
        /// OS에서 이벤트 감지 시 실행할 콜백 함수 등록
        /// </summary> 
        /// <param name="eventMin">탐색 이벤트 최저 값</param>
        /// <param name="eventMax">탐색 이벤트 최대 값</param>
        /// <param name="hmodWinEventProc">hook 함수가 DLL에 있는 경우, WINEVENT_INCONTEXT flag 설정된 경우 dll 핸들</param>
        /// <param name="lpfnWinEventProc">hook 함수 포인터</param>
        /// <param name="idProcess">대상 프로세스. 0인 경우 모든 프로세스로부터 탐색</param>
        /// <param name="idThread">대상 스레드. 0인 경우 모든 프로세스로부터 탐색</param>
        /// <param name="dwflags"><c>SetWinEventHookFlags</c> 플래그</param>
        /// <returns>성공시 이벤트 hook ID값. 실패시 0</returns>
        [DllImport("user32.dll", SetLastError = false)]
        public static extern uint SetWinEventHook(WinApi.EventCode eventMin, WinApi.EventCode eventMax, IntPtr hmodWinEventProc, WinEventProc lpfnWinEventProc, int idProcess, int idThread, SetWinEventHookFlags dwflags);

        public enum SetWinEventHookFlags
        {
            /// <summary>
            /// 콜백 함수가 DLL 안에 존재하는 경우<br/>
            /// 이벤트를 생성하는 프로세스에 콜백 주소를 바인딩 해야하는 경우
            /// </summary>
            WINEVENT_INCONTEXT = 4,
            /// <summary>
            /// 콜백 함수가 프로그램 안에 존재하는 경우<br/>
            /// 이벤트를 생성하는 프로세스에 콜백 주소 바인딩을 할 필요가 없는 경우
            /// </summary>
            WINEVENT_OUTOFCONTEXT = 0,
            /// <summary>
            /// 이벤트 생성 프로세스에 해당 이벤트를 전달하지 않도록 함
            /// </summary>
            WINEVENT_SKIPOWNPROCESS = 2,
            /// <summary>
            /// 이벤트 생성 스레드에 해당 이벤트를 전달하지 않도록 함
            /// </summary>
            WINEVENT_SKIPOWNTHREAD = 1
        }


        /// <summary>
        /// <see cref="SetWinEventHook"/>에서 등록한 함수를 해제합니다.
        /// </summary>
        /// <param name="hWinEventHook"><c>SetWinEventHook</c>에서 등록한 반환 값<br/>: 이벤트 hook 핸들 값</param>
        /// <returns><c>True</c>시 성공</returns>
        [DllImport("user32.dll", SetLastError = false)]
        public static extern bool UnhookWinEvent(uint hWinEventHook);
        
    }
}