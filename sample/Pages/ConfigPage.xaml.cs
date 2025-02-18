namespace Sample;

using EmarsysBinding;

public partial class ConfigPage : ContentPage
{

	public ConfigPage()
	{
		InitializeComponent();
	}

	private async void OnSetContactClicked(object sender, EventArgs e)
	{
		int contactFieldId = 100009769;
		string contactFieldValue = "B8mau1nMO8PilvTp6P"; // demoapp@emarsys.com
		var error = await Emarsys.SetContact(contactFieldId, contactFieldValue);
		Utils.LogResult("SetContact", error);
	}

	private async void OnClearContactClicked(object sender, EventArgs e)
	{
		var error = await Emarsys.ClearContact();
		Utils.LogResult("ClearContact", error);
	}

	private async void OnTrackCustomEventClicked(object sender, EventArgs e)
	{
		string eventName = "testingEventName";
		Dictionary<string, string> eventAttributes = new Dictionary<string, string>
		{
			{ "key1", "value1" },
			{ "key2", "value2" }
		};
		var error = await Emarsys.TrackCustomEvent(eventName, eventAttributes);
		Utils.LogResult("TrackCustomEvent", error);
	}

	private async void OnChangeApplicationCodeClicked(object sender, EventArgs e)
	{
		string applicationCode = "EMS12-04EC1";
		var error = await Emarsys.Config.ChangeApplicationCode(applicationCode);
		Utils.LogResult("ChangeApplicationCode", error);
	}

	private async void OnChangeMerchantIdClicked(object sender, EventArgs e)
	{
		string merchantId = "1DF86BF95CBE8F19";
		var error = await Emarsys.Config.ChangeMerchantId(merchantId);
		Utils.LogResult("ChangeMerchantId", error);
	}

	private void OnGetApplicationCodeClicked(object sender, EventArgs e)
	{
		var applicationCode = Emarsys.Config.GetApplicationCode();
		Utils.LogResult("GetApplicationCode", null, applicationCode);
	}

	private void OnGetMerchantIdClicked(object sender, EventArgs e)
	{
		var merchantId = Emarsys.Config.GetMerchantId();
		Utils.LogResult("GetMerchantId", null, merchantId);
	}

	private void OnGetClientIdClicked(object sender, EventArgs e)
	{
		var clientId = Emarsys.Config.GetClientId();
		Utils.LogResult("GetClientId", null, clientId);
	}

	private void OnGetLanguageCodeClicked(object sender, EventArgs e)
	{
		var languageCode = Emarsys.Config.GetLanguageCode();
		Utils.LogResult("GetLanguageCode", null, languageCode);
	}

	private void OnGetSdkVersionClicked(object sender, EventArgs e)
	{
		var sdkVersion = Emarsys.Config.GetSdkVersion();
		Utils.LogResult("GetSdkVersion", null, sdkVersion);
	}

	private void OnGetContactFieldIdClicked(object sender, EventArgs e)
	{
		var contactFieldId = Emarsys.Config.GetContactFieldId();
		Utils.LogResult("GetContactFieldId", null, $"{contactFieldId}");
	}

	private void OnGetMauiBindingVersionClicked(object sender, EventArgs e)
	{
		var mauiBindingVersion = Emarsys.Config.GetMauiBindingVersion();
		Utils.LogResult("GetMauiBindingVersion", null, $"{mauiBindingVersion}");
	}

}
