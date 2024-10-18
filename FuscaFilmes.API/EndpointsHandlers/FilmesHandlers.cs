using FuscaFilmes.API.DbContexts;
using FuscaFilmes.API.Models;
using FuscaFilmes.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FuscaFilmes.API.EndpointHandlers;

public class FilmesHandlers
{
  public static async Task<IEnumerable<Filme>> GetFilmesAsync(Context context)
  {
    return await context.Filmes
            .Include(filme => filme.Diretores)
            //.OrderBy(filme => filme.Ano)
            .OrderByDescending(filme => filme.Ano)
            //.ThenBy(filme => filme.Titulo)
            .ThenByDescending(filme => filme.Titulo)
            .ToListAsync();
  }

  public static async Task<IEnumerable<Filme>> GetFilmeByIdAsync(
    int id, 
    Context context)
  {
    return await context.Filmes
            .Include(filme => filme.Diretores)
            .Where(filme => filme.Id == id)
            .ToListAsync();
  }

  public static async Task<IEnumerable<Filme>> GetFilmeEFFUnctionsByTituloAsync(
    string titulo, 
    Context context)
  {
    return await context.Filmes
            .Include(filme => filme.Diretores)
            .Where(filme =>
                EF.Functions.Like(filme.Titulo, $"%{titulo}%")
            )
            .ToListAsync();
  }

  public static async Task<IEnumerable<Filme>> GetFilmesContainsbyTituloAsync(
    string titulo, 
    Context context)
  {
    return await context.Filmes
            .Include(filme => filme.Diretores)
            .Where(filme => filme.Titulo.Contains(titulo))
            .ToListAsync();
  }

  public static async Task ExecuteDeleteFilmeAsync(Context context, int filmeId)
  {
    await context.Filmes
        .Where(filme => filme.Id == filmeId)
        .ExecuteDeleteAsync<Filme>();
  }

  public static async Task<IResult> UpdateFilmeAsync(Context context, FilmeUpdate filmeUpdate)
  {
      var filme = await context.Filmes.FindAsync(filmeUpdate.Id);

      if (filme == null) 
      {
          return Results.NotFound("Filme não encontrado");
      }

      filme.Titulo = filmeUpdate.Titulo;
      filme.Ano = filmeUpdate.Ano;

      context.Filmes.Update(filme);

      await context.SaveChangesAsync();

      return Results.Ok($"Filme com ID {filmeUpdate.Id} atualizado com Sucesso!");
  }

  public static async Task<IResult> ExecuteUpdateFilmeAsync(Context context, FilmeUpdate filmeUpdate)
  {
      var linhasAfetadas = await context.Filmes
          .Where(filme => filme.Id == filmeUpdate.Id)
          .ExecuteUpdateAsync(setter => setter
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
