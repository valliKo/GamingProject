using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GamingProject.Data;
using GamingProject.Repository;
using Microsoft.OpenApi.Models;
using System.Reflection;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<GamingProjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GamingProjectContext") ?? throw new InvalidOperationException("Connection string 'GamingProjectContext' not found.")));

builder.Services.AddScoped<IGameInterface,GameRepository>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "List Of Game Api's", Version = "v1" });
    var fileName = Assembly.GetExecutingAssembly().GetName().Name+".xml";
    var filePath = Path.Combine(AppContext.BaseDirectory, fileName);
    c.IncludeXmlComments(filePath);
});

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
