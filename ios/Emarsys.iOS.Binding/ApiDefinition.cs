using System;
using Foundation;
using ObjCRuntime;

namespace EmarsysiOS
{
	// @interface DotnetEMSConfig : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface DotnetEMSConfig
	{
	}

	// @interface DotnetEmarsys : NSObject
	[BaseType (typeof(NSObject))]
	interface DotnetEmarsys
	{
		// @property (copy, nonatomic, class) void (^ _Nullable)(NSString * _Nonnull, NSDictionary<NSString *,id> * _Nullable) pushEventHandler;
		[Static]
		[NullAllowed, Export ("pushEventHandler", ArgumentSemantic.Copy)]
		Action<NSString, NSDictionary<NSString, NSObject>> PushEventHandler { get; set; }

		// +(void)setup:(DotnetEMSConfig * _Nonnull)config;
		[Static]
		[Export ("setup:")]
		void Setup (DotnetEMSConfig config);

		// +(DotnetEMSConfig * _Nonnull)config:(NSString * _Nullable)applicationCode :(NSString * _Nullable)merchantId :(NSString * _Nullable)sharedKeychainAccessGroup :(BOOL)enableLogs __attribute__((warn_unused_result("")));
		[Static]
		[Export ("config::::")]
		DotnetEMSConfig Config ([NullAllowed] string applicationCode, [NullAllowed] string merchantId, [NullAllowed] string sharedKeychainAccessGroup, bool enableLogs);

		// +(void)setPushToken:(NSData * _Nonnull)token;
		[Static]
		[Export ("setPushToken:")]
		void SetPushToken (NSData token);

		// +(void)setContact:(NSInteger)contactFieldId :(NSString * _Nonnull)contactFieldValue;
		[Static]
		[Export ("setContact::")]
		void SetContact (nint contactFieldId, string contactFieldValue);

		// +(void)clearContact;
		[Static]
		[Export ("clearContact")]
		void ClearContact ();
	}
}
