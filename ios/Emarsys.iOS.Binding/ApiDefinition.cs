using System;
using Foundation;

namespace EmarsysiOS
{
	// @interface EMSConfig : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface EMSConfig
	{
	}

	// @interface DotnetEmarsys : NSObject
	[BaseType (typeof(NSObject))]
	interface DotnetEmarsys
	{
		// +(EMSConfig * _Nonnull)config:(NSString * _Nullable)applicationCode :(NSString * _Nullable)merchantId :(NSString * _Nullable)sharedKeychainAccessGroup :(BOOL)enableConsoleLogging __attribute__((warn_unused_result("")));
		[Static]
		[Export ("config::::")]
		EMSConfig Config ([NullAllowed] string applicationCode, [NullAllowed] string merchantId, [NullAllowed] string sharedKeychainAccessGroup, bool enableConsoleLogging);

		// +(void)setup:(EMSConfig * _Nonnull)config;
		[Static]
		[Export ("setup:")]
		void Setup (EMSConfig config);

		// +(void)setContact:(NSInteger)contactFieldId :(NSString * _Nonnull)contactFieldValue;
		[Static]
		[Export ("setContact::")]
		void SetContact (nint contactFieldId, string contactFieldValue);

		// +(void)setContact:(NSInteger)contactFieldId :(NSString * _Nonnull)contactFieldValue :(void (^ _Nonnull)(NSError * _Nullable))completionBlock;
		[Static]
		[Export ("setContact:::")]
		void SetContact (nint contactFieldId, string contactFieldValue, Action<NSError> completionBlock);

		// +(void)clearContact;
		[Static]
		[Export ("clearContact")]
		void ClearContact ();

		// +(void)clearContact:(void (^ _Nonnull)(NSError * _Nullable))completionBlock;
		[Static]
		[Export ("clearContact:")]
		void ClearContact (Action<NSError> completionBlock);

		// +(DotnetEmarsysPush * _Nonnull)getPush __attribute__((warn_unused_result("")));
		[Static]
		[Export ("getPush")]
		DotnetEmarsysPush Push { get; }
	}

	// @interface DotnetEmarsysPush : NSObject
	[BaseType (typeof(NSObject))]
	interface DotnetEmarsysPush
	{
		// -(void)setDelegate;
		[Export ("setDelegate")]
		void SetDelegate ();

		// -(void)setPushToken:(NSData * _Nonnull)pushToken;
		[Export ("setPushToken:")]
		void SetPushToken (NSData pushToken);

		// -(void)setPushToken:(NSData * _Nonnull)pushToken :(void (^ _Nonnull)(NSError * _Nullable))completionBlock;
		[Export ("setPushToken::")]
		void SetPushToken (NSData pushToken, Action<NSError> completionBlock);

		// -(void)setEventHandler:(void (^ _Nonnull)(NSString * _Nonnull, NSDictionary<NSString *,id> * _Nullable))eventHandler;
		[Export ("setEventHandler:")]
		void SetEventHandler (Action<NSString, NSDictionary<NSString, NSObject>> eventHandler);

		// -(void)handleMessage:(NSDictionary * _Nonnull)userInfo;
		[Export ("handleMessage:")]
		void HandleMessage (NSDictionary userInfo);
	}
}
