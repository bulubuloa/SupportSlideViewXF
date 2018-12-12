using System;
using System.ComponentModel;
using System.Linq;
using SupportSlideViewXF.iOS.Renderers;
using SupportSlideViewXF.Widgets;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(SupportImageSliderView), typeof(SupportImageSliderViewRenderer))]
namespace SupportSlideViewXF.iOS.Renderers
{
    public class SupportImageSliderViewRenderer : SupportSlideBaseRenderer<SupportImageSliderView>
    {
        protected override void OnSetNativeDataSource()
        {
            base.OnSetNativeDataSource();
            InitSource();
        }

        private void InitSource()
        {
            if (supportSlide.ImageItems != null)
            {
                slideMainViewController.ReInitializeImageSlider(supportSlide.ImageItems.ToList());
            }
            else
            {
                slideMainViewController.ReInitializeImageSlider(null);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName.Equals(SupportImageSliderView.ImageItemsProperty.PropertyName))
            {
                if (slideMainViewController != null)
                {
                    InitSource();
                }
            }
            else if (e.PropertyName.Equals(SupportImageSliderView.ShowFullScreenProperty.PropertyName))
            {
                if (slideMainViewController != null)
                {
                    slideMainViewController.SetFullScreen(supportSlide.ShowFullScreen);
                }
            }
            else if (e.PropertyName.Equals(SupportImageSliderView.ShowBlankLoadingProperty.PropertyName))
            {
                if (slideMainViewController != null)
                {
                    slideMainViewController.SetBlankLoading(supportSlide.ShowBlankLoading);
                }
            }
            else if (e.PropertyName.Equals(SupportImageSliderView.AspectTypeProperty.PropertyName))
            {
                if (slideMainViewController != null)
                {

                }
            }
        }
    }
}