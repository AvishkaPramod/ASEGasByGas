using gasbygas.lb.business.Common;
using gasbygas.lb.business.Manager;
using gasbygas.lb.business.Mappers;
using gasbygas.lb.business.Wrappers;
using gasbygas.lb.contracts.Manager;
using gasbygas.lb.contracts.Repositories;
using gasbygas.lb.data.Mappers;
using gasbygas.lb.data.Repositories;
using gasbygas.lb.dbcontex.tables.Models;
using gasbygas.lb.entities.Cetificatevalidaton;
using gasbygas.lb.entities.Configuration;
using gasbygas.lb.entities.Customer;
using gasbygas.lb.entities.GasStock;
using gasbygas.lb.entities.User;
using gasbygas.lb.shared.Contracts;
using gasbygas.lb.shared.Models;
using Microsoft.EntityFrameworkCore;

namespace ASEGasByGas.Models
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers the services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        /// 
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<gasbygasContext>(options =>options.UseMySql(configuration.GetConnectionString("ClientConnection"),
            new MySqlServerVersion(new Version("8.0.40"))));

            #region Confgiguration
            //services.Configure<LoginConfiguration>(configuration.GetSection("IdentityServer"));
            services.Configure<ConnectionStringConfiguration>(configuration.GetSection("ConnectionStrings"));
            #endregion

            #region Manager
            //Customer
            services.AddScoped<ICustomerManager, CustomerManager>();
            //GasStock
            services.AddScoped<IGasStockManager, GasStockManager>();
            //User
            services.AddScoped<IUserManager, UserManager>();   
            //CertificateValidation
            services.AddScoped<ICertificatevalidationManager, CertificatevalidationManager>();
            #endregion


            #region Repositories
            //Customer
            services.AddScoped<ICustomerRepositories, CustomerRepository>();
            //GasStock
            services.AddScoped<IGasStockRepositories, GasStockRepository>();
            //User
            services.AddScoped<IUserRepositories, UserRepository>();
            //CertificateValidation
            services.AddScoped<ICertificatevalidationRepositories, CertificatevalidationRepository>();
            #endregion

            #region Mapper
            services.AddSingleton<IEntityMapper, EntityMapper>();
            services.AddSingleton<IMapper<ResponseMessage, ResponseBase>, ServiceErrorMapper>();
            services.AddScoped<IMapper<Object, ResponseBase>, ServiceResponseMapper>();

            //Customer
            services.AddScoped<IMapper<CustomerRequestWrapper, CustomerSaveRequest>, CustomerSaveRequestMapper>();
            //GasStock
            services.AddScoped<IMapper<GasStockRequestWrapper, GasStockSaveRequest>, GasStockSaveRequestMapper>();
            //User
            services.AddScoped<IMapper<UserRequestWrapper, UserSaveRequest>, UserSaveRequestMapper>();
            //CertificateValidation
            services.AddScoped<IMapper<CertificatevalidationRequestWrapper, CertificatevalidationSaveRequest>, CertificatevalidationSaveRequestMapper>();
            #endregion


            return services;
        }
    }
}