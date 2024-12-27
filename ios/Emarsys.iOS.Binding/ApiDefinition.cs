using System;
using Foundation;
using UIKit;
using UserNotifications;

namespace EmarsysiOS
{
	// @interface EMSConfig : NSObject
	[BaseType (typeof(NSObject))]
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

		// +(NSString * _Nullable)getApplicationCode __attribute__((warn_unused_result("")));
		[Static]
		[NullAllowed, Export ("getApplicationCode")]
		string ApplicationCode { get; }

		// +(NSString * _Nullable)getMerchantId __attribute__((warn_unused_result("")));
		[Static]
		[NullAllowed, Export ("getMerchantId")]
		string MerchantId { get; }

		// +(NSString * _Nonnull)getClientId __attribute__((warn_unused_result("")));
		[Static]
		[Export ("getClientId")]
		string ClientId { get; }

		// +(NSString * _Nonnull)getLanguageCode __attribute__((warn_unused_result("")));
		[Static]
		[Export ("getLanguageCode")]
		string LanguageCode { get; }

		// +(NSString * _Nonnull)getSdkVersion __attribute__((warn_unused_result("")));
		[Static]
		[Export ("getSdkVersion")]
		string SdkVersion { get; }

		// +(NSNumber * _Nullable)getContactFieldId __attribute__((warn_unused_result("")));
		[Static]
		[NullAllowed, Export ("getContactFieldId")]
		NSNumber ContactFieldId { get; }
	}

	// @interface EMSGeofence : NSObject
	[BaseType (typeof(NSObject))]
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

	// @interface DotnetEmarsysInbox : NSObject
	[BaseType (typeof(NSObject))]
	interface DotnetEmarsysInbox
	{
		// +(void)fetchMessages:(void (^ _Nonnull)(NSDictionary<NSString *,id> * _Nonnull))resultCallback;
		[Static]
		[Export ("fetchMessages:")]
		void FetchMessages (Action<NSDictionary<NSString, NSObject>> resultCallback);

		// +(void)addTag:(NSString * _Nonnull)tag messageId:(NSString * _Nonnull)messageId :(void (^ _Nonnull)(NSError * _Nullable))completionBlock;
		[Static]
		[Export ("addTag:messageId::")]
		void AddTag (string tag, string messageId, Action<NSError> completionBlock);

		// +(void)removeTag:(NSString * _Nonnull)tag messageId:(NSString * _Nonnull)messageId :(void (^ _Nonnull)(NSError * _Nullable))completionBlock;
		[Static]
		[Export ("removeTag:messageId::")]
		void RemoveTag (string tag, string messageId, Action<NSError> completionBlock);
	}

	// @interface EMSCartItem : NSObject
	[BaseType (typeof(NSObject))]
	interface EMSCartItem
	{
	}

	// @interface EMSLogic : NSObject
	[BaseType (typeof(NSObject))]
	interface EMSRecommendationLogic
	{
	}

	// @interface EMSRecommendationFilterProtocol : NSObject
	[BaseType (typeof(NSObject))]
	interface EMSRecommendationFilter
	{
	}

	// @interface EMSProductProtocol : NSObject
	[BaseType (typeof(NSObject))]
	interface EMSProduct
	{
		[Export ("productId")]
		string ProductId { get; }

		[Export ("title")]
		string Title { get; }

		[Export ("linkUrl")]
		NSUrl LinkUrl { get; }

		[Export ("customFields")]
		NSDictionary<NSString, NSObject> CustomFields { get; }

		[Export ("feature")]
		string Feature { get; }

		[Export ("cohort")]
		string Cohort { get; }

		[Export ("imageUrl")]
		NSUrl ImageUrl { get; }

		[Export ("zoomImageUrl")]
		NSUrl ZoomImageUrl { get; }

		[Export ("categoryPath")]
		string CategoryPath { get; }

		[Export ("available")]
		NSNumber Available { get; }

		[Export ("productDescription")]
		string ProductDescription { get; }

		[Export ("price")]
		NSNumber Price { get; }

		[Export ("msrp")]
		NSNumber Msrp { get; }

		[Export ("album")]
		string Album { get; }

		[Export ("actor")]
		string Actor { get; }

		[Export ("artist")]
		string Artist { get; }

		[Export ("author")]
		string Author { get; }

		[Export ("brand")]
		string Brand { get; }

		[Export ("year")]
		NSNumber Year { get; }
	}

	// @interface DotnetEmarsysPredict : NSObject
	[BaseType (typeof(NSObject))]
	interface DotnetEmarsysPredict
	{
		// +(EMSCartItem * _Nonnull)buildCartItem:(NSString * _Nonnull)itemId :(double)price :(double)quantity __attribute__((warn_unused_result("")));
		[Static]
		[Export ("buildCartItem:::")]
		EMSCartItem BuildCartItem (string itemId, double price, double quantity);

		// +(void)trackCart:(NSArray<EMSCartItem *> * _Nonnull)items;
		[Static]
		[Export ("trackCart:")]
		void TrackCart (EMSCartItem[] items);

		// +(void)trackPurchase:(NSString * _Nonnull)orderId :(NSArray<EMSCartItem *> * _Nonnull)items;
		[Static]
		[Export ("trackPurchase::")]
		void TrackPurchase (string orderId, EMSCartItem[] items);

		// +(void)trackItemView:(NSString * _Nonnull)itemId;
		[Static]
		[Export ("trackItemView:")]
		void TrackItemView (string itemId);

		// +(void)trackCategoryView:(NSString * _Nonnull)categoryPath;
		[Static]
		[Export ("trackCategoryView:")]
		void TrackCategoryView (string categoryPath);

		// +(void)trackSearchTerm:(NSString * _Nonnull)searchTerm;
		[Static]
		[Export ("trackSearchTerm:")]
		void TrackSearchTerm (string searchTerm);

		// +(void)trackTag:(NSString * _Nonnull)tag :(NSDictionary<NSString *,NSString *> * _Nullable)attributes;
		[Static]
		[Export ("trackTag::")]
		void TrackTag (string tag, [NullAllowed] NSDictionary<NSString, NSString> attributes);

		// +(EMSLogic * _Nonnull)buildLogic:(NSString * _Nonnull)name :(NSString * _Nullable)query :(NSArray<EMSCartItem *> * _Nullable)cartItems :(NSArray<NSString *> * _Nullable)variants __attribute__((warn_unused_result("")));
		[Static]
		[Export ("buildLogic::::")]
		EMSRecommendationLogic BuildLogic (string name, [NullAllowed] string query, [NullAllowed] EMSCartItem[] cartItems, [NullAllowed] string[] variants);

		// +(id<EMSRecommendationFilterProtocol> _Nonnull)buildFilter:(NSString * _Nonnull)type :(NSString * _Nonnull)field :(NSString * _Nonnull)comparison :(NSArray<NSString *> * _Nonnull)expectations __attribute__((warn_unused_result("")));
		[Static]
		[Export ("buildFilter::::")]
		EMSRecommendationFilter BuildFilter (string type, string field, string comparison, string[] expectations);

		// +(void)recommendProducts:(EMSLogic * _Nonnull)logic :(NSArray<EMSRecommendationFilter *> * _Nullable)filters :(NSNumber * _Nullable)limit :(NSString * _Nullable)availabilityZone :(void (^ _Nonnull)(NSArray<id<EMSProductProtocol>> * _Nullable, NSError * _Nullable))completionBlock;
		[Static]
		[Export ("recommendProducts:::::")]
		void RecommendProducts (EMSRecommendationLogic logic, [NullAllowed] EMSRecommendationFilter[] filters, [NullAllowed] NSNumber limit, [NullAllowed] string availabilityZone, Action<EMSProduct[], NSError> completionBlock);

		// +(void)trackRecommendationClick:(EMSProduct * _Nonnull)product;
		[Static]
		[Export ("trackRecommendationClick:")]
		void TrackRecommendationClick (EMSProduct product);
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
