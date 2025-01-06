namespace EmarsysBinding.Internal;

using Foundation;

class MessageMapper
{
  public static List<Message> MapInbox(NSArray input) {
    var inputList = ConvertNSArrayToList<Dictionary<string, object>>(input);

    return inputList
      .Where(element => element is Dictionary<string, object> messageMap && messageMap.Count > 0)
      .Select(element => 
      {
        var messageMap = (Dictionary<string, object>)element;
        return new Message(
          id: (string)messageMap["id"],
          campaignId: (string)messageMap["campaignId"],
          collapseId: messageMap.ContainsKey("collapseId") ? messageMap["collapseId"] as string : null,
          title: (string)messageMap["title"],
          body: (string)messageMap["body"],
          imageUrl: messageMap.ContainsKey("imageUrl") ? messageMap["imageUrl"] as string : null,
          receivedAt: Convert.ToInt32(messageMap["receivedAt"]),
          updatedAt: messageMap.ContainsKey("updatedAt") ? (int?)Convert.ToInt32(messageMap["updatedAt"]) : null,
          expiresAt: messageMap.ContainsKey("expiresAt") ? (int?)Convert.ToInt32(messageMap["expiresAt"]) : null,
          properties: ConvertToStringDictionary(
            messageMap.ContainsKey("properties")
                ? messageMap["properties"]
                : null),
          tags: messageMap.ContainsKey("tags")
              ? new List<string>() // TODO: MAP TAGS
              : new List<string>(),
          actions: messageMap.ContainsKey("actions") 
            ? new List<ActionModel>() // TODO: MAP ACTIONS
            : new List<ActionModel>()
        );
      })
      .ToList();
	}

	private static List<ActionModel> MapActions(List<object>? actionList)
	{
		if (actionList == null)
		{
			return null;
		}

		return actionList
			.Select(action => ActionFromMap((Dictionary<string, object>)action))
			.Where(action => action != null)
			.ToList();
	}

	private static ActionModel? ActionFromMap(Dictionary<string, object> actionMap)
	{
		var type = (string)actionMap["type"];

		switch (type)
		{
			case "MEAppEvent":
				return new AppEventActionModel(
					id: (string)actionMap["id"],
					title: (string)actionMap["title"],
					type: (string)actionMap["type"],
					name: (string)actionMap["name"],
					payload: actionMap.ContainsKey("payload") 
						? actionMap["payload"] as Dictionary<string, object> 
						: new Dictionary<string, object>()
				);

			case "MECustomEvent":
				return new CustomEventActionModel(
					id: (string)actionMap["id"],
					title: (string)actionMap["title"],
					type: (string)actionMap["type"],
					name: (string)actionMap["name"],
					payload: actionMap.ContainsKey("payload") 
						? actionMap["payload"] as Dictionary<string, object> 
						: new Dictionary<string, object>()
				);

			case "OpenExternalUrl":
				return new OpenExternalUrlActionModel(
					id: (string)actionMap["id"],
					title: (string)actionMap["title"],
					type: (string)actionMap["type"],
					url: (string)actionMap["url"]
				);

			default:
				return null;
		}
	}

  private static Dictionary<string, string>? ConvertToStringDictionary(object maybeDict)
  {
    if (maybeDict is Dictionary<string, object> dict)
    {
      var result = new Dictionary<string, string>();
      foreach (var kvp in dict)
      {
        if (kvp.Value is string sVal)
        {
          result[kvp.Key] = sVal;
        }
      }
      return result;
    }
    return null;
  }

  private static List<T> ConvertNSArrayToList<T>(NSArray nsArray)
	{
		var list = new List<T>();

		for (nuint i = 0; i < nsArray.Count; i++)
		{
			var item = nsArray.GetItem<NSObject>(i);

			if (typeof(T) == typeof(Dictionary<string, object>))
			{
				if (item is NSDictionary nsDict)
				{
					var dict = nsDict.ToDictionary();
					list.Add((T)(object)dict);
				}
			}
			else if (typeof(T) == typeof(string))
			{
				if (item is NSString nsString)
				{
					list.Add((T)(object)nsString.ToString());
				}
			}
			else if (typeof(T) == typeof(int))
			{
				if (item is NSNumber nsNumber)
				{
					list.Add((T)(object)nsNumber.Int32Value);
				}
			}
			else
			{
				list.Add((T)(object)item);
			}
		}

		return list;
	}
}
