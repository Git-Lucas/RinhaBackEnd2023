using Microsoft.EntityFrameworkCore;
using RinhaBackEnd2023.Application.Exceptions;
using RinhaBackEnd2023.Application.UseCases;
using RinhaBackEnd2023.Domain.Data;
using RinhaBackEnd2023.Infrastructure;
using RinhaBackEnd2023.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionStringMySql = builder.Configuration.GetConnectionString("DefaultConnection")
        ?? throw new Exception("Connection string was not found.");
builder.Services.AddDbContext<DatabaseContext>(opt =>
    opt.UseMySql(connectionStringMySql, ServerVersion.AutoDetect(connectionStringMySql)));

builder.Services
    .AddScoped<IPessoaData, PessoaData>()
    .AddScoped<ICreatePessoa, CreatePessoa>()
    .AddScoped<IGetPessoa, GetPessoa>()
    .AddScoped<IGetPessoas, GetPessoas>();

builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));

var app = builder.Build();

IServiceScope scope = app.Services.CreateScope();
DatabaseContext context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
await context.Database.MigrateAsync();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
