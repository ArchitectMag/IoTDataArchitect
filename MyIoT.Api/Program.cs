//System
using Autofac;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;

//Projects
using MyIoT.Core.Extensions;
using MyIoT.Core.Utilities.IoC;
using MyIoT.Core.DependencyResolvers;
using MyIoT.Core.Utilities.Security.JWT;
using MyIoT.Core.Utilities.Security.Encryption;
using MyIoT.Business.DependencyResolvers.Autofac;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrgin", builder => builder.WithOrigins("http://localhost:7250"));
});

var tokenOption = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = tokenOption.Issuer,
        ValidAudience = tokenOption.Audience,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOption.SecurityKey),
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddDependencyResolvers(new ICoreModule[]
{
    new CoreModule()
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new ServiceRegisterManager());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder.WithOrigins("http://localhost:7250").AllowAnyHeader());
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

