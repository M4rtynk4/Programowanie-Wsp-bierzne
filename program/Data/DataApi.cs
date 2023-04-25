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
        //Metoda „CreateApi” klasy „DataAbstractApi” zwraca nową instancję klasy „DataApi”.
        public static DataAbstractApi CreateApi()
        {
            return new DataApi();
        }
    }
        // klasa wewnętrzna DataApi dziedzicząca z DataAbstractApi
            internal sealed class DataApi : DataAbstractApi
        {
            //coś w przyszłości być może powstanie tutaj :)
        }
    
}

