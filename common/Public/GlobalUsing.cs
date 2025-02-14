#if ANDROID
global using EmarsysAndroid;
global using EventHandlerAction = System.Action<Android.Content.Context, string, Org.Json.JSONObject?>;
global using OnCompletedAction = System.Action<System.Exception?>;
global using ErrorType = System.Exception;
#elif IOS
global using EmarsysiOS;
global using EventHandlerAction = System.Action<Foundation.NSString, Foundation.NSDictionary<Foundation.NSString, Foundation.NSObject>?>;
global using OnCompletedAction = System.Action<System.Exception?>;
global using ErrorType = System.Exception;
#endif
global using EmarsysBinding.Internal;

public static class Global {

	public static string packageVersion = "0.0.1";

}
