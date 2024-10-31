using System;
using Foundation;
using ObjCRuntime;

namespace EmarsysBindingiOS
{
	// @interface DotnetEmarsys : NSObject
	[BaseType (typeof(NSObject))]
	interface DotnetEmarsys
	{
		// +(void)setEmarsysEventListener:(id<EmarsysEventListener> _Nonnull)listener;
    [Static]
    [Export("setEmarsysEventListener:")]
    void SetEventListener(EmarsysEventListener listener);

		// +(void)setupWithApplicationCode:(NSString * _Nonnull)applicationCode merchantId:(NSString * _Nullable)merchantId;
		[Static]
		[Export ("setupWithApplicationCode:merchantId:")]
		void Setup (string applicationCode, [NullAllowed] string merchantId);

		// +(void)setPushTokenWithToken:(NSData * _Nonnull)token;
		[Static]
		[Export ("setPushTokenWithToken:")]
		void SetPushToken (NSData token);

		// +(void)setContactWithContactFieldId:(NSInteger)contactFieldId contactFieldValue:(NSString * _Nonnull)contactFieldValue;
		[Static]
		[Export ("setContactWithContactFieldId:contactFieldValue:")]
		void SetContact (nint contactFieldId, string contactFieldValue);
	}

	[BaseType(typeof(NSObject))]
	[Model]
	[Protocol]
	interface EmarsysEventListener
	{
		[Abstract]
		[Export("onEventWithEventName:payload:")]
		void OnEvent(string eventName, [NullAllowed] NSDictionary payload);
	}
}
