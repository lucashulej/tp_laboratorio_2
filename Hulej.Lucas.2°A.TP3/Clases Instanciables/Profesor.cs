using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Profesor : Universitario
    {
        Queue<Universidad.EClases> clasesDelDia;
        static Random random;

        #region Constructores

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Profesor()
        {

        }

        /// <summary>
        /// Constructor estatico
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random();
        }

        /// <summary>
        /// Constructor parametrizado que setea sus atributos propios y llama al base para setear los atributos heredados
        /// </summary>
        /// <param name="id">id del profesor</param>
        /// <param name="nombre">nombre del profesor</param>
        /// <param name="apellido">apellido del profesor</param>
        /// <param name="dni">dni del profesor</param>
        /// <param name="nacionalidad">nacionalidad del profesor</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Metodo que agrega 2 clases a la Queue de clases
        /// </summary>
        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                this.clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(4));
            }
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Sobrecarga == en la cual un profesor es igual a una clase si este la da
        /// </summary>
        /// <param name="i">profesor a comparar</param>
        /// <param name="clase">clase a comparar</param>
        /// <returns>retorna true si son iguales, caso contrario false</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;

            foreach (Universidad.EClases item in i.clasesDelDia)
            {
                if (item == clase)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Sobrecarga != en la cual un profesor es distinto a una clase si este no la da
        /// </summary>
        /// <param name="i">profesor a comparar</param>
        /// <param name="clase">clase a comparar</param>
        /// <returns>retorna true si son distintos, caso contrario false</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        /// <summary>
        /// Sobrecarga de metodo
        /// </summary>
        /// <returns>retorna los datos del padre y las clases que posee el profesor</returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + this.ParticiparEnClase();
        }

        /// <summary>
        /// Sobrecarga de metodo
        /// </summary>
        /// <returns>retorna las clases del profesor</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine("CLASES DEL DIA");
            foreach (Universidad.EClases item in this.clasesDelDia)
            {
                retorno.AppendLine(item.ToString());
            }

            return retorno.ToString();
        }

        /// <summary>
        /// Sobrecarga de metodo
        /// </summary>
        /// <returns>retorna todos los datos de un profesor</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion
    }
}
