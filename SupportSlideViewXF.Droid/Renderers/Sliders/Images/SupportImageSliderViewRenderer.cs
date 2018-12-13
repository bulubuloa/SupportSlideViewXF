using System;
using System.ComponentModel;
using System.Linq;
using Android.Content;
using Android.Util;
using SupportSlideViewXF.Droid.Renderers.Sliders.Adapters;
using SupportSlideViewXF.Droid.Renderers.Sliders.Images;
using SupportSlideViewXF.Widgets;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(SupportImageSliderView), typeof(SupportImageSliderViewRenderer))]
namespace SupportSlideViewXF.Droid.Renderers.Sliders.Images
{
    public class SupportImageSliderViewRenderer : SupportSlideBaseRenderer<SupportImageSliderView>
    {
        private ImageSlideAdapter imageSlideAdapter;

        public SupportImageSliderViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnSetNativeDataSource()
        {
            base.OnSetNativeDataSource();
            InitSource();
        }

        protected override void OnInitializeOriginalView()
        {
            base.OnInitializeOriginalView();
            buttonRight.Click += (object sender, EventArgs e) =>
            {
                try
                {
                    int next = viewPager.CurrentItem + 1;
                    if (next < supportSlide.ImageItems.Count())
                        viewPager.CurrentItem = next;
                }
                catch (Exception ex)
                {
                    Log.Error("", ex.StackTrace);
                }
            };

            buttonLeft.Click += (object sender, EventArgs e) =>
            {
                try
                {
                    int prev = viewPager.CurrentItem - 1;
                    if (prev >= 0) 
                        viewPager.CurrentItem = prev;
                }
                catch (Exception ex)
                {
                    Log.Error("", ex.StackTrace);
                }
            };
        }

        private void InitSource()
        {
            if (supportSlide.ImageItems != null)
            {
                imageSlideAdapter = new ImageSlideAdapter(Context, supportSlide.ImageItems.ToList(),supportSlide.AspectType);
                viewPager.Adapter = imageSlideAdapter;
            }
            else
            {
                viewPager.Adapter = null;
                imageSlideAdapter = null;
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName.Equals(SupportImageSliderView.ImageItemsProperty.PropertyName))
            {
                InitSource();
            }
            else if (e.PropertyName.Equals(SupportImageSliderView.ShowFullScreenProperty.PropertyName))
            {

            }
            else if (e.PropertyName.Equals(SupportImageSliderView.ShowBlankLoadingProperty.PropertyName))
            {

            }
            else if (e.PropertyName.Equals(SupportImageSliderView.AspectTypeProperty.PropertyName))
            {

            }
        }
    }
}