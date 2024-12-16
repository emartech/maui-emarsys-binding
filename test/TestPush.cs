namespace Test;

public class TestPush
{

	private InternalAPIPush _internal;
	private readonly Mock<IPlatformAPIPush> _platformMock;

	public TestPush()
	{
		_platformMock = new Mock<IPlatformAPIPush>();
		_internal = new InternalAPIPush(_platformMock.Object);
	}

	[Fact]
	public void SetEventHandler_ShouldWork()
	{
		_platformMock.Setup(mock => mock.SetEventHandler(It.IsAny<Action<string>>()));

		_internal.SetEventHandler(Utils.EventHandler());

		_platformMock.Verify(mock => mock.SetEventHandler(It.IsAny<Action<string>>()));
	}

	[Fact]
	public async Task SetPushToken_ShouldWork()
	{
		_platformMock.Setup(mock => mock.SetPushToken(It.IsAny<string>(), It.IsAny<Action<string?>>()))
			.Callback((string _, Action<string?> onCompleted) => onCompleted(null));

		string? result = await _internal.SetPushToken("test");

		_platformMock.Verify(mock => mock.SetPushToken("test", It.IsAny<Action<string?>>()));
		Assert.Null(result);
	}

	[Fact]
	public async Task SetPushToken_ShouldWorkWithError()
	{
		_platformMock.Setup(mock => mock.SetPushToken(It.IsAny<string>(), It.IsAny<Action<string?>>()))
			.Callback((string _, Action<string?> onCompleted) => onCompleted("error"));

		string? result = await _internal.SetPushToken("test");

		_platformMock.Verify(mock => mock.SetPushToken("test", It.IsAny<Action<string?>>()));
		Assert.Equal("error", result);
	}

}
