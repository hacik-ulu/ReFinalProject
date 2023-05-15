using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult :Result
    {
        // base -- SuccesResult Classı
        // true döndürüp mesaj vermek istiyorsak.
        public SuccessResult(string message) : base(true,message)
        {

        }

        // yalnız true döndürmek istersek.
        public SuccessResult() : base(true)
        {

        }
    }
}
