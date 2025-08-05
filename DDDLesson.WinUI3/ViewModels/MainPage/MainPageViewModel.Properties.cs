using DDDLesson.WinUI3.ViewModels.MainPageVM.Responses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DDDLesson.WinUI3.ViewModels.MainPageVM;

public partial class MainPageViewModel
{
    private ObservableCollection<GetWorkDaysListOfMonthResponseEntry> _workDaysOfMonth;
    private DateTime selectedMonth;
    private List<DateTime> dates = new List<DateTime>
    {
        new DateTime(2025, 06, 15),
        new DateTime(2025, 05, 15),
        new DateTime(2025, 04, 15),
        new DateTime(2025, 03, 15),
        new DateTime(2025, 02, 15),
        new DateTime(2025, 01, 15),
        new DateTime(2024, 12, 15),
        new DateTime(2024, 11, 15),
        new DateTime(2024, 10, 15),
        new DateTime(2024, 08, 15),
        new DateTime(2024, 07, 15),
        new DateTime(2024, 06, 15),
        new DateTime(2024, 05, 15),
        new DateTime(2024, 04, 15),
        new DateTime(2024, 03, 15),
        new DateTime(2024, 02, 15),
        new DateTime(2024, 01, 15),
        new DateTime(2023, 12, 15),
        new DateTime(2023, 11, 15),
        new DateTime(2023, 10, 15),
    };

    public ObservableCollection<GetWorkDaysListOfMonthResponseEntry> WorkDaysOfMonth
    {
        get => _workDaysOfMonth;
        set
        {
            SetProperty(ref _workDaysOfMonth, value);
        }
    }

    public DateTime SelectedMonth
    {
        get => selectedMonth;
        set
        {
            SetProperty(ref selectedMonth, value);
        }
    }

    public List<DateTime> Dates
    {
        get => dates;
        set
        {
            SetProperty(ref dates, value);
        }
    }
}
