using HomeBillings.Identidade.API.Configuration;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiConfiguration();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddIdentityConfiguration(builder);

builder.UseApiConfiguration();