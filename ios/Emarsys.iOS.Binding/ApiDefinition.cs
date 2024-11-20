using System;
using Foundation;
using ObjCRuntime;
using UIKit;

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

		// @property (readonly, nonatomic, strong, class) DotnetEmarsysPush * _Nonnull push;
		[Static]
		[Export ("push", ArgumentSemantic.Strong)]
		DotnetEmarsysPush Push { get; }

		// @property (readonly, nonatomic, strong, class) DotnetEmarsysInApp * _Nonnull inApp;
		[Static]
		[Export ("inApp", ArgumentSemantic.Strong)]
		DotnetEmarsysInApp InApp { get; }
	}

	// @interface DotnetEmarsysInApp : NSObject
	[BaseType (typeof(NSObject))]
	interface DotnetEmarsysInApp
	{
		// -(UIView * _Nonnull)InlineInAppView __attribute__((warn_unused_result("")));
		[Export ("InlineInAppView")]
		UIView InlineInAppView ();

		// -(void)setInlineInAppEventHandler:(UIView * _Nonnull)view :(void (^ _Nonnull)(NSString * _Nonnull, NSDictionary<NSString *,id> * _Nullable))eventHandler;
		[Export ("setInlineInAppEventHandler::")]
		void SetInlineInAppEventHandler (UIView view, Action<NSString, NSDictionary<NSString, NSObject>> eventHandler);

		// -(void)setInlineInAppCompletionBlock:(UIView * _Nonnull)view :(void (^ _Nonnull)(NSError * _Nullable))completionBlock;
		[Export ("setInlineInAppCompletionBlock::")]
		void SetInlineInAppCompletionBlock (UIView view, Action<NSError> completionBlock);

		// -(void)setInlineInAppCloseBlock:(UIView * _Nonnull)view :(void (^ _Nonnull)(void))closeBlock;
		[Export ("setInlineInAppCloseBlock::")]
		void SetInlineInAppCloseBlock (UIView view, Action closeBlock);

		// -(void)loadInlineInApp:(UIView * _Nonnull)view :(NSString * _Nonnull)viewId;
		[Export ("loadInlineInApp::")]
		void LoadInlineInApp (UIView view, string viewId);
	}

	// @interface DotnetEmarsysPush : NSObject
	[BaseType (typeof(NSObject))]
	interface DotnetEmarsysPush
	{
		// -(void)setDelegate;
		[Export ("setDelegate")]
		void SetDelegate ();

		// -(void)setEventHandler:(void (^ _Nonnull)(NSString * _Nonnull, NSDictionary<NSString *,id> * _Nullable))eventHandler;
		[Export ("setEventHandler:")]
		void SetEventHandler (Action<NSString, NSDictionary<NSString, NSObject>> eventHandler);

		// -(void)setPushToken:(NSData * _Nonnull)pushToken;
		[Export ("setPushToken:")]
		void SetPushToken (NSData pushToken);

		// -(void)setPushToken:(NSData * _Nonnull)pushToken :(void (^ _Nonnull)(NSError * _Nullable))completionBlock;
		[Export ("setPushToken::")]
		void SetPushToken (NSData pushToken, Action<NSError> completionBlock);

		// -(void)clearPushToken;
		[Export ("clearPushToken")]
		void ClearPushToken ();

		// -(void)clearPushToken:(void (^ _Nonnull)(NSError * _Nullable))completionBlock;
		[Export ("clearPushToken:")]
		void ClearPushToken (Action<NSError> completionBlock);

		// -(NSString * _Nullable)getPushToken __attribute__((warn_unused_result("")));
		[NullAllowed, Export ("getPushToken")]
		string PushToken { get; }

		// -(void)handleMessage:(NSDictionary * _Nonnull)userInfo;
		[Export ("handleMessage:")]
		void HandleMessage (NSDictionary userInfo);
	}
}
