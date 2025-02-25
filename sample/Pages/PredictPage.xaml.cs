﻿namespace Sample;

using EmarsysBinding;
using EmarsysBinding.Model;

public partial class PredictPage : ContentPage
{

	Product? RecommendedProduct;

	public PredictPage()
	{
		InitializeComponent();
	}

	private void OnTrackCartClicked(object sender, EventArgs e)
	{
		List<CartItem> items = new List<CartItem>
		{
			new CartItem("item1", 1.1, 1.0),
			new CartItem("item2", 2.2, 2.0)
		};
		Emarsys.Predict.TrackCart(items);
		Utils.LogResult("TrackCart");
	}

	private void OnTrackPurchaseClicked(object sender, EventArgs e)
	{
		string orderId = "order1";
		List<CartItem> items = new List<CartItem>
		{
			new CartItem("item1", 1.1, 1.0),
			new CartItem("item2", 2.2, 2.0)
		};
		Emarsys.Predict.TrackPurchase(orderId, items);
		Utils.LogResult("TrackPurchase");
	}

	private void OnTrackItemViewClicked(object sender, EventArgs e)
	{
		string itemId = "item1";
		Emarsys.Predict.TrackItemView(itemId);
		Utils.LogResult("TrackItemView");
	}

	private void OnTrackCategoryViewClicked(object sender, EventArgs e)
	{
		string categoryPath = "category1";
		Emarsys.Predict.TrackCategoryView(categoryPath);
		Utils.LogResult("TrackCategoryView");
	}

	private void OnTrackSearchTermClicked(object sender, EventArgs e)
	{
		string searchTerm = "search";
		Emarsys.Predict.TrackSearchTerm(searchTerm);
		Utils.LogResult("TrackSearchTerm");
	}

	private void OnTrackTagClicked(object sender, EventArgs e)
	{
		string tag = "tag";
		Dictionary<string, string> attributes = new Dictionary<string, string>
		{
			{ "key1", "value1" },
			{ "key2", "value2" }
		};
		Emarsys.Predict.TrackTag(tag, attributes);
		Utils.LogResult("TrackTag");
	}

	private async void OnRecommendProductsClicked(object sender, EventArgs e)
	{
		Logic logic = Logic.Home(["1", "2"]);
		List<Filter> filters = new List<Filter> { Filter.ExcludeIsValue("field", "value") };
		int limit = 3;
		string availabilityZone = "en";
		var result = await Emarsys.Predict.RecommendProducts(logic, filters, limit, availabilityZone);
		Utils.LogResult("RecommendProducts", result.Error, $"{result.Products?.Count}");
		if (result.Products != null && result.Products.Count > 0)
		{
			RecommendedProduct = result.Products[0];
			foreach (var p in result.Products)
			{
				Console.Write($"{p.ProductId}, {p.Title}, {p.LinkUrl}, {p.Feature}, {p.Cohort}, " +
					$"{p.ImageUrl}, {p.ZoomImageUrl}, {p.CategoryPath}, {p.Available}, {p.ProductDescription}, {p.Price}, {p.Msrp}, " +
					$"{p.Album}, {p.Actor}, {p.Artist}, {p.Author}, {p.Brand}, {p.Year}, {{ ");
				foreach (var f in p.CustomFields)
				{
					Console.Write($"{f.Key}: {f.Value}, ");
				}
				Console.WriteLine("}");
			}
		}
	}

	private void OnTrackRecommendationClickClicked(object sender, EventArgs e)
	{
		if (RecommendedProduct != null)
		{
			Emarsys.Predict.TrackRecommendationClick(RecommendedProduct);
			Utils.LogResult("TrackRecommendationClick");
		}
		else
		{
			Utils.DisplayAlert("Call Recommend Products first!");
		}
	}

}
