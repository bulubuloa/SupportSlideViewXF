using System.Collections.Generic;
using Android.Content;
using Android.Support.V4.View;
using Android.Views;
using FFImageLoading;
using FFImageLoading.Views;
using Java.Lang;

namespace SupportSlideViewXF.Droid.Renderers.Sliders.Adapters
{
    public class ImageSlideAdapter : PagerAdapter
    {
        private List<string> imageItems;
        private Context context;

        public ImageSlideAdapter(Context _context, List<string> _imageItems)
        {

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
            ImageService.Instance.LoadUrl(imageItems[position]).Finish((obj) =>
            {

            }).Success(() =>
            {

            }).Error((obj) =>
            {

            }).Into(imageView);

            container.AddView(layout);
            return layout;
        }

        public override int Count => imageItems.Count;

        public override bool IsViewFromObject(View view, Java.Lang.Object @object)
        {
            return true;
        }
    }
}
