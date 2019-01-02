using System;
using System.ComponentModel;
using SupportSlideViewXF.iOS.Renderers.Sliders;
using SupportSlideViewXF.Widgets;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using SupportSlideViewXF.Models;
using System.Collections.Generic;
using System.Diagnostics;

[assembly: ExportRenderer(typeof(SupportSlideView), typeof(SupportSlideViewRenderer))]
namespace SupportSlideViewXF.iOS.Renderers.Sliders
{
    public class SupportSlideViewRenderer : ViewRenderer<SupportSlideView, UIView>
    {
        protected UIPageViewController pageController;
        protected UIPageControl pageControl;
        protected SupportSlideView supportSlideView;
        protected BaseSlideDataSource baseSlideData;

        public SupportSlideViewRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SupportSlideView> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null && e.NewElement is SupportSlideView)
            {
                supportSlideView = e.NewElement as SupportSlideView;

                if (Control == null)
                {
                    OnSetNativeControl();
                }
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName.Equals(SupportSlideView.ItemsSourceProperty.PropertyName))
            {
                if (pageController != null)
                {
                    InitSource();
                }
            }
        }

        protected void OnSetNativeControl()
        {
            pageController = new UIPageViewController(UIPageViewControllerTransitionStyle.Scroll, UIPageViewControllerNavigationOrientation.Horizontal, UIPageViewControllerSpineLocation.None,0f);
            pageController.View.ClipsToBounds = true;
            pageController.WillTransition += PageController_WillTransition;
            pageController.DidFinishAnimating += PageController_DidFinishAnimating;
            SetNativeControl(pageController.View);
        }

        private void EnablePager(bool IsEnable)
        {
            if(pageController.ViewControllers!=null)
            {
                foreach (var item in pageController.ViewControllers)
                {
                    item.View.UserInteractionEnabled = IsEnable;
                }
            }
        }

        void PageController_DidFinishAnimating(object sender, UIPageViewFinishedAnimationEventArgs e)
        {
            if(e.Finished)
            {
                EnablePager(true);
            }
        }

        void PageController_WillTransition(object sender, UIPageViewControllerTransitionEventArgs e)
        {
            EnablePager(false);
        }

        private void InitSource()
        {
            if (supportSlideView.ItemsSource != null)
            {
                var viewItems = supportSlideView.ItemsSource.GetList();
                int max = viewItems.Count;

                var controllers = new List<BaseViewController>();

                for (int i = 0; i < max; i++)
                {
                    var item = viewItems[i] as View;
                    item.Parent = this.Element;

                    var bounds = Element.Bounds;
                    var size = new CoreGraphics.CGRect(bounds.X, bounds.Y, bounds.Width, bounds.Height);


                    if (Platform.GetRenderer(item) == null)
                        Platform.SetRenderer(item, Platform.CreateRenderer(item));

                    var vRenderer = Platform.GetRenderer(item);
                    vRenderer.NativeView.Frame = size;
                    vRenderer.NativeView.AutoresizingMask = UIViewAutoresizing.All;
                    vRenderer.NativeView.ContentMode = UIViewContentMode.ScaleToFill;
                    vRenderer.Element?.Layout(size.ToRectangle());
                    var nativeView = vRenderer.NativeView;
                    nativeView.SetNeedsLayout();

                    var controller = new BaseViewController();
                    controller.View = nativeView;
                    controller.Index = i;
                    controller.View.UserInteractionEnabled = false;

                    controllers.Add(controller);

                    baseSlideData = new BaseSlideDataSource(controllers);
                    pageController.DataSource = baseSlideData;
                    pageController.SetViewControllers(new UIViewController[] { controllers[0] }, UIPageViewControllerNavigationDirection.Forward, false, null);

                }
            }
            else
            {

            }
        }

    }
}
