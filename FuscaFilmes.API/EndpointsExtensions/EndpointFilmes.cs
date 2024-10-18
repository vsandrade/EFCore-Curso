using System;
using FuscaFilmes.API.EndpointHandlers;

namespace FuscaFilmes.API.EndpointsExtensions;

public static class EndpointFilmes
{
  public static void FilmesEndpoints(this IEndpointRouteBuilder app)
  {
    app.MapGet("/filmes", FilmesHandlers.GetFilmesAsync)
       .WithOpenApi();

    app.MapGet("/filmes/{id}", FilmesHandlers.GetFilmeByIdAsync)
       .WithOpenApi();

    app.MapGet("/filmesEFFunctions/byName/{titulo}", FilmesHandlers.GetFilmeEFFUnctionsByTituloAsync)
       .WithOpenApi();

    app.MapGet("/filmesContains/byName/{titulo}", FilmesHandlers.GetFilmesContainsbyTituloAsync)
       .WithOpenApi();

    app.MapDelete("/filmes/{filmeId}", FilmesHandlers.ExecuteDeleteFilmeAsync)
       .WithOpenApi();

    app.MapPatch("/filmesUpdate", FilmesHandlers.UpdateFilmeAsync)
       .WithOpenApi();

    app.MapPatch("/filmesExecuteUpdate", FilmesHandlers.ExecuteUpdateFilmeAsync)
       .WithOpenApi();
  }
}
