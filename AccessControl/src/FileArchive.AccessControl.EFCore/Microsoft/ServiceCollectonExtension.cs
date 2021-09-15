using FileArchive.AccessControl;
using FileArchive.AccessControl.Activate;
using FileArchive.AccessControl.EFCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectonExtension
    {
        public static IAccessBuilder AddAccessRepositories(this IAccessBuilder builder, Action<DbContextOptionsBuilder> cfg)
        {
            builder.Services
                .AddDbContext<AccessContext>(cfg)
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IRoleRepository, RoleRepository>()
                .AddScoped<IAuthorityRepository, AuthorityRepository>();
            return builder;
        }
        public static IActivateBuilder AddActivateRepositories(this IActivateBuilder builder, Action<DbContextOptionsBuilder> cfg)
        {
            builder.Services
                .AddDbContext<AccessContext>(cfg)
                .AddScoped<IActivateRecordRepository, ActivateRecordRepository>();
            return builder;
        }
    }
}
