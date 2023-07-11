
using Application.Autores.Command.Update;
using MediatR;
using Persistence.Bases;

namespace Application.Autores.Command.Delete;

public class DeleteAutorCommandHandler:IRequestHandler<DeleteAutorCommand>
{

	private readonly IBaseRepository<Domain.Entitis.Autores> _repository;

	public DeleteAutorCommandHandler(IBaseRepository<Domain.Entitis.Autores> repository )
	{
		_repository = repository;
	}

	public async Task Handle(DeleteAutorCommand request, CancellationToken cancellationToken)
	{
		await _repository.DeleteAsync(predicate: p=> p.Id.Equals(request.id));
	}
}

