using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private string mensajeBase;

        #region Constructores

        /// <summary>
        /// Constructor por defecto que llama al base para setear los atributos heredados
        /// </summary>
        public DniInvalidoException() : base("La nacionalidad no coincide con el DNI")
        {

        }

        /// <summary>
        /// Constructor parametrizado que setea sus atributos propios y llama al base para setear los atributos heredados
        /// </summary>
        /// <param name="message">mensaje</param>
        public DniInvalidoException(string message) : base(message)
        {
            this.mensajeBase = message;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e">excepcion</param>
        public DniInvalidoException(Exception e) : base(e.Message)
        {

        }

        /// <summary>
        /// Constructor parametrizado que setea sus atributos propios y llama al base para setear los atributos heredados
        /// </summary>
        /// <param name="message">mensaje</param>
        /// <param name="e">excepcion</param>
        public DniInvalidoException(string message, Exception e) : base(message, e.InnerException)
        {
            this.mensajeBase = message;
        }

        #endregion
    }
}
