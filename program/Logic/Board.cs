﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Board
    {   
        public int size { get; set; }
        public List<Ball> balls { get; set; }
        private Task ChangePosition;
        private int time = 20;

        public Board(int size) 
        {
            this.size = size;
            balls = new List<Ball>();
        }

        public void AddBalls(int BallsNumber)
        {
            for(int i = 0; i < BallsNumber; i++) 
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
                ball.NewBallPosition(size);
            }

        }
  
        public void StartMoving()
        {
            ChangePosition = new Task(() =>
            {
                while (true)
                {
                    Move();
                    Thread.Sleep(time);

                }
            });
            ChangePosition.Start();
            
        }

    }
}