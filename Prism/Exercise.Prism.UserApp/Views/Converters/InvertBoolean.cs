using System;
using System.Globalization;
using System.Windows.Data;

namespace Exercise.Prism.User.Views.Converters
{
    public class InvertBoolean : IValueConverter
    {
        public object Convert(object a_value, Type a_targetType, object a_parameter, CultureInfo a_culture)
        {
            return a_value != null && !(bool)a_value;
        }

        public object ConvertBack(object a_value, Type a_targetType, object a_parameter, CultureInfo a_culture)
        {
            return null;
        }
    }
}
