# Loja

E-commerce de roupas para estudo: ASP.NET Core 9 (DDD + SOLID) e React + Vite + Tailwind.

## Rodar

```bash
dotnet run --project src/Loja.Api   # API → http://localhost:5080
cd web && npm install && npm run dev # Front → http://localhost:5173
```

## Testar

```bash
dotnet test
cd web && npm run build && npm run lint
```

## Documentação

- [CLAUDE.md](CLAUDE.md): resumo do projeto e regras (para pessoas e para o Claude)
- [docs/roadmap.md](docs/roadmap.md): fases e status
- [docs/arquitetura.md](docs/arquitetura.md): camadas e contextos
- [docs/glossario.md](docs/glossario.md): linguagem ubíqua
- [docs/adr/](docs/adr/): registro de decisões
