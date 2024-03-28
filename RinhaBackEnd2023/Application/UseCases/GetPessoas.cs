using RinhaBackEnd2023.Domain.Data;
using RinhaBackEnd2023.Domain.Entities;
using RinhaBackEnd2023.Domain.UseCases.Interfaces;

namespace RinhaBackEnd2023.Application.UseCases;

public class GetPessoas(IPessoaData pessoaData) : IGetPessoas
{
    public async Task<IEnumerable<Pessoa>> ExecuteAsync(string termoDeBusca)
    {
        IEnumerable<Pessoa> pessoas = await pessoaData.GetAllAsync(termoDeBusca);
        return pessoas;
    }
}
