using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        /// <summary>
        ///  Constructor por defecto que llama al base para setear los atributos heredados
        /// </summary>
        public AlumnoRepetidoException() : base("Alumno repetido")
        {

        }
    }
}
