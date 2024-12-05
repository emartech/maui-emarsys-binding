namespace Test;

using Xunit;
using Xunit.Priority;
using EmarsysBinding;

[TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
public class InAppTest
{

	[Fact, Priority(0)]
	public void Setup() // to ensure sdk is ready before other tests
	{
		#if ANDROID
		var config = Emarsys.Config(Platform.CurrentActivity!.Application!, null, null, null, null, true);
		#elif IOS
		var config = Emarsys.Config(null, null, null, true);
		#endif
		Emarsys.Setup(config);
	}

	[Fact]
	public void SetEventHandler_ShouldWork()
	{
		Emarsys.InApp.SetEventHandler(Utils.EventHandler());
	}

	[Fact]
	public void Pause_ShouldWork()
	{
		Emarsys.InApp.Pause();
	}

	[Fact]
	public void Resume_ShouldWork()
	{
		Emarsys.InApp.Resume();
	}

	[Fact]
	public void IsPaused_ShouldWork()
	{
		Emarsys.InApp.IsPaused();
	}

	[Fact]
	public void SetOnEventActionEventHandler_ShouldWork()
	{
		Emarsys.InApp.SetOnEventActionEventHandler(Utils.EventHandler());
	}

}
