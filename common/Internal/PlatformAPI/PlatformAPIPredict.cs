namespace EmarsysBinding.Internal;

#if ANDROID
using Java.Lang;
#endif

public class PlatformAPIPredict : IPlatformAPIPredict
{

	public EMSCartItem BuildCartItem(string itemId, double price, double quantity)
	{
		return DotnetEmarsysPredict.BuildCartItem(itemId, price, quantity);
	}

	public void TrackCart(IList<EMSCartItem> items)
	{
		DotnetEmarsysPredict.TrackCart(items.ToArray());
	}

	public void TrackPurchase(string orderId, IList<EMSCartItem> items)
	{
		DotnetEmarsysPredict.TrackPurchase(orderId, items.ToArray());
	}

	public void TrackItemView(string itemId)
	{
		DotnetEmarsysPredict.TrackItemView(itemId);
	}

	public void TrackCategoryView(string categoryPath)
	{
		DotnetEmarsysPredict.TrackCategoryView(categoryPath);
	}

	public void TrackSearchTerm(string searchTerm)
	{
		DotnetEmarsysPredict.TrackSearchTerm(searchTerm);
	}

	public void TrackTag(string tag, Dictionary<string, string>? attributes)
	{
		DotnetEmarsysPredict.TrackTag(tag, PlatformUtils.ToNativeDictionary(attributes));
	}

	public EMSRecommendationLogic BuildLogic(string name, string? query, IList<EMSCartItem>? cartItems, IList<string>? variants)
	{
		return DotnetEmarsysPredict.BuildLogic(name, query, cartItems?.ToArray(), variants?.ToArray());
	}

	public EMSRecommendationFilter BuildFilter(string type, string field, string comparison, IList<string> expectations)
	{
		return DotnetEmarsysPredict.BuildFilter(type, field, comparison, expectations.ToArray());
	}

	public void RecommendProducts(EMSRecommendationLogic logic, IList<EMSRecommendationFilter>? filters, int? limit, string? availabilityZone,
		Action<IList<EMSProduct>?, ErrorType?> onCompleted)
	{
		#if ANDROID
		DotnetEmarsysPredict.RecommendProducts(logic, filters?.ToArray(), limit != null ? Integer.ValueOf(limit.Value) : null, availabilityZone,
			new RecommendProductsCompletionListener(onCompleted));
		#elif IOS
		DotnetEmarsysPredict.RecommendProducts(logic, filters?.ToArray(), limit, availabilityZone, onCompleted);
		#endif
	}

	public void TrackRecommendationClick(EMSProduct product)
	{
		DotnetEmarsysPredict.TrackRecommendationClick(product);
	}

}

#if ANDROID
class RecommendProductsCompletionListener(Action<IList<EMSProduct>?, Throwable?> action) : Object, DotnetEmarsysPredict.IRecommendProductsCompletionListener
{
	private readonly Action<IList<EMSProduct>?, Throwable?> _action = action;

	public void OnCompleted(IList<EMSProduct>? products, Throwable? errorCause)
	{
		_action.Invoke(products, errorCause);
	}
}
#endif
