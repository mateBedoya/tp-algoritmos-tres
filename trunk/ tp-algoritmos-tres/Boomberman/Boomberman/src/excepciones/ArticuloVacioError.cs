using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2.src.excepciones
{
    public class ArticuloVacioError : Exception
    {
        public ArticuloVacioError() { }

        public void NoHacerNada() { }
    }
}
