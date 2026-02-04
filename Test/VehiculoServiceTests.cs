using BL;
using DA;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class VehiculoServiceTests
    {
        [TestMethod]
        public void CrearVehiculo_DeberiaAgregarVehiculo()
        {
            var repo = new VehiculoRepository();
            var service = new VehiculoService(repo);

            service.CrearVehiculo(new Vehiculo
            {
                Id = 1,
                Marca = 1,
                Anio = 2024,
                Modelo = "Model Y",
                DobleTraccion = true
            });

            Assert.AreEqual(1, repo.Read().Count);
        }
    }

}
