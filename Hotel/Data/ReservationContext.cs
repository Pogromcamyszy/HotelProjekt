using Hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Data
{
   
        public class ReservationContext : DbContext
        {
            public ReservationContext(DbContextOptions<ReservationContext> options) : base(options)
            {
            }

            public DbSet<Guest> Guests { get; set; }
            public DbSet<Service> Services { get; set; }
            public DbSet<Reservation> Reservations { get; set; }

            public DbSet<Room> Rooms { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Service>().ToTable("Services");
                modelBuilder.Entity<Guest>().ToTable("Guests");
                modelBuilder.Entity<Room>().ToTable("Rooms");
                modelBuilder.Entity<Reservation>().ToTable("Reservations");
            }
        }
    
}
