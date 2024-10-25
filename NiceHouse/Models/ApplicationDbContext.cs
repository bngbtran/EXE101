using Microsoft.EntityFrameworkCore;
using NiceHouse.Models;

public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            {
            }
    
//------------------------------------------------------------------------------

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<HotelImage> HotelImages { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<RoomTypeImage> RoomTypeImages { get; set; }
        public DbSet<Dormitory> Dormitories { get; set; }
        public DbSet<DormitoryImage> DormitoryImages { get; set; }

//------------------------------------------------------------------------------

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<RoomType>().HasOne(rt => rt.Hotel).WithMany(h => h.RoomTypes).HasForeignKey(rt => rt.HotelId).OnDelete(DeleteBehavior.Restrict);
                modelBuilder.Entity<Room>().HasOne(r => r.Hotel).WithMany(h => h.Rooms).HasForeignKey(r => r.HotelId).OnDelete(DeleteBehavior.Cascade);
                modelBuilder.Entity<Room>().HasOne(r => r.RoomType).WithMany(rt => rt.Rooms).HasForeignKey(r => r.RoomTypeId).OnDelete(DeleteBehavior.Cascade);
                modelBuilder.Entity<HotelImage>().HasOne(hi => hi.Hotel).WithMany(h => h.Images).HasForeignKey(hi => hi.HotelId).OnDelete(DeleteBehavior.Cascade);
                modelBuilder.Entity<RoomTypeImage>().HasOne(rti => rti.RoomType).WithMany(rt => rt.Images).HasForeignKey(rti => rti.RoomTypeId).OnDelete(DeleteBehavior.Cascade);
                modelBuilder.Entity<DormitoryImage>().HasOne(di => di.Dormitory).WithMany(d => d.Images).HasForeignKey(di => di.DormitoryId).OnDelete(DeleteBehavior.Cascade);
            }
    }