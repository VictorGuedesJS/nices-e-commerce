using Microsoft.Extensions.DependencyInjection;

namespace Loja.Application;

public static class DependencyInjection
{
    /// <summary>Registra os casos de uso da camada de aplicação.</summary>
    public static IServiceCollection AddApplication(this IServiceCollection services) => services;
}
