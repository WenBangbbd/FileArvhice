using Microsoft.Extensions.DependencyInjection;

namespace FileArchive.AccessControl
{
    public static class IAccessBuilderExtension
    {
        public static IAccessBuilder AddAccessServices(this IAccessBuilder builer)
        {
            builer.Services
               .AddScoped<IUserService, UserService>()
               .AddScoped<IRoleService, RoleService>()
               .AddScoped<IAuthorityService, AuthorityService>();
            return builer;
        }
    }
}
