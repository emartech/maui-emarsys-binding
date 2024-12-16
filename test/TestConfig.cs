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

}
