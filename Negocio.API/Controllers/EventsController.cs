using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Negocio.API.Data;
using Negocio.Shared.Entities;

namespace Negocio.API.Controllers
{
    [ApiController]
    [Route("/api/events")]
    public class EventsController:ControllerBase
    {
        private readonly DataContext _context;
        public EventsController(DataContext context)
        {
            
            _context = context;

        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Events.ToListAsync());
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Event>> GetReservation(int id)
        {
            var @event = await _context.Events.FirstOrDefaultAsync(x => x.Id == id);
            if (@event == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(@event);
            }
        }



        [HttpPost]
        public async Task<ActionResult> Post(Event @event)
        {
            _context.Add(@event);
            await _context.SaveChangesAsync();

            return Ok(@event);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Event @event)
        {
            _context.Update(@event);
            await _context.SaveChangesAsync();

            return Ok(@event);
        }



        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var FilasAfectadas = await _context.Events
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();
            if (FilasAfectadas == 0)
            {
                return NotFound();
            }
            else
            {
                return NoContent();
            }
        }


    }
}
