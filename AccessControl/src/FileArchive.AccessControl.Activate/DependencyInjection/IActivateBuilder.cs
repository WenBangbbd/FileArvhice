namespace Microsoft.Extensions.DependencyInjection
{
    public interface IActivateBuilder
    {
        IServiceCollection Services { get; }
    }
}
