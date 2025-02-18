namespace EmarsysBinding.Internal;

using Java.Lang;
using EmarsysBinding.Model;

public partial class PlatformAPIPredict
{

	public void RecommendProducts(Logic logic, IList<Filter>? filters, int? limit, string? availabilityZone,
		Action<IList<Product>?, ErrorType?> onCompleted)
	{
		var _logicCartItems = logic.CartItems?.Select(i => DotnetEmarsysPredict.BuildCartItem(i.ItemId, i.Price, i.Quantity)).ToArray();
		var _logic = DotnetEmarsysPredict.BuildLogic(logic.Name, logic.Query, _logicCartItems, logic.Variants?.ToArray());
		var _filters = filters?.Select(f => DotnetEmarsysPredict.BuildFilter(f.Type, f.Field, f.Comparison, f.Expectations.ToArray())).ToArray();
		DotnetEmarsysPredict.RecommendProducts(_logic, _filters, limit != null ? Integer.ValueOf(limit.Value) : null, availabilityZone,
			new RecommendProductsCompletionListener(onCompleted));
	}

}

class RecommendProductsCompletionListener(Action<IList<Product>?, ErrorType?> action) : Object, DotnetEmarsysPredict.IRecommendProductsCompletionListener
{

	private readonly Action<IList<Product>?, ErrorType?> _action = action;

	public void OnCompleted(IList<EMSProduct>? products, Throwable? errorCause)
	{
		_action.Invoke(ProductMapper.Map(products), errorCause == null ? null : new Exception(errorCause.Message));
	}

}
