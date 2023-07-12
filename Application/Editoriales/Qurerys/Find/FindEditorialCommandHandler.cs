using AutoMapper;
using Domain.Dtos;
using MediatR;
using Persistence.Bases;

namespace Application.Editoriales.Qurerys.Find;

public class FindEditorialCommandHandler : IRequestHandler<FindEditorialCommand, EditorialDto>
{
    private readonly IBaseRepository<Domain.Entitis.Editoriales> _repository;
    private readonly IMapper _mapper;

    public FindEditorialCommandHandler(IBaseRepository<Domain.Entitis.Editoriales> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<EditorialDto> Handle(FindEditorialCommand request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetAsync(predicate: p => p.Id.Equals(request.id));
        return _mapper.Map<EditorialDto>(result);
    }
}