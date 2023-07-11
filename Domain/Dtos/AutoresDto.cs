namespace Domain.Dtos;

public class AutoresDto
{
    public int Id { get; set; }
    public string Nombre { set; get; }
    public string Apellidos { set; get; }

    public List<AutoresDto> Libros { set; get; } = new();
}