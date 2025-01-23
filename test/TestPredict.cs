namespace Test;

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
	public void BuildCartItem_ShouldWork()
	{
		_platformMock.Setup(mock => mock.BuildCartItem(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>()))
			.Returns("test");;

		string result = _internal.BuildCartItem("test", 1.0, 1.0);

		_platformMock.Verify(mock => mock.BuildCartItem("test", 1.0, 1.0));
		Assert.Equal("test", result);
	}

	[Fact]
	public void TrackCart_ShouldWork()
	{
		_platformMock.Setup(mock => mock.TrackCart(It.IsAny<IList<string>>()));

		List<string> items = new List<string> { "test1", "test2" };
		_internal.TrackCart(items);

		_platformMock.Verify(mock => mock.TrackCart(items));
	}

	[Fact]
	public void TrackPurchase_ShouldWork()
	{
		_platformMock.Setup(mock => mock.TrackPurchase(It.IsAny<string>(), It.IsAny<IList<string>>()));

		List<string> items = new List<string> { "test1", "test2" };
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
	public void BuildLogic_ShouldWork()
	{
		_platformMock.Setup(mock => mock.BuildLogic(It.IsAny<string>(), It.IsAny<string?>(), It.IsAny<IList<string>?>(), It.IsAny<IList<string>?>()))
			.Returns("test");;

		List<string> cartItems = new List<string> { "testCartItems" };
		List<string> variants = new List<string> { "testVariants" };
		string result = _internal.BuildLogic("testName", "testQuery", cartItems, variants);

		_platformMock.Verify(mock => mock.BuildLogic("testName", "testQuery", cartItems, variants));
		Assert.Equal("test", result);
	}

	[Fact]
	public void BuildFilter_ShouldWork()
	{
		_platformMock.Setup(mock => mock.BuildFilter(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<IList<string>>()))
			.Returns("test");;

		List<string> expectations = new List<string> { "testExpectation" };
		string result = _internal.BuildFilter("testType", "testField", "testComparison", expectations);

		_platformMock.Verify(mock => mock.BuildFilter("testType", "testField", "testComparison", expectations));
		Assert.Equal("test", result);
	}

	[Fact]
	public async Task RecommendProducts_ShouldWork()
	{
		List<string> resultProducts = new List<string> { "test" };
		_platformMock.Setup(mock => mock.RecommendProducts(It.IsAny<string>(), It.IsAny<IList<string>?>(), It.IsAny<int?>(), It.IsAny<string?>(), It.IsAny<Action<IList<string>?, string?>>()))
			.Callback((string _, IList<string>? _, int? _, string? _, Action<IList<string>?, string?> onCompleted) => onCompleted(resultProducts, null));
		
		List<string> filters = new List<string> { "testFilter" };
		var result = await _internal.RecommendProducts("testLogic", filters, 3, "testAZ");

		_platformMock.Verify(mock => mock.RecommendProducts("testLogic", filters, 3, "testAZ", It.IsAny<Action<IList<string>?, string?>>()));
		Assert.Equal(resultProducts, result.Products);
		Assert.Null(result.Error);
	}

	[Fact]
	public async Task RecommendProducts_ShouldWorkWithNullOptions()
	{
		List<string> resultProducts = new List<string> { "test" };
		_platformMock.Setup(mock => mock.RecommendProducts(It.IsAny<string>(), It.IsAny<IList<string>?>(), It.IsAny<int?>(), It.IsAny<string?>(), It.IsAny<Action<IList<string>?, string?>>()))
			.Callback((string _, IList<string>? _, int? _, string? _, Action<IList<string>?, string?> onCompleted) => onCompleted(resultProducts, null));
		
		var result = await _internal.RecommendProducts("testLogic", null, null, null);

		_platformMock.Verify(mock => mock.RecommendProducts("testLogic", null, null, null, It.IsAny<Action<IList<string>?, string?>>()));
		Assert.Equal(resultProducts, result.Products);
		Assert.Null(result.Error);
	}

	[Fact]
	public async Task RecommendProducts_ShouldWorkWithError()
	{
		_platformMock.Setup(mock => mock.RecommendProducts(It.IsAny<string>(), It.IsAny<IList<string>?>(), It.IsAny<int?>(), It.IsAny<string?>(), It.IsAny<Action<IList<string>?, string?>>()))
			.Callback((string _, IList<string>? _, int? _, string? _, Action<IList<string>?, string?> onCompleted) => onCompleted(null, "error"));
		
		List<string> filters = new List<string> { "testFilter" };
		var result = await _internal.RecommendProducts("testLogic", filters, 3, "testAZ");

		_platformMock.Verify(mock => mock.RecommendProducts("testLogic", filters, 3, "testAZ", It.IsAny<Action<IList<string>?, string?>>()));
		Assert.Null(result.Products);
		Assert.Equal("error", result.Error);
	}

	[Fact]
	public void TrackRecommendationClick_ShouldWork()
	{
		_platformMock.Setup(mock => mock.TrackRecommendationClick(It.IsAny<string>()));
		
		_internal.TrackRecommendationClick("test");

		_platformMock.Verify(mock => mock.TrackRecommendationClick("test"));
	}

}
