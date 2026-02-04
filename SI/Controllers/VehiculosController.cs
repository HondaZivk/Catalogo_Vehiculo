using BL;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace SI.Controllers
{
    [ApiController]
    [Route("api/vehiculos")]
    public class VehiculosController : ControllerBase
    {
        private readonly IVehiculoService _service;

        public VehiculosController(IVehiculoService service)
        {
            _service = service;
        }

        // CREATE
        [HttpPost]
        public IActionResult Create([FromBody] Vehiculo vehiculo)
        {
            if (vehiculo == null) return BadRequest("Body requerido.");

            try
            {
                var creado = _service.CrearVehiculo(vehiculo);
                return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // READ (LIST)
        [HttpGet]
        public IActionResult Read()
        {
            return Ok(_service.ListarVehiculos());
        }

        // READ (BY ID)
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var vehiculo = _service.ObtenerPorId(id);
            if (vehiculo == null) return NotFound($"No existe un vehículo con Id={id}.");
            return Ok(vehiculo);
        }

        // UPDATE (100% funcional)
        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] Vehiculo vehiculo)
        {
            if (vehiculo == null) return BadRequest("Body requerido.");

            try
            {
                var actualizado = _service.ActualizarVehiculo(id, vehiculo);

                if (!actualizado)
                    return NotFound($"No existe un vehículo con Id={id}.");

                return Ok(new { message = "Vehículo actualizado correctamente." });
                // Alternativa: return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE (100% funcional)
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var eliminado = _service.EliminarVehiculo(id);

            if (!eliminado)
                return NotFound($"No existe un vehículo con Id={id}.");

            return NoContent(); // 204
        }
    }
}

