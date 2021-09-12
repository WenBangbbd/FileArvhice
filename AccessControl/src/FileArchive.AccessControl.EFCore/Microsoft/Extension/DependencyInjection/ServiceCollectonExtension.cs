using FileArchive.AccessControl;
using FileArchive.AccessControl.EFCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectonExtension
    {
        public static IServiceCollection AddAccessRepositories(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction = null)
        {
            services.AddDbContext<AccessContext>(optionsAction);
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IAuthorityRepository, AuthorityRepository>();
            return services;
        }
    }
}
