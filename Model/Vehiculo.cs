using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Vehiculo
    {
        public int Id { get; set; }

        // 1 = Tesla, 2 = Toyota, 3 = BYD
        public int Marca { get; set; }

        public int Año { get; set; }

        public string Modelo { get; set; } = string.Empty;

        public bool DobleTraccion { get; set; }
    }
}
