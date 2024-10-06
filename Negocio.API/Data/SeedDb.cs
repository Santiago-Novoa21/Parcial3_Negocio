using Negocio.Shared.Entities;
using Negocio.API.Data;
using Negocio.Shared.Entities;



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
            await CheckAdminsAsync();
            await CheckMembersAsync();
            await CheckEventsAsync();
            await CheckWorkspacesAsync();
            await CheckResourcesAsync();

        }


        private async Task CheckAdminsAsync()
        {
            if (!_context.Admins.Any())
            {
                _context.Admins.Add(new Admin
                {
                    Name = "Admin 1",
                    Email = "admin1@coworkspace.com",
                    Role = "Administrator"
                });

                _context.Admins.Add(new Admin
                {
                    Name = "Admin 2",
                    Email = "admin2@coworkspace.com",
                    Role = "Administrator"
                });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckMembersAsync()
        {
            if (!_context.Members.Any())
            {
                _context.Members.Add(new Member
                {
                    Name = "Member 1",
                    Email = "member1@coworkspace.com",
                    PhoneNumber = "123456789",
                    MembershipId = 1 // Asumiendo que ya existe una membresía con Id 1
                });

                _context.Members.Add(new Member
                {
                    Name = "Member 2",
                    Email = "member2@coworkspace.com",
                    PhoneNumber = "987654321",
                    MembershipId = 2 // Asumiendo que ya existe una membresía con Id 2
                });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckEventsAsync()
        {
            if (!_context.Events.Any())
            {
                _context.Events.Add(new Event
                {
                    Name = "Event 1",
                    Description = "Description for Event 1",
                    Date = DateTime.Now.AddDays(10),
                    Capacity = 100
                });

                _context.Events.Add(new Event
                {
                    Name = "Event 2",
                    Description = "Description for Event 2",
                    Date = DateTime.Now.AddDays(20),
                    Capacity = 50
                });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckWorkspacesAsync()
        {
            if (!_context.Workspaces.Any())
            {
                _context.Workspaces.Add(new Workspace
                {
                    Name = "Workspace 1",
                    Description = "Description for Workspace 1",
                    Capacity = 10
                });

                _context.Workspaces.Add(new Workspace
                {
                    Name = "Workspace 2",
                    Description = "Description for Workspace 2",
                    Capacity = 20
                });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckResourcesAsync()
        {
            if (!_context.Resources.Any())
            {
                _context.Resources.Add(new Resource
                {
                    Name = "Projector",
                    Description = "High definition projector",
                    Available = true
                });

                _context.Resources.Add(new Resource
                {
                    Name = "Printer",
                    Description = "Color printer",
                    Available = true
                });

                await _context.SaveChangesAsync();
            }

        }
    }

}