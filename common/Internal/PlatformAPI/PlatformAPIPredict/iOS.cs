namespace EmarsysBinding.Internal;

using EmarsysBinding.Model;

public partial class PlatformAPIPredict
{

	public void RecommendProducts(EMSPredictLogic logic, IList<EMSPredictFilter>? filters, int? limit, string? availabilityZone,
		Action<IList<EMSProduct>?, ErrorType?> onCompleted)
	{
		var _logicCartItems = logic.CartItems?.Select(i => DotnetEmarsysPredict.BuildCartItem(i.ItemId, i.Price, i.Quantity)).ToArray();
		var _logic = DotnetEmarsysPredict.BuildLogic(logic.Name, logic.Query, _logicCartItems, logic.Variants?.ToArray());
		var _filters = filters?.Select(f => DotnetEmarsysPredict.BuildFilter(f.Type, f.Field, f.Comparison, f.Expectations.ToArray())).ToArray();
		DotnetEmarsysPredict.RecommendProducts(_logic, _filters, limit, availabilityZone, (products, error) =>
		{
			onCompleted(products, error == null ? null : new Exception(error.Description));
		});
	}

}
