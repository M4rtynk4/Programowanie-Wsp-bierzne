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


    public static void DetectCollisions(int border, List<Ball> balls)
        {
            object _lock = new();

            lock (_lock)
            {


                foreach (Ball ball1 in balls)
                {
                    foreach (Ball ball2 in balls)
                    {
                        if (ball1 == ball2)
                        {
                            continue;
                        }




                        double XS = ball1.XSpeed;
                        double YS = ball1.YSpeed;
                        double M = ball1.mass;

                        double dx = ball1.x - ball2.x;
                        double dy = ball1.y - ball2.y;
                        double distance = Math.Sqrt(dx * dx + dy * dy);
                        double minDist = ball1.r + ball2.r;

                        if (distance < minDist)
                        {
                            double collisionVectorX = ball1.x - ball2.x;
                            double collisionVectorY = ball1.y - ball2.y;
                        
                            ball2.YSpeed *= -1;
                           
                            ball2.XSpeed *= -1;

                           /* double collisionVectorLength = Math.Sqrt(collisionVectorX * collisionVectorX + collisionVectorY * collisionVectorY);

                            double collisionNormalX = collisionVectorX / collisionVectorLength;
                            double collisionNormalY = collisionVectorY / collisionVectorLength;

                            double relativeVelocity = (ball1.XSpeed - ball2.XSpeed) * collisionNormalX + (ball1.YSpeed - ball2.YSpeed) * collisionNormalY;
                            double impulse = (-(1 + 1) * relativeVelocity) / (1 / M + 1 / ball1.mass);

                            double impulseX = impulse * collisionNormalX;
                            double impulseY = impulse * collisionNormalY;

                            ball1.XSpeed -= impulseX / M;
                            ball1.YSpeed -= impulseY / M;
                            ball1.XSpeed += impulseX / ball2.mass;
                            ball1.YSpeed += impulseY / ball2.mass;

                            double overlap = minDist - distance;
                            double overlapX = collisionNormalX * overlap;
                            double overlapY = collisionNormalY * overlap;

                            ball2.x -= overlapX / 2;
                            ball2.y -= overlapY / 2;
                            ball1.x += overlapX / 2;
                            ball1.y += overlapY / 2;*/
                        }
                    }

                }
            }
        }
    }
}


