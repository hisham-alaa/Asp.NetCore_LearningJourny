using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Talabat.APIs.Errors;
using Talabat.APIs.Extensions;
using Talabat.APIs.Helpers;
using Talabat.APIs.Middlewares;
using Talabat.Core.Reporitories.Contract;
using Talabat.Repository.Data.Contexts;
using Talabat.Repository.Repositories.Implementation;

namespace Talabat.APIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var webAppBuilder = WebApplication.CreateBuilder(args);

            #region Configure Services

            webAppBuilder.Services.AddControllers();

            webAppBuilder.Services.AddSwaggerServices();

            webAppBuilder.Services.AddDbContext<StoreContext>(options =>
            {
                options.UseSqlServer(webAppBuilder.Configuration.GetConnectionString("DefaultConnection"));
            });

            webAppBuilder.Services.AddAppServices();

            #endregion Configure Services

            var app = webAppBuilder.Build();

            #region AutoMigrate

            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var dbContext = services.GetRequiredService<StoreContext>();
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            try
            {
                await dbContext.Database.MigrateAsync();
                await StoreContextSeed.SeedDataAsync(dbContext);
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "an Error Occured During Applying Migration");
            }

            #endregion AutoMigrate

            #region Configure Kestrel MiddleWares

            app.UseMiddleware<ExceptionMiddleware>();

            // Configure the HTTP request pi peline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerMiddlewares();
            }

            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.MapControllers(); //replaces the use routing and use endpoint with map controller inside it

            #endregion Configure Kestrel MiddleWares

            app.Run();
        }
    }
}