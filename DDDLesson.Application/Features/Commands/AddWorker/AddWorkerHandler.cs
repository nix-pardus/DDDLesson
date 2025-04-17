//using AutoMapper;
//using DDDLesson.Common;
//using DDDLesson.Infrastructure.Persistence.Entities;
//using DDDLesson.Infrastructure.Repositories.WorkerRepository;
//using MediatR;

//namespace DDDLesson.Application.Features.Commands.AddWorker;

//public class AddWorkerHandler : IRequestHandler<AddWorkerCommand, WorkerId>
//{
//    private readonly IWorkerEntityRepository _repository;
//    private readonly IMapper _mapper;

//    public AddWorkerHandler(IWorkerEntityRepository repository, IMapper mapper)
//    {
//        _repository = repository;
//        _mapper = mapper;
//    }

//    public async Task<WorkerId> Handle(AddWorkerCommand request, CancellationToken cancellationToken)
//    {
//        var worker = await _repository.AddAsync(new WorkerEntity
//        {
//            Id = WorkerId.New(),
//            Name = request.Name
//        });
//        return worker.Entity.Id;
//    }
//}
