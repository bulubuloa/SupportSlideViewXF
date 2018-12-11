using Foundation;
using SupportSlideViewXF.iOS.Renderers.Sliders;
using SupportSlideViewXF.Models;
using SupportSlideViewXF.Widgets;
using System;
using System.Collections.Generic;
using System.Linq;
using UIKit;
using Xamarin.Forms.Platform.iOS;

namespace SupportSlideViewXF.iOS
{
    public partial class SlideMainViewController : UIViewController
    {
        private SliderPageViewController pageViewController;
        private BaseSlideDataSource slideDataSource;
        private SlideMode slideMode;

        /*
         * PROPERTY FOR IMAGE MODE
         */
        private List<string> imageItems;



        /*
         * PROPERTY FOR VIEW MODE
         */
        //
        //
        //

        /*
         * PUBLIC FUNCTION 
         */
        public void ConfigStyle(SupportSlideBase supportSlide)
        {
            if (supportSlide != null)
            {
                pageControlBottom.Hidden = !supportSlide.ShowIndicators;
                BoxArrowLeft.Hidden = !supportSlide.ShowArrows;
                BoxArrowRight.Hidden = !supportSlide.ShowArrows;
                pageControlBottom.TintColor = supportSlide.TintColor.ToUIColor();
                pageControlBottom.CurrentPageIndicatorTintColor = supportSlide.CurrentColor.ToUIColor();
            }
        }

        private void SetIndicatorPage(int number)
        {
            pageControlBottom.Pages = number;
        }

        public UIPageViewController GetPager()
        {
            return pageViewController;
        }

        public SlideMainViewController (IntPtr handle) : base (handle)
        {
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);
            if (segue.Identifier == null)
            {
                Console.WriteLine("segue null");
            }
            else
            {
                if (segue.Identifier.Equals("SliderPageViewController_Segue"))
                {
                    pageViewController = segue.DestinationViewController as SliderPageViewController;
                }
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            BoxArrowLeft.ClipsToBounds = true;
            BoxArrowLeft.Layer.CornerRadius = BoxArrowLeft.Frame.Width / 2;

            BoxArrowRight.ClipsToBounds = true;
            BoxArrowRight.Layer.CornerRadius = BoxArrowRight.Frame.Width / 2;

            InitSource();
        }

        private void ClearInstance()
        {
            if (pageViewController != null)
            {
                var storyboard = UIStoryboard.FromName("Sliders", null);
                var loadingViewController = (LoadingViewController)storyboard.InstantiateViewController("LoadingViewController");
                pageViewController.SetViewControllers(new UIViewController[] { loadingViewController }, UIPageViewControllerNavigationDirection.Forward, false, null);
                pageViewController.DataSource = null;
            }

            slideDataSource = null;
            pageControlBottom.Pages = 0;
        }

        public void ReInitializeImageSlider(List<string> _imageItems)
        {
            imageItems = _imageItems;
            ClearInstance();
            InitSource();
        }

        private void InitializeImageSlider()
        {
            if(imageItems!=null&&imageItems.Count > 0)
            {
                var storyboard = UIStoryboard.FromName("Sliders", null);
                var controllerItems = new List<BaseViewController>();

                int max = imageItems.Count;
                SetIndicatorPage(max);

                for (int i = 0; i < max; i++)
                {
                    var item = imageItems[i];

                    var imageViewController = (ImageViewController)storyboard.InstantiateViewController("ImageViewController");
                    imageViewController.Index = i;
                    imageViewController.SetImage(item);

                    controllerItems.Add(imageViewController);
                }

                slideDataSource = new BaseSlideDataSource(controllerItems);
                pageViewController.DataSource = slideDataSource;
                pageViewController.SetViewControllers(new UIViewController[] { controllerItems[0] }, UIPageViewControllerNavigationDirection.Forward, false, null);
            }
            else
            {
                ClearInstance();
            }
        }

        private void InitSource()
        {
            if (pageViewController != null)
            {
                if(slideMode == SlideMode.Image)
                {
                    InitializeImageSlider();
                }
                else if(slideMode == SlideMode.View)
                {

                }
                else
                {
                    ClearInstance();
                }
            }
            else
            {
                ClearInstance();
            }
        }
    }
}