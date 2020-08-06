using ChatApp.ValueConverters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;

namespace ChatApp
{
    public class SentByUserToBackgroundConverter : BaseValueConverter<SentByUserToBackgroundConverter>
    {

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Application.Current.FindResource("BackgroundLightBrush") : Application.Current.FindResource("BackgroundLighterBrush");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
