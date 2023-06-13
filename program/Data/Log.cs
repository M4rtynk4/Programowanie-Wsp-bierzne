using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading.Tasks;

namespace Data
{
    public class Log 
    {
        private BlockingCollection<string> buffer = new BlockingCollection<string>();
        private Task fileWriter;
        private StreamWriter sw;
        public Log()
        {
            
            fileWriter = new Task(() => Write());
            fileWriter.Start();
             
        }

   
        public void AddToBuffer(Ball ball)
        {
                string time = DateTime.Now.ToString("h:mm:ss.fff tt");
                string log = $"{time} Ruch piłki numer {ball.Id}: Pozycja: x={Math.Round(ball.x, 5)}, y={Math.Round(ball.y, 5)}, Przemieszczenie: x={Math.Round(ball.XSpeed, 5)}, y={Math.Round(ball.YSpeed, 5)}";
                buffer.Add(log);
            
        }

       

        public void Write()
        {
            
                using (sw = new StreamWriter("../../../../Data/log.txt", append: false))
                {
                    foreach (string log in buffer.GetConsumingEnumerable())
                    {
                        sw.WriteLine(log);
                    }
                }
            
        }
    }
}
