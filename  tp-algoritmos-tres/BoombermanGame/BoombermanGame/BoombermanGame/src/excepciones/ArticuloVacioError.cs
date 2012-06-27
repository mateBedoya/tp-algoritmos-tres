using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoombermanGame.src.excepciones
{
    public class ArticuloVacioError : Exception
    {
        public ArticuloVacioError() { }

        public void NoHacerNada() { }
    }
}
