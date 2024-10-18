using System;

namespace FuscaFilmes.Domain.Entities;

public class DiretorDetalhe
{
  public int Id { get; set; }
  public string Biografia { get; set; } = string.Empty;
  public DateTime DataCriacao { get; set; }
  public DateTime DataNascimento { get; set; }

  public int DiretorId { get; set; }
  public Diretor Diretor { get; set; } = null!;
}
