🌍 [Leia em Português](README.pt-BR.md)

# Disaster Pulse Api

API RESTfulf developed as ASP.NET Core and OracleDB + EF Core to manage the warn, alerts and countries.

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

4. Enter in Api Directory:

```bash
cd ./Src/WebApi
```

5. Run migrations:

```bash
dotnet ef database update
```

6. Run the api:

```bash
dotnet run
```

7. The api is avaible on:

- <http://localhost:5272/api>

## Contribution

Contributions are welcome! If you have suggestions for improvements, feel free to open an issue or submit a pull request.

## License

This project is licensed under the [GNU Affero License](https://www.gnu.org/licenses/agpl-3.0.html).
