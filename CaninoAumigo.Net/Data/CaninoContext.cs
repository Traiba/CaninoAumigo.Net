using Microsoft.EntityFrameworkCore;
using CaninoAumigo_API.Models;
namespace CaninoAumigo_API.Data
{

public class CaninoContext : DbContext
{
public CaninoContext(DbContextOptions<CaninoContext> options) : base(options) {}
public DbSet<Animal>? Animal { get; set; }
public DbSet<AnimalPerdido>? AnimalPerdido { get; set; }
public DbSet<Cidade>? Cidade { get; set; }
public DbSet<Conta>? Conta { get; set; }
public DbSet<Estado>? Estado { get; set; }
public DbSet<Porte>? Porte { get; set; }
}
}
