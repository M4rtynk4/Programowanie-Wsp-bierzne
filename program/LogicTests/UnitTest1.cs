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

       


    }
}
