namespace Loja.Domain.Common;

/// <summary>Algo relevante que aconteceu no domínio (ex.: PedidoPago).</summary>
public interface IDomainEvent
{
    DateTime OcorridoEm { get; }
}
