using System.ComponentModel;
using SupportSlideViewXF.Widgets;
using UIKit;
using Xamarin.Forms.Platform.iOS;

namespace SupportSlideViewXF.iOS.Renderers
{
    public class SupportSlideBaseRenderer<TSupportSlide> : ViewRenderer<TSupportSlide,UIView>
        where TSupportSlide : SupportSlideBase
    {
        protected TSupportSlide supportSlide;
        protected UIView originalView;
        protected UIStoryboard slidersStoryboard;
        protected SlideMainViewController slideMainViewController;


        public SupportSlideBaseRenderer()
        {
            slidersStoryboard = UIStoryboard.FromName("Sliders", null);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<TSupportSlide> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null && e.NewElement is TSupportSlide)
            {
                supportSlide = e.NewElement as TSupportSlide;
                if (Control == null)
                {
                    OnInitializeOriginalView();
                    OnSetNativeControl();
                }
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName.Equals(SupportSlideBase.ShowIndicatorsProperty.PropertyName))
            {
                slideMainViewController.SetShowIndicator(supportSlide);
            }
            else if (e.PropertyName.Equals(SupportSlideBase.TintColorProperty.PropertyName))
            {
                slideMainViewController.SetTintColorIndicator(supportSlide.TintColor);
            }
            else if (e.PropertyName.Equals(SupportSlideBase.CurrentColorProperty.PropertyName))
            {
                slideMainViewController.SetCurrentColorIndicator(supportSlide.CurrentColor);
            }
            else if (e.PropertyName.Equals(SupportSlideBase.ShowArrowsProperty.PropertyName))
            {
                slideMainViewController.SetShowArrows(supportSlide.ShowArrows);
            }
            else if (e.PropertyName.Equals(SupportSlideBase.IndicatorsPositionProperty.PropertyName))
            {
                slideMainViewController.SetShowIndicator(supportSlide);
            }
            else if (e.PropertyName.Equals(SupportSlideBase.CurrentPageIndexProperty.PropertyName))
            {

            }
        }

        private void OnSetNativeControl()
        {
            slideMainViewController = (SlideMainViewController)slidersStoryboard.InstantiateViewController("SlideMainViewController");
            slideMainViewController.supportSlideBase = supportSlide;
            slideMainViewController.View.ClipsToBounds = true;
            OnSetNativeDataSource();
            SetNativeControl(slideMainViewController.View);
        }

        private void OnInitializeOriginalView( )
        {

        }

        protected virtual void OnSetNativeDataSource()
        {

        }
    }
}