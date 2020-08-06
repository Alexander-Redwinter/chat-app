using ChatApp.ValueConverters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;

namespace ChatApp
{
    public class SentByUserToAlignmentConverter : BaseValueConverter<SentByUserToAlignmentConverter>
    {

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
                return (bool)value ? HorizontalAlignment.Right : HorizontalAlignment.Left;
            else
                return (bool)value ? HorizontalAlignment.Left : HorizontalAlignment.Right;

        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
