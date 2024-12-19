namespace EmarsysBinding.Internal;

#if ANDROID
using PlatformView = Android.Views.View;
using InlineInAppEventHandlerAction = System.Action<string?, Org.Json.JSONObject?>;
#elif IOS
using PlatformView = UIKit.UIView;
using InlineInAppEventHandlerAction = System.Action<Foundation.NSString, Foundation.NSDictionary<Foundation.NSString, Foundation.NSObject>?>;
#else
using PlatformView = string;
using InlineInAppEventHandlerAction = System.Action<string>;
#endif

public class InternalAPIInApp(IPlatformAPIInApp platform)
{

	private readonly IPlatformAPIInApp _platform = platform;

	public void SetEventHandler(EventHandlerAction eventHandler)
	{
		_platform.SetEventHandler(eventHandler);
	}

	public void Pause()
	{
		_platform.Pause();
	}

	public void Resume()
	{
		_platform.Resume();
	}

	public bool IsPaused()
	{
		return _platform.IsPaused();
	}

	public PlatformView CreateInlineInAppView()
	{
		return _platform.CreateInlineInAppView();
	}

	public void SetInlineInAppEventHandler(PlatformView view, InlineInAppEventHandlerAction eventHandler)
	{
		_platform.SetInlineInAppEventHandler(view, eventHandler);
	}

	public void SetInlineInAppCompletionListener(PlatformView view, OnCompletedAction onCompleted)
	{
		_platform.SetInlineInAppCompletionListener(view, onCompleted);
	}

	public void SetInlineInAppCloseListener(PlatformView view, Action onClosed)
	{
		_platform.SetInlineInAppCloseListener(view, onClosed);
	}

	public void LoadInlineInApp(PlatformView view, string viewId)
	{
		_platform.LoadInlineInApp(view, viewId);
	}

	public void SetOnEventActionEventHandler(EventHandlerAction eventHandler)
	{
		_platform.SetOnEventActionEventHandler(eventHandler);
	}

}
