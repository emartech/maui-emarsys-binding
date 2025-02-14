namespace EmarsysBinding.Model;

#if !ANDROID && !IOS
using EMSProduct = string;
#endif

public class EMSPredictProduct(EMSProduct emsProduct, string productId, string title, Uri linkUrl, string feature, string cohort,
  Dictionary<string, string> customFields, Uri? imageUrl = null, Uri? zoomImageUrl = null,
  string? categoryPath = null, bool? available = null, string? productDescription = null, float? price = null, float? msrp = null,
  string? album = null, string? actor = null, string? artist = null, string? author = null, string? brand = null, int? year = null)
{

    public readonly EMSProduct EMSProduct = emsProduct;

    public readonly string ProductId = productId;
    public readonly string Title = title;
    public readonly Uri LinkUrl = linkUrl;
    public readonly string Feature = feature;
    public readonly string Cohort = cohort;
    public readonly Dictionary<string, string> CustomFields = customFields;
    public readonly Uri? ImageUrl = imageUrl;
    public readonly Uri? ZoomImageUrl = zoomImageUrl;
    public readonly string? CategoryPath = categoryPath;
    public readonly bool? Available = available;
    public readonly string? ProductDescription = productDescription;
    public readonly float? Price = price;
    public readonly float? Msrp = msrp;
    public readonly string? Album = album;
    public readonly string? Actor = actor;
    public readonly string? Artist = artist;
    public readonly string? Author = author;
    public readonly string? Brand = brand;
    public readonly int? Year = year;

}
