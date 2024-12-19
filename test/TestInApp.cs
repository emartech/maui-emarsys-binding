namespace Test;

public class TestInApp
{

	private InternalAPIInApp _internal;
	private readonly Mock<IPlatformAPIInApp> _platformMock;

	public TestInApp()
	{
		_platformMock = new Mock<IPlatformAPIInApp>();
		_internal = new InternalAPIInApp(_platformMock.Object);
	}

	[Fact]
	public void SetEventHandler_ShouldWork()
	{
		_platformMock.Setup(mock => mock.SetEventHandler(It.IsAny<Action<string>>()));

		_internal.SetEventHandler(Utils.EventHandler());

		_platformMock.Verify(mock => mock.SetEventHandler(It.IsAny<Action<string>>()));
	}

	[Fact]
	public void Pause_ShouldWork()
	{
		_platformMock.Setup(mock => mock.Pause());

		_internal.Pause();

		_platformMock.Verify(mock => mock.Pause());
	}

	[Fact]
	public void Resume_ShouldWork()
	{
		_platformMock.Setup(mock => mock.Resume());

		_internal.Resume();

		_platformMock.Verify(mock => mock.Resume());
	}

	[Fact]
	public void IsPaused_ShouldWork()
	{
		_platformMock.Setup(mock => mock.IsPaused())
			.Returns(true);

		bool result = _internal.IsPaused();

		_platformMock.Verify(mock => mock.IsPaused());
		Assert.True(result);
	}

	[Fact]
	public void CreateInlineInAppView_ShouldWork()
	{
		_platformMock.Setup(mock => mock.CreateInlineInAppView())
			.Returns("test");

		string result = _internal.CreateInlineInAppView();

		_platformMock.Verify(mock => mock.CreateInlineInAppView());
		Assert.Equal("test", result);
	}

	[Fact]
	public void SetInlineInAppEventHandler_ShouldWork()
	{
		_platformMock.Setup(mock => mock.SetInlineInAppEventHandler(It.IsAny<string>(), It.IsAny<Action<string>>()));

		_internal.SetInlineInAppEventHandler("test", Utils.EventHandler());

		_platformMock.Verify(mock => mock.SetInlineInAppEventHandler("test", It.IsAny<Action<string>>()));
	}

	[Fact]
	public void SetInlineInAppCompletionListener_ShouldWork()
	{
		_platformMock.Setup(mock => mock.SetInlineInAppCompletionListener(It.IsAny<string>(), It.IsAny<Action<string>>()));

		_internal.SetInlineInAppCompletionListener("test", (error) => {});

		_platformMock.Verify(mock => mock.SetInlineInAppCompletionListener("test", It.IsAny<Action<string>>()));
	}

	[Fact]
	public void SetInlineInAppCloseListener_ShouldWork()
	{
		_platformMock.Setup(mock => mock.SetInlineInAppCloseListener(It.IsAny<string>(), It.IsAny<Action>()));

		_internal.SetInlineInAppCloseListener("test", () => {});

		_platformMock.Verify(mock => mock.SetInlineInAppCloseListener("test", It.IsAny<Action>()));
	}

	[Fact]
	public void LoadInlineInApp_ShouldWork()
	{
		_platformMock.Setup(mock => mock.LoadInlineInApp(It.IsAny<string>(), It.IsAny<string>()));

		_internal.LoadInlineInApp("test", "test-id");

		_platformMock.Verify(mock => mock.LoadInlineInApp("test", "test-id"));
	}

	[Fact]
	public void SetOnEventActionEventHandler_ShouldWork()
	{
		_platformMock.Setup(mock => mock.SetOnEventActionEventHandler(It.IsAny<Action<string>>()));

		_internal.SetOnEventActionEventHandler(Utils.EventHandler());

		_platformMock.Verify(mock => mock.SetOnEventActionEventHandler(It.IsAny<Action<string>>()));
	}
}
