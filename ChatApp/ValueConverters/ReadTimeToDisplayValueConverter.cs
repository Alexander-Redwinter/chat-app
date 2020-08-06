using ChatApp.ValueConverters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;

namespace ChatApp
{
    public class ReadTimeToDisplayValueConverter : BaseValueConverter<ReadTimeToDisplayValueConverter>
    {

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var time = (DateTimeOffset)value;

            if (time == DateTimeOffset.MinValue)
                return String.Empty;

            if (time.Date == DateTimeOffset.UtcNow.Date)
                return $"Read {time.ToLocalTime().ToString("HH:mm")}";

            return $"Read {time.ToLocalTime().ToString("HH:mm, d MMM yyyy")}";
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
