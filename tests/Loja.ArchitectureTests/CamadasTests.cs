using System.Reflection;
using NetArchTest.Rules;

namespace Loja.ArchitectureTests;

/// <summary>
/// Garante a regra de dependência do DDD em camadas:
/// Api → Infrastructure → Application → Domain (o Domain não conhece ninguém).
/// Se alguém quebrar a regra, os testes falham.
/// </summary>
public class CamadasTests
{
    private static readonly Assembly Domain = typeof(Loja.Domain.Common.Entity).Assembly;
    private static readonly Assembly Application = typeof(Loja.Application.DependencyInjection).Assembly;
    private static readonly Assembly Infrastructure = typeof(Loja.Infrastructure.DependencyInjection).Assembly;

    [Fact]
    public void Domain_NaoDependeDeOutrasCamadas()
    {
        var resultado = Types.InAssembly(Domain).ShouldNot()
            .HaveDependencyOnAny("Loja.Application", "Loja.Infrastructure", "Loja.Api",
                "Microsoft.EntityFrameworkCore", "Microsoft.AspNetCore")
            .GetResult();

        Assert.True(resultado.IsSuccessful, Falhas(resultado));
    }

    [Fact]
    public void Application_NaoDependeDeInfrastructureNemApi()
    {
        var resultado = Types.InAssembly(Application).ShouldNot()
            .HaveDependencyOnAny("Loja.Infrastructure", "Loja.Api",
                "Microsoft.EntityFrameworkCore", "Microsoft.AspNetCore")
            .GetResult();

        Assert.True(resultado.IsSuccessful, Falhas(resultado));
    }

    [Fact]
    public void Infrastructure_NaoDependeDaApi()
    {
        var resultado = Types.InAssembly(Infrastructure).ShouldNot()
            .HaveDependencyOn("Loja.Api")
            .GetResult();

        Assert.True(resultado.IsSuccessful, Falhas(resultado));
    }

    private static string Falhas(TestResult resultado) =>
        "Tipos que violam a regra: " + string.Join(", ", resultado.FailingTypeNames ?? []);
}
