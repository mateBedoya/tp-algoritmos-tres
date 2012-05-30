using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2.Fisica;
using TP2.Interfaces;

namespace TP2.Elementales
{
    /// <summary>
    /// Esta clase generaliza a todas las entidades del problema;
    /// es abstracta ya que deja la implementacion de los casos 
    /// particulares a sus clases derivadas
    ///</summary>
    
    public abstract class Entidad : Interactuable
    {
        protected ModeloFisicoEstandar modelo;
        protected double direccion;

        // crea una entidad con direccion predeterminada al Este
        // y con un modelo fisico que lo represente
        public Entidad(ModeloFisicoEstandar modelo){
            this.modelo = modelo;
            this.direccion = Servicios.GetInstancia().DIRECCION_ESTE;
        }

        /// 
        /// <Implemetacion de la interfaz Interactuable>
        ///    

        // se posiciona a la entidad
        public void Posicionar(Punto posicion)
        {
            this.modelo.GetFigura().Posicionar(posicion);
        }

        // retorna la posicion actual de la entidad
        public Punto GetPosicion()
        {
            return (this.modelo.GetFigura().GetPosicion());
        }

        // se direcciona a la entidad
        public void Direccionar(double direccion)
        {
            this.direccion = direccion;
        }

        // retorna la direccion actual de la entidad
        public double GetDireccion()
        {
            return (this.direccion);
        }

        // retorna el modelo fisico que lo representa
        public ModeloFisicoEstandar GetModelo()
        {
            return (this.modelo);
        }

        // retorna si la entidad esta o no dentro de los limites pasados
        public bool EstaDentroDeLosLimites(Punto inferior, Punto superior)
        {
            return (this.modelo.GetFigura().EstaDentroDeLosLimites(inferior, superior));
        }

        // retorna si se encuentra en colision con otro interactuable
        public bool EnColisionCon(Interactuable interactuable)
        {
            return (this.modelo.SeIntersecaCon(interactuable.GetModelo()));
        }

        // 
        public void InteractuarCon(Interactuable interactuable)
        {
            // Debe ser implementado
        }
                         
        /// </Implemetacion>

    }
}
