namespace EmarsysBinding.Internal;

using Java.Lang;
using Org.Json;
using PlatformView = Android.Views.View;
using InlineInAppEventHandlerAction = System.Action<string?, Org.Json.JSONObject?>;

public partial class PlatformAPIInApp
{

	public PlatformView CreateInlineInAppView()
	{
		return DotnetEmarsysInApp.CreateInlineInAppView(Platform.AppContext);
	}

	public void SetInlineInAppEventHandler(PlatformView view, InlineInAppEventHandlerAction eventHandler)
	{
		DotnetEmarsysInApp.SetInlineInAppEventHandler(view, new InlineInAppEventHandler(eventHandler));
	}

	public void SetInlineInAppCompletionListener(PlatformView view, OnCompletedAction onCompleted)
	{
		DotnetEmarsysInApp.SetInlineInAppCompletionListener(view, new CompletionListener(onCompleted));
	}

	public void SetInlineInAppCloseListener(PlatformView view, Action onClosed)
	{
		DotnetEmarsysInApp.SetInlineInAppCloseListener(view, new InlineInAppCloseListener(onClosed));
	}

	public void LoadInlineInApp(PlatformView view, string viewId)
	{
		DotnetEmarsysInApp.LoadInlineInApp(view, viewId);
	}

}

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
