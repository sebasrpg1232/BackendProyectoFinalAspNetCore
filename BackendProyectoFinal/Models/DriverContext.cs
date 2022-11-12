using BackendProyectoFinal.Domain;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace DriverApi.Models
{
    public class DriverContext : DbContext
    {
        public DriverContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Driver> Drivers { get; set; }
    }
}