using InvestmentPoint.Admin;
using InvestmentPoint.Admin.App.IUtilitiesServices;
using InvestmentPoint.Admin.App.UtilitiesServices;
using InvestmentPoint.Admin.Domain.Entites;
using InvestmentPoint.Admin.Persistence;
using InvestmentPoint.Admin.Services.Contract;
using InvestmentPoint.Admin.Services.Implementation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

var connString = builder.Configuration.GetConnectionString("Defaultconnection") ?? throw new InvalidOperationException("Connection string 'IdentityTestContextConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
  options.UseSqlServer(connString));

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


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseSwaggerUI(options =>
//{
//    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
//    options.RoutePrefix = String.Empty;
//});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
