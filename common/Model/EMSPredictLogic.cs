namespace EmarsysBinding.Model;

public class EMSPredictLogic(string name, string? query, IList<EMSPredictCartItem>? cartItems, IList<string>? variants)
{

	public readonly string Name = name;
	public readonly string? Query = query;
	public readonly IList<EMSPredictCartItem>? CartItems = cartItems;
	public readonly IList<string>? Variants = variants;

	public static EMSPredictLogic Search(string? searchTerm = null)
	{
		return new EMSPredictLogic("SEARCH", searchTerm, null, null);
	}

	public static EMSPredictLogic Cart(IList<EMSPredictCartItem>? items = null)
	{
		return new EMSPredictLogic("CART", null, items, null);
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
