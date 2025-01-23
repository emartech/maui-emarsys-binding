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
			.Returns("test");

		string result = _internal.Build("test-code", "test-id", true);

		_platformMock.Verify(mock => mock.Build("test-code", "test-id", true));
		Assert.Equal("test", result);
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

	[Fact]
	public void GetApplicationCode_ShouldWork()
	{
		_platformMock.Setup(mock => mock.GetApplicationCode())
			.Returns("test");

		string? result = _internal.GetApplicationCode();

		_platformMock.Verify(mock => mock.GetApplicationCode());
		Assert.Equal("test", result);
	}

	[Fact]
	public void GetMerchantId_ShouldWork()
	{
		_platformMock.Setup(mock => mock.GetMerchantId())
			.Returns("test");

		string? result = _internal.GetMerchantId();

		_platformMock.Verify(mock => mock.GetMerchantId());
		Assert.Equal("test", result);
	}

	[Fact]
	public void GetClientId_ShouldWork()
	{
		_platformMock.Setup(mock => mock.GetClientId())
			.Returns("test");

		string result = _internal.GetClientId();

		_platformMock.Verify(mock => mock.GetClientId());
		Assert.Equal("test", result);
	}

	[Fact]
	public void GetLanguageCode_ShouldWork()
	{
		_platformMock.Setup(mock => mock.GetLanguageCode())
			.Returns("test");

		string result = _internal.GetLanguageCode();

		_platformMock.Verify(mock => mock.GetLanguageCode());
		Assert.Equal("test", result);
	}

	[Fact]
	public void GetSdkVersion_ShouldWork()
	{
		_platformMock.Setup(mock => mock.GetSdkVersion())
			.Returns("test");

		string result = _internal.GetSdkVersion();

		_platformMock.Verify(mock => mock.GetSdkVersion());
		Assert.Equal("test", result);
	}

	[Fact]
	public void GetContactFieldId_ShouldWork()
	{
		_platformMock.Setup(mock => mock.GetContactFieldId())
			.Returns(123);

		int? result = _internal.GetContactFieldId();

		_platformMock.Verify(mock => mock.GetContactFieldId());
		Assert.Equal(123, result);
	}

}
