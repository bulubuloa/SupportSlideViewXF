using System.Collections.Generic;
using Android.Content;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using FFImageLoading;
using FFImageLoading.Views;
using Java.Lang;
using Supercharge;

namespace SupportSlideViewXF.Droid.Renderers.Sliders.Adapters
{
    public class ImageSlideAdapter : PagerAdapter
    {
        private List<string> imageItems;
        private Context context;
        private ImageView.ScaleType scaleType;

        public ImageSlideAdapter(Context _context, List<string> _imageItems, Xamarin.Forms.Aspect aspect)
        {
            imageItems = _imageItems;
            context = _context;
            switch (aspect)
            {
                case Xamarin.Forms.Aspect.Fill:
                    scaleType = ImageView.ScaleType.FitXy;
                    break;
                case Xamarin.Forms.Aspect.AspectFill:
                    scaleType = ImageView.ScaleType.CenterCrop;
                    break;
                case Xamarin.Forms.Aspect.AspectFit:
                    scaleType = ImageView.ScaleType.FitCenter;
                    break;
            }
        }

        public override void DestroyItem(ViewGroup container, int position, Object @object)
        {
            container.RemoveView((View)@object);
        }

        public override Object InstantiateItem(ViewGroup container, int position)
        {
            LayoutInflater inflater = LayoutInflater.From(context);
            ViewGroup layout = (ViewGroup)inflater.Inflate(Resource.Layout.layout_single_image, container, false);

            var imageView = layout.FindViewById<ImageViewAsync>(Resource.Id.imageView);
            var progressBar = layout.FindViewById<ProgressBar>(Resource.Id.progressBar);

            imageView.SetScaleType(scaleType);

            ImageService.Instance.LoadUrl(imageItems[position]).Finish((obj) =>
            {
                SupportSlideViewSetup.Activity.RunOnUiThread(delegate {
                    progressBar.Visibility = ViewStates.Gone;
                });
            }).Success(() =>
            {

            }).Error((obj) =>
            {
                SupportSlideViewSetup.Activity.RunOnUiThread(delegate {
                    imageView.SetImageResource(Resource.Drawable.image_notfound);
                });
            }).Into(imageView);

            container.AddView(layout);
            return layout;
        }

        public override int Count => imageItems.Count;

        public override bool IsViewFromObject(View view, Java.Lang.Object @object)
        {
            return view == @object;
        }
    }
}