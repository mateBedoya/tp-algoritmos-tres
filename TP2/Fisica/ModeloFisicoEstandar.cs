using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2.Fisica
{
    /// <summary>
    /// Esta clase es solo para especificar un modelo fisico estandar
    /// para cada entidad creada, abstrayendose de las entidades en si
    /// </summary>
    
    public abstract class ModeloFisicoEstandar
    {
        private Figura figura;

        // crea un modelo fisico para una entidad
        public ModeloFisicoEstandar(Figura figura)
        {
            this.figura = figura;
        }

        // retorna la figura que lo representa
        public Figura GetFigura()
        {
            return (this.figura);
        }

        // retorna si el modelo fisico se superpone con el pasado
        public bool SeIntersecaCon(ModeloFisicoEstandar modelo)
        {
            return (this.figura.SeIntersecaConElCirculo(modelo.GetFigura()));
        }
    }
}
