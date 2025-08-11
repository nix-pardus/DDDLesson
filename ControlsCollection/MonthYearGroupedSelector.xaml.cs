using Microsoft.UI.Xaml.Controls;
using System.Collections.Generic;
using System.Globalization;
using System;
using Microsoft.UI.Xaml;
using System.Collections.ObjectModel;
using System.Linq;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ControlsCollection;

public sealed partial class MonthYearGroupedSelector : UserControl
{
    public DateTime? SelectedMonth
    {
        get => (DateTime?)GetValue(SelectedMonthProperty);
        set
        {
            SetValue(SelectedMonthProperty, value);
        }
    }

    public static readonly DependencyProperty SelectedMonthProperty =
        DependencyProperty.Register(
            nameof(SelectedMonth),
            typeof(DateTime?),
            typeof(MonthYearGroupedSelector),
            new PropertyMetadata(null, OnSelectedMonthChanged));

    private static void OnSelectedMonthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var control = d as MonthYearGroupedSelector;
        control?.UpdateSelection();
    }

    private void UpdateSelection()
    {
        if (SelectedMonth == null)
        {
            listView.SelectedItem = null;
            return;
        }

        foreach(YearGroup group in MonthsCVS.Source as ObservableCollection<YearGroup> ?? new())
        {
            foreach(MonthItem item in group.OfType<MonthItem>())
            {
                if(item.Year == SelectedMonth.Value.Year && item.Month == SelectedMonth.Value.Month)
                {
                    listView.SelectedItem = item;
                    return;
                }
            }
        }
        listView.SelectedItem = null;
    }

    //  лассы данных
    public class MonthItem
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public string MonthName => DateTimeFormatInfo.CurrentInfo.GetMonthName(Month);
        public DateTime Date => new DateTime(Year, Month, 1);
    }

    public class YearGroup : List<object>
    {
        public object Key { get; set; }
        public YearGroup(IEnumerable<object> items) : base(items) { }
    }

    // —обытие дл€ выбора мес€ца
    public event EventHandler<DateTime> MonthSelected;

    public MonthYearGroupedSelector()
    {
        this.InitializeComponent();
    }

    // —войство дл€ установки списка дат
    public IEnumerable<DateTime> Dates
    {
        get { return (IEnumerable<DateTime>)GetValue(DatesProperty); }
        set { SetValue(DatesProperty, value); }
    }

    public static readonly DependencyProperty DatesProperty =
            DependencyProperty.Register(
                nameof(Dates),
                typeof(IEnumerable<DateTime>),
                typeof(MonthYearGroupedSelector),
                new PropertyMetadata(null, OnDatesChanged));

    private static void OnDatesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var control = d as MonthYearGroupedSelector;
        if (control != null)
        {
            control.ProcessDates();
        }
    }

    private void ProcessDates()
    {
        if (Dates == null) return;

        // ”никальные мес€цы
        var uniqueMonths = Dates
            .Select(d => new { Year = d.Year, Month = d.Month })
            .Distinct()
            .Select(x => new MonthItem { Year = x.Year, Month = x.Month });

        // √руппировка по году
        var grouped = uniqueMonths
            .GroupBy(item => item.Year)
            .OrderByDescending(g => g.Key) // Ќовые года сверху
            .Select(g => new YearGroup(g.OrderByDescending(m => m.Month).Cast<object>())
            {
                Key = g.Key
            });

        MonthsCVS.Source = new ObservableCollection<YearGroup>(grouped);
        UpdateSelection();
    }

    private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.AddedItems.Count > 0 && e.AddedItems[0] is MonthItem selectedMonth)
        {
            SetValue(SelectedMonthProperty, selectedMonth.Date);
            MonthSelected?.Invoke(this, selectedMonth.Date);
        }
        else if(e.RemovedItems.Count > 0)
        {
            SetValue(SelectedMonthProperty, null);
        }
    }
}
