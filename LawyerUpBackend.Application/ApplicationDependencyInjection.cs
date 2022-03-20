using LawyerUpBackend.Application.Services;
using LawyerUpBackend.Application.Services.Impl;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace LawyerUpBackend.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services )
    {
        services.AddServices();


        return services;
    }

    public static void AddServices(this IServiceCollection services)
    {
        //services.AddScoped<IPredictionModelService, PredictionModelService>();
        services.AddScoped<ILawyerService, LawyerService>();
    }

    
}
