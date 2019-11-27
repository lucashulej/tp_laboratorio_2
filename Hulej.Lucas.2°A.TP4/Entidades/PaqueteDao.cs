using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Entidades
{
    public static class PaqueteDAO
    {
        #region Atributos

        private static SqlCommand comando;
        private static SqlConnection conexion;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto de la clase PaqueteDao
        /// </summary>
        static PaqueteDAO()
        {
            PaqueteDAO.conexion = new SqlConnection(Properties.Settings.Default.Conexion);
            PaqueteDAO.comando = new SqlCommand();

            PaqueteDAO.comando.CommandType = CommandType.Text;
            PaqueteDAO.comando.Connection = PaqueteDAO.conexion;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Agrega un paquete a la base de datos
        /// </summary>
        /// <param name="p"></param>
        /// <returns>retorna true si se pudo agregar a la base de datos, caso contrario retorna false</returns>
        public static bool Insertar(Paquete p)
        {
         
            bool retorno = false;
            PaqueteDAO.comando.CommandText = string.Format("INSERT INTO dbo.Paquetes (direccionEntrega,trackingID,alumno) VALUES('{0}','{1}','{2}')", p.DireccionEntrega, p.TrackingID, "Hulej Lucas");
            
            try
            {
                PaqueteDAO.conexion.Open();
                if(PaqueteDAO.comando.ExecuteNonQuery() != 0)
                {
                    retorno = true;
                }
                
 
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                PaqueteDAO.conexion.Close();
            }
            return retorno;
        }

        #endregion
    }
}
