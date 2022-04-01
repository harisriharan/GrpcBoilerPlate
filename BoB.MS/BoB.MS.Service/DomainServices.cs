using BoB.MS.Domain;
using BoB.MS.Repository.Repositories;

namespace BoB.MS.Service
{
    public class DomainServices
    {
        private static void DefineService(IServiceCollection services)
        {
            services.AddTransient<IClientService, ClientService>();
        }

        private static void DefineRepository(IServiceCollection services)
        {
            services.AddTransient<IClientRepository, ClientRepository>();
        }

        private static void DefineOtherServices(IServiceCollection services)
        {
            //Third party services
        }

        public static void Configure(IServiceCollection services)
        {
            DefineService(services);
            DefineRepository(services);
            DefineOtherServices(services);
        }
    }
}
