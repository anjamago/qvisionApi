
using Application.Autores.Command.Update;
using Application.Editoriales.Command.Update;
using MediatR;
using Persistence.Bases;

namespace Application.Editoriales.Command.Delete;

public class DeleteEditorialCommandHandler:IRequestHandler<DeleteEditorialCommand>
{

	private readonly IBaseRepository<Domain.Entitis.Editoriales> _repository;

	public DeleteEditorialCommandHandler(IBaseRepository<Domain.Entitis.Editoriales> repository )
	{
		_repository = repository;
	}

	public async Task Handle(DeleteEditorialCommand request, CancellationToken cancellationToken)
	{
		await _repository.DeleteAsync(predicate: p=> p.Id.Equals(request.id));
	}
}

