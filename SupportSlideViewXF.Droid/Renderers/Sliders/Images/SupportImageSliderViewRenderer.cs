using System;
using System.Linq;
using Android.Content;
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

        protected override void OnInitializeOriginalView()
        {
            base.OnInitializeOriginalView();

        }

        private void InitSource()
        {
            if (supportSlide.ImageItems != null)
            {
                imageSlideAdapter = new ImageSlideAdapter(Context, supportSlide.ImageItems.ToList());
                viewPager.Adapter = imageSlideAdapter;
            }
            else
            {

            }
        }

    }
}
