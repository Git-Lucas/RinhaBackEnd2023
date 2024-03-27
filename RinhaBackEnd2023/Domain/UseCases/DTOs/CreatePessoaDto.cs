namespace RinhaBackEnd2023.Domain.UseCases.DTOs;

public record CreatePessoaDto(string Apelido, string Nome, string Nascimento, string[]? Stack);