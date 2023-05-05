using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Model
{
    public abstract class ModelAbstractApi
    {
        public abstract List<BallModel> balls { get; }
        public abstract void addBalls(int ballsNumber);

        public abstract void removeBalls();

        public static ModelAbstractApi CreateApi()
        {
            return new ModelApi();
        }

        internal class ModelApi : ModelAbstractApi
        {
            private LogicAbstractApi logicApi;

            public override List<BallModel> balls
            {
                get
                {
                    return ChangeBallToBallInModel();
                }
            }

            public ModelApi()
            {
                logicApi = logicApi ?? LogicAbstractApi.CreateApi(); // jezli wartosc logicApi jest równa null, to zostanie
                                                                     // utworzony nowy obiekt LogicAPI za pomocą metody statycznej Create
            }

            public override void addBalls(int ballsNumber)
            {
                logicApi.CreateBalls(ballsNumber);
                logicApi.start();
            }

            public List<BallModel> ChangeBallToBallInModel()
            {
                List<BallModel> result = new List<BallModel>();

                foreach (Ball ball in logicApi.GetBalls())
                {
                    result.Add(new BallModel(ball));
                }
                return result;
            }

            public override void removeBalls()
            {
                logicApi.stop();
            }
        }
    }
}

