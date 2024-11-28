namespace Test;

using Xunit;
using Xunit.Priority;
#if ANDROID
using Java.Lang;
#elif IOS
using Foundation;
#endif
using EmarsysBinding;

[TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
public class PushTest
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
		#if ANDROID
		Emarsys.Push.SetEventHandler((context, eventName, payload) => {});
		#elif IOS
		Emarsys.Push.SetEventHandler((eventName, payload) => {});
		#endif
	}

	[Fact]
	public void SetPushToken_ShouldWork()
	{
		Emarsys.Push.SetPushToken("test");
	}

	[Fact]
	public void SetPushToken_ShouldWorkWithCompletionListener()
	{
		Emarsys.Push.SetPushToken("test", (error) => {});
	}

	[Fact]
	public void SetPushToken_ShouldWorkWithTask()
	{
		var task = EmarsysTask.Push.SetPushToken("test");
		#if ANDROID
		Assert.True(task.GetType().Equals(typeof(Task<Throwable?>)));
		#elif IOS
		Assert.True(task.GetType().Equals(typeof(Task<NSError?>)));
		#endif
		Assert.Equal(TaskStatus.WaitingForActivation, task.Status);
	}

}
