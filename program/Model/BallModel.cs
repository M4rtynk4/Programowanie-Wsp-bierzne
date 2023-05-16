using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;
using Data;

namespace Model
{
    public class BallModel
    {
        private Ball ball;
        
        
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
