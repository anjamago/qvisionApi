using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Entitis;

public class Libros
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ISBN { set; get; }
    public int EditorialId { set; get; }
    public string titulo { set; get; }
    public string sinopsis { set; get; }
    public string n_paginas { set; get; }

    [ForeignKey("EditorialId")]
    public virtual Editoriales Editoriales {
        set;
        get;
    }

    public List<Autores> Autores { set; get; } = new();

}