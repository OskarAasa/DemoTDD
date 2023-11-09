using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LogErrorWebApi.Data;

namespace LogErrorWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<LogErrorWebApiContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("LogErrorWebApiContext") ?? throw new InvalidOperationException("Connection string 'LogErrorWebApiContext' not found.")));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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