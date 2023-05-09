using Data;
using System;

namespace DataTests
{
 
    public class BallTests
    {
       

        [Test]
        public void NewBallPosition_ReversesXSpeedWhenOutOfBorder()
        {
            
            int border = 500;
            Ball ball = new Ball();
            ball.x = border - ball.r + 1; // Ball is positioned at the right border
            List<Ball> balls = new List<Ball>();
            double initialXSpeed = ball.XSpeed;
            ball.NewBallPosition(border, balls);

            
            Assert.AreEqual(-initialXSpeed, ball.XSpeed);
        }

        [Test]
        public void NewBallPosition_ReversesYSpeedWhenOutOfBorder()
        {
           
            int border = 500;
            Ball ball = new Ball();
            ball.y = border - ball.r + 1; // Ball is positioned at the bottom border
            List<Ball> balls = new List<Ball>();
            double initialYSpeed = ball.YSpeed;
            ball.NewBallPosition(border, balls);

            
            Assert.AreEqual(-initialYSpeed, ball.YSpeed);
        }
    }

}