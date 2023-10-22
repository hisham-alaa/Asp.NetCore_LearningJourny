using Microsoft.EntityFrameworkCore;
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
            // Add services to the container.

            webAppBuilder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            webAppBuilder.Services.AddEndpointsApiExplorer();

            webAppBuilder.Services.AddSwaggerGen();

            webAppBuilder.Services.AddDbContext<StoreContext>(options =>
            {
                options.UseSqlServer(webAppBuilder.Configuration.GetConnectionString("DefaultConnection"));

            });

            webAppBuilder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            #endregion

            var app = webAppBuilder.Build();

            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var dbContext = services.GetRequiredService<StoreContext>();
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            try
            {
                await dbContext.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "an Error Occured During Applying Migration");
            }


            #region Configure Kestrel MiddleWares
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.MapControllers(); //replaces the use routing and use endpoint with map controller inside it 

            #endregion

            app.Run();
        }
    }
}