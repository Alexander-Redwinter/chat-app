﻿using ChatApp.ValueConverters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;

namespace ChatApp
{
    public class BooleanToInvertConverter : BaseValueConverter<BooleanToInvertConverter>
    {

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) => !(bool)value;

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
