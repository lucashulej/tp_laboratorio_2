using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;
namespace EntidadesAbstractas
{
    public abstract class Persona
    {

        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        #region Propiedades

        /// <summary>
        /// Propiedad de escritura y lectura del apellido
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = this.ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Propiedad de escritura y lectura del dni
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = this.ValidarDni(this.nacionalidad, value);
            }
        }

        /// <summary>
        /// Propiedad de escritura y lectura de la nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        /// <summary>
        /// Propiedad de escritura y lectura del nombre
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = this.ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Propiedad de escritura y lectura del dni como string
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.DNI = this.ValidarDni(this.nacionalidad, value);
            }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Persona()
        {

        }

        /// <summary>
        /// Constructor parametrizado que setea atributos propios 
        /// </summary>
        /// <param name="nombre">nombre de la persona</param>
        /// <param name="apellido">apellido de la persona</param>
        /// <param name="nacionalidad">nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor parametrizado que setea atributos propios 
        /// </summary>
        /// <param name="nombre">nombre de la persona</param>
        /// <param name="apellido">apellido de la persona</param>
        /// <param name="dni">dni de la persona</param>
        /// <param name="nacionalidad">nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor parametrizado que setea atributos propios 
        /// </summary>
        /// <param name="nombre">nombre de la persona</param>
        /// <param name="apellido">apellido de la persona</param>
        /// <param name="dni">dni de la persona</param>
        /// <param name="nacionalidad">nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Valida que el dni recibido como int sea valido
        /// </summary>
        /// <param name="nacionalidad">nacionalidad</param>
        /// <param name="dato">dato a validar</param>
        /// <returns>retorna el dni si es valido, caso contrario retorna -1</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            return this.ValidarDni(nacionalidad, dato.ToString());
        }

        /// <summary>
        /// Valida que el dni recibido como string sea valido
        /// </summary>
        /// <param name="nacionalidad">nacionalidad</param>
        /// <param name="dato">dato a validar</param>
        /// <returns>retorna el dni si es valido, caso contrario retorna -1</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int retorno = -1;
            int dni;

            if (dato.Length >= 1 && dato.Length <= 8)
            {
                foreach (char item in dato)
                {
                    if (char.IsNumber(item) == false)
                    {
                        throw new DniInvalidoException("El dni no tiene el formato correcto");
                    }
                }
                dni = int.Parse(dato);
                switch (nacionalidad)
                {
                    case ENacionalidad.Argentino:
                        if (dni < 1 && dni > 89999999)
                        {
                            throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
                        }
                        else
                        {
                            retorno = dni;
                        }
                        break;
                    case ENacionalidad.Extranjero:
                        if (dni < 90000000 && dni > 99999999)
                        {
                            throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
                        }
                        else
                        {
                            retorno = dni;
                        }
                        break;
                }
            }
            else
            {
                throw new DniInvalidoException("El dni no tiene el formato correcto");
            }

            return retorno;
        }

        /// <summary>
        /// Valida que el nombre y el apellido de la persona sean validos
        /// </summary>
        /// <param name="dato">dato a validar</param>
        /// <returns>retorna el nombre y apellido si es valido, caso contrario retorna null</returns>
        private string ValidarNombreApellido(string dato)
        {
            string retorno = dato;

            foreach (char item in dato)
            {
                if (char.IsLetter(item) == false && char.IsWhiteSpace(item) == false)
                {
                    retorno = null;
                    break;
                }
            }

            return retorno;
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Sobrecarga de metodo
        /// </summary>
        /// <returns>retorna todos los datos de una persona</returns>
        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendFormat("NOMBRE COMPLETO: {0} {1}\n", this.apellido, this.nombre);
            retorno.AppendFormat("NACIONALIDAD: {0}\n", this.nacionalidad);

            return retorno.ToString();
        }

        #endregion


        #region Enumerados

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        #endregion
    }
}
