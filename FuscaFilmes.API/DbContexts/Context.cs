using System;
using FuscaFilmes.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace FuscaFilmes.API.DbContexts;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{
  public DbSet<Filme> Filmes { get; set; }
  public DbSet<Diretor> Diretores { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Diretor>()
      .HasMany(e => e.Filmes)
      .WithOne(e => e.Diretor)
      .HasForeignKey(e => e.DiretorId)
      .IsRequired();

    modelBuilder.Entity<Diretor>().HasData(
        new Diretor { Id = 1, Name = "Christopher Nolan" },
        new Diretor { Id = 2, Name = "Steven Spielberg" },
        new Diretor { Id = 3, Name = "Quentin Tarantino" },
        new Diretor { Id = 4, Name = "Martin Scorsese" },
        new Diretor { Id = 5, Name = "James Cameron" },
        new Diretor { Id = 6, Name = "Greta Gerwig" }
    );

    modelBuilder.Entity<Filme>().HasData(
        // Filmes de Christopher Nolan
        new Filme { Id = 1, Titulo = "Inception", Ano = 2010, DiretorId = 1 },
        new Filme { Id = 2, Titulo = "Interstellar", Ano = 2014, DiretorId = 1 },
        new Filme { Id = 3, Titulo = "The Dark Knight", Ano = 2008, DiretorId = 1 },

        // Filmes de Steven Spielberg
        new Filme { Id = 4, Titulo = "Jurassic Park", Ano = 1993, DiretorId = 2 },
        new Filme { Id = 5, Titulo = "E.T. the Extra-Terrestrial", Ano = 1982, DiretorId = 2 },
        new Filme { Id = 6, Titulo = "Schindler's List", Ano = 1993, DiretorId = 2 },

        // Filmes de Quentin Tarantino
        new Filme { Id = 7, Titulo = "Pulp Fiction", Ano = 1994, DiretorId = 3 },
        new Filme { Id = 8, Titulo = "Kill Bill: Vol. 1", Ano = 2003, DiretorId = 3 },
        new Filme { Id = 9, Titulo = "Django Unchained", Ano = 2012, DiretorId = 3 },

        // Filmes de Martin Scorsese
        new Filme { Id = 10, Titulo = "Goodfellas", Ano = 1990, DiretorId = 4 },
        new Filme { Id = 11, Titulo = "The Irishman", Ano = 2019, DiretorId = 4 },
        new Filme { Id = 12, Titulo = "Taxi Driver", Ano = 1976, DiretorId = 4 },

        // Filmes de James Cameron
        new Filme { Id = 13, Titulo = "Avatar", Ano = 2009, DiretorId = 5 },
        new Filme { Id = 14, Titulo = "Titanic", Ano = 1997, DiretorId = 5 },
        new Filme { Id = 15, Titulo = "The Terminator", Ano = 1984, DiretorId = 5 },

        // Filmes de Greta Gerwig
        new Filme { Id = 16, Titulo = "Lady Bird", Ano = 2017, DiretorId = 6 },
        new Filme { Id = 17, Titulo = "Little Women", Ano = 2019, DiretorId = 6 },
        new Filme { Id = 18, Titulo = "Barbie", Ano = 2023, DiretorId = 6 }
    );

  }
}
