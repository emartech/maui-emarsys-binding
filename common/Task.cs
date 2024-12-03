﻿namespace EmarsysBinding;

#if ANDROID
using Java.Lang;
using EmarsysAndroid;
#elif IOS
using Foundation;
using EmarsysiOS;
#endif

public class EmarsysTask
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
		DotnetEmarsys.SetContact(contactFieldId, contactFieldValue, Utils.CompletionListener((error) =>
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
		DotnetEmarsys.ClearContact(Utils.CompletionListener((error) =>
		{
			cs.SetResult(error);
		}));
		return cs.Task;
	}

	#if ANDROID
	public static Task<Throwable?> TrackCustomEvent(string eventName, Dictionary<string, string>? eventAttributes)
	{
		var cs = new TaskCompletionSource<Throwable?>();
		DotnetEmarsys.TrackCustomEvent(eventName, eventAttributes, Utils.CompletionListener((error) =>
		{
			cs.SetResult(error);
		}));
		return cs.Task;
	}
	#elif IOS
	public static Task<NSError?> TrackCustomEvent(string eventName, Dictionary<string, string>? eventAttributes)
	{
		var cs = new TaskCompletionSource<NSError?>();
		DotnetEmarsys.TrackCustomEvent(eventName, Utils.ToNSDictionary(eventAttributes), Utils.CompletionListener((error) =>
		{
			cs.SetResult(error);
		}));
		return cs.Task;
	}
	#endif

	public static TaskPush Push = new TaskPush();

}
