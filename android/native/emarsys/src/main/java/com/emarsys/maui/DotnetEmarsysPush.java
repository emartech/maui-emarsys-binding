package com.emarsys.maui;

import android.content.Context;
import androidx.annotation.NonNull;
import com.emarsys.Emarsys;
import com.emarsys.service.EmarsysFirebaseMessagingServiceUtils;
import com.google.firebase.messaging.RemoteMessage;

public class DotnetEmarsysPush {

    public void setEventHandler(@NonNull EventHandler eventHandler) {
        Emarsys.getPush().setNotificationEventHandler(eventHandler::handleEvent);
    }

    public void setPushToken(@NonNull String pushToken, @NonNull CompletionListener completionListener) {
        Emarsys.getPush().setPushToken(pushToken, completionListener::onCompleted);
    }

    public void clearPushToken(@NonNull CompletionListener completionListener) {
        Emarsys.getPush().clearPushToken(completionListener::onCompleted);
    }

    public String getPushToken() {
        return Emarsys.getPush().getPushToken();
    }

    public boolean handleMessage(@NonNull Context context, @NonNull RemoteMessage message) {
        return EmarsysFirebaseMessagingServiceUtils.handleMessage(context, message);
    }

}
