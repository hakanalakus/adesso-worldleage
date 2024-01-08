using Adesso.WorldLeague.EntityFrameworkCore;
using Adesso.WorldLeague.Leagues;
using Adesso.WorldLeague.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace Adesso.WorldLeague.HttpHost;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddApplicationsServices();
        builder.Services.AddTransient<GlobalResponseHandlerMiddleware>();

        var app = builder.Build();

        app.UseMiddleware<GlobalResponseHandlerMiddleware>();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        using (var seederScope = app.Services.CreateScope())
        {
            var seeder = seederScope.ServiceProvider.GetRequiredService<EfCoreDataSeeder>();
            await seeder.SeedAsync();
        }

        app.MapLeagueServiceEndpoints();

        app.Run();
    }
}
