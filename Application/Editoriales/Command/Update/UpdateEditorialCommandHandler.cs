using System;
using AutoMapper;
using MediatR;
using Persistence.Bases;

namespace Application.Editoriales.Command.Update
{
	public class UpdateEditorialCommandHandler:IRequestHandler<UpdateEditorialCommand>
	{
		private readonly IBaseRepository<Domain.Entitis.Editoriales> _repository;
		private readonly IMapper _mapper;
		public UpdateEditorialCommandHandler(IBaseRepository<Domain.Entitis.Editoriales> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}


		public async Task Handle(UpdateEditorialCommand request, CancellationToken cancellationToken)
		{
			var model = _mapper.Map<Domain.Entitis.Editoriales>(request);
			await _repository.UpdateAsync(model);
		}
	}
}

