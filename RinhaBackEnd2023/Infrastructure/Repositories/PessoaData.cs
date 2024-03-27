using Microsoft.EntityFrameworkCore;
using RinhaBackEnd2023.Domain.Data;
using RinhaBackEnd2023.Domain.Entities;

namespace RinhaBackEnd2023.Infrastructure.Repositories;

public class PessoaData(DatabaseContext context) : IPessoaData
{
    public async Task<Guid> CreateAsync(Pessoa pessoaEntity)
    {
        await context.Pessoas.AddAsync(pessoaEntity);
        await context.SaveChangesAsync();

        return pessoaEntity.Id;
    }
}
