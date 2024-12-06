namespace Test;

#if ANDROID
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
		Emarsys.SetContact(123, "test", Utils.CompletionListener());
	}

	[Fact]
	public void SetContact_ShouldWorkWithTask()
	{
		var task = EmarsysTask.SetContact(123, "test");
		Assert.True(task.GetType().Equals(typeof(Task<ErrorType?>)));
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
		Emarsys.ClearContact(Utils.CompletionListener());
	}

	[Fact]
	public void ClearContact_ShouldWorkWithTask()
	{
		var task = EmarsysTask.ClearContact();
		Assert.True(task.GetType().Equals(typeof(Task<ErrorType?>)));
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
		Emarsys.TrackCustomEvent("test");
	}

	[Fact]
	public void TrackCustomEvent_ShouldWorkWithCompletionListener()
	{
		Dictionary<string, string> eventAttributes = new Dictionary<string, string>
		{
			{ "key", "value" }
		};
		Emarsys.TrackCustomEvent("test", eventAttributes, Utils.CompletionListener());
	}

	[Fact]
	public void TrackCustomEvent_ShouldWorkWithTask()
	{
		Dictionary<string, string> eventAttributes = new Dictionary<string, string>
		{
			{ "key", "value" }
		};
		var task = EmarsysTask.TrackCustomEvent("test", eventAttributes);
		Assert.True(task.GetType().Equals(typeof(Task<ErrorType?>)));
		Assert.Equal(TaskStatus.WaitingForActivation, task.Status);
	}

	[Fact]
	public void TrackDeepLink_ShouldWork()
	{
		#if ANDROID
		Emarsys.TrackDeepLink(Platform.CurrentActivity!, Platform.CurrentActivity!.Intent!);
		#elif IOS
		var userActivity = new NSUserActivity(NSUserActivityType.BrowsingWeb);
		userActivity.WebPageUrl = new NSUrl("http://test");
		Emarsys.TrackDeepLink(userActivity);
		#endif
	}

}
