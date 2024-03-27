using RinhaBackEnd2023.Domain.Data;
using RinhaBackEnd2023.Domain.Entities;
using RinhaBackEnd2023.Domain.UseCases.Interfaces;

namespace RinhaBackEnd2023.Application.UseCases;

public class GetPessoa(IPessoaData pessoaData) : IGetPessoa
{
    public async Task<Pessoa> ExecuteAsync(Guid id)
    {
        Pessoa pessoa = await pessoaData.GetByIdAsync(id);
        return pessoa;
    }
}
