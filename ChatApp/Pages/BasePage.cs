using ChatApp.Animation;
using ChatApp.Core;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace ChatApp
{

    public class BasePage : UserControl
    {
        PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeFromBottom;
        PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeToTop;

        public bool ShouldAnimateOut;
        public float SlideSeconds { get; set; } = 0.5f;

        private object viewModelObject;
        public object ViewModelObject
        {
            get
            {
                return viewModelObject;
            }
            set
            {
                if (viewModelObject == value)
                    return;

                viewModelObject = value;

                OnViewModelChanged();

                DataContext = viewModelObject;
            }
        }

        public BasePage()
        {
            if (PageLoadAnimation != PageAnimation.None)
                Visibility = Visibility.Collapsed;

            Loaded += BasePage_Loaded;
        }

        private async void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
            if (ShouldAnimateOut)
                await AnimateOutAsync();
            else
                await AnimateInAsync();
        }

        public async Task AnimateInAsync()
        {
            // Make sure we have something to do
            if (PageLoadAnimation == PageAnimation.None)
                return;

            switch (PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeFromBottom:

                    // Start the animation
                    await this.SlideAndFadeInAsync(AnimationSlideInDirection.Bottom, false, SlideSeconds, size: (int)Application.Current.MainWindow.Width);

                    break;
            }
        }

        public async Task AnimateOutAsync()
        {
            if (this.PageUnloadAnimation == PageAnimation.None) return;

            switch (this.PageUnloadAnimation)
            {
                case PageAnimation.SlideAndFadeToTop:

                    await this.SlideAndFadeOutAsync(AnimationSlideInDirection.Top, SlideSeconds);

                    break;
            }
        }

        protected virtual void OnViewModelChanged()
        {

        }
    }


    public class BasePage<VM> : BasePage
        where VM : BaseViewModel, new()
    {

        public VM ViewModel
        {
            get => (VM)ViewModelObject;
            set => ViewModelObject = value;
        }

        public BasePage() : base()
        {
            ViewModel = Container.Get<VM>();
        }

        public BasePage(VM specificViewModel = null) : base()
        {
            if (specificViewModel != null)
                ViewModel = specificViewModel;
            else
                ViewModel = Container.Get<VM>();
        }


    }
}
