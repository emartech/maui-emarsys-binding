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
        void onEvent(Context context, String eventName, JSONObject payload);
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
                eventListener.onEvent(context, eventName, payload);
            }
        });
    }

    public static DotnetEMSConfig config(Application application, String applicationCode, String merchantId, String sharedKeychainAccessGroup, boolean enableLogs) {
        return new DotnetEMSConfig(application, applicationCode, merchantId, sharedKeychainAccessGroup, enableLogs);
    }

    public static Boolean handleMessage(Context context, RemoteMessage message) {
        return EmarsysFirebaseMessagingServiceUtils.handleMessage(context, message);
    }

    public static void setPushToken(String token) {
        Emarsys.getPush().setPushToken(token);
    }

    public static void setContact(int contactFieldId, String contactFieldValue) {
        Emarsys.setContact(contactFieldId, contactFieldValue);
    }

    public static void setContact(int contactFieldId, String contactFieldValue, @Nullable CompletionListener completionListener) {
        Emarsys.setContact(contactFieldId, contactFieldValue, (errorCause) -> {
            if (completionListener != null) {
                completionListener.onCompleted(errorCause);
            }
        });
    }

    public static void clearContact() {
        Emarsys.clearContact();
    }
}
