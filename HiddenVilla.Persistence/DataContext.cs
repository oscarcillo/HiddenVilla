using HiddenVilla.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace HiddenVilla.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(){ }

        public DataContext(DbContextOptions<DataContext> options) : base (options){ }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured) options.UseSqlServer("A FALLBACK CONNECTION STRING");
        }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);            
        }

        public DbSet<HotelRoom> HotelRooms {get; set;}
    }
}