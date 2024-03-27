using RinhaBackEnd2023.Domain.Data;
using RinhaBackEnd2023.Domain.Entities;
using RinhaBackEnd2023.Domain.UseCases.CreatePessoa;
using RinhaBackEnd2023.Domain.UseCases.DTOs;

namespace RinhaBackEnd2023.Application.UseCases;

public class CreatePessoa(IPessoaData pessoaData) : ICreatePessoa
{
    public async Task<Guid> ExecuteAsync(CreatePessoaDto createPessoaDto)
    {
        Pessoa pessoaEntity = new(apelido: createPessoaDto.Apelido,
                                  nome: createPessoaDto.Nome,
                                  nascimento: createPessoaDto.Nascimento,
                                  stack: createPessoaDto.Stack);

        Guid createdGuid = await pessoaData.CreateAsync(pessoaEntity);

        return createdGuid;
    }
}
