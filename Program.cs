using OceanoVivo.Models;
using Microsoft.EntityFrameworkCore;
using OceanoVivo.Data;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });

// Adicione a conex�o com o banco de dados Oracle
builder.Services.AddDbContext<OceanoVivoDbContext>(options =>
{
    options.UseOracle(builder.Configuration.GetConnectionString("OracleDbConnection"));
});

// Adicione os servi�os necess�rios ao cont�iner.
builder.Services.AddControllers();

// Aprenda mais sobre a configura��o do Swagger/OpenAPI em https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure o pipeline de solicitao HTTP.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}


app.UseAuthorization();

app.MapControllers();

app.Run();