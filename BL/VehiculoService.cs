using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA;
using Model;

namespace BL
{
    public class VehiculoService : IVehiculoService
    {
        private readonly IVehiculoRepository _repository;

        public VehiculoService(IVehiculoRepository repository)
        {
            _repository = repository;
        }

        public Vehiculo CrearVehiculo(Vehiculo vehiculo)
        {
            ValidarVehiculo(vehiculo);
            _repository.Create(vehiculo);
            return vehiculo;
        }

        public List<Vehiculo> ListarVehiculos()
            => _repository.Read();

        public Vehiculo? ObtenerPorId(int id)
            => _repository.GetById(id);

        public bool ActualizarVehiculo(int id, Vehiculo vehiculo)
        {
            vehiculo.Id = id; // el id de la URL manda
            ValidarVehiculo(vehiculo);
            return _repository.Update(vehiculo);
        }

        public bool EliminarVehiculo(int id)
            => _repository.Delete(id);

        private static void ValidarVehiculo(Vehiculo vehiculo)
        {
            if (vehiculo.Marca < 1 || vehiculo.Marca > 3)
                throw new ArgumentException("Marca inválida. Use 1=Tesla, 2=Toyota, 3=BYD.");

            if (vehiculo.Año < 1886 || vehiculo.Año > DateTime.Now.Year + 1)
                throw new ArgumentException("Año inválido.");

            if (string.IsNullOrWhiteSpace(vehiculo.Modelo))
                throw new ArgumentException("Modelo es requerido.");
        }
    }
}

