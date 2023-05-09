using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class LogicAbstractApi
    {
        public abstract void CreateBalls(int x);
        public abstract List<Ball> GetBalls();
        public abstract void start();
        public abstract void stop();
        public static LogicAbstractApi CreateApi(DataAbstractApi dane = default(DataAbstractApi))
        {
            return new LogicApi(dane == null ? DataAbstractApi.CreateApi() : dane);

        
                 /*w klasie LogicAbstractApi tworzony jest nowy obiekt klasy LogicApi z wstrzykiwanym (w tym przypadku obiektem klasy DataAbstractApi)
                 a nastepnie ten obiekt jest zwracany jako interfejs LogicAPI
                 dzieki temu mamy moziwosc uzywania interfejsu LogicAPI bez koniecznosci wiedzenia, jakie dokladnie obiekty sa w nim wykorzystywane*/
        }
    }
        internal class LogicApi : LogicAbstractApi
        {
            private DataAbstractApi dataApi;
            private Task ChangePosition;
            private Board board;
            public LogicApi(DataAbstractApi dataApii)
            {
                this.dataApi = dataApii;
                board = new Board(500);
            }
            public override void CreateBalls(int amound) 
            {
                board.AddBalls(amound);
            }
            public override List<Ball> GetBalls() 
            {
                return board.balls;
            }
            public override void start() 
            {
                board.ThreadStop = false;
                if (board.balls.Count > 0)
                {
                    ChangePosition = Task.Run(board.StartMoving);
                }
            }
             public override void stop() 
             {
                board.balls.Clear();
                board.ThreadStop=true;
               
             }
        }
    }
