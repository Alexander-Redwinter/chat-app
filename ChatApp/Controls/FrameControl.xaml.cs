using ChatApp.Core;
using ChatApp.Core.DataModels;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ChatApp
{
    /// <summary>
    /// Interaction logic for FrameControl.xaml
    /// </summary>
    public partial class FrameControl : UserControl
    {
        public ApplicationPage CurrentPage
        {
            get => (ApplicationPage)GetValue(CurrentPageProperty);
            set => SetValue(CurrentPageProperty, value); 
        }

        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register(nameof(CurrentPage), typeof(ApplicationPage), typeof(FrameControl), new UIPropertyMetadata(default(ApplicationPage), null,CurrentPagePropertyChanged));

        public BaseViewModel CurrentPageViewModel
        {
            get => (BaseViewModel)GetValue(CurrentPageViewModelProperty);
            set => SetValue(CurrentPageViewModelProperty, value);
        }

        public static readonly DependencyProperty CurrentPageViewModelProperty =
            DependencyProperty.Register(nameof(CurrentPageViewModel), typeof(BaseViewModel), typeof(FrameControl), new UIPropertyMetadata());

        public FrameControl()
        {
            InitializeComponent();
        }

        private static object CurrentPagePropertyChanged(DependencyObject d, object value)
        {

            var currentPage = (ApplicationPage)d.GetValue(CurrentPageProperty);
            var currentPageViewModel = d.GetValue(CurrentPageViewModelProperty);
            
            var newPage = (d as FrameControl).NewPage;
            var oldPage = (d as FrameControl).OldPage;

            //if current page doesn't change just update the ViewModel
            if (newPage.Content is BasePage p && p.ToApplicationPage() == currentPage)
            {
                // Just update the view model
                p.ViewModelObject = currentPageViewModel;

                return value;
            }

            var oldPageContent = newPage.Content;

            newPage.Content = null;

            oldPage.Content = oldPageContent;

            if (oldPageContent is BasePage page)
            {
                page.ShouldAnimateOut = true;

                Task.Delay((int)(page.SlideSeconds * 1000)).ContinueWith((t) =>
                {
                    Application.Current.Dispatcher.Invoke(() => page.Content = null);
                }
                );


            }

            newPage.Content = Container.Application.CurrentPage.ToBasePage();

            return value;
        }
    }
}
