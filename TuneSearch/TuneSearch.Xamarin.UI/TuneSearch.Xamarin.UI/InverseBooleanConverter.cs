using System;
using System.Globalization;
using Xamarin.Forms;

namespace TuneSearch.Xamarin.UI
{
    class InverseBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Boolean b))
            {
                throw new ArgumentException();
            }

            return !b;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Boolean b))
            {
                throw new ArgumentException();
            }

            return !b;
        }
    }
}
