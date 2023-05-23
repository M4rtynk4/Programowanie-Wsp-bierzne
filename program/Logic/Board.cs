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
        private object _locker = new object();
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
            for(int i = 0; i < BallsNumber; i++) 
            {
                balls.Add(new Ball((ball) => Collision.DetectCollisions(ball, balls)));
            }

        }
        public void RemoveBalls(int BallsNumer)
        {
            for(int j = 0; j < BallsNumer; j++)
            {
                balls.RemoveAt(j);
            }
               
        }

        /*
        public void Collision(Ball ball_2)
        {
            lock (_locker)
            {
                foreach (Ball ball in balls)
                {
                    if (ball == ball_2)
                    {
                        continue;
                    }


                    double XS = ball.XSpeed;
                    double YS = ball.YSpeed;
                    double M = ball.mass;

                    double angle = Math.Atan2(YS, XS);

                    double energy = (XS * XS) + (YS * YS) * M / 2;

                    double dx = ball.x - ball_2.x;
                    double dy = ball.y - ball_2.y;
                    double distance = Math.Sqrt(dx * dx + dy * dy);
                    double minDist = ball.r + ball_2.r;

                    if (distance < minDist)
                    {
                        double collisionVectorX = ball.x - ball_2.x;
                        double collisionVectorY = ball.y - ball_2.y;

                        double collisionVectorLength = Math.Sqrt(collisionVectorX * collisionVectorX + collisionVectorY * collisionVectorY);

                        double collisionNormalX = collisionVectorX / collisionVectorLength;
                        double collisionNormalY = collisionVectorY / collisionVectorLength;

                        double relativeVelocity = (ball.XSpeed - ball_2.XSpeed) * collisionNormalX + (ball.YSpeed - ball_2.YSpeed) * collisionNormalY;

                        double impulse = (-(1 + 1) * relativeVelocity) / (1 / M + 1 / ball.mass);

                        double impulseX = impulse * collisionNormalX;
                        double impulseY = impulse * collisionNormalY;

                        ball_2.XSpeed -= impulseX / M;
                        ball_2.YSpeed -= impulseY / M;
                        ball.XSpeed += impulseX / ball.mass;
                        ball.YSpeed += impulseY / ball.mass;

                        double overlap = minDist - distance;
                        double overlapX = collisionNormalX * overlap;
                        double overlapY = collisionNormalY * overlap;

                        ball_2.x -= overlapX / 2;
                        ball_2.y -= overlapY / 2;
                        ball.x += overlapX / 2;
                        ball.y += overlapY / 2;
                    }

                }
            }
        }
        */


        public void Move()
        {
            foreach(Ball ball in balls)
            {
                Thread watek = new Thread(() => {
                    while (!ThreadStop)
                    {
                        
                        ball.NewBallPosition(size, balls);
                        Collision.DetectCollisionsWall(size, balls);
                        Thread.Sleep(time);
                        

                    }
                    });
                watek.Start();
            }

        }
        
       

    }
}
