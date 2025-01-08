namespace EmarsysBinding.Internal;

using Foundation;
using EmarsysBinding.Model;

class MessageMapper
{
  public static List<Message> MapInbox(NSArray input) {
    var inputList = Helper.ConvertNSArrayToList<Dictionary<string, object>>(input);

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
          properties: messageMap.ContainsKey("properties") && messageMap["properties"] is Dictionary<NSObject, NSObject> nsObjectDictionary
            ? Helper.ConvertToStringDictionary(nsObjectDictionary) // TODO: convert to Dictionary<object, object>
            : null,
          tags: messageMap.ContainsKey("tags") && messageMap["tags"] is IEnumerable<object> rawTags
            ? rawTags.Select(item =>
              {
                if (item is NSString nsString)
                {
                  return nsString.ToString();
                }
                else if (item is string realString)
                {
                  return realString;
                }
                else
                {
                  return item?.ToString();
                }
              })
              .Where(s => !string.IsNullOrEmpty(s))
              .ToList()
            : new List<string>(),
          actions: messageMap.ContainsKey("actions") && messageMap["actions"] is List<object> actionList
            ? MapActions(actionList)
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
			.Select(action => {
        return ActionFromMap(Helper.ConvertNSDictionaryToDictionary(action as NSDictionary)); // TODO: convert to Dictionary<object, object>
      })
			.Where(action => action != null)
			.ToList();
	}

	private static ActionModel? ActionFromMap(Dictionary<string, object> actionMap)
	{
    if (actionMap == null)
    {
      Console.WriteLine("Action map is null.");
      return null;
    }

    if (!actionMap.ContainsKey("type") || actionMap["type"] == null)
    {
      Console.WriteLine("Action map does not contain a valid 'type'.");
      return null;
    }

    var type = actionMap["type"] as string;
    if (type == null)
    {
      Console.WriteLine("'type' is not a valid string.");
      return null;
    }

		switch (type)
		{
			case "MEAppEvent":
				return new AppEventActionModel(
					id: (string)actionMap["id"],
					title: (string)actionMap["title"],
					type: (string)actionMap["type"],
					name: (string)actionMap["name"],
          payload: actionMap.ContainsKey("payload") && actionMap["payload"] is Dictionary<NSObject, NSObject> appEventNSObjectDictionary
            ? Helper.ConvertToStringDictionary(appEventNSObjectDictionary)
            : null
				);

			case "MECustomEvent":
				return new CustomEventActionModel(
					id: (string)actionMap["id"],
					title: (string)actionMap["title"],
					type: (string)actionMap["type"],
					name: (string)actionMap["name"],
          payload: actionMap.ContainsKey("payload") && actionMap["payload"] is Dictionary<NSObject, NSObject> customEventNSObjectDictionary
            ? Helper.ConvertToStringDictionary(customEventNSObjectDictionary)
            : null
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
}
