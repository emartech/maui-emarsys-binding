namespace EmarsysBinding.Internal;

#if !ANDROID && !IOS
using EMSProduct = string;
#endif
using EmarsysBinding.Model;

public class InternalAPIPredict(IPlatformAPIPredict platform)
{

	private readonly IPlatformAPIPredict _platform = platform;

	public void TrackCart(IList<EMSPredictCartItem> items)
	{
		_platform.TrackCart(items);
	}

	public void TrackPurchase(string orderId, IList<EMSPredictCartItem> items)
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

	public Task<(IList<EMSPredictProduct>? Products, ErrorType? Error)> RecommendProducts(
		EMSPredictLogic logic, IList<EMSPredictFilter>? filters, int? limit, string? availabilityZone)
	{
		var cs = new TaskCompletionSource<(IList<EMSPredictProduct>?, ErrorType?)>();
		_platform.RecommendProducts(logic, filters, limit, availabilityZone, (products, error) =>
		{
			cs.SetResult((products, error));
		});
		return cs.Task;
	}

	public void TrackRecommendationClick(EMSPredictProduct product)
	{
		_platform.TrackRecommendationClick(product);
	}

}
