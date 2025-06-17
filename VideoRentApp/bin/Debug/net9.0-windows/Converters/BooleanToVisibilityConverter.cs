using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace VideoRentApp.Converters
{
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class BooleanToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Converts a boolean value to a Visibility value.
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool booleanValue)
            {
                // Check for optional inversion parameter
                if (parameter != null && parameter.ToString().ToLower() == "invert")
                {
                    booleanValue = !booleanValue;
                }
                // If the boolean from the ViewModel is true, make the UI element Visible.
                // If it's false, make it Collapsed (hidden and takes up no space).
                return booleanValue ? Visibility.Visible : Visibility.Collapsed;
            }

            // Default to collapsed if the value is not a boolean.
            return Visibility.Collapsed;
        }

        /// <summary>
        /// Converts a Visibility value back to a boolean. This is not needed for this scenario.
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // The ConvertBack method is not required for this converter,
            // so we leave it unimplemented.
            throw new NotImplementedException();
        }
    }
}
