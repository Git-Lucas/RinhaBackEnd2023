using RinhaBackEnd2023.Domain.Exceptions;

namespace RinhaBackEnd2023.Domain.UseCases.DTOs;

public record CreatePessoaDto(string? Apelido, string? Nome, string? Nascimento, string[]? Stack)
{
    public void Validate()
    {
        if (Apelido is null || Nome is null || Nascimento is null)
        {
            throw new InvalidRequest($"Campo não nulo deve ser preenchido: {nameof(Apelido)}, {nameof(Nome)}, {nameof(Nascimento)}");
        }

        if (!DateOnly.TryParseExact(Nascimento, "yyyy-MM-dd", out DateOnly _))
        {
            throw new InvalidRequest($"A data informada foi inválida: {Nascimento}.");
        }
    }
}