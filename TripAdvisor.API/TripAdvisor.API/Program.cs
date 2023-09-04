using TripAdvisor.Db.Implementations;
using TripAdvisor.Db.Interfaces;
using TripAdvisor.Db.Models;
using TripAdvisor.Dto.Config;
using TripAdvisor.Repository.Implementations;
using TripAdvisor.Repository.Interfaces;
using TripAdvisor.Service.Implementations;
using TripAdvisor.Service.Interfaces;

namespace TripAdvisor.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add configurations to the containers
            builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection("ConnectionStrings"));
            builder.Services.Configure<TripAdvisorSettings>(builder.Configuration.GetSection("TripAdvisorSettings"));
            builder.Services.Configure<WeatherForecastApiSettings>(builder.Configuration.GetSection("WeatherForecastApiSettings"));
            builder.Services.AddSingleton<IDbContext, AppDbContext>();


            // Add services to the container.
            builder.Services.AddScoped<IDistrictTemperatureRepository, DistrictTemperatureRepository>();

            builder.Services.AddScoped<IHttpClientService, HttpClientService>();
            
            builder.Services.AddScoped<IWeatherService, WeatherService>();
            builder.Services.AddScoped<IDistrictService, DistrictService>();
            builder.Services.AddScoped<ITripService, TripService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
               
            }

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}