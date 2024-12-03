namespace Test;

using Xunit.Runners.Maui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.ConfigureTests(new TestOptions
			{
				Assemblies =
				{
					typeof(MauiProgram).Assembly
				}
			})
			.UseVisualRunner();

		return builder.Build();
	}
}
