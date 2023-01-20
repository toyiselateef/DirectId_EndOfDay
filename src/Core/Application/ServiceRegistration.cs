using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection; 

namespace Application
{


    public static class ServiceRegistration
    {
        public static void AddApplication(this IServiceCollection services )
        {
           // services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
