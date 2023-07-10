using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entitis;

public class AutoresHasLibros
{
    public int autorId { set; get; }
    public int libro_ISBN { set; get; }
    
    [ForeignKey("autorId")]
    public virtual Autores Autores { set; get; }
    
    [ForeignKey("libro_ISBN")]
    public virtual Libros Libros { set; get; }
}