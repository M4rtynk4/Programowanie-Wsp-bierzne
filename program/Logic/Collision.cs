using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Collision
    {
        public static void DetectCollisionsWall(int border, List<Ball> balls)
        {


            foreach (Ball ball1 in balls)
            {


                double Xtmp = ball1.x + ball1.XSpeed;
                double Ytmp = ball1.y + ball1.YSpeed;

                if (Xtmp < 0 || Xtmp > border)
                {
                    ball1.XSpeed = -ball1.XSpeed;
                }
                if (Ytmp < 0 || Ytmp > border)
                {
                    ball1.YSpeed = -ball1.YSpeed;
                }

            }

        }
        static object _lock = new();

        public static void DetectCollisions(Ball ball1, List<Ball> balls)
        {
            lock (_lock)
            {
                foreach (Ball ball in balls)
                {
                    if (ball == ball1)
                    {
                        continue;
                    }


                  
                    double M = ball.mass;


                    double dx = ball.x - ball1.x;
                    double dy = ball.y - ball1.y;
                    double distance = Math.Sqrt(dx * dx + dy * dy);
                    double minDist = ball.r + ball1.r;

                    if (distance < minDist)
                    {
                        double collisionVectorX = ball.x - ball1.x;
                        double collisionVectorY = ball.y - ball1.y;

                        double collisionVectorLength = Math.Sqrt(collisionVectorX * collisionVectorX + collisionVectorY * collisionVectorY);

                        double collisionNormalX = collisionVectorX / collisionVectorLength;
                        double collisionNormalY = collisionVectorY / collisionVectorLength;

                        double relativeVelocity = (ball.XSpeed - ball1.XSpeed) * collisionNormalX + (ball.YSpeed - ball1.YSpeed) * collisionNormalY;

                        double impulse = (-(1 + 1) * relativeVelocity) / (1 / M + 1 / ball.mass);

                        double impulseX = impulse * collisionNormalX;
                        double impulseY = impulse * collisionNormalY;

                        ball1.XSpeed -= impulseX / M;
                        ball1.YSpeed -= impulseY / M;
                        ball.XSpeed += impulseX / ball.mass;
                        ball.YSpeed += impulseY / ball.mass;

                        double overlap = minDist - distance;
                        double overlapX = collisionNormalX * overlap;
                        double overlapY = collisionNormalY * overlap;

                        ball1.x -= overlapX / 2;
                        ball1.y -= overlapY / 2;
                        ball.x += overlapX / 2;
                        ball.y += overlapY / 2;
                    }

                }
            }
        }
    
    }
}


