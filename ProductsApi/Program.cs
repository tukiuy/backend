using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProductsApi.Application.Handlers;
using ProductsApi.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

//////////////////// Add services to the container. /////////////////////////////////////

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Api Key Auth",
        Version = "v1"
    });
    c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Description = "ApiKey must appear in header",
        Type = SecuritySchemeType.ApiKey,
        Name = "XApiKey",
        In = ParameterLocation.Header,
        Scheme = "ApiKeyScheme"
    });
    var key = new OpenApiSecurityScheme()
    {
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "ApiKey"
        },
        In = ParameterLocation.Header
    };
    var requirement = new OpenApiSecurityRequirement
                    {
                             { key, new List<string>() }
                    };
    c.AddSecurityRequirement(requirement);
});

//Healtchecks
builder.Services.AddHealthChecks();


//MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(Program)));


var Configuration = builder.Configuration;
builder.Services.AddDbContext<ProductsContext>(opts => opts.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection")));

var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swaggerv1");
        //c.RoutePrefix = string.Empty;
    });
}

//HealtCheck

app.MapHealthChecks(
    "/ArticulosHealth",
    new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
