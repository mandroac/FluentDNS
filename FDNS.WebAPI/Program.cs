using FDNS.WebAPI.Extensions;
using FDNS.WebAPI.Validators.Domains;
using FluentValidation.AspNetCore;
using FNDS.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers(opts =>
    {
        var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
        opts.Filters.Add(new AuthorizeFilter(policy));
    })
    .AddFluentValidation(opts =>
    {
        opts.RegisterValidatorsFromAssemblyContaining(typeof(DomainContactsRequestValidator));
        opts.ImplicitlyValidateChildProperties = true;
        opts.ImplicitlyValidateRootCollectionElements = true;
    })
    .AddJsonOptions(opts =>
    {
        opts.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<FndsDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("FdnsDBConnection"));
});

builder.Services.SetupSwagger();
builder.Services.SetupConfigurations(builder.Configuration);
builder.Services.RegisterApiServices();
builder.Services.RegisterApplicationServices();
builder.Services.SetupSecurity(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opts => {
        opts.SwaggerEndpoint("/swagger/v1/swagger.json", "FNDS API");
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();