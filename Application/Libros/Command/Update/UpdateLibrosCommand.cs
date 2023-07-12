using MediatR;

namespace Application.Libros.Command.Update;

public record UpdateLibrosCommand(int ISBN,
    int EditorialId,
    string titulo,
    string sinopsis,
    string n_paginas) : IRequest;

