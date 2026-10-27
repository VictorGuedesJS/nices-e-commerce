---
paths:
  - "src/Loja.Domain/**"
  - "tests/Loja.Domain.Tests/**"
---

# Regras do Domain

- Sem `using` de EF Core, ASP.NET, Application ou Infrastructure. Só BCL e `Loja.Domain.*`.
- Pasta por contexto: `Catalogo/`, `Estoque/`, `Carrinho/`, `Vendas/`, `Pagamentos/`, `Identidade/`.
  Bases compartilhadas ficam em `Common/`.
- Entidade: construtor `private` (para o EF) + método fábrica `static Criar(...)` que valida tudo.
  Propriedades `{ get; private set; }`. Coleções expostas como `IReadOnlyCollection<T>`.
- Agregado protege as invariantes dos filhos: `produto.AdicionarVariacao(...)`, nunca
  `produto.Variacoes.Add(...)`.
- Value Object = `public sealed record` com validação no construtor (ou na fábrica) e implementando `IValueObject`.
- Eventos de domínio: `sealed record NomeNoPassado(...) : IDomainEvent` (ex.: `PedidoCriado`),
  disparados com `RaiseDomainEvent` dentro da raiz.
- Interface de repositório (`IProdutoRepository`) fica no contexto, só para raízes de agregado,
  com métodos no vocabulário do domínio (`ObterPorSkuAsync`), sem `IQueryable`.
- Toda invariante nova ganha teste: caminho feliz e cada violação (`Assert.Throws<DomainException>`).
