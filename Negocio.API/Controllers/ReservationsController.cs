using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Negocio.API.Data;
using Negocio.Shared.Entities;

namespace Negocio.API.Controllers
{
    [ApiController]
    [Route("/api/reservations")]

    public class ReservationsController: ControllerBase
    {
        private readonly DataContext _context;
        public ReservationsController(DataContext context)
        {
            
            _context = context;

        }



        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Reservations.ToListAsync());
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Reservation>> GetReservation(int id)
        {
            var reservation = await _context.Reservations.FirstOrDefaultAsync(x => x.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(reservation);
            }
        }


        [HttpPost]
        public async Task<ActionResult> Post(Reservation reservation)
        {
            _context.Add(reservation);
            await _context.SaveChangesAsync();

            return Ok(reservation);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Reservation reservation)
        {
            _context.Update(reservation);
            await _context.SaveChangesAsync();

            return Ok(reservation);
        }



        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var FilasAfectadas = await _context.Reservations
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
