using System.Reflection;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using OData.Demo.Core.Features.Clients.Models;
using OData.Demo.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers()
    .AddOData(options => options
        .Select()
        .Filter()
        .OrderBy()
        .SetMaxTop(100)
        .Count()
        .Expand()
        .AddRouteComponents("odata", GetEdmModel()));

// Add Infrastructure
builder.Services.AddInfrastructure(builder.Configuration);

// Add MediatR
builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssemblies(
        Assembly.GetExecutingAssembly(),
        Assembly.Load("OData.Demo.Core")
    );
});

// Add AutoMapper
builder.Services.AddAutoMapper(Assembly.Load("OData.Demo.Core"));

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

static IEdmModel GetEdmModel()
{
    var builder = new ODataConventionModelBuilder();
    builder.EntitySet<ClientDto>("Clients");
    return builder.GetEdmModel();
}