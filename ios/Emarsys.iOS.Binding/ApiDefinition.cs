using System;
using Foundation;
using UIKit;
using UserNotifications;

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
		// +(void)setup:(EMSConfig * _Nonnull)config;
		[Static]
		[Export ("setup:")]
		void Setup (EMSConfig config);

		// +(void)setContact:(NSInteger)contactFieldId :(NSString * _Nonnull)contactFieldValue :(void (^ _Nonnull)(NSError * _Nullable))completionBlock;
		[Static]
		[Export ("setContact:::")]
		void SetContact (nint contactFieldId, string contactFieldValue, Action<NSError> completionBlock);

		// +(void)clearContact:(void (^ _Nonnull)(NSError * _Nullable))completionBlock;
		[Static]
		[Export ("clearContact:")]
		void ClearContact (Action<NSError> completionBlock);

		// +(void)trackCustomEvent:(NSString * _Nonnull)eventName :(NSDictionary<NSString *,NSString *> * _Nullable)eventAttributes :(void (^ _Nonnull)(NSError * _Nullable))completionBlock;
		[Static]
		[Export ("trackCustomEvent:::")]
		void TrackCustomEvent (string eventName, [NullAllowed] NSDictionary<NSString, NSString> eventAttributes, Action<NSError> completionBlock);

		// +(BOOL)trackDeepLink:(NSUserActivity * _Nonnull)userActivity :(void (^ _Nullable)(NSString * _Nonnull))sourceHandler __attribute__((warn_unused_result("")));
		[Static]
		[Export ("trackDeepLink::")]
		bool TrackDeepLink (NSUserActivity userActivity, [NullAllowed] Action<NSString> sourceHandler);
	}

	// @interface DotnetEmarsysConfig : NSObject
	[BaseType (typeof(NSObject))]
	interface DotnetEmarsysConfig
	{
		// +(EMSConfig * _Nonnull)build:(NSString * _Nullable)applicationCode :(NSString * _Nullable)merchantId :(NSString * _Nullable)sharedKeychainAccessGroup :(BOOL)enableConsoleLogging __attribute__((warn_unused_result("")));
		[Static]
		[Export ("build::::")]
		EMSConfig Build ([NullAllowed] string applicationCode, [NullAllowed] string merchantId, [NullAllowed] string sharedKeychainAccessGroup, bool enableConsoleLogging);

		// +(void)changeApplicationCode:(NSString * _Nullable)applicationCode :(void (^ _Nonnull)(NSError * _Nullable))completionBlock;
		[Static]
		[Export ("changeApplicationCode::")]
		void ChangeApplicationCode ([NullAllowed] string applicationCode, Action<NSError> completionBlock);

		// +(void)changeMerchantId:(NSString * _Nullable)merchantId :(void (^ _Nonnull)(NSError * _Nullable))completionBlock;
		[Static]
		[Export ("changeMerchantId::")]
		void ChangeMerchantId ([NullAllowed] string merchantId, Action<NSError> completionBlock);
	}

	// @interface EMSGeofence : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface EMSGeofence
	{
		[Export ("id")]
		string Id { get; }

		[Export ("lat")]
		double Lat { get; }

		[Export ("lon")]
		double Lon { get; }

		[Export ("r")]
		int Radius { get; }

		[Export ("waitInterval")]
		double WaitInterval { get; }

		[Export ("triggers")]
		EMSGeofenceTrigger[] Triggers { get; }
	}

	// @interface EMSGeofenceTrigger : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface EMSGeofenceTrigger
	{
		[Export ("id")]
		string Id { get; }

		[Export ("type")]
		string Type { get; }

		[Export ("loiteringDelay")]
		int LoiteringDelay { get; }

		[Export ("action")]
		NSDictionary<NSString, NSObject> Action { get; }
	}

	// @interface DotnetEmarsysGeofence : NSObject
	[BaseType (typeof(NSObject))]
	interface DotnetEmarsysGeofence
	{
		// +(void)setInitialEnterTriggerEnabled:(BOOL)initialEnterTriggerEnabled;
		[Static]
		[Export ("setInitialEnterTriggerEnabled:")]
		void SetInitialEnterTriggerEnabled (bool initialEnterTriggerEnabled);

		// +(void)enable:(void (^ _Nonnull)(NSError * _Nullable))completionBlock;
		[Static]
		[Export ("enable:")]
		void Enable (Action<NSError> completionBlock);

		// +(void)disable;
		[Static]
		[Export ("disable")]
		void Disable ();

		// +(BOOL)isEnabled __attribute__((warn_unused_result("")));
		[Static]
		[Export ("isEnabled")]
		bool IsEnabled { get; }

		// +(void)setEventHandler:(void (^ _Nonnull)(NSString * _Nonnull, NSDictionary<NSString *,id> * _Nullable))eventHandler;
		[Static]
		[Export ("setEventHandler:")]
		void SetEventHandler (Action<NSString, NSDictionary<NSString, NSObject>> eventHandler);

		// +(NSArray<EMSGeofence *> * _Nonnull)registeredGeofences __attribute__((warn_unused_result("")));
		[Static]
		[Export ("registeredGeofences")]
		EMSGeofence[] RegisteredGeofences { get; }
	}

	// @interface DotnetEmarsysInApp : NSObject
	[BaseType (typeof(NSObject))]
	interface DotnetEmarsysInApp
	{
		// +(void)setEventHandler:(void (^ _Nonnull)(NSString * _Nonnull, NSDictionary<NSString *,id> * _Nullable))eventHandler;
		[Static]
		[Export ("setEventHandler:")]
		void SetEventHandler (Action<NSString, NSDictionary<NSString, NSObject>> eventHandler);

		// +(void)pause;
		[Static]
		[Export ("pause")]
		void Pause ();

		// +(void)resume;
		[Static]
		[Export ("resume")]
		void Resume ();

		// +(BOOL)isPaused __attribute__((warn_unused_result("")));
		[Static]
		[Export ("isPaused")]
		bool IsPaused { get; }

		// +(UIView * _Nonnull)createInlineInAppView __attribute__((warn_unused_result("")));
		[Static]
		[Export ("createInlineInAppView")]
		UIView CreateInlineInAppView ();

		// +(void)setInlineInAppEventHandler:(UIView * _Nonnull)view :(void (^ _Nonnull)(NSString * _Nonnull, NSDictionary<NSString *,id> * _Nullable))eventHandler;
		[Static]
		[Export ("setInlineInAppEventHandler::")]
		void SetInlineInAppEventHandler (UIView view, Action<NSString, NSDictionary<NSString, NSObject>> eventHandler);

		// +(void)setInlineInAppCompletionListener:(UIView * _Nonnull)view :(void (^ _Nonnull)(NSError * _Nullable))completionBlock;
		[Static]
		[Export ("setInlineInAppCompletionListener::")]
		void SetInlineInAppCompletionListener (UIView view, Action<NSError> completionBlock);

		// +(void)setInlineInAppCloseListener:(UIView * _Nonnull)view :(void (^ _Nonnull)(void))closeBlock;
		[Static]
		[Export ("setInlineInAppCloseListener::")]
		void SetInlineInAppCloseListener (UIView view, Action closeBlock);

		// +(void)loadInlineInApp:(UIView * _Nonnull)view :(NSString * _Nonnull)viewId;
		[Static]
		[Export ("loadInlineInApp::")]
		void LoadInlineInApp (UIView view, string viewId);

		// +(void)setOnEventActionEventHandler:(void (^ _Nonnull)(NSString * _Nonnull, NSDictionary<NSString *,id> * _Nullable))eventHandler;
		[Static]
		[Export ("setOnEventActionEventHandler:")]
		void SetOnEventActionEventHandler (Action<NSString, NSDictionary<NSString, NSObject>> eventHandler);
	}

	// @interface DotnetEmarsysPush : NSObject
	[BaseType (typeof(NSObject))]
	interface DotnetEmarsysPush
	{
		// +(void)setDelegate;
		[Static]
		[Export ("setDelegate")]
		void SetDelegate ();

		// +(void)setEventHandler:(void (^ _Nonnull)(NSString * _Nonnull, NSDictionary<NSString *,id> * _Nullable))eventHandler;
		[Static]
		[Export ("setEventHandler:")]
		void SetEventHandler (Action<NSString, NSDictionary<NSString, NSObject>> eventHandler);

		// +(void)setPushToken:(NSData * _Nonnull)pushToken :(void (^ _Nonnull)(NSError * _Nullable))completionBlock;
		[Static]
		[Export ("setPushToken::")]
		void SetPushToken (NSData pushToken, Action<NSError> completionBlock);

		// +(void)clearPushToken:(void (^ _Nonnull)(NSError * _Nullable))completionBlock;
		[Static]
		[Export ("clearPushToken:")]
		void ClearPushToken (Action<NSError> completionBlock);

		// +(NSString * _Nullable)getPushToken __attribute__((warn_unused_result("")));
		[Static]
		[NullAllowed, Export ("getPushToken")]
		string PushToken { get; }

		// +(void)handleMessage:(NSDictionary * _Nonnull)userInfo;
		[Static]
		[Export ("handleMessage:")]
		void HandleMessage (NSDictionary userInfo);

		// +(void)didReceiveNotificationRequest:(UNNotificationRequest * _Nonnull)request :(void (^ _Nonnull)(UNNotificationContent * _Nonnull))contentHandler;
		[Static]
		[Export ("didReceiveNotificationRequest::")]
		void DidReceiveNotificationRequest (UNNotificationRequest request, Action<UNNotificationContent> contentHandler);

		// +(void)timeWillExpire;
		[Static]
		[Export ("timeWillExpire")]
		void TimeWillExpire ();

		// +(void)setSilentMessageEventHandler:(void (^ _Nonnull)(NSString * _Nonnull, NSDictionary<NSString *,id> * _Nullable))eventHandler;
		[Static]
		[Export ("setSilentMessageEventHandler:")]
		void SetSilentMessageEventHandler (Action<NSString, NSDictionary<NSString, NSObject>> eventHandler);
	}
}
