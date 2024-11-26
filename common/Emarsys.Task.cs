namespace EmarsysCommon;

#if ANDROID
using Emarsys = EmarsysAndroid.DotnetEmarsys;
#elif IOS
using Emarsys = EmarsysiOS.DotnetEmarsys;
#endif

public class Task
{

	#if ANDROID
	public static Task<Java.Lang.Throwable?> SetContact(int contactFieldId, string contactFieldValue)
	{
		var cs = new TaskCompletionSource<Java.Lang.Throwable?>();
	#elif IOS
	public static Task<Foundation.NSError?> SetContact(int contactFieldId, string contactFieldValue)
	{
		var cs = new TaskCompletionSource<Foundation.NSError?>();
	#endif
		Emarsys.SetContact(contactFieldId, contactFieldValue, Utils.OnCompleted((error) =>
		{
			cs.SetResult(error);
		}));
		return cs.Task;
	}

	#if ANDROID
	public static Task<Java.Lang.Throwable?> ClearContact()
	{
		var cs = new TaskCompletionSource<Java.Lang.Throwable?>();
	#elif IOS
	public static Task<Foundation.NSError?> ClearContact()
	{
		var cs = new TaskCompletionSource<Foundation.NSError?>();
	#endif
		Emarsys.ClearContact(Utils.OnCompleted((error) =>
		{
			cs.SetResult(error);
		}));
		return cs.Task;
	}

	public static TaskPush GetPush()
	{
		return new TaskPush();
	}

}
