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
public class EmarsysTest
{

	[Fact, Priority(0)]
	public void Config_ShouldReturnCorrectValues()
	{
		#if ANDROID
		var sharedPackageNames = new List<string>();
		sharedPackageNames.Add("shared-package-name");
		var config = Emarsys.Config(Platform.CurrentActivity!.Application!, "app-code", "merchant-id", sharedPackageNames, "shared-secret", true);
		Assert.True(config.GetType().Equals(typeof(EmarsysAndroid.DotnetEMSConfig)));
		Assert.Equal(sharedPackageNames, config.SharedPackageNames);
		Assert.Equal("shared-secret", config.SharedSecret);
		#elif IOS
		var config = Emarsys.Config("app-code", "merchant-id", "shared-keychain-access-group", true);
		Assert.True(config.GetType().Equals(typeof(EmarsysiOS.EMSConfig)));
		Assert.Equal("shared-keychain-access-group", config.SharedKeychainAccessGroup);
		#endif
		Assert.Equal("app-code", config.ApplicationCode);
		Assert.Equal("merchant-id", config.MerchantId);
	}

	[Fact, Priority(0)]
	public void Setup_ShouldWork()
	{
		#if ANDROID
		var config = Emarsys.Config(Platform.CurrentActivity!.Application!, null, null, null, null, true);
		#elif IOS
		var config = Emarsys.Config(null, null, null, true);
		#endif
		Emarsys.Setup(config);
	}

	[Fact]
	public void SetContact_ShouldWork()
	{
		Emarsys.SetContact(123, "test");
	}

	[Fact]
	public void SetContact_ShouldWorkWithCompletionListener()
	{
		Emarsys.SetContact(123, "test", (error) => {});
	}

	[Fact]
	public void SetContact_ShouldWorkWithTask()
	{
		var task = EmarsysTask.SetContact(123, "test");
		#if ANDROID
		Assert.True(task.GetType().Equals(typeof(Task<Throwable?>)));
		#elif IOS
		Assert.True(task.GetType().Equals(typeof(Task<NSError?>)));
		#endif
		Assert.Equal(TaskStatus.WaitingForActivation, task.Status);
	}

	[Fact]
	public void ClearContact_ShouldWork()
	{
		Emarsys.ClearContact();
	}

	[Fact]
	public void ClearContact_ShouldWorkWithCompletionListener()
	{
		Emarsys.ClearContact((error) => {});
	}

	[Fact]
	public void ClearContact_ShouldWorkWithTask()
	{
		var task = EmarsysTask.ClearContact();
		#if ANDROID
		Assert.True(task.GetType().Equals(typeof(Task<Throwable?>)));
		#elif IOS
		Assert.True(task.GetType().Equals(typeof(Task<NSError?>)));
		#endif
		Assert.Equal(TaskStatus.WaitingForActivation, task.Status);
	}

	[Fact]
	public void TrackCustomEvent_ShouldWork()
	{
		Dictionary<string, string> eventAttributes = new Dictionary<string, string>
		{
			{ "key", "value" }
		};
		Emarsys.TrackCustomEvent("test", eventAttributes);
	}

	[Fact]
	public void TrackCustomEvent_ShouldWorkWithNullEventAttributes()
	{
		Emarsys.TrackCustomEvent("test", null);
	}

	[Fact]
	public void TrackCustomEvent_ShouldWorkWithCompletionListener()
	{
		Dictionary<string, string> eventAttributes = new Dictionary<string, string>
		{
			{ "key", "value" }
		};
		Emarsys.TrackCustomEvent("test", eventAttributes, (error) => {});
	}

	[Fact]
	public void TrackCustomEvent_ShouldWorkWithTask()
	{
		Dictionary<string, string> eventAttributes = new Dictionary<string, string>
		{
			{ "key", "value" }
		};
		var task = EmarsysTask.TrackCustomEvent("test", eventAttributes);
		#if ANDROID
		Assert.True(task.GetType().Equals(typeof(Task<Throwable?>)));
		#elif IOS
		Assert.True(task.GetType().Equals(typeof(Task<NSError?>)));
		#endif
		Assert.Equal(TaskStatus.WaitingForActivation, task.Status);
	}
}
