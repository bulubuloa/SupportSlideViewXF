using System;
using Xamarin.Forms.Platform.iOS;

namespace SupportSlideViewXF.iOS
{
    public static class SupportSlideViewSetup
    {
        public static FormsApplicationDelegate AppDelegate;

        public static void Initialize(FormsApplicationDelegate _AppDelegate)
        {
            AppDelegate = _AppDelegate;
        }
    }
}