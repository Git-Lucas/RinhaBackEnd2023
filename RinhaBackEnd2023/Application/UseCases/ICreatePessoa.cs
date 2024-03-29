using RinhaBackEnd2023.Domain.UseCases.DTOs;

namespace RinhaBackEnd2023.Application.UseCases;

public interface ICreatePessoa
{
    Task<Guid> ExecuteAsync(CreatePessoaDto createPessoaDto);
}
