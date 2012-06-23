using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2.Elementales;

namespace Boomberman.src.interfaces
{
    public interface IPosicionable
    {
        Casilla Posicion();

        string GetDescripcion();

        int X();

        int Y();

        bool DejaDePosisionarse();
    }
}
