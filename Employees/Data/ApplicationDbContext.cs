using Employees.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Employees.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Position> Positions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeePosition> EmployeePositions { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Position
            modelBuilder.Entity<Position>()
                .HasIndex(p => p.Name)
                .IsUnique(true);

            //EmployeePosition
            modelBuilder.Entity<EmployeePosition>()
                .HasOne(ep => ep.Employee)
                .WithMany(e => e.Positions)
                .HasForeignKey(ep => ep.EmployeeId);

            modelBuilder.Entity<EmployeePosition>()
                .HasOne(ep => ep.Position)
                .WithMany(p => p.EmployeePositions)
                .HasForeignKey(ep => ep.PositionId);

            base.OnModelCreating(modelBuilder);
        }
    }
}