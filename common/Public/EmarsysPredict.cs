namespace EmarsysBinding;

public class EmarsysPredict
{

	private static InternalAPIPredict _internal = new InternalAPIPredict(new PlatformAPIPredict());

	public EMSCartItem BuildCartItem(string itemId, double price, double quantity)
	{
		return _internal.BuildCartItem(itemId, price, quantity);
	}

	public void TrackCart(IList<EMSPredictCartItem> items)
	{
		var _items = items.Select(i => i.Item).ToArray();
		_internal.TrackCart(_items);
	}

	public void TrackPurchase(string orderId, IList<EMSPredictCartItem> items)
	{
		var _items = items.Select(i => i.Item).ToArray();
		_internal.TrackPurchase(orderId, _items);
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

	public EMSRecommendationLogic BuildLogic(string name, string? query, IList<EMSCartItem>? cartItems, IList<string>? variants)
	{
		return _internal.BuildLogic(name, query, cartItems, variants);
	}

	public EMSRecommendationFilter BuildFilter(string type, string field, string comparison, IList<string> expectations)
	{
		return _internal.BuildFilter(type, field, comparison, expectations);
	}

	public Task<(IList<EMSProduct>? Products, ErrorType? Error)> RecommendProducts(
		EMSPredictLogic logic, IList<EMSPredictFilter>? filters = null, int? limit = null, string? availabilityZone = null)
	{	
		var _filters = filters?.Select(f => f.Filter).ToArray();
		return _internal.RecommendProducts(logic.Logic, _filters, limit, availabilityZone);
	}

	public void TrackRecommendationClick(EMSProduct product)
	{
		_internal.TrackRecommendationClick(product);
	}

}

public class EMSPredictCartItem(string itemId, double price, double quantity)
{
	public readonly EMSCartItem Item = Emarsys.Predict.BuildCartItem(itemId, price, quantity);
}

public class EMSPredictLogic(string name, string? query, IList<EMSCartItem>? cartItems, IList<string>? variants)
{
	public readonly EMSRecommendationLogic Logic = Emarsys.Predict.BuildLogic(name, query, cartItems, variants);

	public static EMSPredictLogic Search(string? searchTerm = null)
	{
		return new EMSPredictLogic("SEARCH", searchTerm, null, null);
	}

	public static EMSPredictLogic Cart(IList<EMSPredictCartItem>? items = null)
	{
		var _items = items?.Select(i => i.Item).ToArray();
		return new EMSPredictLogic("CART", null, _items, null);
	}

	public static EMSPredictLogic Related(string? itemId = null)
	{
		return new EMSPredictLogic("RELATED", itemId, null, null);
	}

	public static EMSPredictLogic Category(string? categoryPath = null)
	{
		return new EMSPredictLogic("CATEGORY", categoryPath, null, null);
	}

	public static EMSPredictLogic AlsoBought(string? itemId = null)
	{
		return new EMSPredictLogic("ALSO_BOUGHT", itemId, null, null);
	}

	public static EMSPredictLogic Popular(string? categoryPath = null)
	{
		return new EMSPredictLogic("POPULAR", categoryPath, null, null);
	}

	public static EMSPredictLogic Personal(IList<string>? variants = null)
	{
		return new EMSPredictLogic("PERSONAL", null, null, variants);
	}

	public static EMSPredictLogic Home(IList<string>? variants = null)
	{
		return new EMSPredictLogic("HOME", null, null, variants);
	}

}

public class EMSPredictFilter(string type, string field, string comparison, IList<string> expectations)
{
	public readonly EMSRecommendationFilter Filter = Emarsys.Predict.BuildFilter(type, field, comparison, expectations);

	public static EMSPredictFilter IncludeIsValue(string field, string value)
	{
		return new EMSPredictFilter("INCLUDE", field, "IS", [value]);
	}

	public static EMSPredictFilter IncludeInValues(string field, IList<string> values)
	{
		return new EMSPredictFilter("INCLUDE", field, "IN", values);
	}

	public static EMSPredictFilter IncludeHasValue(string field, string value)
	{
		return new EMSPredictFilter("INCLUDE", field, "HAS", [value]);
	}

	public static EMSPredictFilter IncludeOverlapsValues(string field, IList<string> values)
	{
		return new EMSPredictFilter("INCLUDE", field, "OVERLAPS", values);
	}

	public static EMSPredictFilter ExcludeIsValue(string field, string value)
	{
		return new EMSPredictFilter("EXCLUDE", field, "IS", [value]);
	}

	public static EMSPredictFilter ExcludeInValues(string field, IList<string> values)
	{
		return new EMSPredictFilter("EXCLUDE", field, "IN", values);
	}

	public static EMSPredictFilter ExcludeHasValue(string field, string value)
	{
		return new EMSPredictFilter("EXCLUDE", field, "HAS", [value]);
	}

	public static EMSPredictFilter ExcludeOverlapsValues(string field, IList<string> values)
	{
		return new EMSPredictFilter("EXCLUDE", field, "OVERLAPS", values);
	}

}
