using GestHotelsDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GestHotelsDomain.Data
{
    public class HotelDbContext : DbContext
    {

        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {

        }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Price> Price { get; set; }
        public DbSet<RoomType> RoomType { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder builder)
        //{
        //    IConfigurationRoot configuration = new ConfigurationBuilder()
        //    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        //    .AddJsonFile("appsettings.json")
        //    .Build();
        //    builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        //    //builder.UseSqlServer("Data Source=PC-ANDREA;Initial Catalog=prenotazione;Integrated Security=True");
        //}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Price>()
                .HasAlternateKey(p => new { p.RoomTypeId, p.Date })
                .HasName("IX_UniqueKeyConstraint");
            //builder.Entity<RoomType>()
            //    .HasAlternateKey(r => new { r.Id, r.RoomId })
            //    .HasName("IX_UniqueKeyConstraint");

        }
    }
}
