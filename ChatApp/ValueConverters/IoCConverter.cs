using ChatApp.Core;
using ChatApp.Core.DataModels;
using ChatApp.ValueConverters;
using Ninject;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace ChatApp
{


    public class IoCConverter : BaseValueConverter<IoCConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((string) parameter)
            {
                case nameof(ApplicationViewModel):
                    return Container.Get<ApplicationViewModel>();

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
