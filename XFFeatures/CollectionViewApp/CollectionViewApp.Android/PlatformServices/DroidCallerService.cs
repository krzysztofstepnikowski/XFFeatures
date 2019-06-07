using Android.Content;
using CollectionViewApp.Droid.PlatformServices;
using CollectionViewApp.PlatformServices;
using Xamarin.Forms;
using Application = Android.App.Application;
using Uri = Android.Net.Uri;

[assembly: Dependency(typeof(DroidCallerService))]
namespace CollectionViewApp.Droid.PlatformServices
{
    public class DroidCallerService : ICallerService
    {
        public void Call(string phoneNumber)
        {
            var activity = Application.Context;
            var intent = new Intent(Intent.ActionDial);
            intent.SetData(Uri.Parse($"tel: {phoneNumber}"));
            activity.StartActivity(intent);
        }
    }
}