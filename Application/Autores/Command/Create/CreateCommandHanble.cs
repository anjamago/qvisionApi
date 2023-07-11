using AutoMapper;
using MediatR;
using Persistence.Bases;

namespace Application.Autores.Create;

internal class CreateCommandHanble:IRequestHandler<CreateAutorCommand>
{
    private readonly IBaseRepository<Domain.Entitis.Autores> _repository;
    private readonly IMapper _mapper;

    public CreateCommandHanble(IBaseRepository<Domain.Entitis.Autores> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task Handle(CreateAutorCommand request, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<Domain.Entitis.Autores>(request);
        await _repository.AddAsync(model);
        
    }
}