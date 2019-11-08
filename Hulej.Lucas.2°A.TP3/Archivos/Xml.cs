using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> 
    {
        /// <summary>
        /// Metodo implementado de la interfaz para guardar datos en archivo XML, si no puede arroja la excepcion ArchivosException
        /// </summary>
        /// <param name="archivo">ruta del archivo</param>
        /// <param name="datos">datos a escribir</param>
        /// <returns>retorna true si pudo realizar la operacion, caso contrario retorna false</returns>
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = false;

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                StreamWriter writer = new StreamWriter(archivo);
                serializer.Serialize(writer, datos);
                writer.Close();
                retorno = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return retorno;
        }

        /// <summary>
        /// Metodo implementado de la interfaz para leer datos en archivo XML, si no puede arroja la excepcion ArchivosException
        /// </summary>
        /// <param name="archivo">ruta del archivo</param>
        /// <param name="datos">datos a guardar</param>
        /// <returns>retorna lo leido</returns>
        public bool Leer(string archivo, out T datos)
        {
            bool retorno = false;

            datos = default(T);
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                StreamReader reader = new StreamReader(archivo);
                datos = (T)serializer.Deserialize(reader);
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

