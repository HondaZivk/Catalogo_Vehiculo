using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;

namespace DA
{
    public interface IVehiculoRepository
    {
        void Create(Vehiculo vehiculo);
        List<Vehiculo> Read();
        Vehiculo? GetById(int id);

        bool Update(Vehiculo vehiculo);
        bool Delete(int id);
    }
}
