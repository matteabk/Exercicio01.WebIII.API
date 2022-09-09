using System.Web.Mvc;
using WEB.Aula01.Core.Interfaces;
using WEB.Aula01.Core.Services;
using WEB.Aula01.Filters;
using WEB.Aula01.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IClienteServices, ClienteServices>();
builder.Services.AddScoped<IClientesRepository, ClientesRepository>();
builder.Services.AddScoped<ConferirClienteExistenteActionFilter>();
builder.Services.AddScoped<InvalidarCPFRepetidoActionFilter>();

builder.Services.AddMvc(options =>
{
    options.Filters.Add<GenerateExceptionFilter>();
}
);

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
