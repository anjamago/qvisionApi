using Application.Autores.Command.Update;
using Application.Autores.Create;
using AutoMapper;
using Domain.Dtos;

namespace Application.ProfilesMap;

public class AutorProfile : Profile
{

    public AutorProfile()
    {
        CreateMap<CreateAutorCommand, Domain.Entitis.Autores>()
            .ForMember(d => d.Nombre, op => op.MapFrom(m => m.name))
            .ForMember(d => d.Apellidos, op => op.MapFrom(m => m.lastName));

        CreateMap<UpdateAutorCommand, Domain.Entitis.Autores>()
            .ForMember(d => d.Id, op => op.MapFrom(m => m.Id))
            .ForMember(d => d.Nombre, op => op.MapFrom(m => m.name))
            .ForMember(d => d.Apellidos, op => op.MapFrom(m => m.lastName));


        CreateMap<Domain.Entitis.Autores, AutoresDto>()
            .ForMember(d => d.Nombre, op => op.MapFrom(m => m.Nombre))
            .ForMember(d => d.Apellidos, op => op.MapFrom(m => m.Apellidos))
            .ForMember(d => d.Id, op => op.MapFrom(m => m.Id))
            .ForMember(d => d.Libros, op => op.Ignore());
    }
}