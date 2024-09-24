using System;

namespace FuscaFilmes.API.Entities;

public class Diretor
{
  public int Id { get; set;}
  public required string Name { get; set;}
  public ICollection<Filme> Filmes { get; set; } = [];
}
