using Foundation;
using System;
using UIKit;

namespace SupportSlideViewXF.iOS
{
    public partial class LoadingViewController : UIViewController
    {
        public LoadingViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            indicator.StartAnimating();
        }
    }
}