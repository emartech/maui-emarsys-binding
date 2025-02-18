namespace EmarsysBinding.Internal;

using PlatformView = UIKit.UIView;
using InlineInAppEventHandlerAction = System.Action<Foundation.NSString, Foundation.NSDictionary<Foundation.NSString, Foundation.NSObject>?>;

public partial class PlatformAPIInApp
{

	public PlatformView CreateInlineInAppView()
	{
		return DotnetEmarsysInApp.CreateInlineInAppView();
	}

	public void SetInlineInAppEventHandler(PlatformView view, InlineInAppEventHandlerAction eventHandler)
	{
		DotnetEmarsysInApp.SetInlineInAppEventHandler(view, eventHandler);
	}

	public void SetInlineInAppCompletionListener(PlatformView view, OnCompletedAction onCompleted)
	{
		DotnetEmarsysInApp.SetInlineInAppCompletionListener(view, PlatformUtils.CompletionListener(onCompleted));
	}

	public void SetInlineInAppCloseListener(PlatformView view, Action onClosed)
	{
		DotnetEmarsysInApp.SetInlineInAppCloseListener(view, onClosed);
	}

	public void LoadInlineInApp(PlatformView view, string viewId)
	{
		DotnetEmarsysInApp.LoadInlineInApp(view, viewId);
	}

}
