using System.Globalization;

namespace OOP.Converters
{
    internal class LengthToSubstringConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            string text = (string)value;
            if (text.Length > 130)
                return text[..130];

            return text;
        }
        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
