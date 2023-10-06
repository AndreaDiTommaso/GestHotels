using GestHotelsDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GestHotelsDomain
{
    public class HotelDbContext : DbContext
    {
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Price> Price { get; set; }
        public DbSet<PriceList> PriceList { get; set; }
        public DbSet<Hotel> Room { get; set; }
        public DbSet<Hotel> RoomType { get; set; }

        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            //builder.UseSqlServer("Data Source=PC-ANDREA;Initial Catalog=prenotazione;Integrated Security=True");
        }
    }
}
