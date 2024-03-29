using RinhaBackEnd2023.Domain.Data;

namespace RinhaBackEnd2023.Application.UseCases;

public class CountPessoas(IPessoaData pessoaData) : ICountPessoas
{
    public async Task<int> ExecuteAsync()
    {
        int count = await pessoaData.CountAsync();

        return count;
    }
}
