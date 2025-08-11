using DDDLesson.WinUI3.ViewModels.MainPageVM.Responses;
using System;
using System.Collections.ObjectModel;

namespace DDDLesson.WinUI3.ViewModels.MainPageVM;

public partial class MainPageViewModel
{
    private ObservableCollection<GetWorkDaysListOfMonthResponseEntry> _workDaysOfMonth;
    private GetWorkDaysListOfMonthResponseEntry selectedWorkDay;
    private DateTime selectedMonth;
    private ObservableCollection<DateTime> dates;

    public ObservableCollection<GetWorkDaysListOfMonthResponseEntry> WorkDaysOfMonth
    {
        get => _workDaysOfMonth;
        set
        {
            SetProperty(ref _workDaysOfMonth, value);
        }
    }

    public GetWorkDaysListOfMonthResponseEntry SelectedWorkDay
    {
        get => selectedWorkDay;
        set
        {
            SetProperty(ref selectedWorkDay, value);
        }
    }

    public DateTime SelectedMonth
    {
        get => selectedMonth;
        set
        {
            SetProperty(ref selectedMonth, value);
            GetWorkDaysOfMonthCommand.Execute(value);
        }
    }

    public ObservableCollection<DateTime> Dates
    {
        get => dates;
        set
        {
            SetProperty(ref dates, value);
        }
    }
}
