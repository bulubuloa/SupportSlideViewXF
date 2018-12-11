using System;
using System.ComponentModel;
using SupportSlideViewXF.iOS.Renderers.Sliders;
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

        private int TempIndex = 0;

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

            }
            else if (e.PropertyName.Equals(SupportSlideBase.TintColorProperty.PropertyName))
            {

            }
            else if (e.PropertyName.Equals(SupportSlideBase.CurrentColorProperty.PropertyName))
            {

            }
            else if (e.PropertyName.Equals(SupportSlideBase.ShowArrowsProperty.PropertyName))
            {

            }
            else if (e.PropertyName.Equals(SupportSlideBase.IndicatorsPositionProperty.PropertyName))
            {

            }
            else if (e.PropertyName.Equals(SupportSlideBase.CurrentPageIndexProperty.PropertyName))
            {

            }
        }

       
        protected virtual void OnInitializeOriginalView( )
        {

        }

        void PagerViewController_DidFinishAnimating(object sender, UIPageViewFinishedAnimationEventArgs e)
        {
            if (e.Completed)
            {
                supportSlide.SendOnPageChanged(TempIndex);
            }
        }

        void PagerViewController_WillTransition(object sender, UIPageViewControllerTransitionEventArgs e)
        {
            if (e.PendingViewControllers != null && e.PendingViewControllers.Length > 0)
            {
                TempIndex = (e.PendingViewControllers[0] as BaseViewController).Index;
            }
        }

        protected virtual void OnSetNativeControl( )
        {
            slideMainViewController = (SlideMainViewController)slidersStoryboard.InstantiateViewController("SlideMainViewController");
            //slideMainViewController.ConfigStyle(supportSlide);


            slideMainViewController.GetPager().WillTransition += PagerViewController_WillTransition;
            slideMainViewController.GetPager().DidFinishAnimating += PagerViewController_DidFinishAnimating;


            slideMainViewController.View.ClipsToBounds = true;
            SetNativeControl(slideMainViewController.View);
        }
    }
}