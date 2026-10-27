using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Loja.Infrastructure;

public static class DependencyInjection
{
    /// <summary>Registra banco de dados, repositórios e serviços externos.</summary>
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, IConfiguration configuration)
    {
        _ = configuration; // usado a partir da Fase 1 (connection string)
        return services;
    }
}
