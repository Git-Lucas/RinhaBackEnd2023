using RinhaBackEnd2023.Domain.UseCases.DTOs;

namespace RinhaBackEnd2023.Domain.UseCases.CreatePessoa;

public interface ICreatePessoa
{
    Task<Guid> ExecuteAsync(CreatePessoaDto createPessoaDto);
}
