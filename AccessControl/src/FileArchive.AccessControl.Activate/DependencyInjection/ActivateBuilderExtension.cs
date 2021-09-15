using FileArchive.AccessControl.Activate;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ActivateBuilderExtension
    {
        public static IActivateBuilder AddActivateServices(this IActivateBuilder builder, Action<ActivateOptions> cfg)
        {
            builder.Services.Configure(cfg);
            builder.Services.AddScoped<IAccountActivateService, EmailAccountActivateService>();
            return builder;
        }
    }
}
