using FFImageLoading;
using SupportSlideViewXF.iOS.Renderers.Sliders;
using System;
using UIKit;

namespace SupportSlideViewXF.iOS
{
    public partial class ImageViewController : BaseViewController
    {

        public string ImageUrl { set; get; }
        private bool ImageLoaded = false;

        public ImageViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            if (!ImageLoaded)
            {
                indicator.StartAnimating();
                ImageService.Instance.LoadUrl(ImageUrl).Finish((obj) =>
                {
                    BeginInvokeOnMainThread(() =>
                    {
                        indicator.StopAnimating();
                        indicator.Hidden = true;
                    });
                }).Success(() =>
                {
                    BeginInvokeOnMainThread(() =>
                    {
                        imageView.ContentMode = UIViewContentMode.ScaleAspectFill;
                        ImageLoaded = true;
                    });
                }).Error((obj) => {
                    BeginInvokeOnMainThread(() =>
                    {
                        imageView.ContentMode = UIViewContentMode.ScaleAspectFit;
                        imageView.Image = UIImage.FromFile("image_notfound").ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
                    });
                }).Into(imageView);
            }
        }

        public void SetImage(string imageURL)
        {
            ImageUrl = imageURL;
        }
    }
}