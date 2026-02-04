using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;

namespace DA
{
    // Repositorio en memoria (cumple el lab sin requerir BD)
    public class VehiculoRepository : IVehiculoRepository
    {
        private readonly List<Vehiculo> _vehiculos = new();
        private int _nextId = 1;

        public void Create(Vehiculo vehiculo)
        {
            // Asigna ID automáticamente si no viene
            if (vehiculo.Id <= 0)
            {
                vehiculo.Id = _nextId;
                _nextId++;
            }
            // Evita duplicados si mandan un ID repetido
            else if (_vehiculos.Any(v => v.Id == vehiculo.Id))
            {
                vehiculo.Id = _nextId;
                _nextId++;
            }

            _vehiculos.Add(vehiculo);
        }

        public List<Vehiculo> Read() => _vehiculos;

        public Vehiculo? GetById(int id) => _vehiculos.FirstOrDefault(v => v.Id == id);

        public bool Update(Vehiculo vehiculo)
        {
            var actual = GetById(vehiculo.Id);
            if (actual == null) return false;

            actual.Marca = vehiculo.Marca;
            actual.Año = vehiculo.Año;
            actual.Modelo = vehiculo.Modelo;
            actual.DobleTraccion = vehiculo.DobleTraccion;

            return true;
        }

        public bool Delete(int id)
        {
            var actual = GetById(id);
            if (actual == null) return false;

            _vehiculos.Remove(actual);
            return true;
        }
    }
}
