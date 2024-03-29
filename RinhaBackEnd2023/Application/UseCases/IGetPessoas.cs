using RinhaBackEnd2023.Domain.Entities;

namespace RinhaBackEnd2023.Application.UseCases;

public interface IGetPessoas
{
    Task<IEnumerable<Pessoa>> ExecuteAsync(string termoDeBusca);
}
