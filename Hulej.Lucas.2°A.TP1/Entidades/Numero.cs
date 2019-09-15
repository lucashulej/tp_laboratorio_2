using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;
        /// <summary>
        /// Setter que asigna el valor al atributo this.numero
        /// </summary>
        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        /// <summary>
        /// Convierte un numero binario en decimal si es posible
        /// </summary>
        /// <param name="binario"> es el string que contiene el numero binario a ser convertido </param>
        /// <returns> Retornoel numero decimal si fue posible la conversion, sino retorna Valor invalido </returns>
        public string BinarioDecimal(string binario)
        {
            int i = 0;
            string resultadoBinario = "";
            int resultado = 0;
            int exponente = 0;
            int parseo = 0;

            if (int.TryParse(binario, out parseo) == true)
            {
                if (int.Parse(binario) >= 0)
                {
                    for (i = binario.Length - 1; i > -1; i--)
                    {
                        resultadoBinario = resultadoBinario + binario[i];
                    }

                    for (i = 0; i < resultadoBinario.Length; i++)
                    {
                        exponente = Convert.ToInt32(Math.Pow(2, i));
                        if (resultadoBinario[i] == '1')
                        {
                            resultado = resultado + exponente;
                        }
                    }
                    resultadoBinario = resultado.ToString();
                }
                else
                    resultadoBinario = "Valor invalido";
                          
            }
            else
                resultadoBinario = "Valor invalido";

            return resultadoBinario;
        }

        /// <summary>
        /// Comvertira el numero recibido a binario de ser posible, caso contrario retornara Valor invalido
        /// </summary>
        /// <param name="numero"> Double con el valor a convertir a binario </param>
        /// <returns> Retornara el numero binario si el numero era valido, caso contrario retornara Valor invalido </returns>
        public string DecimalBinario(double numero)
        {
            string binario = "";
            int numeroInt = 0;
            int resto;

            numeroInt = (int)numero;

            if (numeroInt > 0)
            {
                while (numeroInt > 0)
                {
                    resto = (numeroInt % 2);

                    if (resto == 0)
                        binario = 0 + binario;

                    else
                        binario = 1 + binario;
                  
                    numeroInt = numeroInt / 2;
                }
            }
            else if( numeroInt == 0)
            {
                binario = "0";
            }
            else
                binario = "Valor invalido";
            
            return binario;
        }

        /// <summary>
        /// Verifica que el numero recibido sea entero, de ser asi llama a la funcion DecimalBinario pasandole como parametro el valor recibido convertido a double, caso contrario retornara Valor invalido
        /// </summary>
        /// <param name="numero"> String que contiene el numero a ser verificado </param>
        /// <returns> Retornara el numero convertido a binario si era valido, caso contrario retornara Valor invalido</returns>
        public string DecimalBinario(string numero)
        {
            string binario = "";

            if (double.TryParse(numero, out double parseo) == true)
                binario = DecimalBinario(parseo);

            else
                binario = "Valor invalido";

            return binario;
        }

        /// <summary>
        /// Constructor de Numero por defecto. Inicializa el atributo this.numero en 0
        /// </summary>
        public Numero() : this(0)
        {

        }

        /// <summary>
        /// Constructor de Numero con parametro. Le pasa el numero recibido al atributo this.numero
        /// </summary>
        /// <param name="numero"> el valor que se le dara a this.numero </param>
        public Numero(double numero) : this(numero.ToString())
        {

        }

        /// <summary>
        /// Constructor de Numero con parametro. Le pasa el numero recibido al atributo this.numero
        /// </summary>
        /// <param name="strNumero"> el valor que se le dara a this.numero </param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        /// <summary>
        /// Sobrecarga del operador que permite restar los atributos entre los distintos objetos del tipo Numero
        /// </summary>
        /// <param name="n1"> Primer operador del tipo Numero </param>
        /// <param name="n2"> Segundo operador del tipo Numero </param>
        /// <returns> Retorna la resta entre los atrubutos this.numero de los objetos del tipo Numero recibidos </returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador que permite multiplicar los atributos entre los distintos objetos del tipo Numero
        /// </summary>
        /// <param name="n1"> Primer operador del tipo Numero </param>
        /// <param name="n2"> Segundo operador del tipo Numero </param>
        /// <returns> Retorna la multiplicacion entre los atrubutos this.numero de los objetos del tipo Numero recibidos </returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador que permite dividir los atributos entre los distintos objetos del tipo Numero
        /// </summary>
        /// <param name="n1"> Primer operador del tipo Numero </param>
        /// <param name="n2"> Segundo operador del tipo Numero </param>
        /// <returns> Retorna la division entre los atrubutos this.numero de los objetos del tipo Numero recibidos </returns>
        public static double operator /(Numero n1, Numero n2)
        {
            return n1.numero / n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador que permite restar los atributos entre los distintos objetos del tipo Numero
        /// </summary>
        /// <param name="n1"> Primer operador del tipo Numero </param>
        /// <param name="n2"> Segundo operador del tipo Numero </param>
        /// <returns> Retorna la resta entre los atrubutos this.numero de los objetos del tipo Numero recibidos </returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Valido que lo recibido sea un numero entero
        /// </summary>
        /// <param name="strNumero"> String con el numero a validar </param>
        /// <returns> Retorna el numero si es entero, sino retorna 0 </returns>
        private double ValidarNumero(string strNumero)
        {
            if (double.TryParse(strNumero, out double numero) == false)
                numero = 0;

            return numero;
        }
    }
}

