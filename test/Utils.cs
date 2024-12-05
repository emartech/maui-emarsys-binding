namespace Test;

#if ANDROID
using Android.Content;
using Org.Json;
#elif IOS
using Foundation;
#endif

class Utils
{

	#if ANDROID
	public static Action<Context, string, JSONObject?> EventHandler()
	{
		return (context, eventName, payload) => {};
	}
	#elif IOS
	public static Action<NSString, NSDictionary<NSString, NSObject>> EventHandler()
	{
		return (eventName, payload) => {};
	}
	#endif

}
