using FuscaFilmes.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FuscaFilmes.API.DbContexts;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{
  public DbSet<Filme> Filmes { get; set; }
  public DbSet<Diretor> Diretores { get; set; }
  public DbSet<DiretorFilme> DiretoresFilmes { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Diretor>()
            .HasMany(d => d.Filmes)
            .WithMany(f => f.Diretores)
            .UsingEntity<DiretorFilme>(
                df => df.HasOne<Filme>(e => e.Filme)
                        .WithMany(e => e.DiretoresFilmes)
                        .HasForeignKey(e => e.FilmeId),
                df => df.HasOne<Diretor>(e => e.Diretor)
                        .WithMany(e => e.DiretoresFilmes)
                        .HasForeignKey(e => e.DiretorId),
                df => 
                {
                  df.HasKey(e => new { e.DiretorId, e.FilmeId });
                  df.ToTable("DiretoresFilmes");
                }
            );

    modelBuilder.Entity<Diretor>()
      .HasOne(d => d.DiretorDetalhe)
      .WithOne(d => d.Diretor)
      .HasForeignKey<DiretorDetalhe>(dd => dd.DiretorId);

    modelBuilder.Entity<Diretor>().HasData(
        new Diretor { Id = 1, Name = "Christopher Nolan" },
        new Diretor { Id = 2, Name = "Steven Spielberg" },
        new Diretor { Id = 3, Name = "Quentin Tarantino" },
        new Diretor { Id = 4, Name = "Martin Scorsese" },
        new Diretor { Id = 5, Name = "James Cameron" },
        new Diretor { Id = 6, Name = "Greta Gerwig" }
    );

    modelBuilder.Entity<DiretorDetalhe>().HasData(
      new DiretorDetalhe { Id = 1, DiretorId = 1, Biografia = "Biografia do Christopher Nolan", DataNascimento = new DateTime(1970, 7, 30) },
      new DiretorDetalhe { Id = 2, DiretorId = 2, Biografia = "Biografia do Steven Spielberg", DataNascimento = new DateTime(1946, 12, 18) }
    );

    modelBuilder.Entity<Filme>().HasData(
        // Filmes de Christopher Nolan
        new Filme { Id = 1, Titulo = "Inception", Ano = 2010 },
        new Filme { Id = 2, Titulo = "Interstellar", Ano = 2014 },
        new Filme { Id = 3, Titulo = "The Dark Knight", Ano = 2008 },

        // Filmes de Steven Spielberg
        new Filme { Id = 4, Titulo = "Jurassic Park", Ano = 1993 },
        new Filme { Id = 5, Titulo = "E.T. the Extra-Terrestrial", Ano = 1982 },
        new Filme { Id = 6, Titulo = "Schindler's List", Ano = 1993 },

        // Filmes de Quentin Tarantino
        new Filme { Id = 7, Titulo = "Pulp Fiction", Ano = 1994 },
        new Filme { Id = 8, Titulo = "Kill Bill: Vol. 1", Ano = 2003 },
        new Filme { Id = 9, Titulo = "Django Unchained", Ano = 2012 },

        // Filmes de Martin Scorsese
        new Filme { Id = 10, Titulo = "Goodfellas", Ano = 1990 },
        new Filme { Id = 11, Titulo = "The Irishman", Ano = 2019 },
        new Filme { Id = 12, Titulo = "Taxi Driver", Ano = 1976 },

        // Filmes de James Cameron
        new Filme { Id = 13, Titulo = "Avatar", Ano = 2009 },
        new Filme { Id = 14, Titulo = "Titanic", Ano = 1997 },
        new Filme { Id = 15, Titulo = "The Terminator", Ano = 1984 },

        // Filmes de Greta Gerwig
        new Filme { Id = 16, Titulo = "Lady Bird", Ano = 2017 },
        new Filme { Id = 17, Titulo = "Little Women", Ano = 2019 },
        new Filme { Id = 18, Titulo = "Barbie", Ano = 2023 }
    );

    modelBuilder.Entity<DiretorFilme>().HasData(
        new { DiretorId = 1, FilmeId = 1 },
        new { DiretorId = 1, FilmeId = 2 },
        new { DiretorId = 1, FilmeId = 3 },
        new { DiretorId = 2, FilmeId = 4 },
        new { DiretorId = 2, FilmeId = 5 },
        new { DiretorId = 2, FilmeId = 6 },
        new { DiretorId = 3, FilmeId = 7 },
        new { DiretorId = 3, FilmeId = 8 },
        new { DiretorId = 3, FilmeId = 9 },
        new { DiretorId = 4, FilmeId = 10 },
        new { DiretorId = 4, FilmeId = 11 },
        new { DiretorId = 4, FilmeId = 12 },
        new { DiretorId = 5, FilmeId = 13 },
        new { DiretorId = 5, FilmeId = 14 },
        new { DiretorId = 5, FilmeId = 15 },
        new { DiretorId = 6, FilmeId = 16 },
        new { DiretorId = 6, FilmeId = 17 },
        new { DiretorId = 6, FilmeId = 18 }
    );
  }
}
