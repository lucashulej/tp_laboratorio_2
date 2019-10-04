﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public abstract class Producto
    {
        public enum EMarca
        {
            Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
        }
        EMarca marca;
        string codigoDeBarras;
        ConsoleColor colorPrimarioEmpaque;
        
        #region Propiedades
        /// <summary>
        /// Proiedad de solo lectura, retornara la cantidad de calorias
        /// </summary>
        protected abstract short CantidadCalorias
        {
            get;
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de la clase Producto
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="marca"></param>
        /// <param name="color"></param>
        public Producto(string codigo, EMarca marca, ConsoleColor color)
        {
            this.codigoDeBarras = codigo;
            this.marca = marca;
            this.colorPrimarioEmpaque = color;
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Retorna todos los datos del Producto
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }
        #endregion


        #region Operadores
        /// <summary>
        /// Retorna todos los datos del Producto
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator string(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CODIGO DE BARRAS: {0}\r\n", p.codigoDeBarras);
            sb.AppendFormat("MARCA          : {0}\r\n", p.marca.ToString());
            sb.AppendFormat("COLOR EMPAQUE  : {0}\r\n", p.colorPrimarioEmpaque.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            return (v1.codigoDeBarras == v2.codigoDeBarras);
        }

        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            return !(v1 == v2);       
        }
        #endregion
    }
}
