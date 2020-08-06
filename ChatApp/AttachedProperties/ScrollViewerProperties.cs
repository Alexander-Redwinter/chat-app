using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace ChatApp
{
    public class ScrollToBottomOnLoadProperty : BaseAttachedProperty<ScrollToBottomOnLoadProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (!(sender is ScrollViewer control))
                return;

            control.DataContextChanged -= Control_DataContextChanged;
            control.DataContextChanged += Control_DataContextChanged;

        }

        private void Control_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            (sender as ScrollViewer).ScrollToBottom();
        }
    }

    public class AutoScrollToBottomProperty : BaseAttachedProperty<AutoScrollToBottomProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (!(sender is ScrollViewer control))
                return;

            control.ScrollChanged -= Control_ScrollChanged;
            control.ScrollChanged += Control_ScrollChanged;

        }

        private void Control_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            var scroll = sender as ScrollViewer;

            if (scroll.ScrollableHeight - scroll.VerticalOffset < 20)
                scroll.ScrollToEnd();
        }
    }
}
