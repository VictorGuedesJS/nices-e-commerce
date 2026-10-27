# 0003 — SQLite em desenvolvimento, PostgreSQL no deploy

- **Status:** Aceita
- **Data:** 2026-10-26

## Contexto
A máquina de desenvolvimento não tem Docker. Instalar um servidor de banco atrasa o estudo.

## Decisão
SQLite (arquivo local) via EF Core nas fases iniciais; PostgreSQL na fase de deploy.
A troca é de provider e connection string, porque o domínio não conhece o banco.

## Consequências
- Zero setup.
- O SQLite tem limitações (concorrência e alguns tipos, como `decimal`): configure as conversões
  no EF e não dependa de recursos específicos de um banco.
- Recriar as migrations ao migrar para PostgreSQL.
