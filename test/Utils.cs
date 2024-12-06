global using Xunit;
global using Xunit.Priority;
#if ANDROID
global using EventHandlerAction = System.Action<Android.Content.Context, string, Org.Json.JSONObject?>;
global using ErrorType = Java.Lang.Throwable;
#elif IOS
global using EventHandlerAction = System.Action<Foundation.NSString, Foundation.NSDictionary<Foundation.NSString, Foundation.NSObject>>;
global using ErrorType = Foundation.NSError;
#endif

namespace Test;

using EmarsysBinding;

class Utils
{

	public static void SetupTest()
	{
		// to ensure sdk is ready before other tests
		#if ANDROID
		var config = Emarsys.Config(Platform.CurrentActivity!.Application!, null, null, null, null, true);
		#elif IOS
		var config = Emarsys.Config(null, null, null, true);
		#endif
		Emarsys.Setup(config);
	}

	public static Action<ErrorType?> CompletionListener()
	{
		return (error) => {};
	}

	public static EventHandlerAction EventHandler()
	{
		#if ANDROID
		return (context, eventName, payload) => {};
		#elif IOS
		return (eventName, payload) => {};
		#endif
	}

}
