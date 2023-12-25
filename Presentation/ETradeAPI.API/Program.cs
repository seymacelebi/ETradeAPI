using ETradeAPI.Application;
using ETradeAPI.Application.Validators.Products;
using ETradeAPI.Infrastructure;
using ETradeAPI.Infrastructure.Filters;
using ETradeAPI.Persistence;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();
builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>()).ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.WithOrigins("http://localhost:4200" , "https://localhost:4200").AllowAnyHeader().AllowAnyMethod()
    ));
//builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyHeader(). AllowAnyMethod() .AllowAnyOrigin())); 
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer("Admin", options =>
{
    options.TokenValidationParameters = new()
    {
        ValidateAudience = true,
        //Oluþturulacak token deðerini kimlerin/hangi originlerin/sitelerin kullanýcý
        ValidateIssuer = true,
        //Oluþturulacak token deðerini kimin daðýttýðýný ifade edeceðimiz alanýdýr.
        ValidateLifetime = true,
        //Oluþturulan token deðerinin süresini kontrol edecek olan doðrulamadýr.
        ValidateIssuerSigningKey = true,
        //Üretilecek token deðerinin uygulamamýza ait  bir deðer olduðunu ifade eden security key verisinin doðrulanmasýdýr.
        ValidAudience = builder.Configuration["Token:Issuer"],
        ValidIssuer = builder.Configuration["Token:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"]!)),
        LifetimeValidator = (notBefore, expires, securityToken, validatiohParameters) => expires != null ? expires > DateTime.UtcNow :false,


    };
});
var securityScheme = new OpenApiSecurityScheme()
{
    Name = "Authorization",
    Type = SecuritySchemeType.Http,
    Scheme = "Bearer",
    BearerFormat = "JWT",
    In = ParameterLocation.Header,
    Description = "PUT ONLY TOKEN WITHOUT BEARER HERE!",
};
var securityReq = new OpenApiSecurityRequirement()
{
    {
        new OpenApiSecurityScheme
        {
           Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
              },
              Scheme = "oauth2",
              Name = "Bearer",
              In = ParameterLocation.Header,
        },
        new string[] {}
    }
};
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", securityScheme);
    c.AddSecurityRequirement(securityReq);
    //c.SwaggerDoc("v1", new OpenApiInfo { Title = "PmpPlus MarketPlace - V1", Version = "v1" });
    //c.SwaggerDoc("v2", new OpenApiInfo { Title = "PmpPlus MarketPlace - V2", Version = "v2" });
   
   
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles(); 
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseCors();  
app.UseAuthorization();

app.MapControllers();

app.Run();
