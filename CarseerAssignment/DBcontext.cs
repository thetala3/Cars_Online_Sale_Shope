using CarseerAssignment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Xml;

namespace CarseerAssignment
{
    public class DBcontext : DbContext
    {
        public DBcontext(DbContextOptions<DBcontext> options)
        : base(options)
        {
           
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasKey(x => x.id);
        }

        public DbSet<Car> _car { get; set; }
    }
}
