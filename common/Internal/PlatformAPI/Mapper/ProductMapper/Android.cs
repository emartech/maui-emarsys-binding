namespace EmarsysBinding.Internal;

using EmarsysBinding.Model;

class ProductMapper
{

	public static List<Product>? Map(IList<EMSProduct>? input)
	{
		if (input == null)
		{
			return null;
		}

		return input.Select(element =>
			{
				return new Product(
					emsProduct: element,
					productId: element.ProductId,
					title: element.Title,
					linkUrl: new Uri(element.LinkUrl.ToString()),
					feature: element.Feature,
					cohort: element.Cohort,
					customFields: ToDictionary(element.CustomFields),
					imageUrl: element.ImageUrl != null ? new Uri(element.ImageUrl.ToString()) : null,
					zoomImageUrl: element.ZoomImageUrl != null ? new Uri(element.ZoomImageUrl.ToString()) : null,
					categoryPath: element.CategoryPath,
					available: element.Available?.BooleanValue(),
					productDescription: element.ProductDescription,
					price: element.Price?.FloatValue(),
					msrp: element.Msrp?.FloatValue(),
					album: element.Album,
					actor: element.Actor,
					artist: element.Artist,
					author: element.Author,
					brand: element.Brand,
					year: element.Year?.IntValue()
				);
			}).ToList();
	}

	public static Dictionary<string, string> ToDictionary(IDictionary<string, string> input)
	{
		var dict = new Dictionary<string, string>();
		foreach (var key in input.Keys)
		{
			dict[key] = input[key];
		}
		return dict;
	}

}
