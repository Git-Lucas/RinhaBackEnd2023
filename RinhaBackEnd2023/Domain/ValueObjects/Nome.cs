namespace RinhaBackEnd2023.Domain.ValueObjects;

public record Nome
{
    public string Value { get; private set; }

    public Nome(string value)
    {
        Validate(value);
        Value = value;
    }

    private void Validate(string value)
    {
        int maxLength = 100;

        if (value.Length > maxLength)
        {
            throw new Exception($"O tamanho máximo do {nameof(Nome)} é de {maxLength} caracteres.");
        }
    }
}
