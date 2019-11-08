using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo <string>
    {
        /// <summary>
        /// Metodo implementado de la interfaz para guardar datos en archivo de texto, si no puede arroja la excepcion ArchivosException
        /// </summary>
        /// <param name="archivo">ruta del archivo</param>
        /// <param name="datos">datos a escribir</param>
        /// <returns>retorna true si pudo realizar la operacion, caso contrario retorna false</returns>
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;

            try
            {
                StreamWriter writer = new StreamWriter(archivo);
                writer.Write(datos);
                writer.Close();
                retorno = true;
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }

            return retorno;
        }

        /// <summary>
        /// Metodo implementado de la interfaz para leer datos en archivo de texto, si no puede arroja la excepcion ArchivosException
        /// </summary>
        /// <param name="archivo">ruta del archivo</param>
        /// <param name="datos">datos a guardar</param>
        /// <returns>una cadena con los datos leidos</returns>
        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;

            datos = null;
            try
            {
                StreamReader reader = new StreamReader(archivo);
                datos = reader.ReadToEnd();
                reader.Close();
                retorno = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return retorno;
        }
    }
}
