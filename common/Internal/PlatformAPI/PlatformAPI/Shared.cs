namespace EmarsysBinding.Internal;

public partial class PlatformAPI : IPlatformAPI
{

	public void Setup(EMSConfig config)
	{
		DotnetEmarsys.Setup(config);
	}

	public void SetContact(int contactFieldId, string contactFieldValue, OnCompletedAction onCompleted)
	{
		DotnetEmarsys.SetContact(contactFieldId, contactFieldValue, PlatformUtils.CompletionListener(onCompleted));
	}

	public void ClearContact(OnCompletedAction onCompleted)
	{
		DotnetEmarsys.ClearContact(PlatformUtils.CompletionListener(onCompleted));
	}

	public void TrackCustomEvent(string eventName, Dictionary<string, string>? eventAttributes, OnCompletedAction onCompleted)
	{
		DotnetEmarsys.TrackCustomEvent(eventName, PlatformUtils.ToNativeDictionary(eventAttributes), PlatformUtils.CompletionListener(onCompleted));
	}

}
