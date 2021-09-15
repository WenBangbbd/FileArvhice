namespace Microsoft.Extensions.DependencyInjection
{
    public class ActivateBuilder:IActivateBuilder
    {
        public IServiceCollection Services { get; }

        public ActivateBuilder(IServiceCollection services)
        {
            Services = services;
        }
    }
}