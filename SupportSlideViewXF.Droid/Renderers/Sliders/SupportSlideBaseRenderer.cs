using System;
using Android.Content;
using Android.Support.V4.View;
using Android.Views;
using SupportSlideViewXF.Widgets;
using Xamarin.Forms.Platform.Android;

namespace SupportSlideViewXF.Droid.Renderers.Sliders
{
    public class SupportSlideBaseRenderer<TSupportSlide> : ViewRenderer<TSupportSlide, View>
        where TSupportSlide : SupportSlideBase
    {

        protected TSupportSlide supportSlide;
        protected View originalView;

        protected ViewPager viewPager;

        public SupportSlideBaseRenderer(Context context) : base(context)
        {
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

        private void OnSetNativeControl()
        {
            OnSetNativeDataSource();
            SetNativeControl(originalView);
        }

        protected virtual void OnInitializeOriginalView()
        {
            originalView = LayoutInflater.From(Context).Inflate(Resource.Layout.layout_main_pager, null, false);
            viewPager = originalView.FindViewById<ViewPager>(Resource.Id.viewPager);
        }

        protected virtual void OnSetNativeDataSource()
        {

        }
    }
}
