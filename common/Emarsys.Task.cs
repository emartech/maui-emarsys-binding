namespace EmarsysCommon;

#if ANDROID
using Java.Lang;
using Emarsys = EmarsysAndroid.DotnetEmarsys;
#elif IOS
using Foundation;
using Emarsys = EmarsysiOS.DotnetEmarsys;
#endif

public class Task
{

	#if ANDROID
	public static Task<Throwable?> SetContact(int contactFieldId, string contactFieldValue)
	{
		var cs = new TaskCompletionSource<Throwable?>();
	#elif IOS
	public static Task<NSError?> SetContact(int contactFieldId, string contactFieldValue)
	{
		var cs = new TaskCompletionSource<NSError?>();
	#endif
		Emarsys.SetContact(contactFieldId, contactFieldValue, Utils.CompletionListener((error) =>
		{
			cs.SetResult(error);
		}));
		return cs.Task;
	}

	#if ANDROID
	public static Task<Throwable?> ClearContact()
	{
		var cs = new TaskCompletionSource<Throwable?>();
	#elif IOS
	public static Task<NSError?> ClearContact()
	{
		var cs = new TaskCompletionSource<NSError?>();
	#endif
		Emarsys.ClearContact(Utils.CompletionListener((error) =>
		{
			cs.SetResult(error);
		}));
		return cs.Task;
	}

	#if ANDROID
	public static Task<Throwable?> TrackCustomEvent(string eventName, Dictionary<string, string>? eventAttributes)
	{
		var cs = new TaskCompletionSource<Throwable?>();
	#elif IOS
	public static Task<NSError?> TrackCustomEvent(string eventName, NSDictionary<NSString, NSString> eventAttributes)
	{
		var cs = new TaskCompletionSource<NSError?>();
	#endif
		Emarsys.TrackCustomEvent(eventName, eventAttributes, Utils.CompletionListener((error) =>
		{
			cs.SetResult(error);
		}));
		return cs.Task;
	}

	public static TaskPush Push = new TaskPush();

}
