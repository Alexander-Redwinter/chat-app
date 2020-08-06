using ChatApp.Animation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace ChatApp
{
    public static class PageAnimations
    {
        public static async Task SlideAndFadeFromBottom(this Page page, float seconds)
        {
            var sb = new Storyboard();

            sb.AddSlideFromBottom(seconds, page.WindowHeight);

            sb.Begin(page);

            page.Visibility = Visibility.Visible;

            await Task.Delay((int)(seconds * 1000));
        }

        public static async Task SlideAndFadeToTop(this Page page, float seconds)
        {
            var sb = new Storyboard();

            sb.AddSlideToTop(seconds, page.WindowHeight);

            sb.Begin(page);

            page.Visibility = Visibility.Visible;

            await Task.Delay((int)(seconds * 1000));
        }
    }
}
