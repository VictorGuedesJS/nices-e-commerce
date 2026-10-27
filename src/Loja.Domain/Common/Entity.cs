namespace Loja.Domain.Common;

/// <summary>Objeto com identidade: dois objetos são iguais se têm o mesmo Id.</summary>
public abstract class Entity
{
    public Guid Id { get; protected init; } = Guid.NewGuid();

    public override bool Equals(object? obj) =>
        obj is Entity other && other.GetType() == GetType() && other.Id == Id;

    public override int GetHashCode() => HashCode.Combine(GetType(), Id);
}
