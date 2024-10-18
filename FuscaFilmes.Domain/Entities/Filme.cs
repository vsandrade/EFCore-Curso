using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FuscaFilmes.Domain.Entities;

public class Filme
{
  public int Id { get; set; }

  [Required]
  [MaxLength(100)]
  public string Titulo { get; set; } = string.Empty;

  [Range(1900, 2050)]
  public int Ano { get; set; }

  [Column(TypeName = "decimal(18,2)")]
  public decimal Orcamento { get; set; }

  public ICollection<DiretorFilme> DiretoresFilmes { get; set; } = null!;
  public ICollection<Diretor> Diretores { get; set; } = null!;
}
