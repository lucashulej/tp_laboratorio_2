using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitarios
{
    [TestClass]
    public class TestCorreo
    {
        [TestMethod]
        public void TestPaquetesCorreo()
        {
            Correo correo = new Correo();
            bool aux = false;
            try
            {
                Assert.IsNotNull(correo.Paquetes);
                aux = true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            Assert.IsTrue(aux, "El correo se instancio correctamente");
        }

        [TestMethod]
        public void TestPaquetesTrakingId()
        {
            Correo correo = new Correo();
            Paquete paquete1 = new Paquete("direccion 1", "27");
            Paquete paquete2 = new Paquete("direccion 2", "27");
            bool aux = false;
            try
            {
                correo += paquete1;
                correo += paquete2;
            }
            catch (TrackingIdRepetidoException exception)
            {
                aux = true;
            }
            Assert.IsTrue(aux, "Se lanzo una excepcion ya que no se pudo agregar dos paquetes con el mismo ID");
        }

    }
}
