using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Negocio.API.Data;
using Negocio.Shared.Entities;

namespace Negocio.API.Controllers
{
    [ApiController]
    [Route("/api/workspaces")]

    public class WorkspacesController:ControllerBase
    {
        private readonly DataContext _context;
        public WorkspacesController(DataContext context)
        {
            _context = context;
            
        }




        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Workspaces.ToListAsync());
        }



        [HttpGet("{id:int}")]
        public async Task<ActionResult<Reservation>> GetReservation(int id)
        {
            var workspace = await _context.Workspaces.FirstOrDefaultAsync(x => x.Id == id);
            if (workspace == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(workspace);
            }
        }


        [HttpPost]
        public async Task<ActionResult> Post(Workspace workspace)
        {
            _context.Add(workspace);
            await _context.SaveChangesAsync();

            return Ok(workspace);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Workspace workspace)
        {
            _context.Update(workspace);
            await _context.SaveChangesAsync();

            return Ok(workspace);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var FilasAfectadas = await _context.Workspaces
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
