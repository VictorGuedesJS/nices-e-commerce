---
paths:
  - "src/Loja.Application/**"
  - "src/Loja.Infrastructure/**"
  - "src/Loja.Api/**"
---

# Regras de Application, Infrastructure e Api

## Application
- Um caso de uso por pasta: `Catalogo/CriarProduto/{CriarProdutoCommand, CriarProdutoHandler, CriarProdutoValidator}.cs`.
- Handler: valida a entrada, carrega o agregado pelo repositório, chama o método de domínio e salva via `IUnitOfWork`.
  Não toma decisão de negócio.
- Retorna DTOs (`record`), nunca entidades.
- Serviços externos são portas (interfaces) definidas aqui: `IGatewayPagamento`, `ICalculadoraFrete`.
- Registre tudo em `DependencyInjection.AddApplication`.

## Infrastructure
- `LojaDbContext` + uma `IEntityTypeConfiguration<T>` por entidade em `Persistence/Configurations/`.
  Nada de data annotations no Domain.
- Value Objects mapeados com `OwnsOne`/`ComplexProperty` ou conversões.
- Repositórios implementam as interfaces do Domain; o Unit of Work publica eventos de domínio após `SaveChanges`.
- Registre tudo em `DependencyInjection.AddInfrastructure`.

## Api
- Controller fino: `[ApiController]`, rota `api/[controller]`, recebe DTO, chama o handler e devolve o resultado.
- Erros: `DomainException` → 422, validação → 400, não encontrado → 404, sempre em `ProblemDetails`.
- Endpoints de admin com `[Authorize(Roles = "Admin")]`.
- Segredos via `dotnet user-secrets` (dev) e variáveis de ambiente (deploy).
