# 0001 — Stack: ASP.NET Core 9 + React/Vite

- **Status:** Aceita
- **Data:** 2026-10-26

## Contexto
Projeto de estudo de e-commerce. O usuário quer C#/.NET no back e React no front.

## Decisão
- Back: ASP.NET Core 9 Web API com controllers, EF Core e ASP.NET Identity + JWT.
- Front: React + TypeScript + Vite + Tailwind CSS v4, separado em `web/`.
- Em dev, o Vite faz proxy de `/api` para `http://localhost:5080`, sem precisar de CORS no fluxo normal.
- SDK fixado em `global.json` (9.0.x).

## Consequências
- Dois processos em dev (API e Vite).
- Front e back podem ser publicados separados ou com o build do React servido pela API.
