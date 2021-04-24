using System.Linq;
using API.Errors;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services )
        {
            services.AddScoped<IProductRepositry,ProductRepository>();
            services.AddScoped(typeof(IGenericRepostorty<>),(typeof(GenericRepostory<>)));

              services.Configure<ApiBehaviorOptions>(option =>{
             option.InvalidModelStateResponseFactory = actionContext =>{
                 var error = actionContext.ModelState
                 .Where(e => e.Value.Errors.Count > 0)
                 .SelectMany(x => x.Value.Errors)
                 .Select(x => x.ErrorMessage).ToArray();

                 var errorResponse =  new ApiValidationErrorResponse{
                      Errors = error
                 };
                 return new BadRequestObjectResult(errorResponse);
              };
             });
             return  services;
        }
    }
}