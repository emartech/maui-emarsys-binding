package com.emarsys.maui;

import androidx.annotation.NonNull;
import com.emarsys.Emarsys;
import com.emarsys.mobileengage.api.action.ActionModel;
import com.emarsys.mobileengage.api.action.AppEventActionModel;
import com.emarsys.mobileengage.api.action.CustomEventActionModel;
import com.emarsys.mobileengage.api.action.OpenExternalUrlActionModel;
import com.emarsys.mobileengage.api.inbox.InboxResult;
import com.emarsys.mobileengage.api.inbox.Message;

import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.stream.Collectors;

public class DotnetEmarsysInbox {

    public static void fetchMessages(@NonNull ResultCallback resultCallback) {
        Emarsys.getMessageInbox().fetchMessages(result -> {
            if (result.getErrorCause() != null) {
                resultCallback.onResult(null, result.getErrorCause());
            } else {
                List<EMSMessage> messages = List.of();
                for (Message message : result.getResult().getMessages()) {
                    List<EMSActionModel> actions = List.of();
                    for (ActionModel action : message.getActions()) {
                        if (action instanceof AppEventActionModel) {
                            AppEventActionModel appEventAction = (AppEventActionModel) action;
                            actions.add(new EMSAppEventActionModel(appEventAction.getId(),
                                    appEventAction.getTitle(), appEventAction.getType(),
                                    appEventAction.getName(), appEventAction.getPayload()));
                        } else if (action instanceof CustomEventActionModel) {
                            CustomEventActionModel customEvent = (CustomEventActionModel) action;
                            actions.add(new EMSCustomEventActionModel(customEvent.getId(),
                                    customEvent.getTitle(), customEvent.getType(),
                                    customEvent.getName(), customEvent.getPayload()));
                        } else if (action instanceof OpenExternalUrlActionModel) {
                            OpenExternalUrlActionModel externalUrl = (OpenExternalUrlActionModel) action;
                            actions.add(new EMSOpenExternalUrlActionModel(externalUrl.getId(),
                                    externalUrl.getTitle(), externalUrl.getType(),
                                    externalUrl.getUrl()));
                        }
                    }
                    EMSMessage emsMessage = new EMSMessage(message.getId(), message.getCampaignId(),
                            message.getCollapseId(), message.getTitle(), message.getBody(), message.getImageUrl(),
                            message.getReceivedAt(), message.getUpdatedAt(), message.getExpiresAt(), message.getTags(),
                            message.getProperties(), actions);
                    messages.add(emsMessage);
                }
                resultCallback.onResult(messages, null);
            }
        });
    }

    public static void addTag(@NonNull String tag, @NonNull String messageId, @NonNull CompletionListener completionListener) {
        Emarsys.getMessageInbox().addTag(tag, messageId, completionListener::onCompleted);
    }

    public static void removeTag(@NonNull String tag, @NonNull String messageId, @NonNull CompletionListener completionListener) {
        Emarsys.getMessageInbox().removeTag(tag, messageId, completionListener::onCompleted);
    }

//    public static List<Map<String, Object>> mapInbox(InboxResult input) {
//        return input.getMessages().stream().map(message -> {
//            Map<String, Object> resultMap = new HashMap<>();
//            resultMap.put("id", message.getId());
//            resultMap.put("campaignId", message.getCampaignId());
//            resultMap.put("title", message.getTitle());
//            resultMap.put("body", message.getBody());
//            resultMap.put("receivedAt", message.getReceivedAt());
//            List<Map<String, Object>> actionsMap = actionsToMap(message.getActions());
//            if (actionsMap != null) {
//                resultMap.put("actions", actionsMap);
//            }
//            if (message.getCollapseId() != null) {
//                resultMap.put("collapseId", message.getCollapseId());
//            }
//            if (message.getImageUrl() != null) {
//                resultMap.put("imageUrl", message.getImageUrl());
//            }
//            if (message.getUpdatedAt() != null) {
//                resultMap.put("updatedAt", message.getUpdatedAt());
//            }
//            if (message.getTags() != null) {
//                resultMap.put("tags", message.getTags());
//            }
//            if (message.getProperties() != null) {
//                resultMap.put("properties", message.getProperties());
//            }
//            if (message.getExpiresAt() != null) {
//                resultMap.put("expiresAt", message.getExpiresAt());
//            }
//            return resultMap;
//        }).collect(Collectors.toList());
//    }
//
//    private static List<Map<String, Object>> actionsToMap(List<ActionModel> actions) {
//        if (actions == null || actions.isEmpty()) {
//            return null;
//        }
//        return actions.stream().map(action -> {
//            Map<String, Object> actionMap = new HashMap<>();
//            actionMap.put("id", action.getId());
//            actionMap.put("title", action.getTitle());
//            actionMap.put("type", action.getType());
//            if (action instanceof AppEventActionModel) {
//                AppEventActionModel appEvent = (AppEventActionModel) action;
//                actionMap.put("name", appEvent.getName());
//                actionMap.put("payload", appEvent.getPayload());
//            } else if (action instanceof CustomEventActionModel) {
//                CustomEventActionModel customEvent = (CustomEventActionModel) action;
//                actionMap.put("name", customEvent.getName());
//                actionMap.put("payload", customEvent.getPayload());
//            } else if (action instanceof OpenExternalUrlActionModel) {
//                OpenExternalUrlActionModel externalUrl = (OpenExternalUrlActionModel) action;
//                actionMap.put("url", externalUrl.getUrl().toString());
//            }
//            return actionMap;
//        }).collect(Collectors.toList());
//    }
}
