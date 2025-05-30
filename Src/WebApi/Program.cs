using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using DisasterPulseApiDotnet.Src.Infra.Database;
using DisasterPulseApiDotnet.Src.Utils.Functions;

var helper = new HelperFunctions();
helper.LoadEnvFromRoot();

var builder = WebApplication.CreateBuilder(args);

var connectionString = Environment.GetEnvironmentVariable("ORACLE_DB") ?? string.Empty;

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'ORACLE_DB' not found.");
}

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseOracle(connectionString));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseCors("AllowAllOrigins");
app.UseAuthorization();
app.MapControllers();

await app.RunAsync();
