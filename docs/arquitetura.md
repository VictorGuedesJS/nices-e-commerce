# Arquitetura

## Visão geral

```
 [React (web/)] --HTTP /api--> [Loja.Api] --> [Loja.Application] --> [Loja.Domain]
                                    |                 ^
                                    v                 | implementa interfaces
                            [Loja.Infrastructure] ----+
                                    |
                                 [SQLite → PostgreSQL] [Stripe]
```

| Camada | Responsabilidade | Pode depender de |
|---|---|---|
| **Domain** | Regras de negócio puras: entidades, Value Objects, agregados, eventos, interfaces de repositório | nada |
| **Application** | Casos de uso: carrega agregados, chama o domínio, persiste, publica eventos. Define portas (`IGatewayPagamento`, `IUnitOfWork`) | Domain |
| **Infrastructure** | Detalhes técnicos: EF Core (`LojaDbContext`, mapeamentos), repositórios, Stripe, e-mail | Application, Domain |
| **Api** | HTTP: controllers finos, autenticação, tratamento de erros, composição da DI | Application, Infrastructure (só para registrar DI) |

A regra é verificada automaticamente em `tests/Loja.ArchitectureTests`.

## Contextos delimitados (Bounded Contexts)

Monólito modular: um só deploy, com cada contexto em sua própria pasta e namespace dentro de
cada camada (`Loja.Domain/Catalogo`, `Loja.Application/Catalogo`...).

| Contexto | Agregados (raiz) | Responsabilidade |
|---|---|---|
| **Catalogo** | `Produto` (com `Variacao`), `Categoria` | O que vendemos, com variações de tamanho e cor, preços e fotos |
| **Estoque** | `ItemEstoque` (por SKU) | Quantidade disponível e reservas |
| **Carrinho** | `Carrinho` | Intenção de compra antes do pedido |
| **Vendas** | `Pedido` | Pedido fechado, com preços congelados no momento da compra |
| **Pagamentos** | `Pagamento` | Integração com o gateway e status do pagamento |
| **Identidade** | `Cliente` | Conta, login, endereços e papéis (Cliente/Admin) |

Comunicação entre contextos: por **Id** e por **eventos de domínio**
(ex.: `PagamentoAprovado` → Vendas marca o `Pedido` como pago → Estoque confirma a baixa).

## Padrões usados

- **Entity / AggregateRoot / Value Object / Domain Event**: bases em `Loja.Domain/Common`.
- **Repository + Unit of Work**: interface no Domain/Application, EF Core na Infrastructure.
- **Caso de uso por classe** (`CriarPedidoHandler`), no estilo CQRS leve: comandos alteram,
  queries leem e podem projetar direto para DTO.
- **Result/exceções**: `DomainException` para regra violada; middleware converte em `ProblemDetails`.
- **Options pattern** para configuração; **user-secrets** para segredos em dev.

## Front

```
web/src/
  features/<contexto>/   components/, hooks/, api.ts, types.ts
  shared/                api/client.ts, ui/ (botões, inputs), utils/
  App.tsx, main.tsx
```
