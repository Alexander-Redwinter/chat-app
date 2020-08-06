using ChatApp.Controls.Menus;
using ChatApp.Core;
using ChatApp.ValueConverters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;

namespace ChatApp
{
    /// <summary>
    /// Converter on input <see cref="BaseViewModel"/>and returns specific control
    /// </summary>
    public class PopupContentConverter : BaseValueConverter<PopupContentConverter>
    {

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value is AttachmentMenuViewModel basePopup) 
                return new VerticalMenu { DataContext = basePopup.Content};

            return null;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
