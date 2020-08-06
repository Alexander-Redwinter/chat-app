using ChatApp.ValueConverters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Media;

namespace ChatApp
{
    public class StringHexRgbToBrushConverter : BaseValueConverter<StringHexRgbToBrushConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (SolidColorBrush) new BrushConverter().ConvertFrom($"#{value}");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
