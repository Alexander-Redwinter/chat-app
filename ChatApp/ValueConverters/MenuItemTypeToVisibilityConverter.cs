﻿using ChatApp.Core;
using ChatApp.ValueConverters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;

namespace ChatApp
{
    public class MenuItemTypeToVisibilityConverter : BaseValueConverter<MenuItemTypeToVisibilityConverter>
    {

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
                return Visibility.Collapsed;

            if (!Enum.TryParse(parameter as string, out MenuItemType type))
                return Visibility.Collapsed;

            return (MenuItemType)value == type ? Visibility.Visible : Visibility.Collapsed;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
