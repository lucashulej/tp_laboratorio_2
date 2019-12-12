using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardarString
    {
        /// <summary>
        /// Metodo de extension que permite guardar un archivo de texto en el escritorio
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo"></param>
        /// <returns>retorna true si pudo guardar el archivo, caso contrario retorna false</returns>
        public static bool Guardar(this string texto, string archivo)
        {
            bool retorno = false;
            try
            {
                using (StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\" + archivo, true))
                {
                    writer.WriteLine(texto);
                    retorno = true;
                } 
            }
            catch
            {
                retorno = false;
            }
            return retorno;
        }
    }
}
