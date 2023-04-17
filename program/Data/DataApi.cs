using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;


namespace Data
{

    public abstract class DataAbstractApi
    {
        public abstract Ball CreateBall(int xposition, int yposition, int radius);
     //   public abstract List<Ball> GetBall();
       // public abstract int BoardWidth { get; }
       // public abstract int BoardHeight { get; }
       // public abstract void Disable();
       // public abstract void CreateBoard(int width, int height);
             public static DataAbstractApi CreateAPI()
        {
            return new DataAPI();
        }
         internal sealed class DataAPI : DataAbstractApi
        {
            public override Ball CreateBall(int xposition, int yposition, int radius)
            {
                return new Ball(xposition, yposition, radius);
            }

            

        }

     }

    
}

