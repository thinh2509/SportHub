
using Microsoft.EntityFrameworkCore;
using SportHub.API.Data;
using SportHub.API.Repositories;
using SportHub.API.Repositories.Interfaces;
using SportHub.API.Services.Interfaces;
using SportHub.API.Services;
using SportHub.API.Middlewares;

namespace SportHub.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Database
            var connectString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectString);
            });

            // Repositories
            builder.Services.AddScoped<ISportTypeRepository, SportTypeRepository>();

            // Services
            builder.Services.AddScoped<ISportTypeService, SportTypeService>();

            // GlobalHanlder
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.AddProblemDetails();

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
