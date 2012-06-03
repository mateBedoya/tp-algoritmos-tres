using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2_Bomberman.src.Articulos
{
    /// <summary>
    /// Esta clase solo es utilizada para inicializar un objeto
    /// de tipo articulo en nulo (patron null object)
    /// </summary>
    public class ArticuloNull : Articulo
    {
        private static ArticuloNull INSTANCIA = null;

        // solo puede crearse una sola instancia de esta clase
        private ArticuloNull()
            : base() { }

        // retorna la instancia
        public static ArticuloNull GetInstancia()
        {
            if (INSTANCIA == null)
                INSTANCIA = new ArticuloNull();
            return (INSTANCIA);
        }

        //sin implementacion
        public override bool FueDestruido() { return true; }
        public override void DaniarConMolotov(Molotov molotov) { }
        public override void DaniarConToleTole(Bombas.ToleTole toleTole) { }
        public override void DaniarConProyectil(Bombas.Proyectil proyectil) { }
    }
}
