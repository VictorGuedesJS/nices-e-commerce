# 0002 — DDD em 4 camadas, monólito modular

- **Status:** Aceita
- **Data:** 2026-10-26

## Contexto
O objetivo é estudar SOLID e DDD sem a complexidade operacional de microsserviços.

## Opções consideradas
1. Projeto único com pastas: simples, mas nada impede dependências erradas.
2. **Domain / Application / Infrastructure / Api** (estilo Clean Architecture): separação garantida pelo compilador.
3. Microsserviços por contexto: grande demais para o estudo.

## Decisão
Opção 2. Contextos delimitados (Catalogo, Estoque, Carrinho, Vendas, Pagamentos, Identidade)
viram pastas e namespaces dentro de cada camada. A regra de dependência é verificada por
`tests/Loja.ArchitectureTests` (NetArchTest). Repositórios por raiz de agregado, e não acesso
direto ao DbContext nos casos de uso, para deixar explícito o conceito de agregado.

## Consequências
- Mais arquivos por funcionalidade, em troca de fronteiras claras.
- Se um contexto crescer muito, ele pode virar projeto próprio sem reescrever o domínio.
