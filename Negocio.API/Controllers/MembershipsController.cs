using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Negocio.API.Data;
using Negocio.Shared.Entities;

namespace Negocio.API.Controllers
{
    [ApiController]
    [Route("/api/memberships")]

    public class MembershipsController: ControllerBase
    {
        private readonly DataContext _context;
        public MembershipsController(DataContext context)
        {

            _context = context;
            
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Memberships.ToListAsync());
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Reservation>> GetReservation(int id)
        {
            var membership = await _context.Memberships.FirstOrDefaultAsync(x => x.Id == id);
            if (membership == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(membership);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(Membership membership)
        {
            _context.Add(membership);
            await _context.SaveChangesAsync();

            return Ok(membership);
        }


        [HttpPut]
        public async Task<ActionResult> Put(Membership membership)
        {
            _context.Update(membership);
            await _context.SaveChangesAsync();

            return Ok(membership);
        }



        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var FilasAfectadas = await _context.Memberships
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
