using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.DAL
{
    public class EmployeeManagementCatalogContext : DbContext
    {
        public EmployeeManagementCatalogContext(DbContextOptions<EmployeeManagementCatalogContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .ToTable(nameof(Employee));
        }
    }
}
