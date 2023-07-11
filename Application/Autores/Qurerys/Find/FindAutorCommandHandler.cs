using AutoMapper;
using Domain.Dtos;
using MediatR;
using Persistence.Bases;

namespace Application.Autores.Qurerys.Find;

public class FindAutorCommandHandler: IRequestHandler<FindAutorCommand, AutoresDto>
{
    private readonly IBaseRepository<Domain.Entitis.Autores> _repository;
    private readonly IMapper _mapper;

    public FindAutorCommandHandler(IBaseRepository<Domain.Entitis.Autores> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AutoresDto> Handle(FindAutorCommand request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetAsync(predicate: p => p.Id.Equals(request.id));
        return _mapper.Map<AutoresDto>(result);
    }
}