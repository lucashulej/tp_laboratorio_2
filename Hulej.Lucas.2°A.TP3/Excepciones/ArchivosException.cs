using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Constructor parametrizado que llama al base para setear los atributos heredados
        /// </summary>
        /// <param name="innerException"></param>
        public ArchivosException(Exception innerException) : base("Error al leer o guardar archivo", innerException)
        {
            
        }
    }
}
