using RinhaBackEnd2023.Domain.ValueObjects;

namespace RinhaBackEnd2023.Domain.Entities;

public class Pessoa
{
    public Guid Id { get; private set; }
    public Apelido Apelido { get; private set; } = new(string.Empty);
    public Nome Nome { get; private set; } = new(string.Empty);
    public DateOnly Nascimento { get; private set; }
    public Stacks? Stack { get; private set; }

    public Pessoa(string apelido, string nome, string nascimento, string[]? stack)
    {
        Id = Guid.NewGuid();
        Apelido = new Apelido(apelido);
        Nome = new Nome(nome);
        Nascimento = DateOnly.FromDateTime(DateTime.ParseExact(nascimento, "yyyy-MM-dd", null));

        if (stack is not null)
        {
            Stack = new Stacks(stack);
        }
    }

    public Pessoa() { }
}
