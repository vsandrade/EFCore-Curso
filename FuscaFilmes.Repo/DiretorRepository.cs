using System;
using FuscaFilmes.API.DbContexts;
using FuscaFilmes.Domain.Entities;
using FuscaFilmes.Repo.Contratos;
using Microsoft.EntityFrameworkCore;

namespace FuscaFilmes.Repo;

public class DiretorRepository(Context _context) : IDiretorRepository
{
  public Context Context { get; } = _context;

  public async Task<IEnumerable<Diretor>> GetDiretoresAsync()
  {
    return await Context.Diretores.Include(diretor => diretor.Filmes).ToListAsync();
  }

  public async Task<Diretor> GetDiretorByNameAsync(string name)
  {
    return await Context.Diretores
            .Include(diretor => diretor.Filmes)
            .FirstOrDefaultAsync(diretor => diretor.Name.Contains(name))
            ?? new Diretor { Id = 5555, Name = "Marina" };
  }

  public async Task<IEnumerable<Diretor>> GetDiretoresByIdAsync(int id)
  {
    return await Context.Diretores
            .Include(diretor => diretor.Filmes)
            .Where(diretor => diretor.Id == id)
            .ToListAsync();
  }

  public async Task AddAsync(Diretor diretor)
  {
    await Context.Diretores.AddAsync(diretor);
  }

  public async Task DeleteAsync(int diretorId)
  {
    var diretor = await Context.Diretores.FindAsync(diretorId);

    if (diretor != null)
      Context.Diretores.Remove(diretor);
  }

  public async Task UpdateAsync(Diretor diretorNovo)
  {
    var diretor = await Context.Diretores.FindAsync(diretorNovo.Id);

    if (diretor != null)
    {
      diretor.Name = diretorNovo.Name;
      if (diretorNovo.Filmes.Count > 0)
      {
        diretor.Filmes.Clear();
        foreach (var filme in diretorNovo.Filmes)
        {
          diretor.Filmes.Add(filme);
        }
      }
    }
  }

  public async Task<bool> SaveChangesAsync()
  {
    return (await Context.SaveChangesAsync()) > 0;
  }
}
