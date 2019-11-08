using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        #region Propiedades

        /// <summary>
        /// Propiedad escritura y lectura de lista de alumnos
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
        /// Propiedad escritura y lectura de la clase
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        /// <summary>
        /// Propiedad escritura y lectura de el instructor
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor parametrizado que setea sus atributos propios y llama al constructor por defecto
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Metodo para guardar los datos en un archivo de texto
        /// </summary>
        /// <param name="jornada">datos que se escribiran en el archivo</param>
        /// <returns>retorna true si se puedo guardar, caso contrario retorna false</returns>
        public static bool Guardar(Jornada jornada)
        {
            bool retorno = false;

            Texto texto = new Texto();
            retorno = texto.Guardar(AppDomain.CurrentDomain.BaseDirectory + @"Jornada.txt", jornada.ToString());

            return retorno;
        }

        /// <summary>
        /// Metodo para leer los datos de un archivo de texto
        /// </summary>
        /// <returns>retorna un string con los datos obtenidos</returns>
        public static string Leer()
        {
            string retorno = null;

            Texto texto = new Texto();
            texto.Leer(AppDomain.CurrentDomain.BaseDirectory + @"Jornada.txt", out retorno);

            return retorno;
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Sobrecarga == en la cual una jornada es igual a un alumno, si el alumno se encuentra en la misma
        /// </summary>
        /// <param name="j">jornada a comparar</param>
        /// <param name="a">alumno a comparar</param>
        /// <returns>retorna true si son iguales, caso contrario retorna false</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno item in j.alumnos)
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
        /// Sobrecarga != en la cual una jornada es distinto a un alumno, si el alumno no se encuentra en la misma
        /// </summary>
        /// <param name="j">jornada a comparar</param>
        /// <param name="a">alumno a comparar</param>
        /// <returns>retorna true si son distintos, caso contrario retorna false</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Sobrecarga + en la cual un alumno se sumara a una jornada si este no se encuentra en la misma
        /// </summary>
        /// <param name="j">jornada a sumar</param>
        /// <param name="a">alumno a sumar</param>
        /// <returns>retorna la jornada</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }

            return j;
        }

        /// <summary>
        /// Sobrecarga de metodo
        /// </summary>
        /// <returns>retorna todos los datos de una jornada</returns>
        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine("");
            retorno.AppendFormat("CLASE DE {0} POR {1} ", this.clase, this.instructor.ToString());
            retorno.AppendLine("");
            retorno.AppendLine("ALUMNOS: ");
            foreach (Alumno alumno in this.Alumnos)
            {
                retorno.AppendLine(alumno.ToString());
            }

            return retorno.ToString();
        }

        #endregion
    }
}
