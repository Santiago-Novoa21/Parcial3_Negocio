using Microsoft.EntityFrameworkCore;
using Negocio.Shared.Entities;

namespace Negocio.API.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {


        }

        public DbSet<Member> Members { get; set; }

        public DbSet<Membership> Memberships { get; set; }

        public DbSet<Workspace> Workspaces { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
