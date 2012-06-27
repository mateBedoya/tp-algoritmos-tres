using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoombermanGame.src.excepciones;

namespace BoombermanGame.src.articulos
{
    public class FabricaDeArticulos
    {
        private static FabricaDeArticulos INSTANCIA = null;
        private static int PRIORIDAD_TOLETOLE = 5;
        private static int PRIORIDAD_HABANO = 10;
        private static int PRIORIDAD_TIMER = 15;
        private static int RANGO_DE_PRIORIDAD = 50;

        // solo puede crearse una instancia de esta clase
        private FabricaDeArticulos() { }


        // retorna la instancia
        public static FabricaDeArticulos GetInstancia()
        {
            if (INSTANCIA == null)
                INSTANCIA = new FabricaDeArticulos();
            return (INSTANCIA);
        }


        // retorna un articulo si la prioridad obtenida es coincidente 
        // con alguna de las prioridades definidas
        public Articulo SolicitarArticulo()
        {
            Random rand = new Random();
            int prioridadObtenida = rand.Next(RANGO_DE_PRIORIDAD);
            if (prioridadObtenida == PRIORIDAD_TOLETOLE)
                return (new BombaToleTole());
            if (prioridadObtenida == PRIORIDAD_HABANO)
                return (new Habano());
            if (prioridadObtenida == PRIORIDAD_TIMER)
                return (new Timer());
            throw new ArticuloVacioError();
        }
    }
}
