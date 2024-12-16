namespace EmarsysBinding.Internal;

public class InternalAPI(IPlatformAPI platform)
{

	private readonly IPlatformAPI _platform = platform;

	#if ANDROID || IOS
	public void Setup(EMSConfig config)
	#else
	public void Setup(string config)
	#endif
	{
		_platform.Setup(config);
	}

	public Task<ErrorType?> SetContact(int contactFieldId, string contactFieldValue)
	{
		return Utils.Task((onCompleted) =>
		{
			_platform.SetContact(contactFieldId, contactFieldValue, onCompleted);
		});
	}

	public Task<ErrorType?> ClearContact()
	{
		return Utils.Task((onCompleted) =>
		{
			_platform.ClearContact(onCompleted);
		});
	}

}
