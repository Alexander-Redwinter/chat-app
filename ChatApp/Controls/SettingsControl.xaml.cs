using System.ComponentModel;
using System.Windows.Controls;
using ChatApp.Core;

namespace ChatApp
{
    /// <summary>
    /// Interaction logic for SettingsControl.xaml
    /// </summary>
    public partial class SettingsControl : UserControl
    {
        public SettingsControl()
        {
            InitializeComponent();
            DataContext = Core.Container.Settings;
        }
    }
}
