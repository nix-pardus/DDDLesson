using Microsoft.UI.Xaml.Data;
using System;
using System.Globalization;

namespace DDDLesson.WinUI3.Converters;

public class DateTimeToMonthTextConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if(value is DateTime date)
        {
            string monthName = new CultureInfo("ru-RU").DateTimeFormat.GetMonthName(date.Month);
            monthName = char.ToUpper(monthName[0]) + monthName.Substring(1);
            return $"{monthName} {date.Year}";
        }
        return string.Empty;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
