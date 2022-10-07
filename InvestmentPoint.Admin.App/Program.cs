using InvestmentPoint.Admin.App.IUtilitiesServices;
using InvestmentPoint.Admin.App.UtilitiesServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var builders = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Defaultconnection") ?? throw new InvalidOperationException("Connection string 'IdentityTestContextConnection' not found.");
var Key = "this is my test key";
builder.Services.AddSingleton<IJwtToken>(new JwtToken(Key));
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
});
builder.Services.AddTransient<IJwtToken, JwtToken>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
