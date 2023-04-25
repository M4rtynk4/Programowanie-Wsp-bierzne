using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace Model
{
    public class BallModel
    {
        private Ball ball;
        private double x;
        private double y;
        
        public BallModel(Ball ball)
        {
            this.ball = ball;
        }
        public double X 
        {
            get { return ball.x; }
        }
        public double Y
        { 
            get { return ball.y; }
        }
       
    }
    
}
