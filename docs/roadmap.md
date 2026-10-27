# Roadmap

Legenda: ✅ concluída · 🚧 em andamento · ⬜ pendente

| # | Fase | Status | Critério de pronto |
|---|------|--------|--------------------|
| 0 | Fundação: solução DDD, React, docs, regras | ✅ | `dotnet test` verde; front mostra "API online" via proxy |
| 1 | Modelagem do Catálogo (Produto, Variacao, VOs) + EF Core + SQLite + seed | ⬜ | Testes de domínio; migration aplicada; seed com roupas |
| 2 | Catálogo na vitrine: listagem, detalhe, filtros (tamanho, cor, categoria, preço), paginação | ⬜ | Navegar e filtrar produtos no navegador |
| 3 | Carrinho (por SKU) + Estoque | ⬜ | Adicionar/alterar/remover; não passa do estoque |
| 4 | Identidade: cadastro, login, JWT, papéis | ⬜ | Rotas protegidas funcionando |
| 5 | Checkout e Pedido: endereço, frete simulado, reserva de estoque | ⬜ | Pedido criado a partir do carrinho, em transação |
| 6 | Pagamento com Stripe (teste) + webhook | ⬜ | Pedido muda para Pago via webhook |
| 7 | Minha conta: pedidos, endereços, perfil | ⬜ | Cliente vê o histórico |
| 8 | Admin: CRUD de produtos com variações e fotos por cor, gestão de pedidos | ⬜ | Admin cadastra produto completo |
| 9 | Qualidade: testes de integração, Vitest, validação, segurança | ⬜ | CI local verde |
| 10 | Deploy: PostgreSQL, GitHub Actions | ⬜ | Loja publicada |

Extras possíveis: cupons, avaliações, wishlist, e-mails transacionais, SEO, cache.

## Histórico
- **2026-10-26 · Fase 0**: solução .NET 9 com 4 camadas, testes de arquitetura (NetArchTest),
  React + Vite + Tailwind v4, proxy `/api`, CLAUDE.md, ADRs e regras.
