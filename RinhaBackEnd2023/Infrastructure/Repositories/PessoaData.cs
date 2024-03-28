using Microsoft.EntityFrameworkCore;
using RinhaBackEnd2023.Domain.Data;
using RinhaBackEnd2023.Domain.Entities;
using RinhaBackEnd2023.Domain.Exceptions.Repository;

namespace RinhaBackEnd2023.Infrastructure.Repositories;

public class PessoaData(DatabaseContext context) : IPessoaData
{
    public async Task<Guid> CreateAsync(Pessoa pessoaEntity)
    {
        await context.Pessoas.AddAsync(pessoaEntity);
        await context.SaveChangesAsync();

        return pessoaEntity.Id;
    }

    public async Task<IEnumerable<string>> GetAllApelidosAsync()
    {
        return await context.Pessoas.Select(x => x.Apelido.Value).ToArrayAsync();
    }

    public async Task<IEnumerable<Pessoa>> GetAllAsync(string termoDeBusca)
    {
        return await context.Pessoas
            .Where(p => EF.Functions.Like(p.Id, $"%{termoDeBusca}%"))
            //.Where(p => EF.Functions.Like(p.Apelido, $"%{termoDeBusca}%") ||
            //            EF.Functions.Like(p.Nome, $"%{termoDeBusca}%"))
            //            (p.Stack != null && p.Stack.Any(s => EF.Functions.Like(s, $"%{termoDeBusca}%"))))
            .Take(50)
            .ToListAsync();
    }

    public async Task<Pessoa> GetByIdAsync(Guid id)
    {
        return await context.Pessoas.FirstOrDefaultAsync(x => x.Id == id)
            ?? throw new RepositoryException(RepositoryExceptionType.EmptyReturn, $"Não foi encontrada uma {nameof(Pessoa)} com este identificador.");
    }
}
