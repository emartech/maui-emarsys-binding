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

	[Fact]
	public async Task ClearPushToken_ShouldWork()
	{
		_platformMock.Setup(mock => mock.ClearPushToken(It.IsAny<Action<string?>>()))
			.Callback((Action<string?> onCompleted) => onCompleted(null));

		string? result = await _internal.ClearPushToken();

		_platformMock.Verify(mock => mock.ClearPushToken(It.IsAny<Action<string?>>()));
		Assert.Null(result);
	}

	[Fact]
	public async Task ClearPushToken_ShouldWorkWithError()
	{
		_platformMock.Setup(mock => mock.ClearPushToken(It.IsAny<Action<string?>>()))
			.Callback((Action<string?> onCompleted) => onCompleted("error"));

		string? result = await _internal.ClearPushToken();

		_platformMock.Verify(mock => mock.ClearPushToken(It.IsAny<Action<string?>>()));
		Assert.Equal("error", result);
	}

	[Fact]
	public void GetPushToken_ShouldWork()
	{
		_platformMock.Setup(mock => mock.GetPushToken())
			.Returns("test");

		string? result = _internal.GetPushToken();

		_platformMock.Verify(mock => mock.GetPushToken());
		Assert.Equal("test", result);
	}

	[Fact]
	public void HandleMessage_ShouldWork()
	{
		_platformMock.Setup(mock => mock.HandleMessage(It.IsAny<string>()));

		_internal.HandleMessage("test");

		_platformMock.Verify(mock => mock.HandleMessage("test"));
	}

	[Fact]
	public void SetDelegate_ShouldWork()
	{
		_platformMock.Setup(mock => mock.SetDelegate());

		_internal.SetDelegate();

		_platformMock.Verify(mock => mock.SetDelegate());
	}

	[Fact]
	public void DidReceiveNotificationRequest_ShouldWork()
	{
		_platformMock.Setup(mock => mock.DidReceiveNotificationRequest(It.IsAny<string>()));

		_internal.DidReceiveNotificationRequest("test");

		_platformMock.Verify(mock => mock.DidReceiveNotificationRequest("test"));
	}

	[Fact]
	public void TimeWillExpire_ShouldWork()
	{
		_platformMock.Setup(mock => mock.TimeWillExpire());

		_internal.TimeWillExpire();

		_platformMock.Verify(mock => mock.TimeWillExpire());
	}

	[Fact]
	public void SetSilentMessageEventHandler_ShouldWork()
	{
		_platformMock.Setup(mock => mock.SetSilentMessageEventHandler(It.IsAny<Action<string>>()));

		_internal.SetSilentMessageEventHandler(Utils.EventHandler());

		_platformMock.Verify(mock => mock.SetSilentMessageEventHandler(It.IsAny<Action<string>>()));
	}
}
