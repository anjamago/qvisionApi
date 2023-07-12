using AutoMapper;
using MediatR;
using Persistence.Bases;

namespace Application.Autores.Command.Update
{
    public class UpdateAutorCommandHandler : IRequestHandler<UpdateAutorCommand>
    {
        private readonly IBaseRepository<Domain.Entitis.Autores> _repository;
        private readonly IMapper _mapper;
        public UpdateAutorCommandHandler(IBaseRepository<Domain.Entitis.Autores> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task Handle(UpdateAutorCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Domain.Entitis.Autores>(request);
            await _repository.UpdateAsync(model);
        }
    }
}

