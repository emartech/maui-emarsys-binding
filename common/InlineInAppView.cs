namespace EmarsysBinding;

using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

#if ANDROID
using Java.Lang;
using Kotlin;
using Org.Json;
#elif IOS
using Foundation;
#endif

public class InlineInAppView : View
{

	#if ANDROID
	public event EventHandler<Action<string?, JSONObject?>>? _SetEventHandler;
	public void SetEventHandler(Action<string?, JSONObject?> eventHandler)
	#elif IOS
	public event EventHandler<Action<NSString?, NSDictionary<NSString, NSObject>?>>? _SetEventHandler;
	public void SetEventHandler(Action<NSString?, NSDictionary<NSString, NSObject>?> eventHandler)
	#endif
	{
		_SetEventHandler?.Invoke(this, eventHandler);
		WaitForHandler(() =>
		{
			Handler?.Invoke(nameof(InlineInAppView._SetEventHandler), eventHandler);
		});
	}

	public event EventHandler<Action<ErrorType?>>? _SetCompletionListener;
	public void SetCompletionListener(Action<ErrorType?> completionListener)
	{
		_SetCompletionListener?.Invoke(this, completionListener);
		WaitForHandler(() =>
		{
			Handler?.Invoke(nameof(InlineInAppView._SetCompletionListener), completionListener);
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

public partial class InlineInAppViewHandler
{

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

	public static void SetEventHandler(InlineInAppViewHandler handler, InlineInAppView view, object? args)
	{
		#if ANDROID
		if (handler.PlatformView is Android.Views.View && args is Action<string?, JSONObject?>)
		{
			DotnetEmarsys.InApp.SetInlineInAppEventHandler((Android.Views.View) handler.PlatformView, new InlineInAppEventHandler((Action<string?, JSONObject?>) args));
		}
		#elif IOS
		if (handler.PlatformView is UIKit.UIView && args is Action<NSString?, NSDictionary<NSString, NSObject>?>)
		{
			DotnetEmarsys.InApp.SetInlineInAppEventHandler((UIKit.UIView) handler.PlatformView, (Action<NSString?, NSDictionary<NSString, NSObject>?>) args);
		}
		#endif
		else
		{
			Console.WriteLine("Please provide valid InlineInAppView and eventHandler");
		}
	}

	public static void SetCompletionListener(InlineInAppViewHandler handler, InlineInAppView view, object? args)
	{
		#if ANDROID
		if (handler.PlatformView is Android.Views.View && args is Action<Throwable?>)
		{
			DotnetEmarsys.InApp.SetInlineInAppCompletionListener((Android.Views.View) handler.PlatformView, new CompletionListener((Action<Throwable?>) args));
		}
		#elif IOS
		if (handler.PlatformView is UIKit.UIView && args is Action<NSError?>)
		{
			DotnetEmarsys.InApp.SetInlineInAppCompletionBlock((UIKit.UIView) handler.PlatformView, (Action<NSError?>) args);
		}
		#endif
		else
		{
			Console.WriteLine("Please provide valid InlineInAppView and completionListener");
		}
	}

	public static void SetCloseListener(InlineInAppViewHandler handler, InlineInAppView view, object? args)
	{
		#if ANDROID
		if (handler.PlatformView is Android.Views.View && args is Action)
		{
			DotnetEmarsys.InApp.SetInlineInAppCloseListener((Android.Views.View) handler.PlatformView, new InlineInAppCloseListener((Action) args));
		}
		#elif IOS
		if (handler.PlatformView is UIKit.UIView && args is Action)
		{
			DotnetEmarsys.InApp.SetInlineInAppCloseBlock((UIKit.UIView) handler.PlatformView, (Action) args);
		}
		#endif
		else
		{
			Console.WriteLine("Please provide valid InlineInAppView and closeListener");
		}
	}

	public static void LoadInApp(InlineInAppViewHandler handler, InlineInAppView view, object? args)
	{
		#if ANDROID
		if (handler.PlatformView is Android.Views.View && args is string)
		{
			DotnetEmarsys.InApp.LoadInlineInApp((Android.Views.View) handler.PlatformView, (string) args);
		}
		#elif IOS
		if (handler.PlatformView is UIKit.UIView && args is string)
		{
			DotnetEmarsys.InApp.LoadInlineInApp((UIKit.UIView) handler.PlatformView, (string) args);
		}
		#endif
		else
		{
			Console.WriteLine("Please provide valid InlineInAppView and viewId");
		}
	}

}

#if ANDROID
public partial class InlineInAppViewHandler : ViewHandler<InlineInAppView, Android.Views.View>
{
	protected override Android.Views.View CreatePlatformView()
	{
		return DotnetEmarsys.InApp.InlineInAppView(Platform.AppContext);
	}
}
#elif IOS
public partial class InlineInAppViewHandler : ViewHandler<InlineInAppView, UIKit.UIView>
{
	protected override UIKit.UIView CreatePlatformView()
	{
		return DotnetEmarsys.InApp.InlineInAppView();
	}
}
#endif

#if ANDROID
public class InlineInAppEventHandler : Object, DotnetEmarsysInApp.IInlineInAppEventHandler
{
	private readonly Action<string?, JSONObject?> onInvoked;

	public InlineInAppEventHandler(Action<string?, JSONObject?> onInvoked)
	{
		this.onInvoked = onInvoked;
	}

	public void HandleEvent(string? eventName, JSONObject? payload)
	{
		onInvoked?.Invoke(eventName, payload);
	}
}

public class InlineInAppCloseListener : Object, DotnetEmarsysInApp.IInlineInAppCloseListener
{
	private readonly Action onInvoked;

	public InlineInAppCloseListener(Action onInvoked)
	{
		this.onInvoked = onInvoked;
	}

	public void OnClosed()
	{
		onInvoked?.Invoke();
	}
}
#endif
