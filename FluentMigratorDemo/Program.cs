using FluentMigrator.Runner;
using FluentMigratorDemo;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//adding FM service
builder.Services.AddFluentMigratorService();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//running FM service
app.Migrate();

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
