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
        public SupportImageSliderViewRenderer()
        {
        }

        protected override void OnInitializeOriginalView( )
        {
            base.OnInitializeOriginalView();
        }

        protected override void OnSetNativeControl( )
        {
            base.OnSetNativeControl();
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

            }
            else if (e.PropertyName.Equals(SupportImageSliderView.ShowBlankLoadingProperty.PropertyName))
            {

            }
        }
    }
}