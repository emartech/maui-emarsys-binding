namespace EmarsysiOS;

public class Utils
{

	public static Action<Foundation.NSError> Completion(Action<Foundation.NSError> onInvoked)
	{
		return onInvoked;
	}

}
