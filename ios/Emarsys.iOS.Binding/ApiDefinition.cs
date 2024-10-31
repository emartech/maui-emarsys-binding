using System;
using Foundation;

namespace EmarsysBindingiOS
{
	// @interface DotnetEmarsys : NSObject
	[BaseType (typeof(NSObject))]
	interface DotnetEmarsys
	{
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
}
