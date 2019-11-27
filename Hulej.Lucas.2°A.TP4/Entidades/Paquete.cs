using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {

        #region Atributos

        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        #endregion

        public delegate void DelegadoEstado(object sender, EventArgs e);
        public event DelegadoEstado InformaEstado;

        #region Constructores

        /// <summary>
        /// Constructor de la clase Paquete
        /// </summary>
        /// <param name="direccionEntrega"></param>
        /// <param name="trackingID"></param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
            this.Estado = EEstado.ingresado;
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedad de escritura y lectura del atributo direccionEntrega
        /// </summary>
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }

        /// <summary>
        /// Propiedad de escritura y lectura del atributo estado
        /// </summary>
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }

        /// <summary>
        /// Propiedad de escritura y lectura del atributo trankingId
        /// </summary>
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }

        #endregion


        #region Metodos
       
        /// <summary>
        /// Sobrecarga del operador == que verifica si el trankingId de dos objetos del tipo Paquete son iguales
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>retorna true si son iguales, caso contrario retorna false</returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return p1.TrackingID == p2.TrackingID;
        }

        /// <summary>
        /// Sobrecarga del operador != que verifica si el trankingId de dos objetos del tipo Paquete son distintos
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>retorna false si son distintos, caso contrario retorna true</returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
          
            return !(p1 == p2);
        }

        /// <summary>
        /// Muestra todos los datos de un paquete
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns>retorna un string con todos los datos de un paquete</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {

            return string.Format("{0} para {1} ({2})", ((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega, ((Paquete)elemento).Estado);
        }

        /// <summary>
        /// Sobrecarga de metodo
        /// </summary>
        /// <returns>retorna un string con todos los datos de un paquete</returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        /// <summary>
        /// Cambia el estado del paquete cada 4 segundos
        /// </summary>
        public void MockCicloDeVida()
        {
            do
            {
                this.InformaEstado.Invoke(this, null);
                Thread.Sleep(4000);
                if (this.Estado == EEstado.ingresado)
                {
                    this.Estado = EEstado.en_viaje;
                }
                else
                {
                    this.Estado = EEstado.entregado;
                }
            } while (this.Estado != EEstado.entregado);
            this.InformaEstado.Invoke(this, null);
            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        #endregion

        #region Enumerados

        public enum EEstado
        {
            ingresado,
            en_viaje,
            entregado
        }

        #endregion
    }
}
