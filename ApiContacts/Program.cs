using Contacts.Data.Context;
using Contacts.Data.Repositorys;
using Contacts.Domain.Interfaces;
using Contacts.Service.Logger;
using Contacts.Service.Mapper;
using Contacts.Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Jwt configuration
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var key = Encoding.ASCII.GetBytes(configuration.GetValue<string>("SecretJWT"));

builder.Services.AddAuthentication(authenticationOpt =>
{
    authenticationOpt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    authenticationOpt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(jwtBearerOpt =>
  {
      jwtBearerOpt.RequireHttpsMetadata = false;
      jwtBearerOpt.SaveToken = true;
      jwtBearerOpt.TokenValidationParameters = new TokenValidationParameters()
      {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(key),
          ValidateIssuer = false,
          ValidateAudience = false,
      };
  });

// Sql server configuration
builder.Services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("SandroDbConnection") ?? 
               throw new InvalidOperationException("Connection string 'SandroDbConnection' not found."))
               );

// Dependence injection configuration 
builder.Services.AddScoped<IDDDRepository, DDDRepository>();
builder.Services.AddScoped<IDDDService, DDDService>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddScoped<IContatoRepository, ContatoRepository>();
builder.Services.AddScoped<IContatoService, ContatoService>();
builder.Services.AddScoped<ITokenRepository, TokenRepository>();


//builder.Services.AddScoped<IAccountRepository, AccountRepository>();
//builder.Services.AddScoped<IAccountService, AccountService>();

// Automapper configuration
builder.Services.AddAutoMapper(typeof(ContatoMapper));
builder.Services.AddAutoMapper(typeof(DDDMapper));

// Log Configuration
builder.Logging.ClearProviders();
builder.Logging.AddProvider(new CustomLoggerProvider(new CustomLoggerProviderConfiguration
{
    LogLevel = LogLevel.Information,
}));

builder.Services.AddSwaggerGen(swaggergenOpt =>
{
    swaggergenOpt.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Contatos API",
        Version = "v1",
        Description = "Api Contatos.",
        Contact = new OpenApiContact
        {
            Name = "Api Contatos",
            Email = string.Empty,
            Url = new Uri("https://coderjony.com/"),
        },
    });

    swaggergenOpt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description =
            "JWT Authorization Header - utilizado com Bearer Authentication.\r\n\r\n" +
            "Digite 'Bearer' [espaço] e então seu token no campo abaixo.\r\n\r\n" +
            "Exemplo (informar sem as aspas): 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });

    swaggergenOpt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme()
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// Cache configuration
builder.Services.AddMemoryCache();

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
