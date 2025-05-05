using Microsoft.UI.Xaml.Data;
using System;
using System.Globalization;

namespace DDDLesson.WinUI3.Converters;

public class DecimalToStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if(value is decimal decimalValue)
        {
            string format = parameter as string ?? "G";
            return decimalValue.ToString(format, CultureInfo.CurrentCulture);
        }
        return string.Empty;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        if(value is string stringValue)
        {
            if (stringValue.Contains('.')) stringValue = stringValue.Replace('.', ',');
            if(decimal.TryParse(stringValue, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal result))
            {
                return result;
            }
        }
        return 0m;
    }
}
