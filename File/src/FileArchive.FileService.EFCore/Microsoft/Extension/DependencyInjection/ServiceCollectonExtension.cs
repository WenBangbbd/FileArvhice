using FileArchive.FileService;
using FileArchive.FileService.EFCore;
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
        public static IServiceCollection AddFileRepositories(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction = null)
        {
            services.AddDbContext<FileContext>(optionsAction);
            services.AddScoped<IFileArchiveRepository, FileArchiveRepository>();
            return services;
        }
    }
}
