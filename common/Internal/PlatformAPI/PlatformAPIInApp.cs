namespace EmarsysBinding.Internal;

#if ANDROID
using Java.Lang;
using Org.Json;
using PlatformView = Android.Views.View;
using InlineInAppEventHandlerAction = System.Action<string?, Org.Json.JSONObject?>;
#elif IOS
using PlatformView = UIKit.UIView;
using InlineInAppEventHandlerAction = System.Action<Foundation.NSString, Foundation.NSDictionary<Foundation.NSString, Foundation.NSObject>?>;
#endif

public class PlatformAPIInApp : IPlatformAPIInApp
{

	public void SetEventHandler(EventHandlerAction eventHandler)
	{
		DotnetEmarsysInApp.SetEventHandler(PlatformUtils.EventHandler(eventHandler));
	}

	public void Pause()
	{
		DotnetEmarsysInApp.Pause();
	}

	public void Resume()
	{
		DotnetEmarsysInApp.Resume();
	}

	public bool IsPaused()
	{
		return DotnetEmarsysInApp.IsPaused;
	}

	public PlatformView CreateInlineInAppView()
	{
		#if ANDROID
		return DotnetEmarsysInApp.CreateInlineInAppView(Platform.AppContext);
		#elif IOS
		return DotnetEmarsysInApp.CreateInlineInAppView();
		#endif
	}

	public void SetInlineInAppEventHandler(PlatformView view, InlineInAppEventHandlerAction eventHandler)
	{
		#if ANDROID
		DotnetEmarsysInApp.SetInlineInAppEventHandler(view, new InlineInAppEventHandler(eventHandler));
		#elif IOS
		DotnetEmarsysInApp.SetInlineInAppEventHandler(view, eventHandler);
		#endif
	}

	public void SetInlineInAppCompletionListener(PlatformView view, OnCompletedAction onCompleted)
	{
		#if ANDROID
		DotnetEmarsysInApp.SetInlineInAppCompletionListener(view, new CompletionListener(onCompleted));
		#elif IOS
		DotnetEmarsysInApp.SetInlineInAppCompletionListener(view, onCompleted);
		#endif
	}

	public void SetInlineInAppCloseListener(PlatformView view, Action onClosed)
	{
		#if ANDROID
		DotnetEmarsysInApp.SetInlineInAppCloseListener(view, new InlineInAppCloseListener(onClosed));
		#elif IOS
		DotnetEmarsysInApp.SetInlineInAppCloseListener(view, onClosed);
		#endif
	}

	public void LoadInlineInApp(PlatformView view, string viewId)
	{
		DotnetEmarsysInApp.LoadInlineInApp(view, viewId);
	}

	public void SetOnEventActionEventHandler(EventHandlerAction eventHandler)
	{
		DotnetEmarsysInApp.SetOnEventActionEventHandler(PlatformUtils.EventHandler(eventHandler));
	}

}

#if ANDROID
class InlineInAppEventHandler(InlineInAppEventHandlerAction action) : Object, DotnetEmarsysInApp.IInlineInAppEventHandler
{
	private readonly InlineInAppEventHandlerAction _action = action;

	public void HandleEvent(string? eventName, JSONObject? payload)
	{
		_action.Invoke(eventName, payload);
	}
}

class InlineInAppCloseListener(Action action) : Object, DotnetEmarsysInApp.IInlineInAppCloseListener
{
	private readonly Action _action = action;

	public void OnClosed()
	{
		_action.Invoke();
	}
}
#endif
