using RinhaBackEnd2023.Domain.Data;
using RinhaBackEnd2023.Domain.Entities;
using RinhaBackEnd2023.Domain.Exceptions;
using RinhaBackEnd2023.Domain.UseCases.DTOs;
using RinhaBackEnd2023.Domain.ValueObjects;

namespace RinhaBackEnd2023.Application.UseCases;

public class CreatePessoa(IPessoaData pessoaData) : ICreatePessoa
{
    public async Task<Guid> ExecuteAsync(CreatePessoaDto createPessoaDto)
    {
        await ValidateAsync(createPessoaDto);

        Pessoa pessoaEntity = new(apelido: createPessoaDto.Apelido!,
                                  nome: createPessoaDto.Nome!,
                                  nascimento: createPessoaDto.Nascimento!,
                                  stack: createPessoaDto.Stack);

        Guid createdGuid = await pessoaData.CreateAsync(pessoaEntity);

        return createdGuid;
    }

    private async Task ValidateAsync(CreatePessoaDto createPessoaDto)
    {
        createPessoaDto.Validate();

        IEnumerable<string> apelidosDatabase = await pessoaData.GetAllApelidosAsync();
        if (apelidosDatabase.Contains(createPessoaDto.Apelido))
        {
            throw new InvalidRequest($"O {nameof(Apelido)} '{createPessoaDto.Apelido}' já existe na base de dados.");
        }
    }
}
