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
        List<Pessoa> pessoas = await context.Pessoas
            .Take(50)
            .ToListAsync();

        return pessoas.Where(p => p.Nome.Value.Contains(termoDeBusca, StringComparison.OrdinalIgnoreCase) ||
                                  p.Apelido.Value.Contains(termoDeBusca, StringComparison.OrdinalIgnoreCase) ||
                                  p.Stack != null && p.Stack.Values.Any(s => s.Contains(termoDeBusca, StringComparison.OrdinalIgnoreCase)));
    }

    public async Task<Pessoa> GetByIdAsync(Guid id)
    {
        return await context.Pessoas.FirstOrDefaultAsync(x => x.Id == id)
            ?? throw new RepositoryException(RepositoryExceptionType.EmptyReturn, $"Não foi encontrada uma {nameof(Pessoa)} com este identificador.");
    }
}
