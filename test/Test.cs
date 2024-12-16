namespace Test;

public class Test
{

	private InternalAPI _internal;
	private readonly Mock<IPlatformAPI> _platformMock;

	public Test()
	{
		_platformMock = new Mock<IPlatformAPI>();
		_internal = new InternalAPI(_platformMock.Object);
	}

	[Fact]
	public void Setup_ShouldWork()
	{
		_platformMock.Setup(mock => mock.Setup(It.IsAny<string>()));

		_internal.Setup("test");

		_platformMock.Verify(mock => mock.Setup("test"));
	}

	[Fact]
	public async Task SetContact_ShouldWork()
	{
		_platformMock.Setup(mock => mock.SetContact(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<Action<string?>>()))
			.Callback((int _, string _, Action<string?> onCompleted) => onCompleted(null));

		string? result = await _internal.SetContact(123, "test");

		_platformMock.Verify(mock => mock.SetContact(123, "test", It.IsAny<Action<string?>>()));
		Assert.Null(result);
	}

	[Fact]
	public async Task SetContact_ShouldWorkWithError()
	{
		_platformMock.Setup(mock => mock.SetContact(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<Action<string?>>()))
			.Callback((int _, string _, Action<string?> onCompleted) => onCompleted("error"));

		string? result = await _internal.SetContact(123, "test");

		_platformMock.Verify(mock => mock.SetContact(123, "test", It.IsAny<Action<string?>>()));
		Assert.Equal("error", result);
	}

	[Fact]
	public async Task ClearContact_ShouldWork()
	{
		_platformMock.Setup(mock => mock.ClearContact(It.IsAny<Action<string?>>()))
			.Callback((Action<string?> onCompleted) => onCompleted(null));

		string? result = await _internal.ClearContact();

		_platformMock.Verify(mock => mock.ClearContact(It.IsAny<Action<string?>>()));
		Assert.Null(result);
	}

	[Fact]
	public async Task ClearContact_ShouldWorkWithError()
	{
		_platformMock.Setup(mock => mock.ClearContact(It.IsAny<Action<string?>>()))
			.Callback((Action<string?> onCompleted) => onCompleted("error"));

		string? result = await _internal.ClearContact();

		_platformMock.Verify(mock => mock.ClearContact(It.IsAny<Action<string?>>()));
		Assert.Equal("error", result);
	}

	[Fact]
	public async Task TrackCustomEvent_ShouldWork()
	{
		_platformMock.Setup(mock => mock.TrackCustomEvent(It.IsAny<string>(), It.IsAny<Dictionary<string, string>?>(), It.IsAny<Action<string?>>()))
			.Callback((string _, Dictionary<string, string> _, Action<string?> onCompleted) => onCompleted(null));
		
		Dictionary<string, string> eventAttributes = new Dictionary<string, string>
		{
			{ "key1", "value1" },
			{ "key2", "value2" }
		};
		string? result = await _internal.TrackCustomEvent("test", eventAttributes);

		_platformMock.Verify(mock => mock.TrackCustomEvent("test", eventAttributes, It.IsAny<Action<string?>>()));
		Assert.Null(result);
	}

	[Fact]
	public async Task TrackCustomEvent_ShouldWorkWithNullAttributes()
	{
		_platformMock.Setup(mock => mock.TrackCustomEvent(It.IsAny<string>(), It.IsAny<Dictionary<string, string>?>(), It.IsAny<Action<string?>>()))
			.Callback((string _, Dictionary<string, string> _, Action<string?> onCompleted) => onCompleted(null));
		
		string? result = await _internal.TrackCustomEvent("test", null);

		_platformMock.Verify(mock => mock.TrackCustomEvent("test", null, It.IsAny<Action<string?>>()));
		Assert.Null(result);
	}

	[Fact]
	public async Task TrackCustomEvent_ShouldWorkWithEmptyAttributes()
	{
		_platformMock.Setup(mock => mock.TrackCustomEvent(It.IsAny<string>(), It.IsAny<Dictionary<string, string>?>(), It.IsAny<Action<string?>>()))
			.Callback((string _, Dictionary<string, string> _, Action<string?> onCompleted) => onCompleted(null));
		
		Dictionary<string, string> eventAttributes = new Dictionary<string, string>();
		string? result = await _internal.TrackCustomEvent("test", eventAttributes);

		_platformMock.Verify(mock => mock.TrackCustomEvent("test", eventAttributes, It.IsAny<Action<string?>>()));
		Assert.Null(result);
	}

	[Fact]
	public async Task TrackCustomEvent_ShouldWorkWithError()
	{
		_platformMock.Setup(mock => mock.TrackCustomEvent(It.IsAny<string>(), It.IsAny<Dictionary<string, string>?>(), It.IsAny<Action<string?>>()))
			.Callback((string _, Dictionary<string, string> _, Action<string?> onCompleted) => onCompleted("error"));
		
		Dictionary<string, string> eventAttributes = new Dictionary<string, string>
		{
			{ "key1", "value1" },
			{ "key2", "value2" }
		};
		string? result = await _internal.TrackCustomEvent("test", eventAttributes);

		_platformMock.Verify(mock => mock.TrackCustomEvent("test", eventAttributes, It.IsAny<Action<string?>>()));
		Assert.Equal("error", result);
	}

	[Fact]
	public async Task TrackCustomEvent_ShouldThrowError()
	{
		_platformMock.Setup(mock => mock.TrackCustomEvent(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>(), It.IsAny<Action<string?>>()))
			.Callback((string _, Dictionary<string, string> _, Action<string?> onCompleted) =>
			{
				throw new Exception("error");
			});

		Dictionary<string, string> eventAttributes = new Dictionary<string, string>
		{
			{ "key1", "value1" },
			{ "key2", "value2" }
		};
		var exception = await Assert.ThrowsAsync<Exception>(async () =>
			await _internal.TrackCustomEvent("test", eventAttributes)
		);

		_platformMock.Verify(mock => mock.TrackCustomEvent("test", eventAttributes, It.IsAny<Action<string?>>()));
		Assert.Equal("error", exception.Message);
	}

	[Fact]
	public void TrackDeepLink_ShouldWork()
	{
		_platformMock.Setup(mock => mock.TrackDeepLink(It.IsAny<string>()));

		_internal.TrackDeepLink("test");

		_platformMock.Verify(mock => mock.TrackDeepLink("test"));
	}

}
