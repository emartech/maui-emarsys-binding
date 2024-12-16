namespace EmarsysBinding.Internal;

public class PlatformAPI: IPlatformAPI
{

	public void Setup(EMSConfig config)
	{
		DotnetEmarsys.Setup(config);
	}

	public void SetContact(int contactFieldId, string contactFieldValue, OnCompletedAction? onCompleted)
	{
		DotnetEmarsys.SetContact(contactFieldId, contactFieldValue, Utils.CompletionListener(onCompleted));
	}

	public void ClearContact(OnCompletedAction? onCompleted)
	{
		DotnetEmarsys.ClearContact(Utils.CompletionListener(onCompleted));
	}

}
