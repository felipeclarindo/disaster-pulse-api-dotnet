using DisasterPulseApiDotnet.Src.Infra.Database;
using DisasterPulseApiDotnet.Src.Utils.Functions;
using Microsoft.EntityFrameworkCore;

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
        policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
        );
});
builder.Services.AddHttpClient();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    await DbSeeder.SeedCountriesAsync(context);
}

app.UseCors("AllowAllOrigins");
app.UseAuthorization();
app.MapControllers();
app.MapRazorPages();

await app.RunAsync();
