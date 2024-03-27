using RinhaBackEnd2023.Domain.Entities;

namespace RinhaBackEnd2023.Domain.Data;

public interface IPessoaData
{
    Task<Guid> CreateAsync(Pessoa pessoaEntity);
}
