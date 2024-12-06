using Android.App;
using Android.OS;
using Android;
using Android.Content.PM;
using AndroidX.Core.App;
using AndroidX.Core.Content;

namespace Sample;

using EmarsysBinding;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
  protected override void OnCreate(Bundle? savedInstanceState)
  {
    base.OnCreate(savedInstanceState);

    if (Build.VERSION.SdkInt >= BuildVersionCodes.Tiramisu)
    {
      RequestNotificationPermission();
    }
  }

  protected override void OnNewIntent (Android.Content.Intent? intent)
  {
    base.OnNewIntent(intent);

    if (intent != null)
    {
      Emarsys.TrackDeepLink(this, intent, (error) =>
      {
        Utils.LogResult("TrackDeepLink", error);
      });
    }
  }

  private void RequestNotificationPermission()
  {
    #pragma warning disable CA1416
    if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.PostNotifications) != Permission.Granted)
    {
      ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.PostNotifications }, 101);
    }
    #pragma warning restore CA1416
  }
}
