using FFImageLoading;
using SupportSlideViewXF.iOS.Renderers.Sliders;
using System;
using UIKit;
using Xamarin.Forms;

namespace SupportSlideViewXF.iOS
{
    public partial class ImageViewController : BaseViewController
    {
        public Aspect AspectType { set; get; }
        public string ImageUrl { set; get; }
        private bool ImageLoaded = false;

        public ImageViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            switch (AspectType)
            {
                case Aspect.AspectFit:
                    imageView.ContentMode = UIViewContentMode.ScaleAspectFit;
                    break;
                case Aspect.AspectFill:
                    imageView.ContentMode = UIViewContentMode.ScaleAspectFill;
                    break;
                case Aspect.Fill:
                    imageView.ContentMode = UIViewContentMode.ScaleToFill;
                    break;
                default:
                    break;
            }

            UITapGestureRecognizer tapZoom = new UITapGestureRecognizer(() => {

            });
            tapZoom.NumberOfTapsRequired = 2;
            imageView.UserInteractionEnabled = true;
            imageView.AddGestureRecognizer(tapZoom);
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

        public void SetImage(string imageURL, Aspect aspect)
        {
            ImageUrl = imageURL;
            AspectType = aspect;
        }
    }
}