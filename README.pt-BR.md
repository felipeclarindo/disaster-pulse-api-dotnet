🌍 [Read in English](README.md)

# Disaster Pulse Api

API RESTful desenvolvida com ASP.NET Core e OracleDB + EF Core para gerenciar motos, pátios e setores.

## Tecnologias Utilizadas

- `C#` - Linguagem de programação para desenvolvimento.
- `.NET` - Framework de desenvolvimento.
- `Entity Framework Core` - ORM (Mapeador Objeto-Relacional) para comunicação com o banco de dados.
- `Oracle DB` - Banco de dados para armazenamento de dados.
- `Razor + TagHelpers` - Desenvolvimento do front-end.
- `Swagger` - Documentação de detalhes da API e teste de rotas.

## Arquitetura da Solução

- Clean Architecture inspirada em camadas:

    `Domain` (Entidades)

    `Application` (Lógica de negócios e serviços)

    `Infra` (Acesso com EF Core para conectar com o banco de dados oracle)

    `WebApi` (Camada de apresentação e endpoints da API)

    `Front` (Razor Pages com TagHelpers)

## Rotas

(Api)

- `GET api/` - Obter descrição da Api.

(Auth)

- `GET api/auth/login` - Fazer Login.

(Users)

- `GET api/users` -  Obter todas os usuarios.
- `GET api/users/{id}` - Obter usuario pelo Id.
- `POST api/users` - Criar um novo usuario.
- `PUT api/users/{id}` - Atualizar usuario pelo Id.
- `DELETE api/users/{id}` - Delete user by Id.

(Avisos)

- `GET api/warns` - Obter todas os avisos.
- `GET api/warns/{id}` - Obter aviso por ID.
- `GET api/warns/country/{country_id}` - Obter aviso por pais.
- `POST api/warns` - Criar um novo aviso.
- `PUT api/warns/{id}` - Atualizar aviso por ID.
- `DELETE api/warns/{id}` - Deletar aviso por ID.

(Paises)

- `GET api/countries` - Obter todos os paises.
- `GET api/countries/{id}` - Obter pais por ID.
- `POST api/countries` - Criar um novo pais.
- `PUT api/countries/{id}` - Atualizar pais por ID.
- `DELETE api/countries/{id}` - Deletar pais por ID.

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

4. Execute as migrações:

```bash
dotnet ef database update --project ./Src/Infra
```

5. Rode a API:

```bash
dotnet run --project ./Src/WebApi
```

6. Rode o Front:

```bash
dotnet run --project ./Src/Front
```

7. A API está disponível em:

- <http://localhost:5272/api>

8. O Front está disponível em:

- <http://localhost:5170>

## Testes

- Testes manuais realizados via Swagger e interface Razor.

- Exemplos de requisições na interface Swagger.

- Url do Swagger:
    <http://localhost:5272/swagger>

# Demonstração

- Exemplos de Requisição (Swagger)

```http
GET /alerts
POST /alerts
{
  "description": "Enchente no Rio de Janeiro",
  "topic": "Enchente",
  "countryId": 1
}
```

## Contribuição

Contribuições são bem-vindas! Se você tiver sugestões de melhorias, sinta-se à vontade para abrir uma issue ou enviar um pull request.

## Licença

Este projeto está licenciado sob a [GNU Affero License](https://www.gnu.org/licenses/agpl-3.0.html).
