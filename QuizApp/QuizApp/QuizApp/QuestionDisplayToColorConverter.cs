using System;
using System.Globalization;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace QuizApp
{
    class QuestionDisplayToColorConverter : IValueConverter
    {
        public QuestionDisplayToColorConverter()
        {
            switch (AppInfo.RequestedTheme)
            {
                case AppTheme.Unspecified:
                case AppTheme.Light:
                    DefaultColor = Color.FromHex("2196F3");
                    break;
                case AppTheme.Dark:
                    DefaultColor = Color.FromHex("064174");
                    break;
            }
        }

        private Color DefaultColor { get; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is QuestionDisplayType display))
            {
                return null;
            }

            switch (display)
            {
                case QuestionDisplayType.Unanswered:
                    return DefaultColor;
                case QuestionDisplayType.Correct:
                    return Color.Green;
                case QuestionDisplayType.Incorrect:
                    return Color.Crimson;
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}