using BoB.MS.Domain;
using BoB.MS.Repository.Repositories;
using BoB.MS.Service;
using BoB.MS.Service.Services;
using AutoMapper;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();

//mapper configuration to pick up profile automatically
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

//service injection for service and repository classes
DomainServices.Configure(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<ClientsService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
