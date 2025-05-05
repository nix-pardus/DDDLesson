//using AutoMapper;
//using DDDLesson.ApplicationWinUI3.Features.Workers.GetWorkersList;
//using DDDLesson.Domain.Workers.GetWorkersList;

//namespace DDDLesson.ApplicationWinUI3.Features.Workers;

//public class WorkersMappingProfile : Profile
//{
//    public WorkersMappingProfile()
//    {
//        CreateMap<GetWorkersListQueryResultEntry, GetWorkersListResponseEntry>()
//            .ForMember(q => q.Id, q => q.MapFrom(w => w.Id))
//            .ForMember(q => q.Name, q => q.MapFrom(w => w.Name));

//        CreateMap<GetWorkersListQueryResult, GetWorkersListResponse>()
//            .ForMember(q => q.Entries, q => q.MapFrom(w => w.Entries));
//    }
//}
