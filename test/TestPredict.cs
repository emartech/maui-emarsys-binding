namespace Test;

using EmarsysBinding.Model;

public class TestPredict
{

	private InternalAPIPredict _internal;
	private readonly Mock<IPlatformAPIPredict> _platformMock;

	public TestPredict()
	{
		_platformMock = new Mock<IPlatformAPIPredict>();
		_internal = new InternalAPIPredict(_platformMock.Object);
	}

	[Fact]
	public void TrackCart_ShouldWork()
	{
		_platformMock.Setup(mock => mock.TrackCart(It.IsAny<IList<EMSPredictCartItem>>()));

		List<EMSPredictCartItem> items = new List<EMSPredictCartItem> { new EMSPredictCartItem("testId", 1.1, 2.2) };
		_internal.TrackCart(items);

		_platformMock.Verify(mock => mock.TrackCart(items));
	}

	[Fact]
	public void TrackPurchase_ShouldWork()
	{
		_platformMock.Setup(mock => mock.TrackPurchase(It.IsAny<string>(), It.IsAny<IList<EMSPredictCartItem>>()));

		List<EMSPredictCartItem> items = new List<EMSPredictCartItem> { new EMSPredictCartItem("testId", 1.1, 2.2) };
		_internal.TrackPurchase("test", items);

		_platformMock.Verify(mock => mock.TrackPurchase("test", items));
	}

	[Fact]
	public void TrackItemView_ShouldWork()
	{
		_platformMock.Setup(mock => mock.TrackItemView(It.IsAny<string>()));

		_internal.TrackItemView("test");

		_platformMock.Verify(mock => mock.TrackItemView("test"));
	}

	[Fact]
	public void TrackCategoryView_ShouldWork()
	{
		_platformMock.Setup(mock => mock.TrackCategoryView(It.IsAny<string>()));

		_internal.TrackCategoryView("test");

		_platformMock.Verify(mock => mock.TrackCategoryView("test"));
	}

	[Fact]
	public void TrackSearchTerm_ShouldWork()
	{
		_platformMock.Setup(mock => mock.TrackSearchTerm(It.IsAny<string>()));

		_internal.TrackSearchTerm("test");

		_platformMock.Verify(mock => mock.TrackSearchTerm("test"));
	}

	[Fact]
	public void TrackTag_ShouldWork()
	{
		_platformMock.Setup(mock => mock.TrackTag(It.IsAny<string>(), It.IsAny<Dictionary<string, string>?>()));
		
		Dictionary<string, string> eventAttributes = new Dictionary<string, string>
		{
			{ "key1", "value1" },
			{ "key2", "value2" }
		};
		_internal.TrackTag("test", eventAttributes);

		_platformMock.Verify(mock => mock.TrackTag("test", eventAttributes));
	}

	[Fact]
	public async Task RecommendProducts_ShouldWork()
	{
		List<EMSPredictProduct> resultProducts = new List<EMSPredictProduct> { new EMSPredictProduct(
			emsProduct: "testEMSProduct",
			productId: "testProductId",
			title: "testTitle",
			linkUrl: new Uri("https://testLinkUrl.com"),
			feature: "testFeature",
			cohort: "testCohort",
			customFields: new Dictionary<string, string> { { "testCustomFieldsKey", "testCustomFieldsValue" } }
		) };
		_platformMock.Setup(mock => mock.RecommendProducts(It.IsAny<EMSPredictLogic>(), It.IsAny<IList<EMSPredictFilter>?>(), It.IsAny<int?>(), It.IsAny<string?>(), It.IsAny<Action<IList<EMSPredictProduct>?, string?>>()))
			.Callback((EMSPredictLogic _, IList<EMSPredictFilter>? _, int? _, string? _, Action<IList<EMSPredictProduct>?, string?> onCompleted) => onCompleted(resultProducts, null));
		
		EMSPredictLogic logic = EMSPredictLogic.Search();
		List<EMSPredictFilter> filters = new List<EMSPredictFilter> { EMSPredictFilter.IncludeIsValue("testField", "testValue") };
		var result = await _internal.RecommendProducts(logic, filters, 3, "testAZ");

		_platformMock.Verify(mock => mock.RecommendProducts(logic, filters, 3, "testAZ", It.IsAny<Action<IList<EMSPredictProduct>?, string?>>()));
		Assert.Equal(resultProducts, result.Products);
		Assert.Null(result.Error);
	}

