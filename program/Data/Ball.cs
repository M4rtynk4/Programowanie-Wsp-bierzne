using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Ball
    {
        public double x { get; set; }
        public double y { get; set; }
        public double r { get; set; }

        public double w { get; set; }
        public double XSpeed { get; set; }
        public double YSpeed { get; set; }
        
        static SemaphoreSlim semaphore = new SemaphoreSlim(2);





        public Ball()
        {
            Random random = new Random();
            this.XSpeed = random.NextDouble();
            this.YSpeed = random.NextDouble();
            this.x = random.NextDouble() * 500;
            this.y = random.NextDouble() * 500;
            this.r = 10;
            this.w = random.NextDouble() * 500;
        }

        public void NewBallPosition(int border, List<Ball> balls)
        {
            semaphore.Wait();
            double Xtmp = x + XSpeed;
            double Ytmp = y + YSpeed;

            if(Xtmp+r < 0 || Xtmp+r > border) 
            {
                XSpeed = -XSpeed; 
            }
            if(Ytmp+r < 0 || Ytmp+r > border) 
            {
                YSpeed = -YSpeed;
            }
         
            foreach (Ball ball in balls)
            {
                if (ball == this)
                {
                    continue;
                }

                double dx = ball.x - x;
                double dy = ball.y - y;
                double distance = Math.Sqrt(dx * dx + dy * dy);
                double minDist = ball.r + r;

                if (distance < minDist)
                {
                    double angle = Math.Atan2(dy, dx);
                    double targetX = x + Math.Cos(angle) * minDist;
                    double targetY = y + Math.Sin(angle) * minDist;
                    double ax = (targetX - ball.x) * 0.3;
                    double ay = (targetY - ball.y) * 0.3;
                    XSpeed -= ax;
                    YSpeed -= ay;
                    ball.XSpeed += ax;
                    ball.YSpeed += ay;
                }
            }
           

            double X2 = x + XSpeed;
            double Y2 = y + YSpeed;

            x = X2;
            y = Y2;
            semaphore.Release();
        }
     
    }
}


