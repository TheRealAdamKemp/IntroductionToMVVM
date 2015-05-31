using System;
using System.Globalization;
using Xamarin.Forms;

namespace MvvmExample
{
    public class BooleanToTConverter<T> : IValueConverter
    {
        public T TrueValue { get; set; }

        public T FalseValue { get; set; }

        public object Convert (object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? TrueValue : FalseValue;
        }

        public object ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
        {
            return object.Equals((T)value, TrueValue);
        }
    }
}

