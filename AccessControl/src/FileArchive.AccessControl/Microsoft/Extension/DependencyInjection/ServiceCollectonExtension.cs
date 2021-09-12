using FileArchive.AccessControl;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
   public static class ServiceCollectonExtension
    {
        public static IServiceCollection AddAccessServices(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction = null)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IAuthorityService, AuthorityService>();
            return services;
        }
    }
}
