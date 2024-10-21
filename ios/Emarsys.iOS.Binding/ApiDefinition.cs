using Foundation;

namespace EmarsysiOS
{
	// @interface DotnetEmarsys : NSObject
	[BaseType (typeof(NSObject))]
	interface DotnetEmarsys
	{
		// +(NSString * _Nonnull)getStringWithMyString:(NSString * _Nonnull)myString __attribute__((warn_unused_result("")));
		[Static]
		[Export ("getStringWithMyString:")]
		string GetString (string myString);
	}
}
