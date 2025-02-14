namespace EmarsysBinding.Internal;

using EmarsysBinding.Model;

public partial class PlatformAPIPredict : IPlatformAPIPredict
{

	public void TrackCart(IList<EMSPredictCartItem> items)
	{
		var _items = items.Select(i => DotnetEmarsysPredict.BuildCartItem(i.ItemId, i.Price, i.Quantity)).ToArray();
		DotnetEmarsysPredict.TrackCart(_items);
	}

	public void TrackPurchase(string orderId, IList<EMSPredictCartItem> items)
	{
		var _items = items.Select(i => DotnetEmarsysPredict.BuildCartItem(i.ItemId, i.Price, i.Quantity)).ToArray();
		DotnetEmarsysPredict.TrackPurchase(orderId, _items);
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

	public void TrackRecommendationClick(EMSPredictProduct product)
	{
		DotnetEmarsysPredict.TrackRecommendationClick(product.EMSProduct);
	}

}
