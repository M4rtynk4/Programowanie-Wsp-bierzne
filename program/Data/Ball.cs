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
        public double XSpeed { get; set; }
        public double YSpeed { get; set; }




        public Ball()
        {
            Random random = new Random();
            this.XSpeed = random.NextDouble() * 10;
            this.YSpeed = random.NextDouble() * 10;
            this.x = random.NextDouble() * 500;
            this.y = random.NextDouble() * 500;
            this.r = 10;
        }

        public void NewBallPosition(int border)
        {
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

            double X2 = x + XSpeed;
            double Y2 = y + YSpeed;

            x = X2;
            y = Y2;
        }
     
    }
}


