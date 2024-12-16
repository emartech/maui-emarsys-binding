namespace EmarsysBinding.Internal;

public interface IPlatformAPI
{

	#if ANDROID || IOS
	public void Setup(EMSConfig config);
	#else
	public void Setup(string config);
	#endif

	public void SetContact(int contactFieldId, string contactFieldValue, OnCompletedAction? onCompleted);

	public void ClearContact(OnCompletedAction? onCompleted);

}
