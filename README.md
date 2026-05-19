\# Checkpoint Docker - DimDimAPP



\## Integrante

Mateus Teni Pierro - RM 555125



\## Tecnologias

\- ASP.NET Core Web API

\- PostgreSQL

\- Docker

\- Dockerfile



\## Funcionalidades

\- CRUD de Clientes

\- Persistência de dados com PostgreSQL

\- Containers Docker

\- Volume nomeado

\- Rede Docker



\## Como executar



\### Build da imagem



```bash

docker build -t dimdimapp .

```



\### Criar rede



```bash

docker network create rede-555125

```



\### Criar volume



```bash

docker volume create postgres-data-555125

```



\### Rodar PostgreSQL



```bash

docker run -d `

--name db-555125 `

--network rede-555125 `

-e POSTGRES\_PASSWORD=123456 `

-e POSTGRES\_DB=dimdimdb `

-v postgres-data-555125:/var/lib/postgresql/data `

postgres:16

```



\### Rodar API



```bash

docker run -d `

--name api-555125 `

--network rede-555125 `

-p 8080:8080 `

-e CONNECTION\_STRING="Host=db-555125;Port=5432;Database=dimdimdb;Username=postgres;Password=123456" `

dimdimapp

```



\## Swagger



http://localhost:8080/swagger