	[Fact]
	public async Task RecommendProducts_ShouldWorkWithNullOptions()
	{
		List<EMSPredictProduct> resultProducts = new List<EMSPredictProduct> { new EMSPredictProduct(
			emsProduct: "testEMSProduct",
			productId: "testProductId",
			title: "testTitle",
			linkUrl: new Uri("https://testLinkUrl.com"),
			feature: "testFeature",
			cohort: "testCohort",
			customFields: new Dictionary<string, string> { { "testCustomFieldsKey", "testCustomFieldsValue" } }
		) };
		_platformMock.Setup(mock => mock.RecommendProducts(It.IsAny<EMSPredictLogic>(), It.IsAny<IList<EMSPredictFilter>?>(), It.IsAny<int?>(), It.IsAny<string?>(), It.IsAny<Action<IList<EMSPredictProduct>?, string?>>()))
			.Callback((EMSPredictLogic _, IList<EMSPredictFilter>? _, int? _, string? _, Action<IList<EMSPredictProduct>?, string?> onCompleted) => onCompleted(resultProducts, null));
		
		EMSPredictLogic logic = EMSPredictLogic.Search();
		var result = await _internal.RecommendProducts(logic, null, null, null);

		_platformMock.Verify(mock => mock.RecommendProducts(logic, null, null, null, It.IsAny<Action<IList<EMSPredictProduct>?, string?>>()));
		Assert.Equal(resultProducts, result.Products);
		Assert.Null(result.Error);
	}

	[Fact]
	public async Task RecommendProducts_ShouldWorkWithError()
	{
		_platformMock.Setup(mock => mock.RecommendProducts(It.IsAny<EMSPredictLogic>(), It.IsAny<IList<EMSPredictFilter>?>(), It.IsAny<int?>(), It.IsAny<string?>(), It.IsAny<Action<IList<EMSPredictProduct>?, string?>>()))
			.Callback((EMSPredictLogic _, IList<EMSPredictFilter>? _, int? _, string? _, Action<IList<EMSPredictProduct>?, string?> onCompleted) => onCompleted(null, "error"));
		
		EMSPredictLogic logic = EMSPredictLogic.Search();
		List<EMSPredictFilter> filters = new List<EMSPredictFilter> { EMSPredictFilter.IncludeIsValue("testField", "testValue") };
		var result = await _internal.RecommendProducts(logic, filters, 3, "testAZ");

		_platformMock.Verify(mock => mock.RecommendProducts(logic, filters, 3, "testAZ", It.IsAny<Action<IList<EMSPredictProduct>?, string?>>()));
		Assert.Null(result.Products);
		Assert.Equal("error", result.Error);
	}

	[Fact]
	public void TrackRecommendationClick_ShouldWork()
	{
		_platformMock.Setup(mock => mock.TrackRecommendationClick(It.IsAny<EMSPredictProduct>()));
		
		EMSPredictProduct product = new EMSPredictProduct(
			emsProduct: "testEMSProduct",
			productId: "testProductId",
			title: "testTitle",
			linkUrl: new Uri("https://testLinkUrl.com"),
			feature: "testFeature",
			cohort: "testCohort",
			customFields: new Dictionary<string, string> { { "testCustomFieldsKey", "testCustomFieldsValue" } }
		);
		_internal.TrackRecommendationClick(product);

		_platformMock.Verify(mock => mock.TrackRecommendationClick(product));
	}

}
