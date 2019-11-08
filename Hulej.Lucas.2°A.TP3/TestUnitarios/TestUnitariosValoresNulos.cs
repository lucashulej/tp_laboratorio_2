using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using EntidadesInstanciables;
using EntidadesAbstractas;

namespace TestUnitarios
{
    [TestClass]
    public class TestUnitariosValoresNulos
    {
        /// <summary>
        /// Test Unitario que verifica que los atributos de la clase no sean nulos
        /// </summary>
        [TestMethod]
        public void ValidarValoresNulos()
        {
            Universidad universidad = new Universidad();
            Assert.IsNotNull(universidad.Instructores);
            Assert.IsNotNull(universidad.Jornadas);
            Assert.IsNotNull(universidad.Alumnos);
        }
    }
}
