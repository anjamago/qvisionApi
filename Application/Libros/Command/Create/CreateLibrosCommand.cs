using MediatR;

namespace Application.Libros.Create;

public record CreateLibrosCommand( int ISBN ,
    int EditorialId ,
    int AutorId ,
    string titulo ,
    string sinopsis ,
    string n_paginas ) : IRequest;

