using System;
using System.Collections.Generic;
using System.Diagnostics;
using UIKit;

namespace SupportSlideViewXF.iOS.Renderers.Sliders
{
    public class BaseSlideDataSource : UIPageViewControllerDataSource
    {
        public List<BaseViewController> baseViewControllers;

        public BaseSlideDataSource(List<BaseViewController> controllers)
        {
            baseViewControllers = controllers;
        }

        public override UIViewController GetNextViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
        {
            try
            {
                var currentPage = referenceViewController as ImageViewController;
                var index = currentPage.Index;
                if (index < baseViewControllers.Count - 1)
                {
                    index += 1;
                    return baseViewControllers[index];
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                return null;
            }
        }

        public override UIViewController GetPreviousViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
        {
            try
            {
                var currentPage = referenceViewController as ImageViewController;
                var index = currentPage.Index;
                if (index > 0)
                {
                    index -= 1;
                    return baseViewControllers[index];
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                return null;
            }
        }

        public override nint GetPresentationCount(UIPageViewController pageViewController)
        {
            return baseViewControllers.Count;
        }
    }
}