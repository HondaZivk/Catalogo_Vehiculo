using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;

namespace BL
{
    public interface IVehiculoService
    {
        Vehiculo CrearVehiculo(Vehiculo vehiculo);
        List<Vehiculo> ListarVehiculos();
        Vehiculo? ObtenerPorId(int id);

        bool ActualizarVehiculo(int id, Vehiculo vehiculo);
        bool EliminarVehiculo(int id);
    }
}
