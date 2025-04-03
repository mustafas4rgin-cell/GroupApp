using GroupApp.Core.Concrete;
using GroupApp.Core.Services;
using GroupApp.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace GroupApp.Core.Providers;

public class ServiceRegistrationProvider 
{
    public static void RegisterServices(IServiceCollection services)
    {
        var servicesToRegister = new (Type Interface, Type Implementation)[]
        {
            (typeof(IGenericService<>), typeof(GenericService<>)),
            (typeof(IDataRepository), typeof(DataRepository)),
        };

        foreach (var service in servicesToRegister)
        {
            services.AddTransient(service.Interface, service.Implementation);
        }
    }
}