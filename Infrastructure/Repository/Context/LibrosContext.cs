using Domain.Entitis;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context;

public class LibrosContext:DbContext
{
    
    public DbSet<Autores> Autores { set; get; }
    public DbSet<Libros> Libros { set; get; }
    public DbSet<AutoresHasLibros> AutoresHasLibros { set; get; }
    public DbSet<Editoriales> Editoriales { set; get; }


    public LibrosContext(DbContextOptions<LibrosContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
  
}