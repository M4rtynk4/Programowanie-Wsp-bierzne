using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Ball
    {
        private static int IId = 1;
        public double x { get; set; }
        public double y { get; set; }
        public double r { get; set; }
        public int Id { get; set; }
        public double mass { get; set; }
        public double XSpeed { get; set; }
        public double YSpeed { get; set; }
   


        public Ball()
        {

            this.Id = IId++;
            Random random = new Random();
            this.XSpeed = (random.NextDouble() * 8) - 4.0; ;
            this.YSpeed = (random.NextDouble() * 8) - 4.0; ;
            this.x = random.NextDouble() * 500;
            this.y = random.NextDouble() * 500;
            this.r = 10;
            this.mass = random.NextDouble() * 500;
        }

        public void NewBallPosition()
        {            


            double X2 = x + XSpeed;
            double Y2 = y + YSpeed;

            x = X2;
            y = Y2;
        
        }
     
    }
}


