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

}
