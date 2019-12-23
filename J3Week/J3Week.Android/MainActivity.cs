using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using FFImageLoading.Forms.Platform;
using J3Week.ViewModels;
using Android.Util;
using Plugin.CurrentActivity;

namespace J3Week.Droid
{
    [Activity(Label = "J3Week", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            //CachedImageRenderer.Init(true);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            InitDeviceValues();
            LoadApplication(new App());

            // To check and request permission
            CrossCurrentActivity.Current.Init(this, savedInstanceState);
        }
        protected void InitDeviceValues()
        {
            var metrics = Resources.DisplayMetrics;

            int statusBarHeight = 0, totalHeight = 0, contentHeight = 0;
            int resourceId = Resources.GetIdentifier("status_bar_height", "dimen", "android");
            statusBarHeight = Resources.GetDimensionPixelSize(resourceId);

            totalHeight = Resources.DisplayMetrics.HeightPixels;
            contentHeight = totalHeight - statusBarHeight;

            bool AppAlreadyInitialised = Measurements.VirtualScreenHeight != 0;

            Measurements.AvailableVirtualScreenHeight = (int)(contentHeight / metrics.Density);
            Measurements.VirtualScreenWidth = (int)(metrics.WidthPixels / metrics.Density);
            Measurements.HeightInPixels = metrics.HeightPixels;
            Measurements.WidthInPixels = metrics.WidthPixels;
            Measurements.VirtualScreenHeight = (int)(totalHeight / metrics.Density);

            int DPs = (int)TypedValue.ApplyDimension(ComplexUnitType.In, 1, metrics);
            Measurements.InchInVirtualUnits = (int)(DPs / metrics.Density);

            if (AppAlreadyInitialised == false)
            {
                Measurements.InitValues();
            }
        }
    }
}