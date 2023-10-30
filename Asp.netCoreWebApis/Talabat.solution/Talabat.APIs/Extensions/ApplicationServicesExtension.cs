using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using Talabat.APIs.Errors;
using Talabat.APIs.Helpers;
using Talabat.Core.Reporitories.Contract;
using Talabat.Repository.Repositories.Implementation;

namespace Talabat.APIs.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddAutoMapper(typeof(MappingProfiles));

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState.Where(ModelStateValue => ModelStateValue.Value?.Errors.Count > 0)
                                                  .SelectMany(ModelStateValue => ModelStateValue.Value.Errors)
                                                  .Select(Errors => Errors.ErrorMessage)
                                                  .ToList();

                    return new BadRequestObjectResult(new ApiValidationErrorResponse(errors));
                };
            });

            return services;

        }
    }
}
