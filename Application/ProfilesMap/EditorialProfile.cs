using Application.Editoriales.Command.Update;
using Application.Editoriales.Create;
using AutoMapper;
using Domain.Dtos;

namespace Application.ProfilesMap;

public class EditorialProfile:Profile
{
    public  EditorialProfile()
    {
        CreateMap<CreateEditorialCommand, Domain.Entitis.Editoriales>()
            .ForMember(f=>f.Nombre, op=>op.MapFrom(m=>m.name))
            .ForMember(f=>f.Sede, op=>op.MapFrom(m=>m.sede))
            ;
        CreateMap<UpdateEditorialCommand, Domain.Entitis.Editoriales>()
            .ForMember(f=>f.Id,op=>op.MapFrom(m=>m.Id))
            .ForMember(f=>f.Nombre, op=>op.MapFrom(m=>m.name))
            .ForMember(f=>f.Sede, op=>op.MapFrom(m=>m.sede))
            ;
        CreateMap<Domain.Entitis.Editoriales, EditorialDto>()
            .ForMember(f => f.Id, op => op.MapFrom(m => m.Id))
            .ForMember(f => f.Nombre, op => op.MapFrom(m => m.Nombre))
            .ForMember(f => f.Sede, op => op.MapFrom(m => m.Sede))
            ;
    }
}