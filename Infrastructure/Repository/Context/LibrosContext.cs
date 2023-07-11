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
        modelBuilder.Entity<Autores>();
        //modelBuilder.Entity<Libros>();
        modelBuilder.Entity<Editoriales>();
        modelBuilder.Entity<AutoresHasLibros>();
        
        modelBuilder.Entity<Libros>()
            .HasMany<Autores>(m => m.Autores)
            .WithMany(m => m.Libros)
            .UsingEntity<AutoresHasLibros>(
                a=> a.HasOne<Autores>().WithMany().HasForeignKey(e=>e.autorId),
                l=>l.HasOne<Libros>().WithMany().HasForeignKey(e=>e.libro_ISBN)
            );

    }
  
}