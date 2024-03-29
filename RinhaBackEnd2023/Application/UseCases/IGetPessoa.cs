using RinhaBackEnd2023.Domain.Entities;

namespace RinhaBackEnd2023.Application.UseCases;

public interface IGetPessoa
{
    Task<Pessoa> ExecuteAsync(Guid id);
}
