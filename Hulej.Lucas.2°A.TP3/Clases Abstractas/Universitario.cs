using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        #region Constructores

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Universitario()
        {

        }

        /// <summary>
        /// Constructor parametrizado que setea sus atributos propios y llama a base para setaar los atributos heredados
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Meotodo que muestra todos los datos de un universitario
        /// </summary>
        /// <returns>retorna un string con todos los datos del universitario</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine(base.ToString());
            retorno.AppendFormat("LEGAJO NUMERO: {0}\n", this.legajo);
            return retorno.ToString();
        }

        /// <summary>
        /// Metodo abstracto 
        /// </summary>
        /// <returns>retornara un string con las clases que el universitario asiste</returns>
        protected abstract string ParticiparEnClase();

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Sobrecarga == donde un universitario sera igual a otro si poseen el mismo dni o el mismo legajo
        /// </summary>
        /// <param name="pg1">primer universitario a comparar</param>
        /// <param name="pg2">segundo universitario a comparar</param>
        /// <returns>retornara true si son iguales, caso contrario retornara false</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;
            if (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI)
            {
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Sobrecarga != donde un universitario sera distinto a otro si poseen distinto dni y distinto legajo
        /// </summary>
        /// <param name="pg1">primer universitario a comparar</param>
        /// <param name="pg2">segundo universitario a comparar</param>
        /// <returns>retornara false si son distintos, caso contrario retornara true</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        /// <summary>
        /// Sobrecarga de meotod
        /// </summary>
        /// <param name="obj">objeto a comparar</param>
        /// <returns>retorna true si son del mismo tipo y poseen el mismo dni o legajo, caso contrario retornara false</returns>
        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (obj is Universitario)
            {
                if (this == (Universitario)obj)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        #endregion
    }
}
