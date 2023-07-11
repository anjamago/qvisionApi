using Domain.Entitis;

namespace Domain.Dtos;

public class LibrosAutorDto
{
    public List<Libros> Libros { set; get; }
    public List<Autores> Autores { set; get; }
}