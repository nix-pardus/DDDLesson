using System.Collections.ObjectModel;

namespace DDDLesson.WinUI3.ViewModels.MainPageVM.Responses;

public class GetWorkDaysListOfMonthResponse
{
    public required ObservableCollection<GetWorkDaysListOfMonthResponseEntry> Entries { get; init; }
}
