using System;
using System.Collections.Concurrent;
using System.IO;
using System.Timers;

namespace Data
{
    public class Log
    {
        private BlockingCollection<string> buffer = new BlockingCollection<string>();
        private StreamWriter sw;
        private System.Timers.Timer timer;
        private object lockObject = new object();

        public Log()
        {
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += TimerElapsed;
            timer.Start();
        }

        public void AddToBuffer(Ball ball)
        {
            string time = DateTime.Now.ToString("h:mm:ss.fff tt");
            string log = $"{time} Ruch piłki numer {ball.Id}: Pozycja: x={Math.Round(ball.x, 5)}, y={Math.Round(ball.y, 5)}, Przemieszczenie: x={Math.Round(ball.XSpeed, 5)}, y={Math.Round(ball.YSpeed, 5)}";
            buffer.Add(log);
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            Write();
        }

        public void Write()
        {
            lock (lockObject)
            {
                using (sw = new StreamWriter("../../../../Data/log.txt", append: true))
                {
                    while (buffer.TryTake(out string log))
                    {
                        sw.WriteLine(log);
                    }
                }
            }
        }
    }
}
