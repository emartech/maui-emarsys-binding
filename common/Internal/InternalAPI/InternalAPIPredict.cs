namespace EmarsysBinding.Internal;

using EmarsysBinding.Model;

public class InternalAPIPredict(IPlatformAPIPredict platform)
{

	private readonly IPlatformAPIPredict _platform = platform;

	public void TrackCart(IList<CartItem> items)
	{
		_platform.TrackCart(items);
	}

	public void TrackPurchase(string orderId, IList<CartItem> items)
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

	public Task<(IList<Product>? Products, ErrorType? Error)> RecommendProducts(
		Logic logic, IList<Filter>? filters, int? limit, string? availabilityZone)
	{
		var cs = new TaskCompletionSource<(IList<Product>?, ErrorType?)>();
		_platform.RecommendProducts(logic, filters, limit, availabilityZone, (products, error) =>
		{
			cs.SetResult((products, error));
		});
		return cs.Task;
	}

	public void TrackRecommendationClick(Product product)
	{
		_platform.TrackRecommendationClick(product);
	}

}
