using System;
using System.Collections;
using Xamarin.Forms;

namespace SupportSlideViewXF.Widgets
{
    public class SupportSlideView : View
    {
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create("ItemsSource", typeof(IEnumerable), typeof(SupportSlideView), null);
        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public SupportSlideView()
        {
        }
    }
}
