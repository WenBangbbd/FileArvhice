using Microsoft.Extensions.DependencyInjection;

namespace FileArchive.AccessControl
{
    public class AccessBuilder : IAccessBuilder
    {
        public AccessBuilder(IServiceCollection services)
        {
            Services = services;
        }

        public IServiceCollection Services { get; }
    }
}
