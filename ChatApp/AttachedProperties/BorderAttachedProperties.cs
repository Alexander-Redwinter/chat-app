using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ChatApp
{
    public class ClipFromBorderProperty : BaseAttachedProperty<ClipFromBorderProperty, bool>
    {

        private RoutedEventHandler border_Loaded;
        private SizeChangedEventHandler border_SizeChanged;

        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var self = sender as FrameworkElement;

            if (!(self.Parent is Border border))
            {
                Debugger.Break();
                return;
            }

            border_Loaded = (ss, ee) => Border_OnChange(ss, ee, self);

            border_SizeChanged = (ss, ee) => Border_OnChange(ss, ee, self);


            if ((bool)e.NewValue)
            {
                border.Loaded += border_Loaded;
                border.SizeChanged += border_SizeChanged;
            }
            else
            {
                border.Loaded -= border_Loaded; 
                border.SizeChanged -= border_SizeChanged;
            }

        }
        private void Border_OnChange(object sender, RoutedEventArgs e, FrameworkElement child)
        {

            var border = (Border)sender;

            if (border.ActualWidth == 0 && border.ActualHeight == 0)
                return;

            var rect = new RectangleGeometry();

            //match the corner radius with border's corner radius
            rect.RadiusX = rect.RadiusY = Math.Max(0, border.CornerRadius.TopLeft - (border.BorderThickness.Left * 0.5));

            rect.Rect = new Rect(child.RenderSize);

            child.Clip = rect;

        }
    }
}
