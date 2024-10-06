using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Negocio.API.Data;
using Negocio.Shared.Entities;


namespace Negocio.API.Controllers
{

    [ApiController]
    [Route("/api/admin")]
    public class AdminsController : ControllerBase
    {
        private readonly DataContext _context;
        public AdminsController(DataContext context)
        {

            _context = context;

        }

        [HttpGet("seed")]
        public async Task<IActionResult> SeedDatabase([FromServices] SeedDb seeder)
        {
            await seeder.SeedAsync();
            return Ok("Database seeded");
        }

        [HttpGet("admins")]
        public async Task<ActionResult<IEnumerable<Admin>>> Get()
        {
            return Ok(await _context.Admins.ToListAsync());
        }


        [HttpPost("admins")]
        public async Task<ActionResult<Admin>> CreateAdmin(Admin admin)
        {
            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(CreateAdmin), new { id = admin.Id }, admin);
        }


        [HttpGet("reservations")]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetAllReservations()
        {
            return await _context.Reservations.Include(r => r.Workspace).Include(r => r.Member).ToListAsync();
        }

        [HttpGet("reservations/{id}")]
        public async Task<ActionResult<Reservation>> GetReservation(int id)
        {
            var reservation = await _context.Reservations
                .Include(r => r.Workspace)
                .Include(r => r.Member)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (reservation == null)
            {
                return NotFound();
            }

            return reservation;
        }

        [HttpPost("members")]
        public async Task<ActionResult<Member>> CreateMember(Member member)
        {
            _context.Members.Add(member);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(CreateMember), new { id = member.Id }, member);
        }

        [HttpPut("members/{id}")]
        public async Task<IActionResult> UpdateMember(int id, Member member)
        {
            if (id != member.Id)
            {
                return BadRequest();
            }

            _context.Entry(member).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("members/{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var member = await _context.Members.FindAsync(id);

            if (member == null)
            {
                return NotFound();
            }

            _context.Members.Remove(member);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("members")]
        public async Task<ActionResult<IEnumerable<Member>>> GetAllMembers()
        {
            return await _context.Members.ToListAsync();
        }

        [HttpGet("events")]
        public async Task<ActionResult<IEnumerable<Event>>> GetAllEvents()
        {
            return await _context.Events.Include(e => e.Participants).ToListAsync();
        }

        [HttpPost("assign-resources")]
        public async Task<IActionResult> AssignResourcesToWorkspace(int workspaceId, List<int> resourceIds)
        {
            var workspace = await _context.Workspaces.FindAsync(workspaceId);
            if (workspace == null)
            {
                return NotFound();
            }

            var resources = await _context.Resources.Where(r => resourceIds.Contains(r.Id)).ToListAsync();
            workspace.Resources = resources;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("workspaces/availability")]
        public async Task<ActionResult<IEnumerable<Workspace>>> GetAvailableWorkspaces(DateTime startDate, DateTime endDate)
        {
            var availableWorkspaces = await _context.Workspaces
                .Where(w => !w.Reservations.Any(r => r.StartDate < endDate && r.EndDate > startDate))
                .ToListAsync();

            return Ok(availableWorkspaces);
        }




        [HttpPost("events/{id}/reservation")]
        public async Task<IActionResult> RegisterToEvent(int id, int memberId)
        {
            var evento = await _context.Events.Include(e => e.Participants).FirstOrDefaultAsync(e => e.Id == id);
            if (evento == null)
            {
                return NotFound();
            }

            if (evento.Participants.Count >= evento.Capacity)
            {
                return BadRequest("El evento ha alcanzado su capacidad máxima.");
            }

            var member = await _context.Members.FindAsync(memberId);
            if (member == null)
            {
                return NotFound();
            }

            evento.Participants.Add(member);
            await _context.SaveChangesAsync();

            return NoContent();

        }
    }
}
