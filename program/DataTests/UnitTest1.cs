using Data;
using System;

namespace DataTests
{
 
    public class BallTests
    {
        [Test]
        public void NewBallPosition_ShouldUpdateBallCoordinates()
        {

            Ball ball = new Ball();
            ball.x = 50;
            ball.y = 50;
            ball.XSpeed = 2;
            ball.YSpeed = 3;

            ball.NewBallPosition();


            Assert.AreEqual(52, ball.x);
            Assert.AreEqual(53, ball.y);


            ball.XSpeed = -10;
            ball.YSpeed = -8;


            ball.NewBallPosition();

            Assert.AreEqual(42, ball.x);
            Assert.AreEqual(45, ball.y);
        }
    }

}