namespace EmarsysBinding.Internal;

#if !ANDROID && !IOS
using EMSConfig = string;
#endif

public partial class InternalAPI(IPlatformAPI platform)
{

	private readonly IPlatformAPI _platform = platform;

	public void Setup(EMSConfig config)
	{
		_platform.Setup(config);
	}

	public Task<ErrorType?> SetContact(int contactFieldId, string contactFieldValue)
	{
		return InternalUtils.Task((onCompleted) =>
		{
			_platform.SetContact(contactFieldId, contactFieldValue, onCompleted);
		});
	}

	public Task<ErrorType?> ClearContact()
	{
		return InternalUtils.Task((onCompleted) =>
		{
			_platform.ClearContact(onCompleted);
		});
	}

	public Task<ErrorType?> TrackCustomEvent(string eventName, Dictionary<string, string>? eventAttributes)
	{
		return InternalUtils.Task((onCompleted) =>
		{
			_platform.TrackCustomEvent(eventName, eventAttributes, onCompleted);
		});
	}

}
