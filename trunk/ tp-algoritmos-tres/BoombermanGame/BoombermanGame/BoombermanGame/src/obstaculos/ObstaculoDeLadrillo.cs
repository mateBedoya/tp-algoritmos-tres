using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoombermanGame.src.elementales;
using BoombermanGame.src.bombas;

namespace BoombermanGame.src.obstaculos
{
    public class ObstaculoDeLadrillo : Obstaculo
    {
        private static int DURABILIDAD = 5;
        private int durabilidad;

        // crea un obstaculo de ladrillo
        public ObstaculoDeLadrillo()
            : base()
        {
            this.durabilidad = DURABILIDAD;
        }


        // crea un obstaculo de ladrillo
        public ObstaculoDeLadrillo(Casilla posicion)
            : base(posicion)
        {
            this.durabilidad = DURABILIDAD;
        }


        // crea un obstaculo de ladrillo
        public ObstaculoDeLadrillo(bool guardaSalida)
            : base(guardaSalida)
        {
            this.durabilidad = DURABILIDAD;
        }


        // implementacion de la interfaz IDestruible
        public override bool FueDestruido()
        {
            return (this.durabilidad <= 0);
        }


        // implementacion de la interfaz IDaniable
        public override void DaniarPorMolotov(Molotov bomba)
        {
            this.durabilidad = this.durabilidad - bomba.GetDanio();
        }


        public override void DaniarPorProyectil(Proyectil bomba)
        {
            this.durabilidad = this.durabilidad - bomba.GetDanio();
        }


        public override void DaniarPorToletole(ToleTole bomba)
        {
            this.durabilidad = 0;
        }


        // este metodo es utilizado por el controlador para solicitar su actual imagen que la representa
        public override string GetDescripcion()
        {
            return "ObstaculoDeLadrillo";
        }
    }
}
