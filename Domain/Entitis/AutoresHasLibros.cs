using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entitis;

public class AutoresHasLibros
{
    public int autorId { set; get; }
    public int libro_ISBN { set; get; }
    
    public List<Autores> Autores { set; get; }
    
    public List<Libros> Libros { set; get; }
}