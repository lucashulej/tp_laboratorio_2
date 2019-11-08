using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using EntidadesInstanciables;
using EntidadesAbstractas;

namespace TestUnitarios
{
    [TestClass]
    public class TestUnitariosNumericos
    {
        /// <summary>
        /// Test Unitario que verifica que el atributo dni sea entero
        /// </summary>
        [TestMethod]
        public void ValidarDniInvalidoException()
        {
            try
            {
                Alumno alumno = new Alumno(1, "lucas", "hulej", "12a21", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }
    }
}
