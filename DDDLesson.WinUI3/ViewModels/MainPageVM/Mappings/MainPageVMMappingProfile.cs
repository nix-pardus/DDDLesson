using AutoMapper;
using DDDLesson.Domain.WorkDays.GetAllMonths;
using DDDLesson.Domain.WorkDays.GetWorkDaysOfMonth;
using DDDLesson.WinUI3.ViewModels.MainPageVM.Responses;

namespace DDDLesson.WinUI3.ViewModels.MainPageVM.Mappings;

public class MainPageVMMappingProfile : Profile
{
    public MainPageVMMappingProfile()
    {
        CreateMap<GetAllMonthsQueryResultEntry, GetAllMonthsResponseEntry>()
            .ForMember(q => q.Month, q => q.MapFrom(w => w.Date));

        CreateMap<GetAllMonthsQueryResult, GetAllMonthsResponse>()
            .ForMember(q => q.Months, q => q.MapFrom(w => w.Entries));

        CreateMap<GetWorkDaysOfMonthListQueryResultEntry, GetWorkDaysListOfMonthResponseEntry>()
            .ForMember(q => q.Id, q => q.MapFrom(w => w.Id))
            .ForMember(q => q.Date, q => q.MapFrom(w => w.Date))
            .ForMember(q => q.IsWeekend, q => q.MapFrom(w => w.IsWeekend))
            .ForMember(q => q.WorkUnits, q => q.MapFrom(w => w.WorkUnits));

        CreateMap<GetWorkDaysOfMonthListQueryResult, GetWorkDaysListOfMonthResponse>()
            .ForMember(q => q.Entries, q => q.MapFrom(w => w.Entries));
    }
}
