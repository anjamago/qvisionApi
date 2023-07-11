
using Application.Libros.Command.Update;
using MediatR;
using Persistence.Bases;

namespace Application.Libros.Command.Delete;

public class DeleteAutorCommandHandler:IRequestHandler<DeleteLibrosCommand>
{

	private readonly IBaseRepository<Domain.Entitis.Libros> _repository;

	public DeleteAutorCommandHandler(IBaseRepository<Domain.Entitis.Libros> repository )
	{
		_repository = repository;
	}

	public async Task Handle(DeleteLibrosCommand request, CancellationToken cancellationToken)
	{
		await _repository.DeleteAsync(predicate: p=> p.ISBN.Equals(request.id));
	}
}

