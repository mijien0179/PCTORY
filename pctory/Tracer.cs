using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;

namespace pctory
{
    /// <summary>
    /// 프로세스의 활성 정보를 담고있는 클래스입니다.
    /// </summary>
    [Serializable]
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
    [Serializable]
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
        /// [주의] key에 해당하는 리스트를 교체합니다. key에 해당하는 리스트가 없는 경우 등록됩니다.
        /// </summary>
        /// <param name="key">검사할 키</param>
        /// <param name="newData">교체/등록할 리스트</param>
        public void ReplaceList(string key, List<PCB> newData)
        {
            if (data.ContainsKey(key)) data.Remove(key);
            data.Add(key, newData);
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

        /// <summary>
        /// 관리중인 키인지 검사합니다.
        /// </summary>
        /// <param name="key">검사할 키</param>
        /// <returns>관리 여부</returns>
        public bool ContainsKey(string key) => data.ContainsKey(key);



        #endregion
    }

    public class Tracer
    {
        #region property

        #region GC 방지용
        private WinApi.WinEventProc apiHookForegroundWindow;        // instance가 여러개 만들어질 수 있으므로 non-static
        private WinApi.WinEventProc apiHookForegroundWindowTextChange; // instance가 여러개 만들어질 수 있으므로 non-static
        private static WinApi.dGetWindowText apiGetWindowText = new WinApi.dGetWindowText(WinApi.GetWindowText);
        private static WinApi.dGetForegroundWindow apiGetForegroundWindow = new WinApi.dGetForegroundWindow(WinApi.GetForegroundWindow);
        private static WinApi.dGetWindowThreadProcessId apiGetWindowThreadProcessId = new WinApi.dGetWindowThreadProcessId(WinApi.GetWindowThreadProcessId);
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

        /// <summary>
        /// 현재 활성 윈도우의 프로세스
        /// </summary>
        private string ActiveProcessPath
        {
            get { return activeProcPath; }
            set { activeProcPath = value; }
        }
        private string activeProcPath;

        /// <summary>
        /// 현재 활성화 여부
        /// </summary>
        public bool Status
        {
            get => status;
            private set => status = value;
        }
        private bool status;

        #endregion

        #region constructor

        public Tracer(bool windowTextSaving)
        {
            WindowTextSaving = windowTextSaving;

            HookCodeForeground = 0;
            HookCodeForegroundTextChange = 0;

            apiHookForegroundWindow = new WinApi.WinEventProc(hookForegroundWindow);
            apiHookForegroundWindowTextChange = new WinApi.WinEventProc(hookForegrondTextChange);

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
            try
            {
                Process proc = Process.GetProcessById(windowHandle);
                if (!proc.HasExited)
                {
                    ActiveProcessPath = proc.MainModule.FileName;
                    ProcInfoList.Add(proc.MainModule.FileName);

                    if (WindowTextSaving)
                    {

                        string sb = WinApi.GetWindowText(ForegroundHandle);

                        ProcInfoList.Add(proc.MainModule.FileName, sb.ToString());

                        if (HookCodeForegroundTextChange != 0) ApiHelper.EndHook(HookCodeForegroundTextChange);

                        HookCodeForegroundTextChange = ApiHelper.SetHook(WinApi.EventCode.EVENT_OBJECT_NAMECHANGE, apiHookForegroundWindowTextChange, proc.Id);

                    }
                }

            }
            catch (ArgumentException) { } // 이미 종료된 프로세스
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        private void hookForegrondTextChange(int hWinEventHook, int iEvent, int hWnd, int idObject, int idChild, int dwEventThread, int dwmsEventTime)
        {
            if (hWnd != ForegroundHandle || idObject != 0) return;
            ForegroundHandle = apiGetForegroundWindow();
            try
            {
                string title = WinApi.GetWindowText(ForegroundHandle);
                if (ProcInfoList[ActiveProcessPath].Last().GetCaptionData().Value.Item2 != title)
                {
                    ProcInfoList.Add(ActiveProcessPath, title);
                }

            }
            catch (Exception ex)
            {
#if DEBUG
                Trace.WriteLine($"Text: {ex.Message}");
#endif
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
            else
            {
                Status = true;
            }


            return this;
        }

        public Tracer StopTrace()
        {
            Status = false;
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
