using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AlarmClock
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                AlarmClock clock = new AlarmClock(); 

                clock.AlarmTime = new ClockTime(DateTime.Now.Hour,DateTime.Now.Minute,DateTime.Now.Second + 5);
                clock.TickEvent += ShowTime;
                clock.AlarmEvent += PlayMusic;
                new Thread(clock.Run).Start();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private static void ShowTime(AlarmClock sender)
        {
            ClockTime time = sender.CurrentTime;
            Console.WriteLine($"Tick Event: " +$"{time.Hour}:{time.Minute}:{time.Second}");
        }

        public static void PlayMusic(AlarmClock sender)
        {
            ClockTime time = sender.CurrentTime;
            Console.WriteLine($"Alarm Event: {time.Hour}:{time.Minute}:{time.Second}");
            Console.WriteLine("Playing music....");
        }
    }
    class AlarmClock
    {

        public event Action<AlarmClock> AlarmEvent;

        public event Action<AlarmClock> TickEvent;

        public AlarmClock()
        {
            CurrentTime = new ClockTime();
        }

        public ClockTime CurrentTime { get; set; }

        public ClockTime AlarmTime { get; set; }

        /// start a clock, and keep it run
        public void Run()
        {
            while (true)
            {
                DateTime now = DateTime.Now;
                CurrentTime = new ClockTime(now.Hour, now.Minute, now.Second);
                TickEvent(this);
                if (AlarmTime.Equals(CurrentTime))
                    AlarmEvent(this);
                Thread.Sleep(1000);
            }
        }
    }
    class ClockTime
    {

        private int hour;
        private int minute;
        private int second;

        public ClockTime(int hour = 0, int minute = 0, int second = 0)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }

        public int Hour
        {
            get { return hour; }
            set
            {
                if (value < 0 || value > 24) throw new ArgumentOutOfRangeException("invalid hour!");
                hour = value;
            }
        }

        public int Minute
        {
            get { return minute; }
            set
            {
                if (value < 0 || value > 60)
                {
                    throw new ArgumentOutOfRangeException("minute invalid!");
                }
                minute = value;
            }
        }

        public int Second
        {
            get { return second; }
            set
            {
                if (value < 0 || value > 60)
                {
                    throw new ArgumentOutOfRangeException("invalid second!");
                }
                second = value;
            }
        }

        public override bool Equals(object obj)
        {
            var time = obj as ClockTime;
            return time != null &&
                   Hour == time.Hour &&
                   Minute == time.Minute &&
                   Second == time.Second;
        }

        public override int GetHashCode()
        {
            var hashCode = 1505761165;
            hashCode = hashCode * -1521134295 + Hour.GetHashCode();
            hashCode = hashCode * -1521134295 + Minute.GetHashCode();
            hashCode = hashCode * -1521134295 + Second.GetHashCode();
            return hashCode;
        }
    }
}
