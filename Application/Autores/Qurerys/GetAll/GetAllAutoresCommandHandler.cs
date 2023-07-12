using AutoMapper;
using Domain.Dtos;
using MediatR;
using Persistence.Bases;

namespace Application.Autores.GetAll;

public class GetAllAutoresCommandHandler : IRequestHandler<GetAllAutoresCommand, List<AutoresDto>>
{
    private readonly IBaseRepository<Domain.Entitis.Autores> _repository;
    private readonly IMapper _mapper;

    public GetAllAutoresCommandHandler(IBaseRepository<Domain.Entitis.Autores> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<AutoresDto>> Handle(GetAllAutoresCommand request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetAllAsync();
        return _mapper.Map<List<AutoresDto>>(result);
    }
}