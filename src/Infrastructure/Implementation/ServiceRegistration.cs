using Application.Interfaces.Services;
using Implementation.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Implementation
{
    public static class ServiceRegistration
    {
        public static void AddImplementation(this IServiceCollection services)
        {
            services.AddScoped<IAccountService,AccountService>();
            services.AddScoped<IUserService,UserService>();
           
        }
    }
}
