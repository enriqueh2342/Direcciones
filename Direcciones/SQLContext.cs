using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Direcciones.Models;

namespace Direcciones
{
    public class SQLContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DireccionesDB"].ConnectionString;

            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Address> Address { get; set; }
        //public DbSet<BuildVersion> BuildVersion { get; set; }

    }
}