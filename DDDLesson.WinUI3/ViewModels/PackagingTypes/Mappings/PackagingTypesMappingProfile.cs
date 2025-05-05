using AutoMapper;
using DDDLesson.Domain.PackagingTypes.GetPackagingTypesList;

namespace DDDLesson.WinUI3.ViewModels.PackagingTypes;

public class PackagingTypesMappingProfile : Profile
{
    public PackagingTypesMappingProfile()
    {
        CreateMap<GetPackagingTypesListQueryResultEntry, GetPackagingTypesListResponseEntry>()
            .ForMember(q => q.Id, q => q.MapFrom(w => w.Id))
            .ForMember(q => q.Name, q => q.MapFrom(w => w.Name))
            .ForMember(q => q.PricePerSquareMeter, q => q.MapFrom(w => w.PricePerSquareMeter))
            .ForMember(q => q.PricePerSquareMeterOnWeekend, q => q.MapFrom(w => w.PricePerSquareMeterOnWeekend));

        CreateMap<GetPackagingTypesListQueryResult, GetPackagingTypesListResponse>()
            .ForMember(q => q.Entries, q => q.MapFrom(w => w.Entries));

        
    }
}
