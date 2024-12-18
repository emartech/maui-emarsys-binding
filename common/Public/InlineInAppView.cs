namespace EmarsysBinding;

using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

#if ANDROID
using PlatformView = Android.Views.View;
using InlineInAppEventHandlerAction = System.Action<string?, Org.Json.JSONObject?>;
#elif IOS
using PlatformView = UIKit.UIView;
using InlineInAppEventHandlerAction = System.Action<Foundation.NSString, Foundation.NSDictionary<Foundation.NSString, Foundation.NSObject>?>;
#endif

public class InlineInAppView : View
{

	public event EventHandler<InlineInAppEventHandlerAction>? _SetEventHandler;
	public void SetEventHandler(InlineInAppEventHandlerAction eventHandler)
	{
		_SetEventHandler?.Invoke(this, eventHandler);
		WaitForHandler(() =>
		{
			Handler?.Invoke(nameof(InlineInAppView._SetEventHandler), eventHandler);
		});
	}

	public event EventHandler<OnCompletedAction>? _SetCompletionListener;
	public void SetCompletionListener(OnCompletedAction onCompleted)
	{
		_SetCompletionListener?.Invoke(this, onCompleted);
		WaitForHandler(() =>
		{
			Handler?.Invoke(nameof(InlineInAppView._SetCompletionListener), onCompleted);
		});
	}

	public event EventHandler<Action>? _SetCloseListener;
	public void SetCloseListener(Action closeListener)
	{
		_SetCloseListener?.Invoke(this, closeListener);
		WaitForHandler(() =>
		{
			Handler?.Invoke(nameof(InlineInAppView._SetCloseListener), closeListener);
		});
	}

	public event EventHandler<string>? _LoadInApp;
	public void LoadInApp(string viewId)
	{
		_LoadInApp?.Invoke(this, viewId);
		WaitForHandler(() =>
		{
			Handler?.Invoke(nameof(InlineInAppView._LoadInApp), viewId);
		});
	}

	void WaitForHandler(Action onReady) {
		System.Threading.Tasks.Task.Run(async () =>
		{
			while (Handler == null)
			{
				await System.Threading.Tasks.Task.Delay(100);
			}
			MainThread.BeginInvokeOnMainThread(() =>
			{
				onReady.Invoke();
			});
		});
	}

}

public partial class InlineInAppViewHandler : ViewHandler<InlineInAppView, PlatformView>
{

	private static InternalAPIInApp _internal = new InternalAPIInApp(new PlatformAPIInApp());

	public static IPropertyMapper<InlineInAppView, InlineInAppViewHandler> PropertyMapper = new PropertyMapper<InlineInAppView, InlineInAppViewHandler>(ViewHandler.ViewMapper)
	{
	};
	public static CommandMapper<InlineInAppView, InlineInAppViewHandler> CommandMapper = new (ViewCommandMapper)
	{
		[nameof(InlineInAppView._SetEventHandler)] = SetEventHandler,
		[nameof(InlineInAppView._SetCompletionListener)] = SetCompletionListener,
		[nameof(InlineInAppView._SetCloseListener)] = SetCloseListener,
		[nameof(InlineInAppView._LoadInApp)] = LoadInApp
	};

	public InlineInAppViewHandler() : base(PropertyMapper, CommandMapper)
	{
	}

	protected override PlatformView CreatePlatformView()
	{
		return _internal.CreateInlineInAppView();
	}

	public static void SetEventHandler(InlineInAppViewHandler handler, InlineInAppView view, object? args)
	{
		if (args is InlineInAppEventHandlerAction)
		{
			_internal.SetInlineInAppEventHandler(handler.PlatformView, (InlineInAppEventHandlerAction) args);
		}
		else
		{
			Console.WriteLine("Please provide valid eventHandler");
		}
	}

	public static void SetCompletionListener(InlineInAppViewHandler handler, InlineInAppView view, object? args)
	{
		if (args is OnCompletedAction)
		{
			_internal.SetInlineInAppCompletionListener(handler.PlatformView, (OnCompletedAction) args);
		}
		else
		{
			Console.WriteLine("Please provide valid completionListener");
		}
	}

	public static void SetCloseListener(InlineInAppViewHandler handler, InlineInAppView view, object? args)
	{
		if (args is Action)
		{
			_internal.SetInlineInAppCloseListener(handler.PlatformView, (Action) args);
		}
		else
		{
			Console.WriteLine("Please provide valid closeListener");
		}
	}

	public static void LoadInApp(InlineInAppViewHandler handler, InlineInAppView view, object? args)
	{
		if (args is string)
		{
			_internal.LoadInlineInApp(handler.PlatformView, (string) args);
		}
		else
		{
			Console.WriteLine("Please provide valid viewId");
		}
	}

}
