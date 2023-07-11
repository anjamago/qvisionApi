using Application.Libros.Command.Update;
using Application.Libros.Create;
using AutoMapper;
using Domain.Dtos;

namespace Application.ProfilesMap;

public class LibrosProfile:Profile
{

    public  LibrosProfile()
    {
        CreateMap<CreateLibrosCommand, Domain.Entitis.Libros>()
            .ForMember(f=>f.EditorialId, op=>op.MapFrom(m=>m.EditorialId))
            .ForMember(f=>f.titulo, op=>op.MapFrom(m=>m.titulo))
            .ForMember(f=>f.sinopsis, op=>op.MapFrom(m=>m.sinopsis))
            .ForMember(f=>f.n_paginas, op=>op.MapFrom(m=>m.n_paginas))
            .ForMember(f=>f.titulo, op=>op.MapFrom(m=>m.titulo))
            
            ;
        CreateMap<UpdateLibrosCommand, Domain.Entitis.Libros>()
            .ForMember(f=>f.ISBN,op=>op.MapFrom(m=>m.ISBN))
            .ForMember(f=>f.EditorialId, op=>op.MapFrom(m=>m.EditorialId))
            .ForMember(f=>f.titulo, op=>op.MapFrom(m=>m.titulo))
            .ForMember(f=>f.sinopsis, op=>op.MapFrom(m=>m.sinopsis))
            .ForMember(f=>f.n_paginas, op=>op.MapFrom(m=>m.n_paginas))
            .ForMember(f=>f.titulo, op=>op.MapFrom(m=>m.titulo))
            ;
        CreateMap<Domain.Entitis.Libros, LibrosDto>()
            .ForMember(f=>f.ISBN,op=>op.MapFrom(m=>m.ISBN))
            .ForMember(f=>f.Editorial, op=>op.MapFrom(m=>m.Editoriales))
            .ForMember(f=>f.titulo, op=>op.MapFrom(m=>m.titulo))
            .ForMember(f=>f.sinopsis, op=>op.MapFrom(m=>m.sinopsis))
            .ForMember(f=>f.n_paginas, op=>op.MapFrom(m=>m.n_paginas))
            .ForMember(f=>f.titulo, op=>op.MapFrom(m=>m.titulo))
            .ForMember(f=>f.Autores,op=>op.MapFrom(m=>m.Autores))
            .ForMember(f=>f.Editorial,op=>op.MapFrom(m=>m.Editoriales))
            ;
    }
}