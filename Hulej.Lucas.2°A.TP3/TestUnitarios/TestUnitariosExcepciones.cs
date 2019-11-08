using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using EntidadesInstanciables;
using EntidadesAbstractas;

namespace TestUnitarios
{
    [TestClass]
    public class TestUnitariosExcepciones
    {
        /// <summary>
        /// Test Unitario que verifica la excepcion AlumnoRepetidoException
        /// </summary>
        [TestMethod]
        public void ValidarAlumnoRepetidoException()
        {
            try
            {
                Universidad universidad = new Universidad();
                Alumno alumno1 = new Alumno(1, "lucas", "hulej", "42028318", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
                Alumno alumno2 = new Alumno(1, "camila", "ainchil", "41022367", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

                universidad = universidad + alumno1;
                universidad = universidad + alumno2;
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        }

        /// <summary>
        /// Test Unitario que verifica la excepcion NacionalidadInvalidaException
        /// </summary>
        [TestMethod]
        public void ValidarNacionalidadInvalidaException()
        {
            try
            {
                Alumno alumno = new Alumno(1, "lucas", "hulej", "90000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        }
    }
}
