namespace EmarsysBinding;

using EmarsysBinding.Model;

public class EmarsysPredict
{

	internal EmarsysPredict() {}

	private static InternalAPIPredict _internal = new InternalAPIPredict(new PlatformAPIPredict());

	public void TrackCart(IList<EMSPredictCartItem> items)
	{
		_internal.TrackCart(items);
	}

	public void TrackPurchase(string orderId, IList<EMSPredictCartItem> items)
	{
		_internal.TrackPurchase(orderId, items);
	}

	public void TrackItemView(string itemId)
	{
		_internal.TrackItemView(itemId);
	}

	public void TrackCategoryView(string categoryPath)
	{
		_internal.TrackCategoryView(categoryPath);
	}

	public void TrackSearchTerm(string searchTerm)
	{
		_internal.TrackSearchTerm(searchTerm);
	}

	public void TrackTag(string tag, Dictionary<string, string>? attributes)
	{
		_internal.TrackTag(tag, attributes);
	}

	public Task<(IList<EMSPredictProduct>? Products, ErrorType? Error)> RecommendProducts(
		EMSPredictLogic logic, IList<EMSPredictFilter>? filters = null, int? limit = null, string? availabilityZone = null)
	{	
		return _internal.RecommendProducts(logic, filters, limit, availabilityZone);
	}

	public void TrackRecommendationClick(EMSPredictProduct product)
	{
		_internal.TrackRecommendationClick(product);
	}

}
