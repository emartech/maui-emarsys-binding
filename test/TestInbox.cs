﻿namespace Test;

using EmarsysBinding.Model;

public class TestInbox
{

	private InternalAPIInbox _internal;
	private readonly Mock<IPlatformAPIInbox> _platformMock;

	public TestInbox()
	{
		_platformMock = new Mock<IPlatformAPIInbox>();
		_internal = new InternalAPIInbox(_platformMock.Object);
	}

	[Fact]
	public async Task FetchMessages_ShouldWork()
	{
		List<Message> resultMessages = new List<Message> { new Message(
			id: "testId",
			campaignId: "testCampaignId",
			title: "testTitle",
			body: "testBody",
			receivedAt: 123
		) };
		_platformMock.Setup(mock => mock.FetchMessages(It.IsAny<Action<List<Message>?, string?>>()))
			.Callback((Action<List<Message>?, string?> resultCallback) => resultCallback(resultMessages, null));

		var result = await _internal.FetchMessages();

		_platformMock.Verify(mock => mock.FetchMessages(It.IsAny<Action<List<Message>?, string?>>()));
		Assert.Equal(resultMessages, result.Messages);
		Assert.Null(result.Error);
	}

	[Fact]
	public async Task FetchMessages_ShouldWorkWithError()
	{
		_platformMock.Setup(mock => mock.FetchMessages(It.IsAny<Action<List<Message>?, string?>>()))
			.Callback((Action<List<Message>?, string?> resultCallback) => resultCallback(null, "error"));

		var result = await _internal.FetchMessages();

		_platformMock.Verify(mock => mock.FetchMessages(It.IsAny<Action<List<Message>?, string?>>()));
		Assert.Null(result.Messages);
		Assert.Equal("error", result.Error);
	}

	[Fact]
	public async Task AddTag_ShouldWork()
	{
		_platformMock.Setup(mock => mock.AddTag(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Action<string?>>()))
			.Callback((string _, string _, Action<string?> onCompleted) => onCompleted(null));

		string? result = await _internal.AddTag("test", "test");

		_platformMock.Verify(mock => mock.AddTag("test", "test", It.IsAny<Action<string?>>()));
		Assert.Null(result);
	}

	[Fact]
	public async Task AddTag_ShouldWorkWithError()
	{
		_platformMock.Setup(mock => mock.AddTag(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Action<string?>>()))
			.Callback((string _, string _, Action<string?> onCompleted) => onCompleted("error"));

		string? result = await _internal.AddTag("test", "test");

		_platformMock.Verify(mock => mock.AddTag("test", "test", It.IsAny<Action<string?>>()));
		Assert.Equal("error", result);
	}

	[Fact]
	public async Task RemoveTag_ShouldWork()
	{
		_platformMock.Setup(mock => mock.RemoveTag(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Action<string?>>()))
			.Callback((string _, string _, Action<string?> onCompleted) => onCompleted(null));

		string? result = await _internal.RemoveTag("test", "test");

		_platformMock.Verify(mock => mock.RemoveTag("test", "test", It.IsAny<Action<string?>>()));
		Assert.Null(result);
	}

	[Fact]
	public async Task RemoveTag_ShouldWorkWithError()
	{
		_platformMock.Setup(mock => mock.RemoveTag(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Action<string?>>()))
			.Callback((string _, string _, Action<string?> onCompleted) => onCompleted("error"));

		string? result = await _internal.RemoveTag("test", "test");

		_platformMock.Verify(mock => mock.RemoveTag("test", "test", It.IsAny<Action<string?>>()));
		Assert.Equal("error", result);
	}

}
