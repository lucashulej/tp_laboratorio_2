using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region Atributos

        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto de la clase Correo
        /// </summary>
        public Correo()
        {
            paquetes = new List<Paquete>();
            mockPaquetes = new List<Thread>();
        }

        #endregion


        #region Propiedades

        /// <summary>
        /// Porpiedad de escritura y lectura del atributo paquetes
        /// </summary>
        public List<Paquete> Paquetes
        {
            get
            { 
                return this.paquetes; 
            }
            set
            { 
                this.paquetes = value; 
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sobrecarga del operador + que agrega un paquete a un correo si este no se encuentra en el mismo
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns>retorna el correo</returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete item in c.Paquetes)
            {
                if (item == p)
                {
                    throw new TrackingIdRepetidoException("Paquete repetido");
                }
            }
            c.Paquetes.Add(p);
            Thread hilo = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(hilo);
            hilo.Start();

            return c;
        }

        /// <summary>
        /// Elimina todos los hilos que sigan activos
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread aux in this.mockPaquetes)
            {
                if (aux.IsAlive)
                {
                    aux.Abort();
                }
            }
        }

        /// <summary>
        /// Muestra todos los datos de una lista de paquetes
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns>retorna un string con todos los datos la lista</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder retorno = new StringBuilder();
            if (elementos is Correo)
            {
                foreach (Paquete aux in ((Correo)elementos).Paquetes)
                {
                    retorno.AppendFormat("{0} para {1} ({2})", aux.TrackingID, aux.DireccionEntrega,aux.Estado.ToString());
                    retorno.AppendLine();
                }
            }
            return retorno.ToString();
        }

        #endregion
    }
}
