using FuscaFilmes.API.DbContexts;
using FuscaFilmes.API.Models;
using FuscaFilmes.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FuscaFilmes.API.EndpointHandlers;

public class FilmesHandlers
{
  public static IEnumerable<Filme> GetFilmes(Context context)
  {
    return context.Filmes
            .Include(filme => filme.Diretores)
            //.OrderBy(filme => filme.Ano)
            .OrderByDescending(filme => filme.Ano)
            //.ThenBy(filme => filme.Titulo)
            .ThenByDescending(filme => filme.Titulo)
            .ToList();
  }

  public static IEnumerable<Filme> GetFilmeById(int id, Context context)
  {
    return context.Filmes
            .Where(filme => filme.Id == id)
            .Include(filme => filme.Diretores).ToList();
  }

  public static IEnumerable<Filme> GetFilmeEFFUnctionsByTitulo(string titulo, Context context)
  {
    return context.Filmes
            .Where(filme =>
                EF.Functions.Like(filme.Titulo, $"%{titulo}%")
            )
            .Include(filme => filme.Diretores).ToList();
  }

  public static IEnumerable<Filme> GetFilmesContainsbyTitulo(string titulo, Context context)
  {
    return context.Filmes
            .Where(filme => filme.Titulo.Contains(titulo))
            .Include(filme => filme.Diretores).ToList();
  }

  public static void ExecuteDeleteFilme(Context context, int filmeId)
  {
    context.Filmes
        .Where(filme => filme.Id == filmeId)
        .ExecuteDelete<Filme>();
  }

  public static IResult UpdateFilme(Context context, FilmeUpdate filmeUpdate)
  {
      var filme = context.Filmes.Find(filmeUpdate.Id);

      if (filme == null) 
      {
          return Results.NotFound("Filme não encontrado");
      }

      filme.Titulo = filmeUpdate.Titulo;
      filme.Ano = filmeUpdate.Ano;

      context.Filmes.Update(filme);
      context.SaveChanges();

      return Results.Ok($"Filme com ID {filmeUpdate.Id} atualizado com Sucesso!");
  }

  public static IResult ExecuteUpdateFilme(Context context, FilmeUpdate filmeUpdate)
  {
      var linhasAfetadas = context.Filmes
          .Where(filme => filme.Id == filmeUpdate.Id)
          .ExecuteUpdate(setter => setter
              .SetProperty(f => f.Titulo, filmeUpdate.Titulo)
              .SetProperty(f => f.Ano, filmeUpdate.Ano)
          );

      if (linhasAfetadas > 0) {
          return Results.Ok($"Você teve um total de {linhasAfetadas} Linha(s) afeta(s)");
      } else {
          return Results.NoContent();
      }
  }
}
