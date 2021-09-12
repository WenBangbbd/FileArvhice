using FileArchive.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
   public static class ServiceCollectonExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction = null)
        {
            services.AddAccessRepositories(optionsAction);
            services.AddAccessServices();
            services.AddScoped<IAccessControlService, AccessControlService>();           
            services.AddAutoMapper(typeof(AccessProfile));
            return services;
        }
    }
}
