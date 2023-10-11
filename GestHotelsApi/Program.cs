using GestHotelsDomain.Data;
using GestHotelsDomain.Queries.Price;
using GestHotelsDomain.Repositories.Hotel;
using GestHotelsDomain.Repositories.Price;
using GestHotelsDomain.Repositories.RoomType;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<HotelDbContext>(
        options => options.UseSqlServer( 
        builder.Configuration.GetConnectionString("DefaultConnection")));

var assembly = typeof(GetPriceListQuery).Assembly;
builder.Services.AddMediatR(typeof(GetPriceListQuery).GetTypeInfo().Assembly);
builder.Services.AddScoped<IPriceRepository, PriceRepository>();
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
using (IServiceScope scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    scope.ServiceProvider.GetService<HotelDbContext>().Database.Migrate();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
