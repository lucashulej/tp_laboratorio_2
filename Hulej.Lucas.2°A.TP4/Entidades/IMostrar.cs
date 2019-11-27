using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IMostrar<T>
    {
        #region Metodos

        /// <summary>
        /// Firma de metodo que muestra los datos del elemeto recibido
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns>retorna todos los datos del elemento</returns>
        string MostrarDatos(IMostrar<T> elemento);

        #endregion
    }
}
