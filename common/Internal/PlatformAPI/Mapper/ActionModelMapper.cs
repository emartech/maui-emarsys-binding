namespace EmarsysBinding.Internal;

using EmarsysBinding.Model;

class ActionModelMapper
{

	public static List<EMSActionModel> Map(object input)
	{
		if (input is List<object> inputList)
		{
			return inputList
				.Where(element => element is Dictionary<string, object> actionMap && actionMap.Count > 0)
				.Select(element =>
				{
					return MapAction((Dictionary<string, object>)element);
				})
				.Where(action => action != null)
				.Cast<EMSActionModel>()
				.ToList();
		}
		return new List<EMSActionModel>();
	}

	private static EMSActionModel? MapAction(Dictionary<string, object> actionMap)
	{
		if (!actionMap.ContainsKey("type") || actionMap["type"] == null)
		{
			Console.WriteLine("Action map does not contain a valid 'type'.");
			return null;
		}

		var type = (string)actionMap["type"];
		switch (type)
		{
			case "MEAppEvent":
				return new EMSAppEventActionModel(
					id: (string)actionMap["id"],
					title: (string)actionMap["title"],
					type: (string)actionMap["type"],
					name: (string)actionMap["name"],
					payload: actionMap.ContainsKey("payload")
						? (Dictionary<string, object>)actionMap["payload"]
						: null
				);

			case "MECustomEvent":
				return new EMSCustomEventActionModel(
					id: (string)actionMap["id"],
					title: (string)actionMap["title"],
					type: (string)actionMap["type"],
					name: (string)actionMap["name"],
					payload: actionMap.ContainsKey("payload")
						? (Dictionary<string, object>)actionMap["payload"]
						: null
				);

			case "OpenExternalUrl":
				return new EMSOpenExternalUrlActionModel(
					id: (string)actionMap["id"],
					title: (string)actionMap["title"],
					type: (string)actionMap["type"],
					url: (string)actionMap["url"]
				);

			default:
				return null;
		}
	}

}
