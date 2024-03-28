using RinhaBackEnd2023.Domain.Entities;

namespace RinhaBackEnd2023.Domain.UseCases.Interfaces;

public interface IGetPessoa
{
    Task<Pessoa> ExecuteAsync(Guid id);
}
