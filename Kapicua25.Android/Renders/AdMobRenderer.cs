using Android.Content;
using Android.Gms.Ads;
using Android.Widget;
using Kapicua25;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Kapicua25.Droid.Renders;

[assembly: ExportRenderer(typeof(AdMobView), typeof(AdMobRenderer))]
namespace Kapicua25.Droid.Renders
{
    public class AdMobRenderer : ViewRenderer
    {
        public AdMobRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if ((Element is AdMobView adMobElement) && (e.OldElement == null))
            {
                var adId = "ca-app-pub-3940256099942544/6300978111";

                var ad = new AdView(Context)
                {
                    AdSize = AdSize.Banner,
                    AdUnitId = adId
                };

                var requestbuilder = new AdRequest.Builder();
                ad.LoadAd(requestbuilder.Build());
                SetNativeControl(ad);
            }
        }
    }
}