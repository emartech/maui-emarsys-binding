namespace Sample;

using Microsoft.Maui.ApplicationModel;

using EmarsysBinding;

public partial class PushPage : ContentPage
{

	public PushPage()
	{
		InitializeComponent();
	}

	private async void OnSetPushTokenClicked(object sender, EventArgs e)
	{
		#if ANDROID
		var pushToken = Firebase.Messaging.FirebaseMessaging.Instance.GetToken().Result.ToString();
		var error = await Emarsys.Push.SetPushToken(pushToken);
		Utils.LogResult("SetPushToken", error);
		#elif IOS
		UIKit.UIApplication.SharedApplication.RegisterForRemoteNotifications();
		#endif
	}

	private async void OnClearPushTokenClicked(object sender, EventArgs e)
	{
		var error = await Emarsys.Push.ClearPushToken();
		Utils.LogResult("ClearPushToken", error);
	}

	private void OnGetPushTokenClicked(object sender, EventArgs e)
	{
		var pushToken = Emarsys.Push.GetPushToken();
		Utils.LogResult("GetPushToken", null, pushToken);
	}

	private async void OnRequestLocationPermissionClicked(object sender, EventArgs e)
	{
		await Permissions.RequestAsync<Permissions.LocationAlways>();
	}

	private void OnGeofenceSetInitialEnterTriggerEnabledClicked(object sender, EventArgs e)
	{
		Emarsys.Geofence.SetInitialEnterTriggerEnabled(true);
		Utils.LogResult("SetInitialEnterTriggerEnabled");
	}

	private async void OnGeofenceEnableClicked(object sender, EventArgs e)
	{
		var error = await Emarsys.Geofence.Enable();
		Utils.LogResult("Enable", error);
	}

	private void OnGeofenceDisableClicked(object sender, EventArgs e)
	{
		Emarsys.Geofence.Disable();
		Utils.LogResult("Disable");
	}

	private void OnGeofenceGetIsEnabledClicked(object sender, EventArgs e)
	{
		var isEnabled = Emarsys.Geofence.IsEnabled();
		Utils.LogResult("IsEnabled", null, $"{isEnabled}");
	}

	private void OnGeofenceGetRegisteredGeofencesClicked(object sender, EventArgs e)
	{
		var registeredGeofences = Emarsys.Geofence.GetRegisteredGeofences();
		Utils.LogResult("GetRegisteredGeofences", null, $"{registeredGeofences.Count}");
		foreach (var g in registeredGeofences) {
			Console.WriteLine($"{g.Id}, {g.Lat}, {g.Lon}, {g.Radius}, {g.WaitInterval}");
			foreach (var t in g.Triggers) {
				Console.WriteLine($"  {t.Id}, {t.Type}, {t.LoiteringDelay}, {t.Action}");
			}
		}
	}

}
