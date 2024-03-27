﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RinhaBackEnd2023.Infrastructure;

#nullable disable

namespace RinhaBackEnd2023.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("RinhaBackEnd2023.Domain.Entities.Pessoa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateOnly>("Nascimento")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("RinhaBackEnd2023.Domain.Entities.Pessoa", b =>
                {
                    b.OwnsOne("RinhaBackEnd2023.Domain.ValueObjects.Apelido", "Apelido", b1 =>
                        {
                            b1.Property<Guid>("PessoaId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("longtext")
                                .HasColumnName("Apelido");

                            b1.HasKey("PessoaId");

                            b1.ToTable("Pessoas");

                            b1.WithOwner()
                                .HasForeignKey("PessoaId");
                        });

                    b.OwnsOne("RinhaBackEnd2023.Domain.ValueObjects.Nome", "Nome", b1 =>
                        {
                            b1.Property<Guid>("PessoaId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("longtext")
                                .HasColumnName("Nome");

                            b1.HasKey("PessoaId");

                            b1.ToTable("Pessoas");

                            b1.WithOwner()
                                .HasForeignKey("PessoaId");
                        });

                    b.OwnsOne("RinhaBackEnd2023.Domain.ValueObjects.Stacks", "Stack", b1 =>
                        {
                            b1.Property<Guid>("PessoaId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Values")
                                .IsRequired()
                                .HasColumnType("longtext")
                                .HasColumnName("Stack");

                            b1.HasKey("PessoaId");

                            b1.ToTable("Pessoas");

                            b1.WithOwner()
                                .HasForeignKey("PessoaId");
                        });

                    b.Navigation("Apelido")
                        .IsRequired();

                    b.Navigation("Nome")
                        .IsRequired();

                    b.Navigation("Stack");
                });
#pragma warning restore 612, 618
        }
    }
}
