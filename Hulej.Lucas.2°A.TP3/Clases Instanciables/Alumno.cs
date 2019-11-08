using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Alumno : Universitario
    {
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        #region Constructores

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Alumno()
        {

        }

        /// <summary>
        /// Constructor parametrizado que setea sus atributos propios y llama al base para setear los atributos heredados
        /// </summary>
        /// <param name="id">id del alumno</param>
        /// <param name="nombre">nombre del alumno</param>
        /// <param name="apellido">apellido del alumno</param>
        /// <param name="dni">dni del alumno</param>
        /// <param name="nacionalidad">nacionalidad del alumno</param>
        /// <param name="claseQueToma">clase que toma el alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor parametrizado que setea sus atributos propios y llama al base para setear los atributos heredados
        /// </summary>
        /// <param name="id">id del alumno</param>
        /// <param name="nombre">nombre del alumno</param>
        /// <param name="apellido">apellido del alumno</param>
        /// <param name="dni">dni del alumno</param>
        /// <param name="nacionalidad">nacionalidad del alumno</param>
        /// <param name="claseQueToma">clase que toma el alumno</param>
        /// <param name="estadoCuenta">estado de cuenta del alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Sobrecarga == en la cual un alumno es igual a una clase si este toma esa clase y su cuenta no es Deudor   
        /// </summary>
        /// <param name="a">alumno a comparar</param>
        /// <param name="clase">clase a comparar</param>
        /// <returns>retorna true si son iguales, caso contrario retorna false</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor;
        }

        /// <summary>
        /// Sobrecarga != en la cual un alumno es distinto a una clase si este no toma esa clase 
        /// </summary>
        /// <param name="a">alumno a comparar</param>
        /// <param name="clase">clase a comparar</param>
        /// <returns>retorna true si son distintos, caso contrario retorna false</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return a.claseQueToma != clase;
        }

        /// <summary>
        /// Sobrecarga de metodo
        /// </summary>
        /// <returns>retorna todos los datos de un alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine(base.MostrarDatos());
            retorno.AppendFormat("ESTADO DE CUENTA {0}\n", this.estadoCuenta);
            retorno.Append(this.ParticiparEnClase());

            return retorno.ToString();
        }

        /// <summary>
        /// Sobrecarga de metodo
        /// </summary>
        /// <returns>retorna la clase que toma el alumno</returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASES DE " + this.claseQueToma;
        }

        /// <summary>
        /// Sobrecarga de metodo
        /// </summary>
        /// <returns>retorna todos los datos de un alumno</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region Enumerados

        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        #endregion

    }
}
