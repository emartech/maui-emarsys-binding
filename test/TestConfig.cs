namespace Test;

public class TestConfig
{

	private InternalAPIConfig _internal;
	private readonly Mock<IPlatformAPIConfig> _platformMock;

	public TestConfig()
	{
		_platformMock = new Mock<IPlatformAPIConfig>();
		_internal = new InternalAPIConfig(_platformMock.Object);
	}

	[Fact]
	public void Build_ShouldWork()
	{
		_platformMock.Setup(mock => mock.Build(It.IsAny<string?>(), It.IsAny<string?>(), It.IsAny<bool>()))
			.Returns(true);

		bool result = _internal.Build("test-code", "test-id", true);

		_platformMock.Verify(mock => mock.Build("test-code", "test-id", true));
		Assert.True(result);
	}

	[Fact]
	public async Task ChangeApplicationCode_ShouldWork()
	{
		_platformMock.Setup(mock => mock.ChangeApplicationCode(It.IsAny<string>(), It.IsAny<Action<string?>>()))
			.Callback((string _, Action<string?> onCompleted) => onCompleted(null));

		string? result = await _internal.ChangeApplicationCode("test");

		_platformMock.Verify(mock => mock.ChangeApplicationCode("test", It.IsAny<Action<string?>>()));
		Assert.Null(result);
	}

	[Fact]
	public async Task ChangeApplicationCode_ShouldWorkWithError()
	{
		_platformMock.Setup(mock => mock.ChangeApplicationCode(It.IsAny<string>(), It.IsAny<Action<string?>>()))
			.Callback((string _, Action<string?> onCompleted) => onCompleted("error"));

		string? result = await _internal.ChangeApplicationCode("test");

		_platformMock.Verify(mock => mock.ChangeApplicationCode("test", It.IsAny<Action<string?>>()));
		Assert.Equal("error", result);
	}

	[Fact]
	public async Task ChangeMerchantId_ShouldWork()
	{
		_platformMock.Setup(mock => mock.ChangeMerchantId(It.IsAny<string>(), It.IsAny<Action<string?>>()))
			.Callback((string _, Action<string?> onCompleted) => onCompleted(null));

		string? result = await _internal.ChangeMerchantId("test");

		_platformMock.Verify(mock => mock.ChangeMerchantId("test", It.IsAny<Action<string?>>()));
		Assert.Null(result);
	}

	[Fact]
	public async Task ChangeMerchantId_ShouldWorkWithError()
	{
		_platformMock.Setup(mock => mock.ChangeMerchantId(It.IsAny<string>(), It.IsAny<Action<string?>>()))
			.Callback((string _, Action<string?> onCompleted) => onCompleted("error"));

		string? result = await _internal.ChangeMerchantId("test");

		_platformMock.Verify(mock => mock.ChangeMerchantId("test", It.IsAny<Action<string?>>()));
		Assert.Equal("error", result);
	}
}
