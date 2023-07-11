namespace Domain.Dtos;

public class LibrosDto
{
    public int ISBN { set; get; }
    public string titulo { set; get; }
    public string sinopsis { set; get; }
    public string n_paginas { set; get; }
    public List<AutoresDto> Autores { set; get; } = new();
    public EditorialDto Editorial { set; get; } = new();
}