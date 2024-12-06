namespace Test;

using EmarsysBinding;

[TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
public class PushTest
{

	[Fact, Priority(0)]
	public void Setup()
	{
		Utils.SetupTest();
	}

	[Fact]
	public void SetEventHandler_ShouldWork()
	{
		Emarsys.Push.SetEventHandler(Utils.EventHandler());
	}

	[Fact]
	public void SetPushToken_ShouldWork()
	{
		Emarsys.Push.SetPushToken("test");
	}

	[Fact]
	public void SetPushToken_ShouldWorkWithCompletionListener()
	{
		Emarsys.Push.SetPushToken("test", Utils.CompletionListener());
	}

	[Fact]
	public void SetPushToken_ShouldWorkWithTask()
	{
		var task = EmarsysTask.Push.SetPushToken("test");
		Assert.True(task.GetType().Equals(typeof(Task<ErrorType?>)));
		Assert.Equal(TaskStatus.WaitingForActivation, task.Status);
	}

	[Fact]
	public void ClearPushToken_ShouldWork()
	{
		Emarsys.Push.ClearPushToken();
	}

	[Fact]
	public void ClearPushToken_ShouldWorkWithCompletionListener()
	{
		Emarsys.Push.ClearPushToken(Utils.CompletionListener());
	}

	[Fact]
	public void ClearPushToken_ShouldWorkWithTask()
	{
		var task = EmarsysTask.Push.ClearPushToken();
		Assert.True(task.GetType().Equals(typeof(Task<ErrorType?>)));
		Assert.Equal(TaskStatus.WaitingForActivation, task.Status);
	}

	[Fact]
	public void GetPushToken_ShouldWork()
	{
		Emarsys.Push.GetPushToken();
	}

	[Fact]
	public void HandleMessage_ShouldWork()
	{
		#if ANDROID
		Emarsys.Push.HandleMessage(Platform.CurrentActivity!.ApplicationContext!, new Firebase.Messaging.RemoteMessage.Builder("test").Build());
		#elif IOS
		Emarsys.Push.HandleMessage(new Foundation.NSDictionary());
		#endif
	}

}
