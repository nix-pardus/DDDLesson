using AutoMapper;
using DDDLesson.Domain.Workers.GetWorkersList;
using DDDLesson.WinUI3.ViewModels.Workers.Responses;

namespace DDDLesson.WinUI3.ViewModels.Workers.Mappings;

public class WorkersMappingProfile : Profile
{
    public WorkersMappingProfile()
    {
        CreateMap<GetWorkersListQueryResultEntry, GetWorkersListResponseEntry>()
            .ForMember(q => q.Id, q => q.MapFrom(w => w.Id))
            .ForMember(q => q.Name, q => q.MapFrom(w => w.Name))
            .ForMember(q => q.IsInOurShift, q => q.MapFrom(w => w.IsInOurShift));

        CreateMap<GetWorkersListQueryResult, GetWorkersListResponse>()
            .ForMember(q => q.Entries, q => q.MapFrom(w => w.Entries));
    }
}
