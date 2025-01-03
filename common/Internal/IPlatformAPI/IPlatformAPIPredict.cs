namespace EmarsysBinding.Internal;

#if !IOS && !ANDROID
using EMSCartItem = string;
using EMSRecommendationLogic = string;
using EMSRecommendationFilter = string;
using EMSProduct = string;
#endif

public interface IPlatformAPIPredict
{

	public EMSCartItem BuildCartItem(string itemId, double price, double quantity);

	public void TrackCart(IList<EMSCartItem> items);

	public void TrackPurchase(string orderId, IList<EMSCartItem> items);

	public void TrackItemView(string itemId);

	public void TrackCategoryView(string categoryPath);

	public void TrackSearchTerm(string searchTerm);

	public void TrackTag(string tag, Dictionary<string, string>? attributes);

	public EMSRecommendationLogic BuildLogic(string name, string? query, IList<EMSCartItem>? cartItems, IList<string>? variants);

	public EMSRecommendationFilter BuildFilter(string type, string field, string comparison, IList<string> expectations);

	public void RecommendProducts(EMSRecommendationLogic logic, IList<EMSRecommendationFilter>? filters, int? limit, string? availabilityZone,
		Action<IList<EMSProduct>?, ErrorType?> onCompleted);

	public void TrackRecommendationClick(EMSProduct product);

}
