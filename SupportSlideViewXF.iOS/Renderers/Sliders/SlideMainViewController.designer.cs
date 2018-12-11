// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace SupportSlideViewXF.iOS
{
    [Register ("SlideMainViewController")]
    partial class SlideMainViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView BoxArrowLeft { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView BoxArrowRight { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView containerView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imageArrowLeft { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imageArrowRight { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgFullScreen { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPageControl pageControlBottom { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (BoxArrowLeft != null) {
                BoxArrowLeft.Dispose ();
                BoxArrowLeft = null;
            }

            if (BoxArrowRight != null) {
                BoxArrowRight.Dispose ();
                BoxArrowRight = null;
            }

            if (containerView != null) {
                containerView.Dispose ();
                containerView = null;
            }

            if (imageArrowLeft != null) {
                imageArrowLeft.Dispose ();
                imageArrowLeft = null;
            }

            if (imageArrowRight != null) {
                imageArrowRight.Dispose ();
                imageArrowRight = null;
            }

            if (imgFullScreen != null) {
                imgFullScreen.Dispose ();
                imgFullScreen = null;
            }

            if (pageControlBottom != null) {
                pageControlBottom.Dispose ();
                pageControlBottom = null;
            }
        }
    }
}