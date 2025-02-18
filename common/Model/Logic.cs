namespace EmarsysBinding.Model;

public class Logic(string name, string? query, IList<CartItem>? cartItems, IList<string>? variants)
{

	public readonly string Name = name;
	public readonly string? Query = query;
	public readonly IList<CartItem>? CartItems = cartItems;
	public readonly IList<string>? Variants = variants;

	public static Logic Search(string? searchTerm = null)
	{
		return new Logic("SEARCH", searchTerm, null, null);
	}

	public static Logic Cart(IList<CartItem>? items = null)
	{
		return new Logic("CART", null, items, null);
	}

	public static Logic Related(string? itemId = null)
	{
		return new Logic("RELATED", itemId, null, null);
	}

	public static Logic Category(string? categoryPath = null)
	{
		return new Logic("CATEGORY", categoryPath, null, null);
	}

	public static Logic AlsoBought(string? itemId = null)
	{
		return new Logic("ALSO_BOUGHT", itemId, null, null);
	}

	public static Logic Popular(string? categoryPath = null)
	{
		return new Logic("POPULAR", categoryPath, null, null);
	}

	public static Logic Personal(IList<string>? variants = null)
	{
		return new Logic("PERSONAL", null, null, variants);
	}

	public static Logic Home(IList<string>? variants = null)
	{
		return new Logic("HOME", null, null, variants);
	}

}
