using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using SocialNetwork.Repository.Infrustruce;
using SocialNetwork.Repository.Repositories.Concrete;
using SocialNetwork.Service.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Infrastructure
{
    public static class ProjectDependencies
    {
        public static IServiceCollection AddProjectDependencies(this IServiceCollection services,
            IConfiguration configuration)
        {
            var repositoryAssembly = Assembly.GetAssembly(typeof(UserRepository));

            services.RegisterAssemblyPublicNonGenericClasses(repositoryAssembly)
                .Where(c => c.Name.EndsWith("Repository"))
                .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);

            services.RegisterAssemblyPublicNonGenericClasses(repositoryAssembly)
                .Where(c => c.Name.EndsWith("Command"))
                .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);

            services.RegisterAssemblyPublicNonGenericClasses(repositoryAssembly)
                .Where(c => c.Name.EndsWith("Query"))
                .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);

            var serviceAssembly = Assembly.GetAssembly(typeof(UserService));

            services.RegisterAssemblyPublicNonGenericClasses(serviceAssembly)
                .Where(c => c.Name.EndsWith("Service"))
                .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);

            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            //services.Configure<MailSettings>(configuration.GetSection("MailSettings"));

            //services.AddTransient<IEmailService, EmailService>();
            services.AddMemoryCache();
            //services.Configure<IpRateLimitOptions>(configuration.GetSection("IpRateLimiting"));
            //services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            //services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            //services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            //services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
            //services.AddInMemoryRateLimiting();

            return services;
        }
    }
}
