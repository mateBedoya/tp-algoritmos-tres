using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2.Fisica;

namespace TP2.Interfaces
{
    public interface Interactuable
    {
        void Posicionar(Punto posicion);

        Punto GetPosicion();

        void Direccionar(double direccion);

        double GetDireccion();

        ModeloFisicoEstandar GetModelo();

        bool EstaDentroDeLosLimites(Punto inferior, Punto superior);

        bool EnColisionCon(Interactuable interactuable);

        void InteractuarCon(Interactuable interactuable);
    }
}
