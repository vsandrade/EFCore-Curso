namespace FuscaFilmes.Domain.Entities;
public class Diretor
{
  public int Id { get; set;}
  public required string Name { get; set;}
  public ICollection<Filme> Filmes { get; set; } = [];
}
