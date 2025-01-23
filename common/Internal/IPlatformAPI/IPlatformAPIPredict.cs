namespace EmarsysBinding.Internal;

#if !ANDROID && !IOS
using EMSProduct = string;
#endif
using EmarsysBinding.Model;

public interface IPlatformAPIPredict
{

	public void TrackCart(IList<EMSPredictCartItem> items);

	public void TrackPurchase(string orderId, IList<EMSPredictCartItem> items);

	public void TrackItemView(string itemId);

	public void TrackCategoryView(string categoryPath);

	public void TrackSearchTerm(string searchTerm);

	public void TrackTag(string tag, Dictionary<string, string>? attributes);

	public void RecommendProducts(EMSPredictLogic logic, IList<EMSPredictFilter>? filters, int? limit, string? availabilityZone,
		Action<IList<EMSProduct>?, ErrorType?> onCompleted);

	public void TrackRecommendationClick(EMSProduct product);

}
