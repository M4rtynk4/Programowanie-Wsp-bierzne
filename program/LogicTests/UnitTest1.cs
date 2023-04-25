using Logic;
using System;

namespace LogicTests

{
    [TestFixture]
    public class BallTests
    {
        private const int BORDER = 500;
        private Ball ball;

        [SetUp]
        public void Setup()
        {
            ball = new Ball();
        }

        [Test]
        public void BallNewBallPositiontest()
        {
            
            double initialX = ball.x;
            double initialY = ball.y;

            
            ball.NewBallPosition(BORDER);

            
            Assert.AreNotEqual(initialX, ball.x);
            Assert.AreNotEqual(initialY, ball.y);
        }

        [Test]
        public void BallNewBallPositiontest2()
        {
            
            ball.x = BORDER - ball.r;
            ball.XSpeed = 1;

            
            ball.NewBallPosition(BORDER);

            
            Assert.AreEqual(-1, ball.XSpeed);
        }

        [Test]
        public void BallNewBallPositiontest3()
        {
            
            ball.y = BORDER - ball.r;
            ball.YSpeed = 1;

            ball.NewBallPosition(BORDER);

            
            Assert.AreEqual(-1, ball.YSpeed);
        }

        [Test]
        public void UpBallNewBallPositiontest4()
        {
            Ball ball = new Ball();
            double positionX = ball.x;
            double positionY = ball.y;
            double xSpeed = ball.XSpeed;
            double ySpeed = ball.YSpeed;
            ball.NewBallPosition(530);
            Assert.AreEqual(ball.x, positionX + ball.XSpeed);
            Assert.AreEqual(ball.y, positionY + ball.YSpeed);
        }

    }
}