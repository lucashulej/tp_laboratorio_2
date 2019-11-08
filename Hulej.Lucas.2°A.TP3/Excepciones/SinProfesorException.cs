using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        /// <summary>
        ///  Constructor por defecto que llama al base para setear los atributos heredados
        /// </summary>
        public SinProfesorException() : base("No hay un profesor para la clase")
        {

        }
    }
}
