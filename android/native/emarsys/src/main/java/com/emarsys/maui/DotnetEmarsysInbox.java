package com.emarsys.maui;

import androidx.annotation.NonNull;
import com.emarsys.Emarsys;
import com.emarsys.mobileengage.api.action.ActionModel;
import com.emarsys.mobileengage.api.action.AppEventActionModel;
import com.emarsys.mobileengage.api.action.CustomEventActionModel;
import com.emarsys.mobileengage.api.action.OpenExternalUrlActionModel;
import com.emarsys.mobileengage.api.inbox.Message;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.stream.Collectors;

public class DotnetEmarsysInbox {

    public interface FetchMessagesResultCallback {
        void onResult(List<Map<String, Object>> messages, Throwable error);
    }

    public static void fetchMessages(@NonNull FetchMessagesResultCallback resultCallback) {
        Emarsys.getMessageInbox().fetchMessages(result -> {
            if (result.getErrorCause() != null) {
                resultCallback.onResult(null, result.getErrorCause());
            } else {
                if (result.getResult() != null) {
                    List<Map<String, Object>> mappedMessages = mapMessages(result.getResult().getMessages());
                    resultCallback.onResult(mappedMessages, null);
                } else {
                    resultCallback.onResult(List.of(), null);
                }
            }
        });
    }

    public static void addTag(@NonNull String tag, @NonNull String messageId, @NonNull CompletionListener completionListener) {
        Emarsys.getMessageInbox().addTag(tag, messageId, completionListener::onCompleted);
    }

    public static void removeTag(@NonNull String tag, @NonNull String messageId, @NonNull CompletionListener completionListener) {
        Emarsys.getMessageInbox().removeTag(tag, messageId, completionListener::onCompleted);
    }

    private static @NonNull List<Map<String, Object>> mapMessages(@NonNull List<Message> messages) {
        return messages.stream().map(message -> {
            Map<String, Object> resultMap = new HashMap<>();
            resultMap.put("id", message.getId());
            resultMap.put("campaignId", message.getCampaignId());
            if (message.getCollapseId() != null) {
                resultMap.put("collapseId", message.getCollapseId());
            }
            resultMap.put("title", message.getTitle());
            resultMap.put("body", message.getBody());
            if (message.getImageUrl() != null) {
                resultMap.put("imageUrl", message.getImageUrl());
            }
            resultMap.put("receivedAt", message.getReceivedAt());
            if (message.getUpdatedAt() != null) {
                resultMap.put("updatedAt", message.getUpdatedAt());
            }
            if (message.getExpiresAt() != null) {
                resultMap.put("expiresAt", message.getExpiresAt());
            }
            if (message.getTags() != null) {
                resultMap.put("tags", message.getTags());
            }
            if (message.getProperties() != null) {
                resultMap.put("properties", message.getProperties());
            }
            if (message.getActions() != null) {
                resultMap.put("actions", mapActions(message.getActions()));
            }
            return resultMap;
        }).collect(Collectors.toList());
    }

    private static @NonNull List<Map<String, Object>> mapActions(@NonNull List<ActionModel> actions) {
        return actions.stream().map(action -> {
            Map<String, Object> actionMap = new HashMap<>();
            actionMap.put("id", action.getId());
            actionMap.put("title", action.getTitle());
            actionMap.put("type", action.getType());
            if (action instanceof AppEventActionModel) {
                AppEventActionModel appEvent = (AppEventActionModel) action;
                actionMap.put("name", appEvent.getName());
                actionMap.put("payload", appEvent.getPayload());
            } else if (action instanceof CustomEventActionModel) {
                CustomEventActionModel customEvent = (CustomEventActionModel) action;
                actionMap.put("name", customEvent.getName());
                actionMap.put("payload", customEvent.getPayload());
            } else if (action instanceof OpenExternalUrlActionModel) {
                OpenExternalUrlActionModel externalUrl = (OpenExternalUrlActionModel) action;
                actionMap.put("url", externalUrl.getUrl().toString());
            }
            return actionMap;
        }).collect(Collectors.toList());
    }

}
