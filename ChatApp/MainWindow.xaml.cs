using System.Windows;

namespace ChatApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            DataContext = new WindowViewModel(this);
        }

        private void AppWindow_Deactivated(object sender, System.EventArgs e)
        {
            (DataContext as WindowViewModel).DimmableOverlayVisible = true;
        }

        private void AppWindow_Activated(object sender, System.EventArgs e)
        {
            (DataContext as WindowViewModel).DimmableOverlayVisible = false;

        }
    }
}
