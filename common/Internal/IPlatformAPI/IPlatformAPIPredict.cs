namespace EmarsysBinding.Internal;

using EmarsysBinding.Model;

public interface IPlatformAPIPredict
{

	public void TrackCart(IList<CartItem> items);

	public void TrackPurchase(string orderId, IList<CartItem> items);

	public void TrackItemView(string itemId);

	public void TrackCategoryView(string categoryPath);

	public void TrackSearchTerm(string searchTerm);

	public void TrackTag(string tag, Dictionary<string, string>? attributes);

	public void RecommendProducts(Logic logic, IList<Filter>? filters, int? limit, string? availabilityZone,
		Action<IList<Product>?, ErrorType?> onCompleted);

	public void TrackRecommendationClick(Product product);

}
