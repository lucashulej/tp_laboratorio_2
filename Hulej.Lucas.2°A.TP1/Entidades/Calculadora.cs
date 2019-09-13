using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Realiza el tipo de operacion recibida entre dos objetos del tipo Numero
        /// </summary>
        /// <param name="num1"> Primer operador del tipo Numero </param>
        /// <param name="num2"> Segundo operador del tipo Numero </param>
        /// <param name="operador"> String que contiene el tipo de operacion a realizar </param>
        /// <returns> Retorna el resultado de la operacion entre el primer y el segundo operador </returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;
            operador = ValidarOperador(operador);

            switch (operador)
            {
                case "/":
                    resultado = num1 / num2;
                    if (double.IsInfinity(resultado))
                        resultado = double.MinValue;
                    break;

                case "*":
                    resultado = num1 * num2;
                    break;

                case "-":
                    resultado = num1 - num2;
                    break;

                case "+":
                    resultado = num1 + num2;
                    break;
            }
            return resultado;
        }

        /// <summary>
        /// Valida que lo recibido sea valido
        /// </summary>
        /// <param name="operador"> String que contiene el operador a validar </param>
        /// <returns> Retorna el operador si se encuentra dentro de los tipos previstos, caso contrario retorna "+" </returns>
        private static string ValidarOperador(string operador)
        {
            string retorno = "+";

            if (operador == "/" || operador == "*" || operador == "-")
                retorno = operador;

            return retorno;
        }
    }
}
