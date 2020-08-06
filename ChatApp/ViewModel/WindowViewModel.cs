using ChatApp.Core;
using System.Windows;
using System.Windows.Input;

namespace ChatApp
{
    public class WindowViewModel : BaseViewModel
    {


        private readonly Window window;
        public ICommand MinimizeCommand { get; set; }
        public ICommand MaximizeCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand MenuCommand { get; set; }

        private int TitleHeight { get; set; } = 40;
        private int outerMargineSize = 10;
        private int windowRadius = 10;
        private WindowDockPosition dockPosition = WindowDockPosition.Undocked;
        public int WindowMinimumWidth { get; set; } = 800;
        public int WindowMinimumHeight { get; set; } = 570;

        public bool DimmableOverlayVisible { get; set; }

        public int ResizeBorder { get { return Borderless ? 0 : 6; } }
        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize); } }

        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight + ResizeBorder); } }

        public bool Borderless { get { return (window.WindowState == WindowState.Maximized || dockPosition != WindowDockPosition.Undocked); } }
        public int OuterMarginSize
        {
            get { return Borderless ? 0 : outerMargineSize; }
            set { outerMargineSize = value; }
        }
        public Thickness OuterMarginSizeThickness { get { return new Thickness(ResizeBorder); } }
        public int WindowRadius
        {
            get { return Borderless ? 0 : windowRadius; }

            set { windowRadius = value; }
        }
        public CornerRadius WindowCornerRadius { get { return new CornerRadius(windowRadius); } }

        public WindowViewModel(Window window)
        {
            this.window = window;

            window.StateChanged += (sender, e) =>
            {
                OnPropertyChanged(nameof(Borderless));
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));

            };

            MinimizeCommand = new RelayCommand(() => 
            {
                window.WindowState = WindowState.Minimized;
                //prevent app from dissapearing from taskbar
                window.ShowInTaskbar = true;
            });
            MaximizeCommand = new RelayCommand(() => 
            {
                window.WindowState ^= WindowState.Maximized;

            });


            CloseCommand = new RelayCommand(() => window.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(window, GetMousePosition()));


        }


        private Point GetMousePosition()
        {
            // Position of the mouse relative to the window
            var position = Mouse.GetPosition(window);

            // Add the window position so its a "ToScreen"
            return new Point(position.X + window.Left, position.Y + window.Top);
        }

    }
}
