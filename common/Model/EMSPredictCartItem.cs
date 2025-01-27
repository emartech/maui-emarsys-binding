namespace EmarsysBinding.Model;

public class EMSPredictCartItem(string itemId, double price, double quantity)
{

	public readonly string ItemId = itemId;
	public readonly double Price = price;
	public readonly double Quantity = quantity;

}
