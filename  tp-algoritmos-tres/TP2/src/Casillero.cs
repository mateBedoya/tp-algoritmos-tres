using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2
{
    class Casillero
    {
        private int fila;
        private int columna;

        public Casillero(int x, int y)
        {
            this.fila = x;
            this.columna = y;
        }

        public int Columna
		{
			get { return this.columna; }
		}

		public int Fila
		{
			get { return this.fila; }
		}
    }
}
