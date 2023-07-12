using AutoMapper;
using Domain.Dtos;
using MediatR;
using Persistence.Bases;

namespace Application.Editoriales.GetAll;

public class GetAllEditorialCommandHandler : IRequestHandler<GetAllEditorialCommand, List<EditorialDto>>
{
    private readonly IBaseRepository<Domain.Entitis.Editoriales> _repository;
    private readonly IMapper _mapper;

    public GetAllEditorialCommandHandler(IBaseRepository<Domain.Entitis.Editoriales> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<EditorialDto>> Handle(GetAllEditorialCommand request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetAllAsync();
        return _mapper.Map<List<EditorialDto>>(result);
    }
}