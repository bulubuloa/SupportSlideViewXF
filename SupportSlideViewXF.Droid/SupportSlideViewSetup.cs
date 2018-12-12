using System;
using Android.App;

namespace SupportSlideViewXF.Droid
{
    public static class SupportSlideViewSetup
    {
        public static Activity Activity { set; get; }

        public static void Initialize(Activity _Activity)
        {
            Activity = _Activity;
        }
    }
}