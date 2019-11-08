using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        ///  Constructor por defecto que llama al base para setear los atributos heredados
        /// </summary>
        public NacionalidadInvalidaException() : base("La nacionalidad no coincide con el DNI")
        {

        }

        /// <summary>
        /// Constructor parametrizado que llama al base para setear los atributos heredados
        /// </summary>
        /// <param name="message"></param>
        public NacionalidadInvalidaException(string message) : base(message)
        {

        }
    }
}
