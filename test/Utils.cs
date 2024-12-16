global using Xunit;
global using Moq;
global using EmarsysBinding.Internal;

namespace Test;

class Utils
{

	public static Action<string> EventHandler()
	{
		return (eventName) => {};
	}

}
