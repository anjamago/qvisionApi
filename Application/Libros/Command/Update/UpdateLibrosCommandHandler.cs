using AutoMapper;
using MediatR;
using Persistence.Bases;

namespace Application.Libros.Command.Update
{
    public class UpdateLibrosCommandHandler : IRequestHandler<UpdateLibrosCommand>
    {
        private readonly IBaseRepository<Domain.Entitis.Libros> _repository;
        private readonly IMapper _mapper;
        public UpdateLibrosCommandHandler(IBaseRepository<Domain.Entitis.Libros> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task Handle(UpdateLibrosCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Domain.Entitis.Libros>(request);
            await _repository.UpdateAsync(model);
        }
    }
}

