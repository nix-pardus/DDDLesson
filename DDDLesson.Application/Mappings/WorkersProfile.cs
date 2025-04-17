using AutoMapper;
using DDDLesson.Application.DTOs;
using DDDLesson.Infrastructure.Persistence.Entities;

namespace DDDLesson.Application.Mappings;

public class WorkersProfile : Profile
{
    public WorkersProfile()
    {
        CreateMap<WorkerEntity, WorkerDTO>()
            .ForMember(q => q.Id, q => q.MapFrom(w => w.Id))
            .ForMember(q => q.Name, q => q.MapFrom(w => w.Name));
    }
}
