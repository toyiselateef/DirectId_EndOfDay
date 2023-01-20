using Application.Interfaces.Respository;  
using Microsoft.Extensions.DependencyInjection; 
using Persistance.Repositories;

namespace Persistance
{


    public static class ServiceRegistration
    {
        public static void AddPersistance(this IServiceCollection services)
        {

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IUserRepository, UserRepository>();


           
        }
    }
}
