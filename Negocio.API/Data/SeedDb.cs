using Negocio.Shared.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Negocio.API.Data
{
    public class SeedDb
    {
        // Declarar el campo _context una sola vez
        private readonly DataContext _context;

        // Inyectar el contexto de base de datos en el constructor
        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            // Asegurarse de que la base de datos existe y aplicar migraciones
            await _context.Database.EnsureCreatedAsync();

            // Llamar a los métodos para poblar las diferentes tablas
            await CheckMembershipsAsync();
            await CheckMembersAsync();
            await CheckWorkspacesAsync();
            await CheckResourcesAsync();
            await CheckEventsAsync();
            await CheckReservationsAsync();
        }

        private async Task CheckMembershipsAsync()
        {
            if (!_context.Memberships.Any())
            {
                _context.Memberships.Add(new Membership
                {
                    Level = "Gold",
                    Privileges = "Acceso ilimitado a todas las áreas"
                });

                _context.Memberships.Add(new Membership
                {
                    Level = "Silver",
                    Privileges = "Acceso a oficinas y salas de reuniones"
                });

                _context.Memberships.Add(new Membership
                {
                    Level = "Bronze",
                    Privileges = "Acceso a áreas comunes y escritorios"
                });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckMembersAsync()
        {
            if (!_context.Members.Any())
            {
                var goldMembership = _context.Memberships.FirstOrDefault(m => m.Level == "Gold");
                var silverMembership = _context.Memberships.FirstOrDefault(m => m.Level == "Silver");

                _context.Members.Add(new Member
                {
                    Name = "Juan Pérez",
                    Email = "juan.perez@example.com",
                    PhoneNumber = "123456789",
                    MembershipId = goldMembership.Id
                });

                _context.Members.Add(new Member
                {
                    Name = "Maria Lopez",
                    Email = "maria.lopez@example.com",
                    PhoneNumber = "987654321",
                    MembershipId = silverMembership.Id
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
                    Name = "Sala de Reuniones A",
                    Description = "Sala de reuniones para 10 personas",
                    Capacity = 10
                });

                _context.Workspaces.Add(new Workspace
                {
                    Name = "Oficina Compartida",
                    Description = "Oficina compartida con 20 escritorios",
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
                    Description = "4K Projector",
                    Available = true
                });

                _context.Resources.Add(new Resource
                {
                    Name = "Whiteboard",
                    Description = "Large whiteboard",
                    Available = true
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
                    Name = "Conferencia de Innovación",
                    Description = "Evento sobre innovación en tecnología",
                    Date = DateTime.Now.AddMonths(1),
                    Capacity = 100
                });

                _context.Events.Add(new Event
                {
                    Name = "Taller de Emprendimiento",
                    Description = "Taller para futuros emprendedores",
                    Date = DateTime.Now.AddMonths(2),
                    Capacity = 50
                });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckReservationsAsync()
        {
            if (!_context.Reservations.Any())
            {
                var workspace = _context.Workspaces.FirstOrDefault(w => w.Name == "Sala de Reuniones A");
                var member = _context.Members.FirstOrDefault(m => m.Name == "Juan Pérez");

                _context.Reservations.Add(new Reservation
                {
                    StartDate = DateTime.Now.AddDays(5),
                    EndDate = DateTime.Now.AddDays(6),
                    WorkspaceId = workspace.Id,
                    MemberId = member.Id
                });

                await _context.SaveChangesAsync();
            }
        }
    }
}