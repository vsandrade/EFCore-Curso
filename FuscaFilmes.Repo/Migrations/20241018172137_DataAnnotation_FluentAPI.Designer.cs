﻿// <auto-generated />
using System;
using FuscaFilmes.API.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FuscaFilmes.Repo.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20241018172137_DataAnnotation_FluentAPI")]
    partial class DataAnnotation_FluentAPI
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("FuscaFilmes.Domain.Entities.Diretor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id_diretor");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Diretores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Christopher Nolan"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Steven Spielberg"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Quentin Tarantino"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Martin Scorsese"
                        },
                        new
                        {
                            Id = 5,
                            Name = "James Cameron"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Greta Gerwig"
                        });
                });

            modelBuilder.Entity("FuscaFilmes.Domain.Entities.DiretorDetalhe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Biografia")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("TEXT");

                    b.Property<int>("DiretorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DiretorId")
                        .IsUnique();

                    b.ToTable("DiretorDetalhe");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Biografia = "Biografia do Christopher Nolan",
                            DataCriacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataNascimento = new DateTime(1970, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DiretorId = 1
                        },
                        new
                        {
                            Id = 2,
                            Biografia = "Biografia do Steven Spielberg",
                            DataCriacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataNascimento = new DateTime(1946, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DiretorId = 2
                        });
                });

            modelBuilder.Entity("FuscaFilmes.Domain.Entities.DiretorFilme", b =>
                {
                    b.Property<int>("DiretorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FilmeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("DiretorId", "FilmeId");

                    b.HasIndex("FilmeId");

                    b.ToTable("DiretoresFilmes", (string)null);

                    b.HasData(
                        new
                        {
                            DiretorId = 1,
                            FilmeId = 1
                        },
                        new
                        {
                            DiretorId = 1,
                            FilmeId = 2
                        },
                        new
                        {
                            DiretorId = 1,
                            FilmeId = 3
                        },
                        new
                        {
                            DiretorId = 2,
                            FilmeId = 4
                        },
                        new
                        {
                            DiretorId = 2,
                            FilmeId = 5
                        },
                        new
                        {
                            DiretorId = 2,
                            FilmeId = 6
                        },
                        new
                        {
                            DiretorId = 3,
                            FilmeId = 7
                        },
                        new
                        {
                            DiretorId = 3,
                            FilmeId = 8
                        },
                        new
                        {
                            DiretorId = 3,
                            FilmeId = 9
                        },
                        new
                        {
                            DiretorId = 4,
                            FilmeId = 10
                        },
                        new
                        {
                            DiretorId = 4,
                            FilmeId = 11
                        },
                        new
                        {
                            DiretorId = 4,
                            FilmeId = 12
                        },
                        new
                        {
                            DiretorId = 5,
                            FilmeId = 13
                        },
                        new
                        {
                            DiretorId = 5,
                            FilmeId = 14
                        },
                        new
                        {
                            DiretorId = 5,
                            FilmeId = 15
                        },
                        new
                        {
                            DiretorId = 6,
                            FilmeId = 16
                        },
                        new
                        {
                            DiretorId = 6,
                            FilmeId = 17
                        },
                        new
                        {
                            DiretorId = 6,
                            FilmeId = 18
                        });
                });

            modelBuilder.Entity("FuscaFilmes.Domain.Entities.Filme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Ano")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Orcamento")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Titulo")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Filmes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ano = 2010,
                            Orcamento = 0m,
                            Titulo = "Inception"
                        },
                        new
                        {
                            Id = 2,
                            Ano = 2014,
                            Orcamento = 0m,
                            Titulo = "Interstellar"
                        },
                        new
                        {
                            Id = 3,
                            Ano = 2008,
                            Orcamento = 0m,
                            Titulo = "The Dark Knight"
                        },
                        new
                        {
                            Id = 4,
                            Ano = 1993,
                            Orcamento = 0m,
                            Titulo = "Jurassic Park"
                        },
                        new
                        {
                            Id = 5,
                            Ano = 1982,
                            Orcamento = 0m,
                            Titulo = "E.T. the Extra-Terrestrial"
                        },
                        new
                        {
                            Id = 6,
                            Ano = 1993,
                            Orcamento = 0m,
                            Titulo = "Schindler's List"
                        },
                        new
                        {
                            Id = 7,
                            Ano = 1994,
                            Orcamento = 0m,
                            Titulo = "Pulp Fiction"
                        },
                        new
                        {
                            Id = 8,
                            Ano = 2003,
                            Orcamento = 0m,
                            Titulo = "Kill Bill: Vol. 1"
                        },
                        new
                        {
                            Id = 9,
                            Ano = 2012,
                            Orcamento = 0m,
                            Titulo = "Django Unchained"
                        },
                        new
                        {
                            Id = 10,
                            Ano = 1990,
                            Orcamento = 0m,
                            Titulo = "Goodfellas"
                        },
                        new
                        {
                            Id = 11,
                            Ano = 2019,
                            Orcamento = 0m,
                            Titulo = "The Irishman"
                        },
                        new
                        {
                            Id = 12,
                            Ano = 1976,
                            Orcamento = 0m,
                            Titulo = "Taxi Driver"
                        },
                        new
                        {
                            Id = 13,
                            Ano = 2009,
                            Orcamento = 0m,
                            Titulo = "Avatar"
                        },
                        new
                        {
                            Id = 14,
                            Ano = 1997,
                            Orcamento = 0m,
                            Titulo = "Titanic"
                        },
                        new
                        {
                            Id = 15,
                            Ano = 1984,
                            Orcamento = 0m,
                            Titulo = "The Terminator"
                        },
                        new
                        {
                            Id = 16,
                            Ano = 2017,
                            Orcamento = 0m,
                            Titulo = "Lady Bird"
                        },
                        new
                        {
                            Id = 17,
                            Ano = 2019,
                            Orcamento = 0m,
                            Titulo = "Little Women"
                        },
                        new
                        {
                            Id = 18,
                            Ano = 2023,
                            Orcamento = 0m,
                            Titulo = "Barbie"
                        });
                });

            modelBuilder.Entity("FuscaFilmes.Domain.Entities.DiretorDetalhe", b =>
                {
                    b.HasOne("FuscaFilmes.Domain.Entities.Diretor", "Diretor")
                        .WithOne("DiretorDetalhe")
                        .HasForeignKey("FuscaFilmes.Domain.Entities.DiretorDetalhe", "DiretorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diretor");
                });

            modelBuilder.Entity("FuscaFilmes.Domain.Entities.DiretorFilme", b =>
                {
                    b.HasOne("FuscaFilmes.Domain.Entities.Diretor", "Diretor")
                        .WithMany("DiretoresFilmes")
                        .HasForeignKey("DiretorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FuscaFilmes.Domain.Entities.Filme", "Filme")
                        .WithMany("DiretoresFilmes")
                        .HasForeignKey("FilmeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diretor");

                    b.Navigation("Filme");
                });

            modelBuilder.Entity("FuscaFilmes.Domain.Entities.Diretor", b =>
                {
                    b.Navigation("DiretorDetalhe");

                    b.Navigation("DiretoresFilmes");
                });

            modelBuilder.Entity("FuscaFilmes.Domain.Entities.Filme", b =>
                {
                    b.Navigation("DiretoresFilmes");
                });
#pragma warning restore 612, 618
        }
    }
}
