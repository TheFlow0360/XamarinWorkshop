using System;
using System.Globalization;
using Xamarin.Forms;

namespace QuizApp
{
    class QuestionDisplayToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is QuestionDisplayType display))
            {
                return null;
            }

            switch (display)
            {
                case QuestionDisplayType.Unanswered:
                    return Color.FromHex("2196F3");
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