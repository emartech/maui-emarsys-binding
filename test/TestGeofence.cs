namespace Test;

using EmarsysBinding.Model;

public class TestGeofence
{

	private InternalAPIGeofence _internal;
	private readonly Mock<IPlatformAPIGeofence> _platformMock;

	public TestGeofence()
	{
		_platformMock = new Mock<IPlatformAPIGeofence>();
		_internal = new InternalAPIGeofence(_platformMock.Object);
	}

	[Fact]
	public void SetInitialEnterTriggerEnabled_ShouldWork()
	{
		_platformMock.Setup(mock => mock.SetInitialEnterTriggerEnabled(It.IsAny<bool>()));

		_internal.SetInitialEnterTriggerEnabled(true);

		_platformMock.Verify(mock => mock.SetInitialEnterTriggerEnabled(true));
	}

	[Fact]
	public async Task Enable_ShouldWork()
	{
		_platformMock.Setup(mock => mock.Enable(It.IsAny<Action<string?>>()))
			.Callback((Action<string?> onCompleted) => onCompleted(null));

		string? result = await _internal.Enable();

		_platformMock.Verify(mock => mock.Enable(It.IsAny<Action<string?>>()));
		Assert.Null(result);
	}

	[Fact]
	public async Task Enable_ShouldWorkWithError()
	{
		_platformMock.Setup(mock => mock.Enable(It.IsAny<Action<string?>>()))
			.Callback((Action<string?> onCompleted) => onCompleted("error"));

		string? result = await _internal.Enable();

		_platformMock.Verify(mock => mock.Enable(It.IsAny<Action<string?>>()));
		Assert.Equal("error", result);
	}

	[Fact]
	public void Disable_ShouldWork()
	{
		_platformMock.Setup(mock => mock.Disable());

		_internal.Disable();

		_platformMock.Verify(mock => mock.Disable());
	}

	[Fact]
	public void IsEnabled_ShouldWork()
	{
		_platformMock.Setup(mock => mock.IsEnabled())
			.Returns(true);

		bool result = _internal.IsEnabled();

		_platformMock.Verify(mock => mock.IsEnabled());
		Assert.True(result);
	}

	[Fact]
	public void SetEventHandler_ShouldWork()
	{
		_platformMock.Setup(mock => mock.SetEventHandler(It.IsAny<Action<string>>()));

		_internal.SetEventHandler(Utils.EventHandler());

		_platformMock.Verify(mock => mock.SetEventHandler(It.IsAny<Action<string>>()));
	}

	[Fact]
	public void GetRegisteredGeofences_ShouldWork()
	{
		List<Geofence> resultGeofences = new List<Geofence> {
			new Geofence(id: "testId", lat: 0, lon: 0, radius: 0, waitInterval: 0, triggers: [])
		};
		_platformMock.Setup(mock => mock.GetRegisteredGeofences())
			.Returns(resultGeofences);

		var result = _internal.GetRegisteredGeofences();

		_platformMock.Verify(mock => mock.GetRegisteredGeofences());
		Assert.Equal(resultGeofences, result);
	}

}
