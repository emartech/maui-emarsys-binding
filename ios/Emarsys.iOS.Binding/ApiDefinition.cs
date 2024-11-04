using System;
using Foundation;
using ObjCRuntime;

namespace EmarsysiOS
{
	// @interface DotnetEmarsys : NSObject
	[BaseType (typeof(NSObject))]
	interface DotnetEmarsys
	{
		// @property (copy, nonatomic, class) void (^ _Nullable)(NSString * _Nonnull, NSDictionary<NSString *,id> * _Nullable) pushEventHandler;
		[Static]
		[NullAllowed, Export ("pushEventHandler", ArgumentSemantic.Copy)]
		Action<NSString, NSDictionary<NSString, NSObject>> PushEventHandler { get; set; }

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

		// +(void)clearContact;
		[Static]
		[Export ("clearContact")]
		void ClearContact ();
	}
}
