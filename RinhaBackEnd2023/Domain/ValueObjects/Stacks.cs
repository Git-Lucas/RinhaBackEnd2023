namespace RinhaBackEnd2023.Domain.ValueObjects;

public record Stacks
{
    public string[] Values { get; private set; }

    public Stacks(string[] values)
    {
        Validate(values);
        Values = values;
    }

    private void Validate(string[] values)
    {
        int maxLength = 32;

        foreach (string value in values)
        {
            if (value.Length > maxLength)
            {
                throw new Exception($"O tamanho máximo do {nameof(Stacks)} é de {maxLength} caracteres.");
            }
        }
    }
}
