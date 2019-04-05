//By Krystian Horoszkiewicz
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ShutdownLogic
{
    public class ShutdownTimer
    {
        private Timer timer = new Timer();
        // Takes time in milliseconds
        public event Action timeTickEvent;
        private int seconds, minutes, hours = 0;
        public ShutdownTimer(uint millisec = 1000, bool enabled = false)
        {
            timer.Elapsed += OnTimedEvent;
            timer.Interval = millisec;
            timer.Enabled = enabled;
            timer.AutoReset = true;
        }

        public int Seconds
        {
            get
            {
                return seconds;
            }
            set
            {
                if (CheckValidTime(value))
                {
                    seconds = value;
                }
            }
        }
        public int Minutes
        {
            get
            {
                return minutes;
            }
            set
            {
                if (CheckValidTime(value))
                {
                    minutes = value;
                }
            }
        }
        public int Hours
        {
            get
            {
                return hours;
            }
            set
            {
                if (CheckValidTime(value))
                {
                    hours = value;
                }
            }
        }

        private bool CheckValidTime(int time)
        {
            if (int.TryParse(time.ToString(), out time) && time >= 0 && time <= 59)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if(timeTickEvent != null)
            {
                timeTickEvent();
                TickSecondDec();
            }
        }

        public void StartTimer()
        {
            timer.Enabled = true;
            timer.Start();
        }

        public void StopTimer()
        {
            timer.Stop();
            timer.Enabled = false;
        }

        public void ResetTimer()
        {
            Seconds = 0;
            Minutes = 0;
            Hours = 0;
        }

        public void DisposeTimer()
        {
            timer.Dispose();
        }

        public int TimeToSeconds()
        {
            return (Hours * (60 * 60)) + (Minutes * 60) + Seconds;       // Hours Minutes Seconds            
        }

        #region Time buttons functions
        public void TickSecondInc(bool onlyThisValue = false)
        {
            seconds++;
            if (seconds > 59)
            {
                Seconds = 0;
                if(!onlyThisValue)
                {
                    TickMinuteInc();
                }                
            }            
        }

        public void TickSecondDec(bool onlyThisValue = false)
        {
            seconds--;
            if (seconds < 0)
            {
                Seconds = 59;
                if (!onlyThisValue)
                {
                    TickMinuteDec();
                }
            }            
        }

        public void TickMinuteInc(bool onlyThisValue = false)
        {
            minutes++;
            if (minutes > 59)
            {
                Minutes = 0;
                if (!onlyThisValue)
                {
                    TickHourInc();
                }
            }            
        }
        public void TickMinuteDec(bool onlyThisValue = false)
        {
            minutes--;
            if (minutes < 0)
            {
                Minutes = 59;
                if (!onlyThisValue)
                {
                    TickHourDec();
                }
            }            
        }

        public void TickHourInc()
        {
            hours++;
            if (hours > 59)
            {
                Hours = 0;
            }            
        }
        public void TickHourDec()
        {
            hours--;
            if (hours < 0)
            {
                Hours = 59;
            }            
        }
        #endregion
    }
}
