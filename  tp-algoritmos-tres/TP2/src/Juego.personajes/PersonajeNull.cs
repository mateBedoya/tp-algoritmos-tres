﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2.Juego.personajes
{
    /// <summary>
    /// Esta clase solo es utilizada para inicializar un objeto
    /// de tipo obstaculo en nulo (patron null object)
    /// </summary>
    public class PersonajeNull : Personaje
    {
         private static PersonajeNull INSTANCIA = null;

        // solo puede crearse una sola instancia de esta clase
         private PersonajeNull()
            : base() { }

        // retorna la instancia
         public static PersonajeNull GetInstancia()
        {
            if (INSTANCIA == null)
                INSTANCIA = new PersonajeNull();
            return (INSTANCIA);
        }
    }
}