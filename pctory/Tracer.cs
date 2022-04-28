using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using wa = pctory.WinApi;
using ah = pctory.ApiHelper;


namespace pctory
{
    class PCB
    {
        [Flags]
        public enum InnerDataFlags : uint
        {
            NULL =                      0x00,   // 아무 이벤트 없음
            WINDOW_FOREGROUND =         0x01,   // Window가 Foreground로 올라옴
            WINDOW_BACKGROUND =         0x02,   // Window가 Background로 내려감
            WINDOW_TITLE =              0x04,   // Window의 Title을 기록함
        }
        InnerDataFlags containData;
        DateTime startTime;
        DateTime endTime;
        string title;

        public PCB(DateTime _startTime, DateTime _endTime, string _title)
        {
            StartTime = _startTime;
            EndTime = _endTime;
            title = _title;
        }
        
        public PCB(DateTime _startTime) : this(_startTime, DateTime.MinValue, null)
        {
        }

        public PCB() : this(DateTime.MinValue, DateTime.MinValue, null)
        {
        }

        public InnerDataFlags ContainData
        {
            get { return containData; }
            private set { containData = value; }
        }

        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value;
                if (startTime != DateTime.MinValue) containData |= InnerDataFlags.WINDOW_FOREGROUND;
                else containData &= ~InnerDataFlags.WINDOW_FOREGROUND;
            }
        }
        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value;
                if(startTime != DateTime.MinValue) containData |= InnerDataFlags.WINDOW_BACKGROUND;
                else containData &= ~InnerDataFlags.WINDOW_BACKGROUND;
            }
        }
        public string WindowTitle
        {
            get { return title; }
            set { title = value;
                if (title != null) containData |= InnerDataFlags.WINDOW_TITLE;
                else containData &= ~InnerDataFlags.WINDOW_TITLE;
            }
        }
    }

    class ProcessInfoList
    {
        Dictionary<string, List<PCB>> list; // 프로세스 이용 데이터를 저장한 리스트입니다.
        string last_key;                    // 마지막 접근한 데이터입니다.

        public ProcessInfoList()
        {
            list = new Dictionary<string, List<PCB>>();
            last_key = null;
        }

        /// <summary>
        /// 프로세스 데이터를 저장하기 위한 함수입니다. 내부 작업용.
        /// </summary>
        /// <param name="key">식별용 키</param>
        /// <param name="data">넣을 데이터</param>
        private void Add(string key, PCB data)
        {
            if(last_key != null)
            {
                PCB p = list[last_key].Last();
                p.EndTime = data.StartTime;
            }

            if (!list.ContainsKey(key))
            {
                list[key] = new List<PCB>();
            }

            list[key].Add(data);

            last_key = key;
        }

        /// <summary>
        /// 프로세스 정보를 ProcessInfoList에 저장합니다.
        /// </summary>
        /// <param name="proc">입력할 프로세스</param>
        /// <param name="containTitle">해당 프로세스의 MainTitle을 저장할 지 여부</param>
        public void Add(Process proc, bool containTitle)
        {
            PCB d = new PCB()
            {
                StartTime = DateTime.Now,
                EndTime = DateTime.MinValue,
            };

            if (containTitle)
            {
                d.WindowTitle = proc.MainWindowTitle;
            }

            Add(proc.MainModule.FileName, d);
        }

        /// <summary>
        /// 마지막 접근 데이터의 <c>EndTime</c>에 데이터 저장이 필요할 때 사용합니다.<br/>
        /// 예상되는 사용 위치는 데이터 저장 전, 끝맺음을 위한 호출입니다.
        /// </summary>
        public void LogEndProcTime()
        {
            if (last_key == null) return;
            if (!list.ContainsKey(last_key)) return;

            list[last_key].Last().EndTime = DateTime.Now;

        }
        /* TODO:
         * 데이터를 저장한 후 폐기하지 않고 모으게 되면, 메모리 차지량이 늘어날 수 있음
         * 따라서 설정에서 특정 용량 이상을 받게 되면 강제로 데이터를 파일 형태로 백업한 뒤,
         * 저장된 데이터를 삭제한 후 초기화 상태에서 다시 받는 방향으로 개발을 진행할 것을 권고함.
         */

        public List<string> GetKeys()
        {
            return list.Keys.ToList();
        }

        public List<PCB> GetData(string key)
        {
            if (!list.ContainsKey(key)) return null;
            else return list[key];
        }

    }   

    internal class Tracer
    {
        private uint? hHookCode;
        ProcessInfoList procInfoList;

        private wa.WinEventProc handler; //GC에 의한 이동 방지

        public ProcessInfoList ProcInfoList
        {
            get { return procInfoList; }
            private set { procInfoList = value; }

        }

        public Tracer()
        {
            hHookCode = null;
            procInfoList = new ProcessInfoList();
        }
        ~Tracer()
        {
            StopTrace();
        }
        /// <summary>
        /// 후킹 바인딩 코드
        /// </summary>
        private void GetForeGroundWindow(IntPtr hWinEventHook, int iEvent, IntPtr hWnd, int idObject, int idChild, int dwEventThread, int dwmsEventTime)
        {
            uint windowHandle;

            wa.GetWindowThreadProcessId(hWnd, out windowHandle);
            if (windowHandle == 0) return;

            ProcInfoList.Add(Process.GetProcessById((int)windowHandle), true);

        }
        
        public Tracer RunTrace()
        {
            handler = GetForeGroundWindow;
            if (hHookCode != null && hHookCode != 0) return this;

            hHookCode = ah.SetHook(wa.EventCode.EVENT_SYSTEM_FOREGROUND, handler);

            if(hHookCode == 0) Trace.Write("Tracer 후킹 코드 바인딩 실패");
            else Trace.Write("Tracer 후킹 코드 바인딩 성공");
            return this;
        }
        public Tracer StopTrace()
        {
            if (hHookCode != null && hHookCode != 0)
            {
                if (ah.EndHook(hHookCode ?? 0)) Trace.WriteLine("후킹 코드 바인딩 해제 성공");
                else Trace.WriteLine("후킹 코드 바인딩 해제 실패");
            }
            handler = null;
            return this;
        }


    }
}
