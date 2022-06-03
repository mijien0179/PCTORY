using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

namespace pctory
{
    /// <summary>
    /// 특정 시간이 지났을 때 이벤트 발생
    /// </summary>
    public class DayTrace
    {
        public event EventHandler DayChanged;

        private DateTime bDate;

        private Thread thread;

        public DayTrace(EventHandler handler)
        {
            DayChanged += handler;
            bDate = DateTime.Today;
            thread = new Thread(TimeChecker);
            thread.Start();
        }

        private void TimeChecker()
        {
            DateTime now = DateTime.Today;
            if(bDate.Day != now.Day)
            {
                DayChanged(this, new EventArgs());
            }
            bDate = now;
            Thread.Sleep(3000);
            TimeChecker();
        }

        ~DayTrace()
        {
            if(thread != null && thread.IsAlive)
            {
                if (!thread.Join(3000))
                {
                    thread.Abort();
                }

            }
        }
    }
}
