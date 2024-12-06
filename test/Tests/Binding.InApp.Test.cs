namespace Test;

using EmarsysBinding;

[TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
public class InAppTest
{

	[Fact, Priority(0)]
	public void Setup()
	{
		Utils.SetupTest();
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
