using Microsoft.EntityFrameworkCore;
using RinhaBackEnd2023.Domain.Entities;
using RinhaBackEnd2023.Domain.ValueObjects;

namespace RinhaBackEnd2023.Infrastructure;

public class DatabaseContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Pessoa> Pessoas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pessoa>()
            .OwnsOne(pessoa => pessoa.Apelido)
            .Property(apelido => apelido.Value)
            .HasColumnName(nameof(Apelido));

        modelBuilder.Entity<Pessoa>()
            .OwnsOne(pessoa => pessoa.Nome)
            .Property(nome => nome.Value)
            .HasColumnName(nameof(Nome));

        modelBuilder.Entity<Pessoa>()
            .OwnsOne(pessoa => pessoa.Stack)
            .Property(stacks => stacks.Values)
            .HasColumnName("Stack");
    }
}
