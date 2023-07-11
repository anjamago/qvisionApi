using FluentValidation;
using Persistence.Bases;
using Application.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Application.Libros.Create;


public class CreateLibrosCommandValidate:AbstractValidator<CreateLibrosCommand>
{
    private readonly IBaseRepository<Domain.Entitis.Libros> _repository;
    public  CreateLibrosCommandValidate ( IBaseRepository<Domain.Entitis.Libros> repository)
    {
        _repository = repository;
        RuleSet("LibroAutor",
        ()=>
        {
            RuleFor(r => r.titulo).MustAsync(LibroWhitAutor)
                .WithMessage("Nombre del Libro ya se encuetra registrado en el sistema");
        });
        RuleFor(r => r.titulo).NotEmpty().NotEmpty();
        RuleFor(r => r.sinopsis).NotEmpty().NotEmpty();
        RuleFor(r => r.n_paginas).NotEmpty().NotEmpty();
    }

    private async Task<bool> LibroWhitAutor(string name, CancellationToken cancellationToken)
    {
        var isValid = await _repository.GetAsync(
            predicate: l=>l.titulo== name
           // include: inc=> inc.
        );
        
        
       return !isValid.IsValid();
    }
}