# Loja — e-commerce de roupas (projeto de estudo)

E-commerce de roupas construído fase a fase para estudo. Back em **ASP.NET Core 9** com **DDD** e
**SOLID**; front em **React + TypeScript + Vite + Tailwind**. O usuário aprende pelo processo:
explique o *porquê* das decisões ao entregar cada parte.

- Roadmap e fase atual: @docs/roadmap.md
- Arquitetura e camadas: @docs/arquitetura.md
- Linguagem ubíqua (glossário): @docs/glossario.md
- Decisões registradas: `docs/adr/` (uma decisão por arquivo)
- Regras por área (carregam sozinhas pelo caminho): `.claude/rules/`

## Comandos

```bash
dotnet build                                  # compila a solução (warnings = erro)
dotnet test                                   # testes de domínio + arquitetura
dotnet run --project src/Loja.Api             # API em http://localhost:5080
cd web && npm run dev                         # front em http://localhost:5173 (proxy /api → 5080)
cd web && npm run build && npm run lint       # checagem do front
```

## Estrutura

```
src/Loja.Domain          Entidades, Value Objects, agregados, eventos, interfaces de repositório
src/Loja.Application     Casos de uso, DTOs, portas (interfaces de serviços externos)
src/Loja.Infrastructure  EF Core, repositórios, integrações (Stripe, e-mail, storage)
src/Loja.Api             Controllers finos, auth, configuração, composição (DI)
tests/Loja.Domain.Tests          testes unitários do domínio
tests/Loja.ArchitectureTests     garante a regra de dependência entre camadas
web/                      React (src/features/<contexto>, src/shared)
```

Regra de dependência (verificada por teste): `Api → Infrastructure → Application → Domain`.
O **Domain não referencia nada** (nem EF Core, nem ASP.NET).

## Regras obrigatórias

### DDD
- Toda regra de negócio vive no **Domain**, dentro da entidade ou do Value Object que a possui.
  Controllers e casos de uso **orquestram**, não decidem.
- Entidades nascem válidas: construtor ou método fábrica valida as invariantes; nada de setters
  públicos. Altere o estado só por métodos com nome de negócio (`pedido.Pagar()`, não `Status = 2`).
- Value Objects (`Dinheiro`, `Sku`, `Email`, `Endereco`, `Tamanho`, `Cor`) são `sealed record`,
  imutáveis e se validam ao serem criados. Nunca use `decimal` solto para dinheiro.
- Um **repositório por raiz de agregado**, com a interface no Domain e a implementação na
  Infrastructure. Um agregado referencia outro **só pelo Id**.
- Uma transação altera **um agregado**. Efeitos em outros agregados acontecem via evento de domínio.
- Violação de regra de negócio → `DomainException` (vira HTTP 422 na Api).
- Use os nomes do @docs/glossario.md no código. Termo novo → adicione no glossário antes.

### SOLID
- **S**: uma classe, um motivo para mudar. Um caso de uso por classe (`CriarPedidoHandler`).
- **O**: extensão por novas implementações (ex.: `ICalculadoraFrete`), sem `switch` crescendo.
- **L**: subtipos não podem enfraquecer as invariantes da base.
- **I**: interfaces pequenas e específicas; nada de `IService` genérico com 20 métodos.
- **D**: camadas internas definem interfaces e as externas implementam. Injeção via construtor.

### Código C#
- Domínio em **português sem acento** (`Produto`, `Variacao`, `Pedido`); termos técnicos em inglês
  (`Repository`, `Handler`, `Dto`, `Controller`).
- `sealed` por padrão; `async` de ponta a ponta com `CancellationToken`.
- Nada de lógica em controller além de: receber → chamar caso de uso → mapear resultado HTTP.
- Não exponha entidades na API; use DTOs (`record`).
- Analisadores com warnings como erro: corrija o warning em vez de suprimir. Supressão só com
  justificativa em comentário.

### Testes
- Toda regra de domínio nova ganha um teste em `Loja.Domain.Tests` (`Metodo_Cenario_Resultado`).
- `dotnet test` e `npm run build` precisam passar antes de dar uma tarefa por concluída.

### Front
- Pastas por funcionalidade: `src/features/<contexto>/` (components, hooks, api, types).
  `src/shared/` só para o que é usado por 2+ features.
- Chamadas HTTP só via `src/shared/api/client.ts`; caminhos relativos (`/api/...`).
- O front **não calcula** preço, frete nem estoque: só exibe o que a API devolve.

## Fluxo de trabalho
1. Uma fase por vez (ver roadmap). Antes de codar, confirme o escopo da fase com o usuário.
2. Decisão arquitetural nova → crie um ADR em `docs/adr/` a partir do `0000-template.md`.
3. Ao terminar a fase: rode as checagens, atualize o `docs/roadmap.md` e explique o que foi feito.
4. Commits no padrão **Conventional Commits** (`feat(catalogo): ...`, `fix:`, `docs:`, `test:`),
   só quando o usuário pedir.

## Não fazer
- Não colocar regra de negócio em controller, componente React ou configuração do EF.
- Não referenciar `Microsoft.EntityFrameworkCore` nem `Microsoft.AspNetCore` no Domain/Application.
- Não salvar segredos (chaves Stripe, connection strings de produção) no repositório: use
  `dotnet user-secrets` em dev e variáveis de ambiente no deploy.
- Não adicionar pacotes sem dizer por quê.
