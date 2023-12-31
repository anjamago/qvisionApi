using Application.Autores;
using Application.Editoriales;
using Application.Libros;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application.inyect;

public static class Application
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
        => service
            .AddMediatR(op => op.RegisterServicesFromAssemblies(typeof(ApplicationAssembly).Assembly))
            .AddValidatorsFromAssembly(typeof(ApplicationAssembly).Assembly)
            .AddAutoMapper(typeof(ApplicationAssembly).Assembly)

            .AddScoped<IAutorBusiness, AutorBusiness>()
            .AddScoped<ILibrosBusiness, LibrosBusiness>()
            .AddScoped<IEditorialBusiness, EditorialBusiness>()
        ;
}