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
        public static IServiceCollection ConfigAccess(this IServiceCollection services, Action<IAccessBuilder> cfg)
        {
            var builder = new AccessBuilder(services);
            cfg(builder);
            builder.AddAccessServices();
            return services;
        }
    }


}
