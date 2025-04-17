//using AutoMapper;
//using DDDLesson.Application.DTOs;
//using DDDLesson.Infrastructure.Repositories.WorkerRepository;
//using MediatR;

//namespace DDDLesson.Application.Features.Queries.GetWorkers;

//public class GetWorkersHandler : IRequestHandler<GetWorkersQuery, IEnumerable<WorkerDTO>>
//{
//    private readonly IWorkerEntityRepository _repository;
//    private readonly IMapper _mapper;

//    public GetWorkersHandler(IWorkerEntityRepository repository, IMapper mapper)
//    {
//        _repository = repository;
//        _mapper = mapper;
//    }

//    public async Task<IEnumerable<WorkerDTO>> Handle(GetWorkersQuery request, CancellationToken cancellationToken)
//    {
//        var workers = await _repository.GetAllAsync(cancellationToken);
//        return _mapper.Map<IEnumerable<WorkerDTO>>(workers);
//    }
//}
