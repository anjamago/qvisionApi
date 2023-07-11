using FluentValidation;

namespace Application.Libros.Command.Update;

public class UpdateLibrosCommandValidate:AbstractValidator<UpdateLibrosCommand>
{
    public UpdateLibrosCommandValidate()
    {
        RuleFor(f => f.ISBN).NotNull().NotEmpty().DependentRules(() =>
        {
            RuleFor(f => f.titulo).NotNull();
            RuleFor(f => f.sinopsis).NotNull();
            RuleFor(f => f.n_paginas).NotNull();
            RuleFor(f => f.EditorialId).NotNull();
        });
    }
}