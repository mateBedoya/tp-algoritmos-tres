using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoombermanGame.src.estrategias;

namespace BoombermanGame.src.personajes
{
    public class Bombita : Personaje
    {
        private static int RESISTENCIA_INICIAL = 1;
        private static int VELOCIDAD_INICIAL = 1;
        private static int VELOCIDAD_MAXIMA = 3;
        private static double PORCENTAJE_DE_RETARDO_MINIMO = 0.5;
        private static Bombita INSTANCIA = null;
        private bool encontroSalida;

        // inicializa los atributos
        private void Inicializar()
        {
            this.estrategiaDeLanzamiento = new LanzarMolotov(this);
            INSTANCIA = this;
        }



        // crea a Bombita 
        public Bombita()
            : base(RESISTENCIA_INICIAL, VELOCIDAD_INICIAL)
        {
            this.Inicializar();
            this.encontroSalida = false;
        }


        // retorna la instancia
        public static Bombita GetInstancia()
        {
            if (INSTANCIA == null)
                INSTANCIA = new Bombita();
            return (INSTANCIA);
        }

        public static void SetInstancia(Bombita bombita)
        {
            INSTANCIA = bombita;
        }

        // reinicia la instancia de bombita cuando pierde una vida o cuando pasa de  nivel
        public void Reiniciar()
        {
            INSTANCIA = null;
        }


        // coloca en null la instancia de bombita.
        // Este metodo es usado para hacer pasar las pruebas mas de una vez
        // ya que bombita es un singleton
        public static void LimpiarInstancia()
        {
            INSTANCIA = null;
        }


        // retorna que es bombita
        public override bool EsBombita()
        {
            return true;
        }


        // retorna que no es enemigo
        public override bool EsEnemigo()
        {
            return false;
        }


        // bombita pasa a plantar bombas tole tole unicamente
        public void CambiarAToleTole()
        {
            this.estrategiaDeLanzamiento = new LanzarToleTole(this);
        }


        // bombita aumenta su velocidad de desplazamiento, siempre y cuando
        // no haya alcanzado su velocidad maxima
        public void AumentarVelocidad()
        {
            if (this.velocidad < VELOCIDAD_MAXIMA)
                this.velocidad++;
        }


        // reduce el porcentaje de retardo en un 15% siempre y cuando no 
        // haya alcanzado el porcentaje d eretardo minimo
        public void ReducirRetardo(double reduccion)
        {
            this.porcentajeDeRetardo = this.porcentajeDeRetardo * reduccion;
            if (this.porcentajeDeRetardo < PORCENTAJE_DE_RETARDO_MINIMO)
                this.porcentajeDeRetardo = PORCENTAJE_DE_RETARDO_MINIMO;
        }


        // bombita encuentra la salida
        public void EncontrarSalida()
        {
            this.encontroSalida = true;
        }


        // retorna si bombita encontro la salida
        public bool EncontroLaSalida()
        {
            return (this.encontroSalida);
        }


        // bombita es daniado por un enemigo
        public void SerDaniadoPorEnemigo()
        {
            this.resistencia = 0;
        }


        // este metodo es utilizado por el controlador para solicitar su actual imagen que lo represente
        public override string GetDescripcion()
        {
            if (this.direccion == ESTE)
                return ("BombitaDerecha");
            if (this.direccion == NORTE)
                return ("BombitaArriba");
            if (this.direccion == OESTE)
                return ("BombitaIzquierda");
            return ("BombitaAbajo");
        }


    }
}
