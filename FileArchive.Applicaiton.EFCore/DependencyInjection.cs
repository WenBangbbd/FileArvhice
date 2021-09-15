using FileArchive.AccessControl.Activate;
using FileArchive.Applicaiton.EFCore;
using FileArchive.Application;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicaitonRepositories(this IServiceCollection services,Action<DbContextOptionsBuilder> cfg)
        {
            services.AddDbContext<DbContext>(cfg);
            services.AddScoped<IActivateRecordRepository, ActivateRecordRepository>();
            return services;
        }
    }
}
