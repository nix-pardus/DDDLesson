using Microsoft.UI.Xaml.Data;
using System;

namespace DDDLesson.WinUI3.Converters;

public class DecimalToDoubleConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        var result = value is decimal decimalValue ? System.Convert.ToDouble(decimalValue) : 0.0;
        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        var result =  value is string doubleValue ? System.Convert.ToDecimal(doubleValue) : 0m;
        return result;
    }
}
