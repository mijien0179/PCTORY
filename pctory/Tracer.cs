using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace pctory
{
    /// <summary>
    /// 프로세스의 활성 정보를 담고있는 클래스입니다.
    /// </summary>
    public class PCB
    {
        /// <summary>
        /// PCB에 저장된 데이터 분별 FLAG<br/>내부에서 자동으로 관리됨
        /// </summary>
        [Flags]
        public enum DataFlags : uint
        {
            NULL = 0,
            FOREGROUND_TIME = 0x01, // 활성화 시간 저장 중
            BACKGROUND_TIME = 0x02, // 비활성화 시간 저장 중
            WINDOW_CAPTION = 0x04, // 윈도우 제목 저장 중

            PREVIOUS_BLOCK = 0x10, // 이전 블록 저장 중
            AFTER_BLOCK = 0x20  // 다음 블록 저장 중
        }

        #region property

        /// <summary>
        /// 어떤 정보를 담고있는지 관리하는 Flag 데이터
        /// </summary>
        public DataFlags Flags
        {
            get { return flags; }
            private set { flags = value; }
        }
        private DataFlags flags; // 담고있는 데이터 정보

        /// <summary>
        /// 활성화 시간
        /// </summary>
        public DateTime? ForegroundTime
        {
            get { return foregroundTime; }
            set
            {
                foregroundTime = value;
                if (value != null) Flags |= DataFlags.FOREGROUND_TIME;
                else Flags &= ~DataFlags.FOREGROUND_TIME;
            }
        }
        private DateTime? foregroundTime;

        /// <summary>
        /// 비활성화 시간
        /// </summary>
        public DateTime? BackgroundTime
        {
            get { return backgroundTime; }
            set
            {
                backgroundTime = value;
                if (value != null) Flags |= DataFlags.BACKGROUND_TIME;
                else Flags &= ~DataFlags.BACKGROUND_TIME;
            }
        }
        private DateTime? backgroundTime;

        /// <summary>
        /// 현재 생성 후 직후에 저장된 <c>PCB</c> 데이터
        /// </summary>
        public PCB AfterBlock
        {
            get { return afterBlock; }
            set
            {
                afterBlock = value;
                if (value == null) Flags &= ~DataFlags.AFTER_BLOCK;
                else Flags |= DataFlags.AFTER_BLOCK;
            }
        }
        private PCB afterBlock;

        /// <summary>
        /// 현재 <c>PCB</c>직전에 저장된 데이터
        /// </summary>
        public PCB BeforeBlock
        {
            get { return previousBlock; }
            set
            {
                previousBlock = value;
                if (value == null) Flags &= ~DataFlags.PREVIOUS_BLOCK;
                else Flags |= DataFlags.PREVIOUS_BLOCK;
            }
        }
        private PCB previousBlock;

        private List<(DateTime, string)?> captionData;
        #endregion

        #region constructor
        public PCB(DateTime? _foregroundTime = null)
        {
            Flags = DataFlags.NULL;
            if (_foregroundTime != null) ForegroundTime = _foregroundTime ?? null;
            captionData = null;
        }
        #endregion

        #region method

        /// <summary>
        /// 윈도우 캡션(타이틀) 정보를 가져옵니다.
        /// </summary>
        /// <param name="index">가져올 요소 번호</param>
        /// <returns>-1: 마지막 저장된 정보 저장<br/>없거나 범위를 벗어난 경우 null 반환</returns>
        public (DateTime, string)? GetCaptionData(in int index = -1)
        {
#if DEBUG
            Debug.Assert(index >= -1);
            // debug에서 문제가 나는 경우, assert 내므로
            // release에서는 체크할 필요가 없다고 판단함
#endif
            if (!Flags.HasFlag(DataFlags.WINDOW_CAPTION)) return null;
            if (index == -1) return captionData.Last();
            if (index < captionData.Count) return captionData[index];
            return null;
        }
        public (DateTime, string)? this[int index]
        {
            get => GetCaptionData(index);
        }

        /// <summary>
        /// 윈도우 타이틀(캡션) 저장
        /// </summary>
        /// <param name="date">저장할 시점 시간</param>
        /// <param name="caption">윈도우 타이틀</param>
        public void SaveCaption(DateTime date, string caption)
        {
            if (!Flags.HasFlag(DataFlags.WINDOW_CAPTION))
            {
                captionData = new List<(DateTime, string)?>();
                Flags |= DataFlags.WINDOW_CAPTION;
            }

            captionData.Add((date, caption));
        }

        /// <summary>
        /// 현재 로컬 시간으로 윈도우 타이틀(캡션) 저장
        /// </summary>
        /// <param name="caption">타이틀</param>
        public void SaveCaption(string caption)
        {
            SaveCaption(DateTime.Now, caption);
        }

        /// <summary>
        /// 보관 중인 윈도우 타이틀(캡션) 개수를 불러옵니다.
        /// </summary>
        /// <returns>데이터를 저장하지 않거나 없는 경우 0</returns>
        public int CaptionCount() => Flags.HasFlag(DataFlags.WINDOW_CAPTION) ? captionData.Count : 0;

        #endregion

    }

    /// <summary>
    /// <c>PCB</c>를 관리하는 컨테이너 클래스
    /// </summary>
    public class ProcessInfoList
    {
        #region property
        private Dictionary<string, List<PCB>> data;
        private string last_key;
        private PCB before;
        #endregion

        #region constructor
        public ProcessInfoList()
        {
            data = new Dictionary<string, List<PCB>>();
            last_key = null;
            before = null;
        }
        #endregion

        #region method

        /// <summary>
        /// <c>PCB</c> 정보를 저장합니다.
        /// </summary>
        /// <param name="key">저장할 키 값</param>
        /// <param name="title">null일 경우 저장 안함</param>
        public void Add(string key, string title = null)
        {
            DateTime now = DateTime.Now;
            PCB item;
            if (!data.ContainsKey(key)) data[key] = new List<PCB>();

            bool overwrite = false;
            if (last_key == key)
            {
                item = data[key].Last();
                if (item.Flags.HasFlag(PCB.DataFlags.BACKGROUND_TIME))
                {
                    overwrite = true;
                    item = new PCB(now);
                }
            }
            else
            {
                overwrite = true;
                item = new PCB(now);
            }

            if (title != null) item.SaveCaption(title);

            if (last_key != key || overwrite)
            {
                item.BeforeBlock = before;
                if (before != null)
                {
                    before.BackgroundTime = now;
                    before.AfterBlock = item;
                }
                before = item;
                data[key].Add(item);
            }
            last_key = key;
        }

        /// <summary>
        /// 마지막으로 저장한 <c>PCB</c>의 <c>BackgroundTime</c>을 설정합니다.
        /// </summary>
        public void LogBackgroundTime2LastPCB()
        {
            if (before != null && !before.Flags.HasFlag(PCB.DataFlags.BACKGROUND_TIME)) before.BackgroundTime = DateTime.Now;
        }

        /// <summary>
        /// 저장에 사용한 키를 가져옵니다.
        /// </summary>
        /// <returns>키 목록</returns>
        public List<string> GetKeys() => data.Keys.ToList();

        /// <summary>
        /// key에 해당하는 데이터 불러오기
        /// </summary>
        /// <param name="key">검색할 키입니다.</param>
        /// <returns>key로 저장한 데이터가 없는 경우 null</returns>
        public List<PCB> GetData(string key)
        {
            if (data.ContainsKey(key)) return data[key];
            return null;
        }
        public List<PCB> this[string key] => GetData(key);

        #endregion
    }

    public class Tracer
    {
        #region property

        #region GC 방지용
        private WinApi.WinEventProc apiHookForegroundWindow;        // instance가 여러개 만들어질 수 있으므로 non-static
        private WinApi.WinEventProc apiHookForegroundWindowTextChange; // instance가 여러개 만들어질 수 있으므로 non-static
        private static WinApi.dGetWindowText apiGetWindowText = WinApi.GetWindowText;
        private static WinApi.dGetForegroundWindow apiGetForegroundWindow = WinApi.GetForegroundWindow;
        private static WinApi.dGetWindowThreadProcessId apiGetWindowThreadProcessId = WinApi.GetWindowThreadProcessId;
        #endregion

        ProcessInfoList procInfoList;
        public ProcessInfoList ProcInfoList
        {
            get { return procInfoList; }
            private set { procInfoList = value; }
        }

        private bool isWindowTextSave;
        public bool WindowTextSaving
        {
            get { return isWindowTextSave; }
            set { isWindowTextSave = value; }
        }

        /// <summary>
        /// 현재 활성 윈도우
        /// </summary>
        private int ForegroundHandle
        {
            get { return hForeground; }
            set { hForeground = value; }
        }
        private int hForeground;

        /// <summary>
        /// <c>hookForegroundWindow</c> 후킹 코드 바인딩 결과
        /// </summary>
        private int HookCodeForeground
        {
            get { return hookCodeForeground; }
            set { hookCodeForeground = value; }
        }
        private int hookCodeForeground;

        /// <summary>
        /// <c>hookForegroundTextChange</c> 후킹 코드 바인딩 결과
        /// </summary>
        private int HookCodeForegroundTextChange
        {
            get { return hookCodeForegroundTextChange; }
            set { hookCodeForegroundTextChange = value; }
        }
        private int hookCodeForegroundTextChange;
        #endregion

        #region constructor

        public Tracer(bool windowTextSaving)
        {
            WindowTextSaving = windowTextSaving;

            HookCodeForeground = 0;
            HookCodeForegroundTextChange = 0;

            apiHookForegroundWindow = hookForegroundWindow;
            apiHookForegroundWindowTextChange = hookForegrondTextChange;

            ProcInfoList = new ProcessInfoList();
        }

        public Tracer() : this(false) { }

        ~Tracer()
        {
            StopTrace();
        }

        #endregion

        #region method

        private void hookForegroundWindow(int hWinEventHook, int iEvent, int hWnd, int idObject, int idChild, int dwEventThread, int dwmsEventTime)
        {
            if (ForegroundHandle == hWnd) return;
            ForegroundHandle = hWnd; // apiGetForegroundWindow();
            int windowHandle;
            apiGetWindowThreadProcessId(ForegroundHandle, out windowHandle);
            Process proc = Process.GetProcessById(windowHandle);
            try
            {
                if (!proc.HasExited)
                {
                    StringBuilder sb = new StringBuilder(256);
                    WinApi.GetWindowText(ForegroundHandle, sb);
                    ProcInfoList.Add(proc.MainModule.FileName);

                    if (WindowTextSaving)
                    {
                        if (HookCodeForegroundTextChange != 0) ApiHelper.EndHook(HookCodeForegroundTextChange);

                        HookCodeForegroundTextChange = ApiHelper.SetHook(WinApi.EventCode.EVENT_OBJECT_NAMECHANGE, apiHookForegroundWindowTextChange, proc.Id);
                        // Trace.WriteLine(HookCodeForegroundTextChange);
                        if (sb.ToString().Trim() == "")
                        {
                            sb.Clear();
                            sb.Append(proc.MainWindowTitle);
                        }
                        ProcInfoList.Add(proc.MainModule.FileName, sb.ToString());
                        Trace.WriteLine(sb.ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        private void hookForegrondTextChange(int hWinEventHook, int iEvent, int hWnd, int idObject, int idChild, int dwEventThread, int dwmsEventTime)
        {
            if (hWnd != ForegroundHandle) return;

            int windowHandle;
            apiGetWindowThreadProcessId(ForegroundHandle, out windowHandle);
            Process proc = Process.GetProcessById(windowHandle);
            if (!proc.HasExited)
            {
                try
                {
                    StringBuilder sb = new StringBuilder(256);
                    apiGetWindowText(ForegroundHandle, sb);
                    if (sb.ToString().Trim() == "")
                    {
                        sb.Clear();
                        sb.Append(proc.MainWindowTitle);
                    }
                    if (ProcInfoList[proc.MainModule.FileName].Last().GetCaptionData().Value.Item2 != sb.ToString())
                    {
                        Trace.WriteLine($"{ForegroundHandle} {hWnd}: {sb}");
                        ProcInfoList.Add(proc.MainModule.FileName, sb.ToString());
                    }

                }
                catch (Exception ex)
                {
#if DEBUG
                    Trace.WriteLine($"Text: {ex.Message}");
#endif
                }
            }
        }

        public Tracer RunTrace()
        {
            if (HookCodeForeground != 0) return this;
            // 이미 바인딩 중인 경우 취소
#if DEBUG
            Trace.WriteLine("트레이서 시작");
#endif   
            HookCodeForeground = ApiHelper.SetHook(WinApi.EventCode.EVENT_SYSTEM_FOREGROUND, apiHookForegroundWindow);
            if (HookCodeForeground == 0) Trace.WriteLine("Tracer 실행 실패: HookCodeForeground");

            return this;
        }

        public Tracer StopTrace()
        {
            if (HookCodeForeground != 0)
            {
                if (!ApiHelper.EndHook(HookCodeForeground)) Trace.WriteLine("Tracer 바인딩 해제 실패: HookCodeForeground");
                HookCodeForeground = 0;
                Trace.WriteLine("트레이서 종료");
            }
            // 바인딩이 안 되어 있는 경우 취소



            return this;
        }

        public void LogBackgroundTime2LastPCB()
        {
            ProcInfoList.LogBackgroundTime2LastPCB();
        }

        #endregion
    }
}

//    public class _PCB
//    {
//        [Flags]
//        public enum InnerDataFlags : uint
//        {
//            NULL =                      0x00,   // 아무 이벤트 없음
//            WINDOW_FOREGROUND =         0x01,   // Window가 Foreground로 올라옴
//            WINDOW_BACKGROUND =         0x02,   // Window가 Background로 내려감
//            WINDOW_TITLE =              0x04,   // Window의 Title을 기록함
//        }
//        InnerDataFlags containData;
//        DateTime startTime;
//        DateTime endTime;
//        List<(DateTime?, string)> windowText;

//        public _PCB(DateTime _startTime, DateTime _endTime, string _title)
//        {
//            StartTime = _startTime;
//            EndTime = _endTime;
//            windowText = new List<(DateTime?, string)>();
//            if (_title != null)
//            {
//                windowText.Add((_startTime, _title));
//            }
//        }

//        public _PCB(DateTime _startTime) : this(_startTime, DateTime.MinValue, null)
//        {
//        }

//        public _PCB() : this(DateTime.MinValue, DateTime.MinValue, null)
//        {
//        }

//        public InnerDataFlags ContainData
//        {
//            get { return containData; }
//            private set { containData = value; }
//        }

//        public DateTime StartTime
//        {
//            get { return startTime; }
//            set { startTime = value;
//                if (startTime != DateTime.MinValue) containData |= InnerDataFlags.WINDOW_FOREGROUND;
//                else containData &= ~InnerDataFlags.WINDOW_FOREGROUND;
//            }
//        }
//        public DateTime EndTime
//        {
//            get { return endTime; }
//            set { endTime = value;
//                if(startTime != DateTime.MinValue) containData |= InnerDataFlags.WINDOW_BACKGROUND;
//                else containData &= ~InnerDataFlags.WINDOW_BACKGROUND;
//            }
//        }
//        public int GetWindowCount()
//        {
//            return windowText.Count;
//        }
//        public (DateTime?, string) GetWindowTitle(int i = -1)
//        {
//            if (windowText.Count == 0) return (null, null);

//            if (i < 0) return windowText.Last();
//            else if (i < windowText.Count()) return windowText[i];
//            else return (null, null);
//        }
//        public void SaveWindowText(DateTime time, string text)
//        {
//            windowText.Add((time, text));
//        }
//        public void SaveWindowText((DateTime, string) data)
//        {
//            windowText.Add(data);
//        }
//    }

//    public class _ProcessInfoList
//    {
//        Dictionary<string, List<_PCB>> list; // 프로세스 이용 데이터를 저장한 리스트입니다.
//        string last_key;                    // 마지막 접근한 데이터입니다.

//        public _ProcessInfoList()
//        {
//            list = new Dictionary<string, List<_PCB>>();
//            last_key = null;
//        }

//        /// <summary>
//        /// 프로세스 데이터를 저장하기 위한 함수입니다. 내부 작업용.
//        /// </summary>
//        /// <param name="key">식별용 키</param>
//        /// <param name="data">넣을 데이터</param>
//        private void Add(string key, _PCB data)
//        {
//            if (last_key != null)
//            {
//                _PCB p = list[last_key].Last();
//                p.EndTime = data.StartTime;
//            }

//            if (!list.ContainsKey(key))
//            {
//                list[key] = new List<_PCB>();
//            }

//            list[key].Add(data);

//            last_key = key;
//        }

//        /// <summary>
//        /// 프로세스 정보를 ProcessInfoList에 저장합니다.
//        /// </summary>
//        /// <param name="proc">입력할 프로세스</param>
//        /// <param name="containTitle">해당 프로세스의 MainTitle을 저장할 지 여부</param>
//        public void Add(Process proc, bool containTitle)
//        {
//            _PCB d = new _PCB()
//            {
//                StartTime = DateTime.Now,
//                EndTime = DateTime.MinValue,
//            };

//            if (containTitle)
//            {
//                d.SaveWindowText(d.StartTime, proc.MainWindowTitle);
//            }

//            Add(proc.MainModule.FileName, d);
//        }

//        public void SaveWindowText(Process proc, IntPtr hWnd)
//        {
//            if (last_key == null)
//            {
//                Add(proc, true);
//                return;
//            }
//            if (!list[proc.MainModule.FileName].Last().GetWindowTitle().Item2.Equals(proc.MainWindowTitle))
//            {
//                list[proc.MainModule.FileName].Last().SaveWindowText((DateTime.Now, proc.MainWindowTitle));
//            }
//        }

//        /// <summary>
//        /// 마지막 접근 데이터의 <c>EndTime</c>에 데이터 저장이 필요할 때 사용합니다.<br/>
//        /// 예상되는 사용 위치는 데이터 저장 전, 끝맺음을 위한 호출입니다.
//        /// </summary>
//        public void LogEndProcTime()
//        {
//            if (last_key == null) return;
//            if (!list.ContainsKey(last_key)) return;

//            list[last_key].Last().EndTime = DateTime.Now;

//        }
//        /* TODO:
//         * 데이터를 저장한 후 폐기하지 않고 모으게 되면, 메모리 차지량이 늘어날 수 있음
//         * 따라서 설정에서 특정 용량 이상을 받게 되면 강제로 데이터를 파일 형태로 백업한 뒤,
//         * 저장된 데이터를 삭제한 후 초기화 상태에서 다시 받는 방향으로 개발을 진행할 것을 권고함.
//         */

//        public List<string> GetKeys()
//        {
//            return list.Keys.ToList();
//        }

//        public List<_PCB> GetData(string key)
//        {
//            if (!list.ContainsKey(key)) return null;
//            else return list[key];
//        }

//        public List<_PCB> this[string key]{
//            get { return GetData(key); }
//        }
//    }   

//    internal class _Tracer
//    {
//        _ProcessInfoList procInfoList;
//        public _ProcessInfoList ProcInfoList
//        {
//            get { return procInfoList; }
//            private set { procInfoList = value; }

//        }

//        private bool pWindowTextTracking;
//        public bool WindowTextTracking
//        {
//            get { return pWindowTextTracking; }
//            set { pWindowTextTracking = value; }
//        }

//        #region GC에 의한 삭제 방지

//        private wa.WinEventProc hEventForeground; // detect change foreground
//        private uint? hForegroundHookCode;

//        private wa.WinEventProc hEventWindowText; // detect change window text
//        private uint? hWindowTextHookCode;

//        private wa.dGetWindowText hGetWindowText = wa.GetWindowText;

//        #endregion

//        private IntPtr foreground_hWnd;


//        public _Tracer(bool windowTextTracking)
//        {
//            hForegroundHookCode = null;
//            hWindowTextHookCode = null;

//            WindowTextTracking = windowTextTracking;

//            procInfoList = new _ProcessInfoList();
//        }

//        public _Tracer() : this(false) {}

//        ~_Tracer()
//        {
//            StopTrace();
//        }
//        /// <summary>
//        /// foreground 후킹 바인딩 코드
//        /// </summary>
//        static int count = 0;
//        private void GetForeGroundWindow(IntPtr hWinEventHook, int iEvent, IntPtr hWnd, int idObject, int idChild, int dwEventThread, int dwmsEventTime)
//        {
//            this.foreground_hWnd = hWnd;
//            uint windowHandle;
//            StringBuilder sb = new StringBuilder();
//            IntPtr h = wa.GetForegroundWindow();
//            wa.GetWindowText(h, sb);
//            Trace.WriteLine(sb.ToString());
//            wa.GetWindowThreadProcessId(hWnd, out windowHandle);
//            if (windowHandle == 0) return;
//            Process proc = Process.GetProcessById((int)windowHandle);
//            ProcInfoList.Add(proc, WindowTextTracking);


//            if (WindowTextTracking) // Text 후킹 코드 체크
//            {
//                hEventWindowText = GetForegroundText;
//                if (hWindowTextHookCode != null && hWindowTextHookCode != 0)
//                {
//                    wa.UnhookWinEvent(hWindowTextHookCode ?? 0);
//                    Trace.WriteLine("해제됨");
//                }

//                hWindowTextHookCode = ah.SetHook(wa.EventCode.EVENT_OBJECT_NAMECHANGE, hEventWindowText, proc.Id);

//                if (hWindowTextHookCode == 0) Trace.WriteLine("Tracer Text 후킹 연결 실패");
//                else Trace.WriteLine("Tracer 후킹 코드 바인딩 성공");
//            }


//        }

//        private void GetForegroundText(IntPtr hWinEventHook, int iEvent, IntPtr hWnd, int idObject, int idChild, int dwEventThread, int dwmsEventTime)
//        {
//            if (hWnd != this.foreground_hWnd) return;
//            StringBuilder sb = new StringBuilder();
//            hGetWindowText(foreground_hWnd, sb);
//            Trace.WriteLine(sb);
//            uint windowHandle;
//            wa.GetWindowThreadProcessId(hWnd, out windowHandle);
//            if (windowHandle == 0) return;
//            ProcInfoList.SaveWindowText(Process.GetProcessById((int)windowHandle), hWnd);
//        }

//        public _Tracer RunTrace()
//        {
//            hEventForeground = GetForeGroundWindow;
//            if (hForegroundHookCode != null && hForegroundHookCode != 0) return this;

//            hForegroundHookCode = ah.SetHook(wa.EventCode.EVENT_SYSTEM_FOREGROUND, hEventForeground);

//            if(hForegroundHookCode == 0) Trace.WriteLine("Tracer 후킹 코드 바인딩 실패");
//            else Trace.WriteLine("Tracer 후킹 코드 바인딩 성공");

//            return this;
//        }
//        public _Tracer StopTrace()
//        {
//            if (hForegroundHookCode != null && hForegroundHookCode != 0)
//            {
//                if (ah.EndHook(hForegroundHookCode ?? 0)) Trace.WriteLine("후킹 코드 바인딩 해제 성공");
//                else Trace.WriteLine("후킹 코드 바인딩 해제 실패");
//            }

//            if (hForegroundHookCode != null && hForegroundHookCode != 0)
//            {
//                if (ah.EndHook(hWindowTextHookCode ?? 0)) Trace.WriteLine("Text 후킹 코드 바인딩 성공");
//                else Trace.WriteLine("후킹 코드 바인딩 해제 실패");
//            }

//            hEventForeground = null;
//            hEventWindowText = null;
//            return this;
//        }

//        public void SaveCurrent()
//        {
//            ProcInfoList.LogEndProcTime();
//        }


//    }
//}
