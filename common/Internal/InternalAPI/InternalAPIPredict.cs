namespace EmarsysBinding.Internal;

#if !IOS && !ANDROID
using EMSCartItem = string;
using EMSRecommendationLogic = string;
using EMSRecommendationFilter = string;
using EMSProduct = string;
#endif

public class InternalAPIPredict(IPlatformAPIPredict platform)
{

	private readonly IPlatformAPIPredict _platform = platform;

	public EMSCartItem BuildCartItem(string itemId, double price, double quantity)
	{
		return _platform.BuildCartItem(itemId, price, quantity);
	}

	public void TrackCart(IList<EMSCartItem> items)
	{
		_platform.TrackCart(items);
	}

	public void TrackPurchase(string orderId, IList<EMSCartItem> items)
	{
		_platform.TrackPurchase(orderId, items);
	}

	public void TrackItemView(string itemId)
	{
		_platform.TrackItemView(itemId);
	}

	public void TrackCategoryView(string categoryPath)
	{
		_platform.TrackCategoryView(categoryPath);
	}

	public void TrackSearchTerm(string searchTerm)
	{
		_platform.TrackSearchTerm(searchTerm);
	}

	public void TrackTag(string tag, Dictionary<string, string>? attributes)
	{
		_platform.TrackTag(tag, attributes);
	}

	public EMSRecommendationLogic BuildLogic(string name, string? query, IList<EMSCartItem>? cartItems, IList<string>? variants)
	{
		return _platform.BuildLogic(name, query, cartItems, variants);
	}

	public EMSRecommendationFilter BuildFilter(string type, string field, string comparison, IList<string> expectations)
	{
		return _platform.BuildFilter(type, field, comparison, expectations);
	}

	public Task<(IList<EMSProduct>? Products, ErrorType? Error)> RecommendProducts(
		EMSRecommendationLogic logic, IList<EMSRecommendationFilter>? filters, int? limit, string? availabilityZone)
	{
		var cs = new TaskCompletionSource<(IList<EMSProduct>?, ErrorType?)>();
		_platform.RecommendProducts(logic, filters, limit, availabilityZone, (products, error) =>
		{
			cs.SetResult((products, error));
		});
		return cs.Task;
	}

	public void TrackRecommendationClick(EMSProduct product)
	{
		_platform.TrackRecommendationClick(product);
	}

}
