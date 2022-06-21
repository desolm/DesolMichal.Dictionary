using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace DesolMichal.Dictionary.Core.Converters
{
    [ValueConversion(typeof(IEnumerable<string>), typeof(string))]
    public class StringsArrayToCommaSeparatedStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value is not null ? string.Join(", ", (IEnumerable<string>)value) : null;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotSupportedException();
    }
}
