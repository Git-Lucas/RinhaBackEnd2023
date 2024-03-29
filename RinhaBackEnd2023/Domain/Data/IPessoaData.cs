using RinhaBackEnd2023.Domain.Entities;

namespace RinhaBackEnd2023.Domain.Data;

public interface IPessoaData
{
    Task<int> CountAsync();
    Task<Guid> CreateAsync(Pessoa pessoa);
    Task<IEnumerable<string>> GetAllApelidosAsync();
    Task<IEnumerable<Pessoa>> GetAllAsync(string termoDeBusca);
    Task<Pessoa> GetByIdAsync(Guid id);
}
