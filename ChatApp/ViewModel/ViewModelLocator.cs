using ChatApp.Core;
using System.ComponentModel;

namespace ChatApp
{
    public class ViewModelLocator
    {

        public static ViewModelLocator Instance = new ViewModelLocator();
        public static ApplicationViewModel ApplicationViewModel => Core.Container.Application;
        public static SettingsViewModel SettingsViewModel => Core.Container.Settings;

    }
}
