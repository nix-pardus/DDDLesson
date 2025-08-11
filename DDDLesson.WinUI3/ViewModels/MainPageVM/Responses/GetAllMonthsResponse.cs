using System;
using System.Collections.ObjectModel;

namespace DDDLesson.WinUI3.ViewModels.MainPageVM.Responses;

public class GetAllMonthsResponse
{
    public required ObservableCollection<GetAllMonthsResponseEntry> Months { get; init; }
}
