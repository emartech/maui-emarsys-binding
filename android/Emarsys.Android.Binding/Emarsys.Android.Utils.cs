namespace EmarsysAndroid;

public class Utils
{

	public static CompletionListener Completion(Action<Java.Lang.Throwable> onInvoked)
	{
		return new CompletionListener (onInvoked);
	}

}

public class CompletionListener : Java.Lang.Object, DotnetEmarsys.ICompletionListener
{
	private readonly Action<Java.Lang.Throwable> onInvoked;

	public CompletionListener(Action<Java.Lang.Throwable> onInvoked)
	{
		this.onInvoked = onInvoked;
	}

	public void OnCompleted(Java.Lang.Throwable? errorCause)
	{
		onInvoked?.Invoke(errorCause);
	}
}
