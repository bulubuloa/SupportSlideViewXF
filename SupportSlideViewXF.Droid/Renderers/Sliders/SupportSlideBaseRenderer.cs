using System;
using System.ComponentModel;
using Android.Content;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
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
        protected TabLayout tabLayout;
        protected ImageButton buttonRight, buttonLeft;

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

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName.Equals(SupportSlideBase.ShowIndicatorsProperty.PropertyName))
            {
                SetShowIndicator(supportSlide);
            }
            else if (e.PropertyName.Equals(SupportSlideBase.TintColorProperty.PropertyName))
            {
                SetTintColorIndicator(supportSlide.TintColor);
            }
            else if (e.PropertyName.Equals(SupportSlideBase.CurrentColorProperty.PropertyName))
            {
                SetCurrentColorIndicator(supportSlide.CurrentColor);
            }
            else if (e.PropertyName.Equals(SupportSlideBase.ShowArrowsProperty.PropertyName))
            {
                SetShowArrows(supportSlide);
            }
            else if (e.PropertyName.Equals(SupportSlideBase.IndicatorsPositionProperty.PropertyName))
            {
                SetShowIndicator(supportSlide);
            }
            else if (e.PropertyName.Equals(SupportSlideBase.CurrentPageIndexProperty.PropertyName))
            {

            }
        }

        protected void SetShowIndicator(SupportSlideBase supportSlide)
        {
            tabLayout.Visibility = supportSlide.ShowIndicators ? ViewStates.Visible : ViewStates.Gone;
        }

        protected void SetTintColorIndicator(Xamarin.Forms.Color color)
        {
        }

        protected void SetCurrentColorIndicator(Xamarin.Forms.Color color)
        {
        }

        protected void SetShowArrows(SupportSlideBase supportSlide)
        {
            buttonLeft.Visibility = supportSlide.ShowArrows ? ViewStates.Visible : ViewStates.Gone;
            buttonRight.Visibility = supportSlide.ShowArrows ? ViewStates.Visible : ViewStates.Gone;
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
            tabLayout = originalView.FindViewById<TabLayout>(Resource.Id.tabLayout);
            buttonLeft = originalView.FindViewById<ImageButton>(Resource.Id.arrowLeft);
            buttonRight = originalView.FindViewById<ImageButton>(Resource.Id.arrowRight);

            tabLayout.SetupWithViewPager(viewPager,true);
            viewPager.OffscreenPageLimit = 1000;
        }

        protected virtual void OnSetNativeDataSource()
        {

        }
    }
}
