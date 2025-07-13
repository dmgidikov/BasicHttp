namespace BasicWebServer.Server.Common
{
    public interface IServiceCollection
    {
        IServiceCollection Add<TService, TImplementation>()
            where TImplementation : TService
            where TService : class;

        IServiceCollection Add<TService>()
            where TService : class;

        object CreateInstance(Type serviceType);

        TService Get<TService>()
            where TService : class;
    }
}