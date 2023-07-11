using AutoMapper;
using Domain.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Bases;

namespace Application.Libros.GetAll;

public class GetAllLibrosCommandHandler:IRequestHandler<GetAllLibrosCommand, List<LibrosDto>>
{
    private readonly IBaseRepository<Domain.Entitis.Libros> _repository;
    private readonly IMapper _mapper;

    public GetAllLibrosCommandHandler(IBaseRepository<Domain.Entitis.Libros> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<LibrosDto>> Handle(GetAllLibrosCommand request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetAllAsync(
            include:inc=>inc.Include(
                i=>i.Editoriales
            ).Include(i=>i.Autores)

        );
        return _mapper.Map<List<LibrosDto>>(result);
    }
}