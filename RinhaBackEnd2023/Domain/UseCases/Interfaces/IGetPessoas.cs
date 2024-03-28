using RinhaBackEnd2023.Domain.Entities;

namespace RinhaBackEnd2023.Domain.UseCases.Interfaces;

public interface IGetPessoas
{
    Task<IEnumerable<Pessoa>> ExecuteAsync(string termoDeBusca);
}
