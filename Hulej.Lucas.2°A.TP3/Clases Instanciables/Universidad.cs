using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace EntidadesInstanciables
{
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        #region Propiedades

        /// <summary>
        /// Propiedad de escritura y lectura de alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// Propiedad de escritura y lectura de instructores
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        /// <summary>
        /// Propiedad de escritura y lectura de jornadas
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }

        /// <summary>
        /// Indexador de jornadas
        /// </summary>
        /// <param name="i">index</param>
        /// <returns>retorna el elemento que se encuentra en el index recibido</returns>
        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];
            }
            set
            {
                this.jornada[i] = value;
            }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Metodo para guardar los datos en un archivo XML
        /// </summary>
        /// <param name="uni">datos que se escribiran en el archivo</param>
        /// <returns>retorna true si se pudo guardar, caso contrario retorna false</returns>
        public static bool Guardar(Universidad uni)
        {
            bool retorno = false;

            Xml<Universidad> xml = new Xml<Universidad>();
            retorno = xml.Guardar(AppDomain.CurrentDomain.BaseDirectory + @"Universidad.xml", uni);

            return retorno;
        }

        /// <summary>
        /// Metodo para leer los datos de un archivo XML
        /// </summary>
        /// <returns>retorna objeto universidad obtenido apartir de los datos obtenidos</returns>
        public static Universidad Leer()
        {
            Universidad universidad = null;

            Xml<Universidad> xml = new Xml<Universidad>();
            xml.Leer(AppDomain.CurrentDomain.BaseDirectory + @"Universidad.xml", out universidad);

            return universidad;
        }

        /// <summary>
        /// Metodo statico que recibe una universidad y muestra sus datos
        /// </summary>
        /// <param name="uni">universidad a mostrar</param>
        /// <returns>retorna los datos de la univercidad recibida</returns>
        private static string MostrarDatos(Universidad uni)
        {

            StringBuilder retorno = new StringBuilder();

            foreach (Jornada item in uni.jornada)
            {
                retorno.AppendLine(item.ToString());
                retorno.AppendLine("<------------------------------------------------>");
            }

            return retorno.ToString();
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Sobrecarga == en la cual una universidad es igual a un alumno, si este se encuentra en ella
        /// </summary>
        /// <param name="g">universidad a comparar</param>
        /// <param name="a">alumno a comparar</param>
        /// <returns>retorna true si son iguales, caso contrario false</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno item in g.alumnos)
            {
                if (item == a)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Sobrecarga != en la cual una universidad es distinta a un alumno, si este no se encuentra en ella
        /// </summary>
        /// <param name="g">universidad a comparar</param>
        /// <param name="a">alumno a comparar</param>
        /// <returns>retorna true si son distintas, caso contrario false</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Sobrecarga == en la cual una universidad es igual a un profesor, si este se encuentra en la misma
        /// </summary>
        /// <param name="g">universidad a comparar</param>
        /// <param name="i">profesor a comparar</param>
        /// <returns>retorna true si son iguales, caso contrario retorna false</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;

            foreach (Profesor item in g.profesores)
            {
                if (item == i)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Sobrecarga != en la cual una universidad es distinta a un profesor, si este no se encuentra en la misma
        /// </summary>
        /// <param name="g">universidad a comparar</param>
        /// <param name="i">profesor a comparar</param>
        /// <returns>retorna true si son distintas, caso contrario retorna false</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Sobrecarga == en la cual se retorna un profesor que pueda dar es clase, si no existe se lanza la excepcion SinProfesorException
        /// </summary>
        /// <param name="g">universidad a comparar</param>
        /// <param name="clase">clase a comparar</param>
        /// <returns>retorna un profesor</returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            Profesor retorno = null;
            bool aux = false;

            foreach (Profesor item in g.profesores)
            {
                if (item == clase)
                {
                    aux = true;
                    retorno = item;
                    break;
                }
            }
            if (aux == false)
            {
                throw new SinProfesorException();
            }

            return retorno;
        }

        /// <summary>
        /// Sobrecarga != en la cual se retorna el profesor que no pueda dar es clase, si no existe se lanza la excepcion SinProfesorException
        /// </summary>
        /// <param name="g">universidad a comparar</param>
        /// <param name="clase">clase a comparar</param>
        /// <returns>retorna un profesor</returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            Profesor retorno = null;
            bool aux = false;

            foreach (Profesor item in g.profesores)
            {
                if (item != clase)
                {
                    aux = true;
                    retorno = item;
                    break;
                }
            }
            if (aux == false)
            {
                throw new SinProfesorException();
            }

            return retorno;
        }

        /// <summary>
        /// Sobrecarga + en la cual se agregara una clase a la universidad
        /// </summary>
        /// <param name="g">universidad a sumar</param>
        /// <param name="clase">clase a sumar</param>
        /// <returns>retorna la universidad</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor auxProfesor = (g == clase);
            Jornada auxJornada = new Jornada(clase, auxProfesor);

            foreach (Alumno item in g.alumnos)
            {
                if (item == clase)
                {
                    auxJornada = auxJornada + item;
                }
            }
            g.jornada.Add(auxJornada);

            return g;
        }

        /// <summary>
        /// Sobrecarga + en la cual se agrefara un alumno a la universidad si este no se encuentra en la misma
        /// </summary>
        /// <param name="u">universidad a sumar</param>
        /// <param name="a">alumno a sumar</param>
        /// <returns>retorna la universidad</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            bool aux = false;

            foreach (Alumno item in u.alumnos)
            {
                if (item == a)
                {
                    aux = true;
                    break;
                }
            }
            if (aux == false)
            {
                u.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }

            return u;
        }

        /// <summary>
        /// Sobrecarga + en la cual se agregara un profesor a la universidad si este no se encuentra en la misma
        /// </summary>
        /// <param name="u">universidad a sumar</param>
        /// <param name="i">profesor a sumar</param>
        /// <returns>retorna la universidad</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            bool aux = false;

            foreach (Profesor item in u.profesores)
            {
                if (item == i)
                {
                    aux = true;
                    break;
                }
            }
            if (aux == false)
            {
                u.profesores.Add(i);
            }

            return u;
        }

        /// <summary>
        /// Sobrecarga de metodo
        /// </summary>
        /// <returns>retorna todos los datos de una jornada</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        #endregion

        #region Enumerados

        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        #endregion
    }
}
