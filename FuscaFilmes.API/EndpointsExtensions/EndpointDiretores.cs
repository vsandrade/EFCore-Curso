using FuscaFilmes.API.EndpointHandlers;

namespace FuscaFilmes.API.EndpointsExtensions;

public static class EndpointDiretores
{
  public static void DiretoresEndpoints(this IEndpointRouteBuilder app)
  {
    app.MapGet("/diretores", DiretoresHandlers.GetDiretoresAsync)
       .WithOpenApi();

    app.MapGet("/diretores/agregacao/{name}", DiretoresHandlers.GetDiretorByNameAsync)
       .WithOpenApi();

    app.MapGet("/diretores/where/{id}", DiretoresHandlers.GetDiretoresByIdAsync)
       .WithOpenApi();

    app.MapPost("/diretores", DiretoresHandlers.AddDiretorAsync)
       .WithOpenApi();

    app.MapPut("/diretores", DiretoresHandlers.UpdateDiretorAsync)
       .WithOpenApi();

    app.MapDelete("/diretores/{diretorId}", DiretoresHandlers.DeleteDiretorAsync)
       .WithOpenApi();
  }
}
