using System;
using FuscaFilmes.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace FuscaFilmes.API.DbContexts;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{
  public DbSet<Filme> Filmes { get; set; }
  public DbSet<Diretor> Diretores { get; set; }
}
