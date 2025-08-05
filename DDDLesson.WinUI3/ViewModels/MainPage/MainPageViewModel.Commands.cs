using CommunityToolkit.Mvvm.Input;
using DDDLesson.Domain.WorkDays.GetWorkDaysOfMonth;
using DDDLesson.WinUI3.ViewModels.MainPageVM.Responses;
using System.Threading.Tasks;

namespace DDDLesson.WinUI3.ViewModels.MainPageVM;

public partial class MainPageViewModel
{
    [RelayCommand]
    public async Task GetWorkDaysOfMonthAsync()
    {
        var response = await _mediator.Send(new GetWorkDaysOfMonthListQuery { Month = SelectedMonth });
        WorkDaysOfMonth = _mapper.Map<GetWorkDaysListOfMonthResponse>(response).Entries;
    }
}
