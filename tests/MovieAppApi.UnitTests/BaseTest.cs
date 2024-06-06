namespace MovieAppApi.UnitTests;

using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieAppApi.EnvConfig;

public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        DotEnv.Load();
        builder.ConfigureServices(services =>
        {
            // Configurar servicios específicos para pruebas si es necesario
        });

        return base.CreateHost(builder);
    }
}