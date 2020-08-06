using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace ChatApp
{
    public class NoFrameHistoryAttachedProperty : BaseAttachedProperty<NoFrameHistoryAttachedProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var frame = (sender as Frame);
            frame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;

            frame.Navigated += (s, e) => ((Frame)s).NavigationService.RemoveBackEntry();
        }

    }
}
