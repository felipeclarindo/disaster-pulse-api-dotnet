🌍 [Read in English](README.md)

# Disaster Pulse Api

API RESTful desenvolvida com ASP.NET Core e OracleDB + EF Core para gerenciar motos, pátios e setores.

## Rotas

(Api)

- `GET api/` - Obter descrição da Api.

(Warn)

- `GET api/warns` - Obter todas os avisos.
- `GET api/warns/{id}` - Obter aviso por ID.
- `GET api/warns/country/{sector_id}` - Obter aviso por pais.
- `POST api/warns` - Criar um novo aviso.
- `PUT api/warns/{id}` - Atualizar aviso por ID.
- `DELETE api/warns/{id}` - Deletar aviso por ID.

(Country)

- `GET api/country` - Obter todos os paises.
- `GET api/country/{id}` - Obter pais por ID.
- `POST api/country` - Criar um novo pais.
- `PUT api/country/{id}` - Atualizar pais por ID.
- `DELETE api/country/{id}` - Deletar pais por ID.

(Alert)

- `GET api/alerts/{id}` - Obter alerta por ID.
- `GET api/alerts` - Obter todos os alertas.
- `POST api/alerts` - Criar um novo alerta.
- `PUT api/alerts/{id}` - Atualizar alerta por ID.
- `DELETE api/alerts/{id}` - Deletar alerta por ID.

## Passos para rodar

1. Clone o repositório:

```bash
git clone https://github.com/felipeclarindo/disaster-pulse-api-dotnet.git
```

2. Entre no repositório:

```bash
cd disaster-pulse-api-dotnet
```

3. Crie e configure o arquivo .env usando o modelo em [.env.example](./.env.example)

4. Enter no diretorio da API:

```bash
cd ./Src/WebApi
```

5. Execute as migrações:

```bash
dotnet ef database update
```

6. Rode a API:

```bash
dotnet run
```

7. A API está disponível em:

- <http://localhost:5272/api>

## Contribuição

Contribuições são bem-vindas! Se você tiver sugestões de melhorias, sinta-se à vontade para abrir uma issue ou enviar um pull request.

## Licença

Este projeto está licenciado sob a [GNU Affero License](https://www.gnu.org/licenses/agpl-3.0.html).
