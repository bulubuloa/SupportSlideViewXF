using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SupportSlideViewXF.Widgets
{
    public class SupportContentSliderView : SupportSlideBase
    {
        /*
         * PUBLIC PROPERTY
         * 
         */
        public static readonly BindableProperty ViewItemsProperty = BindableProperty.Create("ViewItems", typeof(IEnumerable<View>), typeof(SupportContentSliderView), null);
        public IEnumerable<View> ViewItems
        {
            get { return (IEnumerable<View>)GetValue(ViewItemsProperty); }
            set { SetValue(ViewItemsProperty, value); }
        }

        public SupportContentSliderView()
        {
            SlideMode = Models.SlideMode.View;
        }
    }
}
