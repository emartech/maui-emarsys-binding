namespace EmarsysCommon;

public class Utils
{

	#if ANDROID
	public static CompletionListener OnCompleted (Action<Java.Lang.Throwable?> onInvoked)
	{
		return new CompletionListener (onInvoked);
	}
	#elif IOS
	public static Action<Foundation.NSError?> OnCompleted (Action<Foundation.NSError?> onInvoked)
	{
		return onInvoked;
	}
	#endif

}

#if ANDROID
public class CompletionListener : Java.Lang.Object, EmarsysAndroid.DotnetEmarsys.ICompletionListener
{
	private readonly Action<Java.Lang.Throwable?> onInvoked;

	public CompletionListener (Action<Java.Lang.Throwable?> onInvoked)
	{
		this.onInvoked = onInvoked;
	}

	public void OnCompleted (Java.Lang.Throwable? errorCause)
	{
		onInvoked?.Invoke(errorCause);
	}
}
#endif
