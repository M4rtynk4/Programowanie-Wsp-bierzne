using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Logic
{
    public class Board
    {
       
       
        public int size { get; set; }
        public List<Ball> balls { get; set; }
        private int time = 20;
        public bool ThreadStop { get; set; }
        public Board(int size) 
        {   
            ThreadStop = true;  
            this.size = size;
            balls = new List<Ball>();
        }

        public void AddBalls(int BallsNumber)
        {
            for (int i = 0; i < BallsNumber; i++)
            {
                balls.Add(new Ball());
            }

        }
        public void RemoveBalls(int BallsNumer)
        {
            for(int j = 0; j < BallsNumer; j++)
            {
                balls.RemoveAt(j);
            }
               
        }

        public void Move()
        {
            foreach(Ball ball in balls)
            {
                Thread watek = new Thread(() => {
                while (!ThreadStop)
                {

                    ball.NewBallPosition();
                    Collision.DetectCollisionsWall(size, balls);
                    Collision.DetectCollisions(ball, balls);
                    Thread.Sleep(time);
                        

                    }
                    });
                watek.Start();
            }

        }
        
       

    }
}
