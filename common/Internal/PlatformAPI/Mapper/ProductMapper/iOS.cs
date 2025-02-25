namespace EmarsysBinding.Internal;

using Foundation;
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
					linkUrl: element.LinkUrl!,
					feature: element.Feature,
					cohort: element.Cohort,
					customFields: (Dictionary<string, object>) PlatformUtils.ToDotnetObject(element.CustomFields),
					imageUrl: element.ImageUrl,
					zoomImageUrl: element.ZoomImageUrl,
					categoryPath: element.CategoryPath,
					available: element.Available?.Int32Value == 1,
					productDescription: element.ProductDescription,
					price: element.Price?.FloatValue,
					msrp: element.Msrp?.FloatValue,
					album: element.Album,
					actor: element.Actor,
					artist: element.Artist,
					author: element.Author,
					brand: element.Brand,
					year: element.Year?.Int32Value
				);
			}).ToList();
	}

}
