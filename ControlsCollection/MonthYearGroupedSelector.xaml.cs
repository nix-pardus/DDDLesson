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
    // ������ ������
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

    // ������� ��� ������ ������
    public event EventHandler<DateTime> MonthSelected;

    public MonthYearGroupedSelector()
    {
        this.InitializeComponent();
    }

    // �������� ��� ��������� ������ ���
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

        // ���������� ������
        var uniqueMonths = Dates
            .Select(d => new { Year = d.Year, Month = d.Month })
            .Distinct()
            .Select(x => new MonthItem { Year = x.Year, Month = x.Month });

        // ����������� �� ����
        var grouped = uniqueMonths
            .GroupBy(item => item.Year)
            .OrderByDescending(g => g.Key) // ����� ���� ������
            .Select(g => new YearGroup(g.OrderByDescending(m => m.Month).Cast<object>())
            {
                Key = g.Key
            });

        MonthsCVS.Source = new ObservableCollection<YearGroup>(grouped);
    }

    private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.AddedItems.Count > 0 && e.AddedItems[0] is MonthItem selectedMonth)
        {
            MonthSelected?.Invoke(this, selectedMonth.Date);
        }
    }

    private void ListView_ItemClick(object sender, ItemClickEventArgs e)
    {
        if (e.ClickedItem is MonthItem clickedMonth)
        {
            MonthSelected?.Invoke(this, clickedMonth.Date);
        }
    }
}
