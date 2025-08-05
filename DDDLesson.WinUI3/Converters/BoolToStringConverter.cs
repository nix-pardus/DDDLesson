using Microsoft.UI.Xaml.Data;
using System;

namespace DDDLesson.WinUI3.Converters;

public class BoolToStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        string result = (bool)value == true ? "Да" : "Нет";
        return result;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        return null;
    }
}
