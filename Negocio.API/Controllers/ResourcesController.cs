using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Negocio.API.Data;
using Negocio.Shared.Entities;

namespace Negocio.API.Controllers
{
    [ApiController]
    [Route("/api/resources")]

    public class ResourcesController:ControllerBase
    {
        private readonly DataContext _context;
        public ResourcesController(DataContext context)
        {
            
            _context = context;

        }




        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Resources.ToListAsync());
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Reservation>> GetReservation(int id)
        {
            var resource = await _context.Resources.FirstOrDefaultAsync(x => x.Id == id);
            if (resource == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(resource);
            }
        }



        [HttpPost]
        public async Task<ActionResult> Post(Resource resource)
        {
            _context.Add(resource);
            await _context.SaveChangesAsync();

            return Ok(resource);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Resource resource)
        {
            _context.Update(resource);
            await _context.SaveChangesAsync();

            return Ok(resource);
        }



        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var FilasAfectadas = await _context.Resources
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
