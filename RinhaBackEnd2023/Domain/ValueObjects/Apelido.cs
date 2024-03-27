
namespace RinhaBackEnd2023.Domain.ValueObjects;

public record Apelido
{
    public string Value { get; private set; }

    public Apelido(string value)
    {
        Validate(value);
        Value = value;
    }

    private void Validate(string value)
    {
        int maxLength = 32;

        if (value.Length > maxLength)
        {
            throw new Exception($"O tamanho máximo do {nameof(Apelido)} é de {maxLength} caracteres.");
        }
    }
}
