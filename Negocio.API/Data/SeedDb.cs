using Negocio.Shared.Entities;
using System.Threading.Tasks;

namespace Negocio.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            if (!_context.Admins.Any())
            {
                await AddAdmins();
            }

            if (!_context.Memberships.Any())
            {
                await AddMemberships();
            }

            if (!_context.Members.Any())
            {
                await AddMembers();
            }

            if (!_context.Workspaces.Any())
            {
                await AddWorkspaces();
            }

            if (!_context.Resources.Any())
            {
                await AddResources();
            }

            if (!_context.Reservations.Any())
            {
                await AddReservations();
            }

            await _context.SaveChangesAsync();
        }

        private async Task AddAdmins()
        {
            _context.Admins.Add(new Admin { Name = "Admin 1", Email = "admin1@example.com", Role = "SuperAdmin" });
            _context.Admins.Add(new Admin { Name = "Admin 2", Email = "admin2@example.com", Role = "Admin" });

            await _context.SaveChangesAsync();
        }

        private async Task AddMemberships()
        {
            _context.Memberships.Add(new Membership { Level = "Basic", Privileges = "Access to common areas" });
            _context.Memberships.Add(new Membership { Level = "Premium", Privileges = "Access to all areas, including premium rooms" });

            await _context.SaveChangesAsync();
        }

        private async Task AddMembers()
        {
            var membership = _context.Memberships.First();

            _context.Members.Add(new Member { Name = "John Doe", Email = "john@example.com", PhoneNumber = "123456789", MembershipId = membership.Id });
            _context.Members.Add(new Member { Name = "Jane Doe", Email = "jane@example.com", PhoneNumber = "987654321", MembershipId = membership.Id });

            await _context.SaveChangesAsync();
        }

        private async Task AddWorkspaces()
        {
            _context.Workspaces.Add(new Workspace { Name = "Meeting Room 1", Description = "Room with a projector", Capacity = 10 });
            _context.Workspaces.Add(new Workspace { Name = "Conference Hall", Description = "Large hall for conferences", Capacity = 100 });

            await _context.SaveChangesAsync();
        }

        private async Task AddResources()
        {
            _context.Resources.Add(new Resource { Name = "Projector", Description = "4K Projector", Available = true });
            _context.Resources.Add(new Resource { Name = "Whiteboard", Description = "Large whiteboard", Available = true });

            await _context.SaveChangesAsync();
        }

        private async Task AddReservations()
        {
            var member = _context.Members.First();
            var workspace = _context.Workspaces.First();

            _context.Reservations.Add(new Reservation
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                MemberId = member.Id,
                WorkspaceId = workspace.Id
            });

            await _context.SaveChangesAsync();
        }
    }
}