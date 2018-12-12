using Foundation;
using SupportSlideViewXF.iOS.Renderers.Sliders;
using SupportSlideViewXF.Models;
using SupportSlideViewXF.Widgets;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace SupportSlideViewXF.iOS
{
    public partial class SlideMainViewController : UIViewController
    {
        public SupportSlideBase supportSlideBase;

        private SliderPageViewController pageViewController;
        private List<BaseViewController> baseViewControllers;
        private BaseSlideDataSource slideDataSource;
        private int TempIndex = 0, CurrentIndex = 0;
        /*
         * PROPERTY FOR IMAGE MODE
         */
        private List<string> imageItems;


        /*
         * PROPERTY FOR VIEW MODE
         */

       
        public SlideMainViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            BoxArrowLeft.ClipsToBounds = true;
            BoxArrowLeft.Layer.CornerRadius = BoxArrowLeft.Frame.Width / 2;

            BoxArrowRight.ClipsToBounds = true;
            BoxArrowRight.Layer.CornerRadius = BoxArrowRight.Frame.Width / 2;

            BoxArrowLeft.Layer.MasksToBounds = false;
            BoxArrowLeft.Layer.ShadowRadius = 5;
            BoxArrowLeft.Layer.ShadowColor = UIColor.Gray.CGColor;
            BoxArrowLeft.Layer.ShadowOpacity = 0.2f;
            BoxArrowLeft.Layer.ShadowOffset = new SizeF();

            BoxArrowRight.Layer.MasksToBounds = false;
            BoxArrowRight.Layer.ShadowRadius = 5;
            BoxArrowRight.Layer.ShadowColor = UIColor.Gray.CGColor;
            BoxArrowRight.Layer.ShadowOpacity = 0.2f;
            BoxArrowRight.Layer.ShadowOffset = new SizeF();

            UITapGestureRecognizer tapNext = new UITapGestureRecognizer(()=> {
                try
                {
                    if(CurrentIndex < baseViewControllers.Count-1)
                    {
                        CurrentIndex += 1;
                        pageViewController.SetViewControllers(new UIViewController[] { baseViewControllers[CurrentIndex] }, UIPageViewControllerNavigationDirection.Forward, true, null);
                        SetCurrentIndicatorPage(CurrentIndex);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.StackTrace);
                }
            });
            tapNext.NumberOfTapsRequired = 1;
            BoxArrowRight.UserInteractionEnabled = true;
            BoxArrowRight.AddGestureRecognizer(tapNext);

            UITapGestureRecognizer tapPrevious = new UITapGestureRecognizer(() => {
                try
                {
                    if (CurrentIndex > 0)
                    {
                        CurrentIndex -= 1;
                        pageViewController.SetViewControllers(new UIViewController[] { baseViewControllers[CurrentIndex] }, UIPageViewControllerNavigationDirection.Reverse, true, null);
                        SetCurrentIndicatorPage(CurrentIndex);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.StackTrace);
                }
            });
            tapPrevious.NumberOfTapsRequired = 1;
            BoxArrowLeft.UserInteractionEnabled = true;
            BoxArrowLeft.AddGestureRecognizer(tapPrevious);

            ConfigStyle();
            InitSource();
        }

        /*
         * PageViewController
         */
        #region PREPARE FOR PageViewController
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
                    pageViewController.WillTransition += PageViewController_WillTransition;
                    pageViewController.DidFinishAnimating += PageViewController_DidFinishAnimating;
                }
            }
        }

        void PageViewController_DidFinishAnimating(object sender, UIPageViewFinishedAnimationEventArgs e)
        {
            if (e.Completed)
            {
                CurrentIndex = TempIndex;
                SetCurrentIndicatorPage(CurrentIndex);
                supportSlideBase.SendOnPageChanged(CurrentIndex);
            }
        }

        void PageViewController_WillTransition(object sender, UIPageViewControllerTransitionEventArgs e)
        {
            if (e.PendingViewControllers != null && e.PendingViewControllers.Length > 0)
            {
                TempIndex = (e.PendingViewControllers[0] as BaseViewController).Index;
            }
        }
        #endregion


        /*
         * PUBLIC FUNCTION 
         */
        #region public function
        public void ReInitializeImageSlider(List<string> _imageItems)
        {
            imageItems = _imageItems;
            ClearInstance();
            InitSource();
        }

        public void SetShowIndicator(SupportSlideBase supportSlide)
        {
            if(supportSlide.IndicatorsPosition == IndicatorPosition.Top)
            {
                pageControlBottom.Hidden = true;
                pageControlTop.Hidden = !supportSlide.ShowIndicators;
            }
            else if (supportSlide.IndicatorsPosition == IndicatorPosition.Bottom)
            {
                pageControlTop.Hidden = true;
                pageControlBottom.Hidden = !supportSlide.ShowIndicators;
            }
            else
            {
                pageControlBottom.Hidden = false;
                pageControlTop.Hidden = false;
            }
        }

        public void SetTintColorIndicator(Color color)
        {
            pageControlBottom.TintColor = color.ToUIColor();
            pageControlTop.TintColor = color.ToUIColor();
        }

        public void SetCurrentColorIndicator(Color color)
        {
            pageControlBottom.CurrentPageIndicatorTintColor = color.ToUIColor();
            pageControlTop.CurrentPageIndicatorTintColor = color.ToUIColor();
        }

        public void SetShowArrows(bool IsShow)
        {
            BoxArrowLeft.Hidden = !IsShow;
            BoxArrowRight.Hidden = !IsShow;
        }

        public void SetFullScreen(bool IsShow)
        {
            imgFullScreen.Hidden = !IsShow;
        }

        public void SetBlankLoading(bool IsShow)
        {
           
        }
        #endregion


        /*
         * PRIVATE FUNCTION
         */
        #region private function
        private void ConfigStyle()
        {
            if (supportSlideBase != null)
            {
                SetShowIndicator(supportSlideBase);
                SetShowArrows(supportSlideBase.ShowArrows);
                SetTintColorIndicator(supportSlideBase.TintColor);
                SetCurrentColorIndicator(supportSlideBase.CurrentColor);

                if(supportSlideBase is SupportImageSliderView)
                {
                    var configImageSlider = supportSlideBase as SupportImageSliderView;
                    SetFullScreen(configImageSlider.ShowFullScreen);
                    SetBlankLoading(configImageSlider.ShowBlankLoading);
                }
            }
        }

        private void SetIndicatorPage(int number)
        {
            pageControlBottom.Pages = number;
            pageControlTop.Pages = number;
        }

        private void SetCurrentIndicatorPage(int currentIndex)
        {
            pageControlBottom.CurrentPage = currentIndex;
            pageControlTop.CurrentPage = currentIndex;
        }


        #endregion


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


        private void InitializeImageSlider()
        {
            if(imageItems!=null&&imageItems.Count > 0)
            {
                var storyboard = UIStoryboard.FromName("Sliders", null);
                baseViewControllers = new List<BaseViewController>();
                var aspect = (supportSlideBase as SupportImageSliderView).AspectType;

                int max = imageItems.Count;
                SetIndicatorPage(max);

                for (int i = 0; i < max; i++)
                {
                    var item = imageItems[i];

                    var imageViewController = (ImageViewController)storyboard.InstantiateViewController("ImageViewController");
                    imageViewController.Index = i;
                    imageViewController.SetImage(item, aspect);

                    baseViewControllers.Add(imageViewController);
                }

                slideDataSource = new BaseSlideDataSource(baseViewControllers);
                pageViewController.DataSource = slideDataSource;
                pageViewController.SetViewControllers(new UIViewController[] { baseViewControllers[0] }, UIPageViewControllerNavigationDirection.Forward, false, null);
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
                if(supportSlideBase.SlideMode == SlideMode.Image)
                {
                    InitializeImageSlider();
                }
                else if(supportSlideBase.SlideMode == SlideMode.View)
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