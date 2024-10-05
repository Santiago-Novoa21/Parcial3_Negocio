using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Negocio.API.Data;
using Negocio.Shared.Entities;

namespace Negocio.API.Controllers
{
    [ApiController]
    [Route("/api/members")]

    public class MembersController:ControllerBase
    {
        private readonly DataContext _context;
        public MembersController(DataContext context)
        {
            
            _context = context;

        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Members.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Reservation>> GetReservation(int id)
        {
            var member = await _context.Members.FirstOrDefaultAsync(x=>x.Id==id);
            if (member == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(member);
            }
        }



        [HttpPost]
        public async Task<ActionResult> Post(Member member)
        {
            _context.Add(member);
            await _context.SaveChangesAsync();

            return Ok(member);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Member member)
        {
            _context.Update(member);
            await _context.SaveChangesAsync();

            return Ok(member);
        }



        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var FilasAfectadas = await _context.Members
                .Where(x=>x.Id==id)
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
