using Data;
using Logic;
using System;

namespace LogicTests

{
    public class BoardTests
    {
        [Test]
        public void AddBalls_Test()
        {

            int size = 5;
            int ballsNumber = 3;
            Board board = new Board(size);


            board.AddBalls(ballsNumber);


            Assert.AreEqual(ballsNumber, board.balls.Count);
        }

        [Test]
        public void RemoveBalls_Test()
        {

            int size = 5;
            int initialBallsNumber = 5;
            int ballsToRemove = 3;
            Board board = new Board(size);
            board.AddBalls(initialBallsNumber);
            board.RemoveBalls(ballsToRemove);
            Assert.AreEqual(initialBallsNumber - ballsToRemove, board.balls.Count);
        }
        [Test]
        public void DetectCollisionsWall_test()
        {

            int border = 500;
            Ball ball = new Ball();
            ball.y = border + 1;
            ball.YSpeed = 3;
            List<Ball> balls = new List<Ball> { ball };

            double initialYSpeed = ball.YSpeed;

            Collision.DetectCollisionsWall(border, balls);

            Assert.AreEqual(-initialYSpeed, ball.YSpeed);
        }
        

        [Test]
        public void DetectCollisions_test()
        {
            
            Ball ball1 = new Ball();
            ball1.mass = 1;
            ball1.x = 0;
            ball1.y = 0;
            ball1.XSpeed = 1;
            ball1.YSpeed = 0;

            Ball ball2 = new Ball();
            ball2.mass = 2;
            ball2.x = 3;
            ball2.y = 0;
            ball2.XSpeed = -1;
            ball2.YSpeed = 0;

            List<Ball> balls = new List<Ball> { ball1, ball2 };

            
            Collision.DetectCollisions(ball1, balls);

            
            Assert.AreEqual(-1, ball1.XSpeed);
            Assert.AreEqual(0, ball1.YSpeed);
            Assert.AreEqual(1, ball2.XSpeed);
            Assert.AreEqual(0, ball2.YSpeed);
            Assert.AreEqual(-0.5, ball1.x);
            Assert.AreEqual(0, ball1.y);
            Assert.AreEqual(0.5, ball2.x);
            Assert.AreEqual(0, ball2.y);
        }
    }
}


