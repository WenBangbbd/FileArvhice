using FileArchive.AccessControl.Activate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigActivate(this IServiceCollection services, Action<IActivateBuilder> cfg)
        {
            var builder = new ActivateBuilder(services);
            cfg(builder);
            return services;
        }
    }

}
