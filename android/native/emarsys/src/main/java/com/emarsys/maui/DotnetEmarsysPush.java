package com.emarsys.maui;

import android.content.Context;
import androidx.annotation.NonNull;
import com.emarsys.Emarsys;
import com.emarsys.service.EmarsysFirebaseMessagingServiceUtils;
import com.google.firebase.messaging.RemoteMessage;

public class DotnetEmarsysPush {

    public static void setEventHandler(@NonNull EventHandler eventHandler) {
        Emarsys.getPush().setNotificationEventHandler(eventHandler::handleEvent);
    }

    public static void setPushToken(@NonNull String pushToken, @NonNull CompletionListener completionListener) {
        Emarsys.getPush().setPushToken(pushToken, completionListener::onCompleted);
    }

    public static void clearPushToken(@NonNull CompletionListener completionListener) {
        Emarsys.getPush().clearPushToken(completionListener::onCompleted);
    }

    public static String getPushToken() {
        return Emarsys.getPush().getPushToken();
    }

    public static boolean handleMessage(@NonNull Context context, @NonNull RemoteMessage message) {
        return EmarsysFirebaseMessagingServiceUtils.handleMessage(context, message);
    }

    public static void setSilentMessageEventHandler(@NonNull EventHandler eventHandler) {
        Emarsys.getPush().setSilentMessageEventHandler(eventHandler::handleEvent);
    }
}
