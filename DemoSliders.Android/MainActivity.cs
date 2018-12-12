
using Android.App;
using Android.Content.PM;
using Android.OS;
using SupportSlideViewXF.Droid;

namespace DemoSliders.Droid
{
    [Activity(Label = "DemoSliders", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            SupportSlideViewSetup.Initialize(this);
            LoadApplication(new App());
        }
    }
}