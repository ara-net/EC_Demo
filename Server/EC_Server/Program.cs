global using Microsoft.EntityFrameworkCore;
global using EC.BL.Interface;
global using EC.Domain;
global using EC.Common.DTO;
using EC_Server.Hubs;
using EC.Domain.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Scan(scan =>
    scan.FromAssembliesOf(typeof(IProductBL))
        .AddClasses()
        .AsMatchingInterface()
        .WithScopedLifetime()
        );

builder.Services.AddDbContext<EcContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("EcDb"));
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
app.MapHub<BasketHub>("/basketHub");
app.Run();
