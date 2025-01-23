namespace EmarsysBinding.Internal;

using EmarsysBinding.Model;

class MessageMapper
{

	public static List<EMSMessage>? Map(object? input)
	{
		if (input == null)
		{
			return null;
		}

		var _input = PlatformUtils.ToDotnetObject(input);
		if (_input is List<object> inputList)
		{
			return inputList
				.Where(element => element is Dictionary<string, object> messageMap && messageMap.Count > 0)
				.Select(element =>
				{
					var messageMap = (Dictionary<string, object>)element;

					var id = (string)messageMap["id"];
					var campaignId = (string)messageMap["campaignId"];
					var collapseId = messageMap.ContainsKey("collapseId") ? (string)messageMap["collapseId"] : null;
					var title = (string)messageMap["title"];
					var body = (string)messageMap["body"];
					var imageUrl = messageMap.ContainsKey("imageUrl") ? (string)messageMap["imageUrl"] : null;
					var receivedAt = Convert.ToInt32(messageMap["receivedAt"]);
					var updatedAt = messageMap.ContainsKey("updatedAt") ? (int?)Convert.ToInt32(messageMap["updatedAt"]) : null;
					var expiresAt = messageMap.ContainsKey("expiresAt") ? (int?)Convert.ToInt32(messageMap["expiresAt"]) : null;

					var tags = messageMap.ContainsKey("tags") && messageMap["tags"] is List<object> tagsList
						? tagsList.Select(tag => tag?.ToString() ?? "").ToList()
						: null;

					var properties = messageMap.ContainsKey("properties")
						? (Dictionary<string, object>)messageMap["properties"]
						: null;

					var actions = messageMap.ContainsKey("actions")
						? ActionModelMapper.Map(messageMap["actions"])
						: null;

					return new EMSMessage(
						id: id,
						campaignId: campaignId,
						collapseId: collapseId,
						title: title,
						body: body,
						imageUrl: imageUrl,
						receivedAt: receivedAt,
						updatedAt: updatedAt,
						expiresAt: expiresAt,
						tags: tags,
						properties: properties,
						actions: actions
					);
				})
				.ToList();
		}
		else
		{
			return new List<EMSMessage>();
		}
	}

}
