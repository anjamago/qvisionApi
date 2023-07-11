using AutoMapper;
using Domain.Dtos;
using MediatR;
using Persistence.Bases;

namespace Application.Libros.Qurerys.Find;

public class FindLibrosCommandHandler: IRequestHandler<FindLibrosCommand, LibrosDto>
{
    private readonly IBaseRepository<Domain.Entitis.Libros> _repository;
    private readonly IMapper _mapper;

    public FindLibrosCommandHandler(IBaseRepository<Domain.Entitis.Libros> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<LibrosDto> Handle(FindLibrosCommand request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetAsync(predicate: p => p.ISBN.Equals(request.id));
        return _mapper.Map<LibrosDto>(result);
    }
}