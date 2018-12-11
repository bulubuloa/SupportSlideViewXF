using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SupportSlideViewXF.Widgets
{
    public class SupportImageSliderView : SupportSlideBase
    {
        /*
         * PUBLIC PROPERTY
         * 
         */        
        public static readonly BindableProperty ImageItemsProperty = BindableProperty.Create("ImageItems", typeof(IEnumerable<string>), typeof(SupportImageSliderView), null);
        public IEnumerable<string> ImageItems
        {
            get { return (IEnumerable<string>)GetValue(ImageItemsProperty); }
            set { SetValue(ImageItemsProperty, value); }
        }

        public static readonly BindableProperty ShowFullScreenProperty = BindableProperty.Create("ShowFullScreen", typeof(bool), typeof(SupportImageSliderView), false);
        public bool ShowFullScreen
        {
            get { return (bool)GetValue(ShowFullScreenProperty); }
            set { SetValue(ShowFullScreenProperty, value); }
        }

        public static readonly BindableProperty ShowBlankLoadingProperty = BindableProperty.Create("ShowBlankLoading", typeof(bool), typeof(SupportImageSliderView), true);
        public bool ShowBlankLoading
        {
            get { return (bool)GetValue(ShowBlankLoadingProperty); }
            set { SetValue(ShowBlankLoadingProperty, value); }
        }
    }
}