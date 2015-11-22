using System;
using System.Globalization;
using System.Windows.Data;

namespace LanguageResource
{
    /// <summary>
    /// Provides a boolean value based upon if the given culture name is equal to the CurrentUICulture english name.
    /// </summary>
    public class CurrentCulture : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string languageName = (string)value;
            return CultureInfo.CurrentUICulture.EnglishName.Contains(languageName);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return string.Empty;
        }
    }
}
