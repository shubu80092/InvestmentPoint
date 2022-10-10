using InvestmentPoint.Admin.App.IUtilitiesServices;
using InvestmentPoint.Admin.App.UtilitiesServices;
using InvestmentPoint.Admin.Domain.Entites;
using InvestmentPoint.Admin.Services.Contract;
using InvestmentPoint.Admin.Services.Implementation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var builders = WebApplication.CreateBuilder(args);
builder.Services.AddMvcCore().AddApiExplorer();

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
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key)),
        ValidateIssuer = false,
        ValidateAudience = false
};
});
//builder.Services.AddTransient<IJwtToken, JwtToken>();


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
