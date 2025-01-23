namespace EmarsysBinding.Internal;

#if !ANDROID && !IOS
using EMSConfig = string;
#endif

public partial interface IPlatformAPI
{

	public void Setup(EMSConfig config);

	public void SetContact(int contactFieldId, string contactFieldValue, OnCompletedAction onCompleted);

	public void ClearContact(OnCompletedAction onCompleted);

	public void TrackCustomEvent(string eventName, Dictionary<string, string>? eventAttributes, OnCompletedAction onCompleted);

}
