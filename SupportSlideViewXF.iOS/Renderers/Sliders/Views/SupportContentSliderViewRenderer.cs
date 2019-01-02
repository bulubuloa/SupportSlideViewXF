using System;
using System.ComponentModel;
using System.Linq;
using SupportSlideViewXF.iOS.Renderers.Sliders.Views;
using SupportSlideViewXF.Widgets;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(SupportContentSliderView), typeof(SupportContentSliderViewRenderer))]
namespace SupportSlideViewXF.iOS.Renderers.Sliders.Views
{
    public class SupportContentSliderViewRenderer : SupportSlideBaseRenderer<SupportContentSliderView>
    {
        protected override void OnSetNativeDataSource()
        {
            base.OnSetNativeDataSource();
            InitSource();
        }

        private void InitSource()
        {
            if (supportSlide.ViewItems != null)
            {
                slideMainViewController.ReInitializeViewsSlider(supportSlide.ViewItems.ToList());
            }
            else
            {
                slideMainViewController.ReInitializeViewsSlider(null);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName.Equals(SupportContentSliderView.ViewItemsProperty.PropertyName))
            {
                if (slideMainViewController != null)
                {
                    InitSource();
                }
            }
        }
    }
}
