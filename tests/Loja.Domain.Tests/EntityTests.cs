using Loja.Domain.Common;

namespace Loja.Domain.Tests;

public class EntityTests
{
    private sealed class Exemplo : Entity
    {
        public Exemplo(Guid id) => Id = id;
    }

    [Fact]
    public void Entidades_ComMesmoId_SaoIguais()
    {
        var id = Guid.NewGuid();
        Assert.Equal(new Exemplo(id), new Exemplo(id));
    }

    [Fact]
    public void Entidades_ComIdsDiferentes_SaoDiferentes()
    {
        Assert.NotEqual(new Exemplo(Guid.NewGuid()), new Exemplo(Guid.NewGuid()));
    }
}
