using FluentValidation;
using GroupApp.Core.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace GroupApp.Core.Registrations;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessService(this IServiceCollection services)
    {

        services.AddHttpContextAccessor();

        var validatorAssemblies = ValidatorAssemblyProvider.GetValidatorAssemblies();
        foreach (var assemblyType in validatorAssemblies)
        {
            services.AddValidatorsFromAssemblyContaining(assemblyType);
        }

        ServiceRegistrationProvider.RegisterServices(services);

        return services;

    }
}