using ChatApp.ValueConverters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;

namespace ChatApp
{
    public class HorizontalAlignmentConverter : BaseValueConverter<HorizontalAlignmentConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (HorizontalAlignment)value;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
