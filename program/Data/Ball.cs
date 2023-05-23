﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Ball
    {
        private Action<Ball> Detect_Collision;
        public double x { get; set; }
        public double y { get; set; }
        public double r { get; set; }

        public double mass { get; set; }
        public double XSpeed { get; set; }
        public double YSpeed { get; set; }
     





        public Ball(Action<Ball> action)
        {

            Detect_Collision = action;
            Random random = new Random();
            this.XSpeed = (random.NextDouble() * 8) - 4.0; ;
            this.YSpeed = (random.NextDouble() * 8) - 4.0; ;
            this.x = random.NextDouble() * 500;
            this.y = random.NextDouble() * 500;
            this.r = 10;
            this.mass = random.NextDouble() * 500;
        }

        public void NewBallPosition(int border, List<Ball> balls)
        {


            

            double Xtmp = x + XSpeed;
            double Ytmp = y + YSpeed;

            /*if (Xtmp < 0 || Xtmp > border)
            {
                XSpeed = -XSpeed;
            }
            if (Ytmp < 0 || Ytmp > border)
            {
                YSpeed = -YSpeed;
            }
           
            
                foreach (Ball ball in balls)
                {
                    if (ball == this)
                    {
                        continue;
                    }


                    double XS = ball.XSpeed;
                    double YS = ball.YSpeed;
                    double M = ball.mass;

                    double angle = Math.Atan2(YS, XS);

                    double energy = (XS * XS) + (YS * YS) * M / 2;

                    double dx = ball.x - x;
                    double dy = ball.y - y;
                    double distance = Math.Sqrt(dx * dx + dy * dy);
                    double minDist = ball.r + r;

                    if (distance < minDist)
                    {
                        double collisionVectorX = ball.x - x;
                        double collisionVectorY = ball.y - y;

                        double collisionVectorLength = Math.Sqrt(collisionVectorX * collisionVectorX + collisionVectorY * collisionVectorY);

                        double collisionNormalX = collisionVectorX / collisionVectorLength;
                        double collisionNormalY = collisionVectorY / collisionVectorLength;

                        double relativeVelocity = (ball.XSpeed - XSpeed) * collisionNormalX + (ball.YSpeed - YSpeed) * collisionNormalY;

                        double impulse = (-(1 + 1) * relativeVelocity) / (1 / M + 1 / ball.mass);

                        double impulseX = impulse * collisionNormalX;
                        double impulseY = impulse * collisionNormalY;

                        XSpeed -= impulseX / M;
                        YSpeed -= impulseY / M;
                        ball.XSpeed += impulseX / ball.mass;
                        ball.YSpeed += impulseY / ball.mass;

                        double overlap = minDist - distance;
                        double overlapX = collisionNormalX * overlap;
                        double overlapY = collisionNormalY * overlap;

                        x -= overlapX / 2;
                        y -= overlapY / 2;
                        ball.x += overlapX / 2;
                        ball.y += overlapY / 2;
                    }

                
            }*/


            double X2 = x + XSpeed;
            double Y2 = y + YSpeed;

            x = X2;
            y = Y2;
            Detect_Collision(this);
        }
     
    }
}


