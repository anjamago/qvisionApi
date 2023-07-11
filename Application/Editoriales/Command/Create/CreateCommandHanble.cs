using AutoMapper;
using MediatR;
using Persistence.Bases;

namespace Application.Editoriales.Create;

internal class CreateCommandHanble:IRequestHandler<CreateEditorialCommand>
{
    private readonly IBaseRepository<Domain.Entitis.Editoriales> _repository;
    private readonly IMapper _mapper;

    public CreateCommandHanble(IBaseRepository<Domain.Entitis.Editoriales> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task Handle(CreateEditorialCommand request, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<Domain.Entitis.Editoriales>(request);
        await _repository.AddAsync(model);
        
    }
}