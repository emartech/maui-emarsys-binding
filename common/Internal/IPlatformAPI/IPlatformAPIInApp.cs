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

public interface IPlatformAPIInApp
{

	public void SetEventHandler(EventHandlerAction eventHandler);

	public void Pause();

	public void Resume();

	public bool IsPaused();

	public PlatformView CreateInlineInAppView();

	public void SetInlineInAppEventHandler(PlatformView view, InlineInAppEventHandlerAction eventHandler);

	public void SetInlineInAppCompletionListener(PlatformView view, OnCompletedAction onCompleted);

	public void SetInlineInAppCloseListener(PlatformView view, Action onClosed);

	public void LoadInlineInApp(PlatformView view, string viewId);

	public void SetOnEventActionEventHandler(EventHandlerAction eventHandler);

}
