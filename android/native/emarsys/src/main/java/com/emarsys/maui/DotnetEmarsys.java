package com.emarsys.maui;

import android.app.Application;
import android.content.Context;
import androidx.annotation.Nullable;
import com.emarsys.Emarsys;
import com.emarsys.config.EmarsysConfig;
import com.emarsys.service.EmarsysFirebaseMessagingServiceUtils;
import com.google.firebase.messaging.RemoteMessage;
import org.json.JSONObject;

import java.util.Collections;

public class DotnetEmarsys {
    static String TAG = "EmarsysBinding";

    public interface EmarsysEventListener {
        void handleEvent(Context context, String eventName, @Nullable JSONObject payload);
    }

    public interface CompletionListener {
        void onCompleted(@Nullable Throwable errorCause);
    }

    private static EmarsysEventListener eventListener;

    public static void setEventListener(EmarsysEventListener listener) {
        eventListener = listener;
    }

    public static void setup(DotnetEMSConfig dotnetConfig) {
        EmarsysConfig.Builder builder = new EmarsysConfig.Builder();
        builder.application(dotnetConfig.getApplication());
        if (dotnetConfig.getApplicationCode() != null && !dotnetConfig.getApplicationCode().isEmpty()) {
            builder.applicationCode(dotnetConfig.getApplicationCode());
        }
        if (dotnetConfig.getMerchantId() != null && !dotnetConfig.getMerchantId().isEmpty()) {
            builder.merchantId(dotnetConfig.getMerchantId());
        }
        if (dotnetConfig.getSharedKeychainAccessGroup() != null && !dotnetConfig.getSharedKeychainAccessGroup().isEmpty()) {
            builder.sharedPackageNames(Collections.singletonList(dotnetConfig.getSharedKeychainAccessGroup()));        }
        if (dotnetConfig.getEnableLogs() != null && dotnetConfig.getEnableLogs()) {
            builder.enableVerboseConsoleLogging();
        }

        EmarsysConfig config = builder.build(); 
        Emarsys.setup(config);

        Emarsys.getPush().setNotificationEventHandler((context, eventName, payload) -> {
            if (eventListener != null) {
                eventListener.handleEvent(context, eventName, payload);
            }
        });
    }

    public static DotnetEMSConfig config(Application application, String applicationCode, String merchantId, String sharedKeychainAccessGroup, boolean enableLogs) {
        return new DotnetEMSConfig(application, applicationCode, merchantId, sharedKeychainAccessGroup, enableLogs);
    }

    public static Boolean handleMessage(Context context, RemoteMessage message) {
        return EmarsysFirebaseMessagingServiceUtils.handleMessage(context, message);
    }

    public static void setPushToken(String pushToken) {
        Emarsys.getPush().setPushToken(pushToken);
    }

    public static void setPushToken(String pushToken, CompletionListener completionListener) {
        Emarsys.getPush().setPushToken(pushToken, completionListener::onCompleted);
    }

    public static void setContact(int contactFieldId, String contactFieldValue) {
        Emarsys.setContact(contactFieldId, contactFieldValue);
    }

    public static void setContact(int contactFieldId, String contactFieldValue, CompletionListener completionListener) {
        Emarsys.setContact(contactFieldId, contactFieldValue, completionListener::onCompleted);
    }

    public static void clearContact() {
        Emarsys.clearContact();
    }

    public static void clearContact(CompletionListener completionListener) {
        Emarsys.clearContact(completionListener::onCompleted);
    }

}
