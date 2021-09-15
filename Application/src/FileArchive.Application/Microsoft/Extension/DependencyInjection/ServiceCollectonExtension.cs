using FileArchive.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using FileArchive.AccessControl.EFCore;
using FileArchive.AccessControl;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectonExtension
    {
        public static IServiceCollection ConfigFileArchive(this IServiceCollection services, Action<IFileArchiveBuilder> cfg)
        {
            var builder = new FileArchiveBuilder(services);
            cfg(builder);
            builder.AddApplicationServices();
            return services;
        }

        public static IFileArchiveBuilder AddApplicationServices(this IFileArchiveBuilder builder)
        {
            builder.Services
                .AddScoped<IAccessControlService, AccessControlService>()
                .AddAutoMapper(typeof(AccessProfile));
            return builder;
        }
    }

    public class FileArchiveBuilder : IFileArchiveBuilder
    {
        public IServiceCollection Services { get; }

        public FileArchiveBuilder(IServiceCollection services)
        {
            Services = services;
        }
    }

    public static class FileArchiveExtension
    {
        public static IFileArchiveBuilder ConfigAccess(this IFileArchiveBuilder builder, Action<IAccessBuilder> cfg)
        {
            builder.Services.ConfigAccess(cfg);
            return builder;
        }
        public static IFileArchiveBuilder ConfigActivate(this IFileArchiveBuilder builder,Action<IActivateBuilder> cfg)
        {
            builder.Services.ConfigActivate(cfg);
            return builder;
        }
    }

    public interface IFileArchiveBuilder
    {
        IServiceCollection Services { get; }
    }

}
