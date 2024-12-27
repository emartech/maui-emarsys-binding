global using EmarsysBinding.Internal;
#if ANDROID
global using EmarsysAndroid;
global using OnCompletedAction = System.Action<Java.Lang.Throwable?>;
global using EventHandlerAction = System.Action<Android.Content.Context, string, Org.Json.JSONObject?>;
global using ErrorType = Java.Lang.Throwable;
#elif IOS
global using EmarsysiOS;
global using OnCompletedAction = System.Action<Foundation.NSError?>;
global using EventHandlerAction = System.Action<Foundation.NSString, Foundation.NSDictionary<Foundation.NSString, Foundation.NSObject>?>;
global using ErrorType = Foundation.NSError;
global using CallbackType = Foundation.NSDictionary<Foundation.NSString, Foundation.NSObject>;
#endif
