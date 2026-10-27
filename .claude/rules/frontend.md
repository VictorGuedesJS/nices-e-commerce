---
paths:
  - "web/**"
---

# Regras do front (React)

- Componentes de função em TypeScript estrito; nada de `any` (use `unknown` + narrowing).
- Pasta por feature: `src/features/catalogo/{components,hooks}/`, `api.ts`, `types.ts`.
- Tipos da API espelham os DTOs do back, com os mesmos nomes de campos.
- HTTP só via `src/shared/api/client.ts`. Estados de carregando, erro e vazio sempre tratados na tela.
- Estilo só com classes Tailwind; componentes reutilizáveis em `src/shared/ui/`.
- Textos da interface em português do Brasil; preços formatados com `Intl.NumberFormat('pt-BR', { style: 'currency', currency: 'BRL' })`.
- Antes de concluir: `npm run build` e `npm run lint` sem erros.
