🌍 [Leia em Português](README.pt-BR.md)

# Disaster Pulse Api

API RESTfulf developed as ASP.NET Core and OracleDB + EF Core to manage the warn, alerts and countries.

# Technologies Used

- `C#` - Language to developer.
- `dotnet` - Development Framework.
- `ef Core` - ORM to talk with db.
- `Oracle DB` - Database to storage data.
- `Razor + TagHelpers` - Front end Development.
- `Swagger` - Api details docs with swagger and tests routers.

## Architecture

- Clean Architecture inspired by layers:

    `Domain` (Entities)

    `Application` (Business logic and services)

    `Infra` (Access with EF Core to connect with oracle database)

    `WebApi` (Presentation layer and API endpoints)

    `Front` (Razor Pages with TagHelpers)

## Routes

(Api)

- `GET api/` - Get api description.

(Auth)

- `GET api/auth/login` - Make a login.

(Users)

- `GET api/users` - Get all Users.
- `GET api/users/{id}` - Get user by Id.
- `POST api/users` - Create a new Warb.
- `PUT api/users/{id}` - Update user by Id.
- `DELETE api/users/{id}` - Delete user by Id.

(Warn)

- `GET api/warns` - Get All warns.
- `GET api/warns/{id}` - Get warn by Id.
- `GET api/warns/countries/{sector_id}` - Get warn by Country Id.
- `POST api/warns` - Create a New Warb.
- `PUT api/warns/{id}` - Update warn by Id.
- `DELETE api/warns/{id}` - Delete warn by Id.

(Country)

- `GET api/countries` - Get All countries.
- `GET api/countries/{id}`- Get country by Id.
- `POST api/countries` - Create a New country.
- `PUT api/countries/{id}` - Update country by Id.
- `DELETE api/countries/{id}` - Delete country by Id.

(Alerts)

- `GET api/alerts/{id}` - Get alert by id
- `GET api/alerts` - Get All alerts.
- `POST api/alerts` - Create a New alert
- `PUT api/alerts/{id}` - Update alert by Id.
- `DELETE api/alerts/{id}` - Delete alert by Id.

## Steps to run

1. Clone the repository:

```bash
git clone https://github.com/felipeclarindo/disaster-pulse-api-dotnet.git
```

2. Enter repository:

```bash
cd disaster-pulse-api-dotnet
```

3. Create and configure the `.env` file using the model in [.env.example](./.env.example)

4. Run migrations:

```bash
dotnet ef database update --project ./Src/Infra
```

5. Run api:

```bash
dotnet run --project ./Src/WebApi
```

6. Run the Front:

```bash
dotnet run --project ./Src/Front
```

7. The api is avaible on:

- <http://localhost:5272/api>

8. The Front is avaible on:

- <http://localhost:5170>

## Tests

- Manual tests performed via Swagger and Razor interface.

- Examples of requests in the Swagger interface.

- Url Swagger:
    <http://localhost:5272/swagger>

## Demonstration

- Request Examples (Swagger)

``http
GET /alerts
POST /alerts
{
  "description": "Enchente no Rio de Janeiro", Brazil
  "topic": "French",
  "countryId": 1
}
`

## Contribution

Contributions are welcome! If you have suggestions for improvements, feel free to open an issue or submit a pull request.

## License

This project is licensed under the [GNU Affero License](https://www.gnu.org/licenses/agpl-3.0.html).
