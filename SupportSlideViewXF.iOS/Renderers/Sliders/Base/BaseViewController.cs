using System;
using UIKit;

namespace SupportSlideViewXF.iOS.Renderers.Sliders
{
    public class BaseViewController : UIViewController
    {
        public int Index { set; get; }

        public BaseViewController()
        {

        }

        public BaseViewController(IntPtr handle) : base(handle)
        {
        }
    }
}