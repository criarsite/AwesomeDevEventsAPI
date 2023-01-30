using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AwesomeDevEvents.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeDevEvents.Controllers
{
    [ApiController]
    [Route("api/dev-events")]
    public class DevEventsController : ControllerBase
    {
        private readonly DevEventsDbContext _context;
        public DevEventsController(DevEventsDbContext context)
        {
            _context = context;
        }

        // Listar todos os eventos que nao esteja, (cancelados => deletados)
        [HttpGet]
        public IActionResult GelAll()
        {
            var devEvents = _context.DevEvents.Where(d => !d.IsDeleted).ToList();
            return Ok(devEvents);

        }

        // Buscar item por ID
        [HttpGet("{id}")]
        public IActionResult GelItem(int id)
        {
            var devEvent = _context.DevEvents.SingleOrDefault(d => d.Id == id);

            if (devEvent == null) return NotFound();

            return Ok(devEvent);
        }

        // Adicionar um novo evento
        [HttpPost]
        public IActionResult Post(DevEvents devEvent)
        {
            _context.DevEvents.Add(devEvent);

            return CreatedAtAction(nameof(GelItem), new { id = devEvent.Id }, devEvent);
        }

        // Atualizar evento ja cadastrado
        [HttpPut("{id}")]
        public IActionResult Update(DevEvents input, int id)
        {
            var devEvent = _context.DevEvents.SingleOrDefault(d => d.Id == id);

            if (devEvent == null) return NotFound();

            devEvent.Update(input.Title, input.Description, input.StartDate, input.EndDate);

            return NoContent();
        }

        // Deletar um evento (Cancelar)
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var devEvent = _context.DevEvents.SingleOrDefault(d => d.Id == id);

            if (devEvent == null) return NotFound();

            devEvent.Delete();
            return NoContent();
        }
    }
}