package com.emarsys.maui;

import android.app.Application;
import android.content.Context;
import android.util.Log;

import com.emarsys.Emarsys;
import com.emarsys.config.EmarsysConfig;
import com.emarsys.service.EmarsysFirebaseMessagingServiceUtils;
import com.google.firebase.messaging.RemoteMessage;
import org.json.JSONObject;

public class DotnetEmarsys
{
    static String TAG = "EmarsysPlugin";

    public interface EmarsysEventListener {
        void onEvent(Context context, String eventName, JSONObject payload);
    }

    private static EmarsysEventListener eventListener;

    public static void setEventListener(EmarsysEventListener listener) {
        eventListener = listener;
    }

    public static void setup(Application application, String applicationCode) {
        Log.i(TAG, "Emarsys setup with app code " + applicationCode);

        EmarsysConfig config = new EmarsysConfig.Builder()
                .application(application)
                .applicationCode(applicationCode)
                .enableVerboseConsoleLogging()
                .build();

        Emarsys.setup(config);

        Emarsys.getPush().setNotificationEventHandler((context, eventName, payload) -> {
            if (eventListener != null) {
                eventListener.onEvent(context, eventName, payload);
            }
        });
    }

    public static Boolean handleMessage(Context context, RemoteMessage message) {
        Log.i(TAG, "handleMessage");
        return EmarsysFirebaseMessagingServiceUtils.handleMessage(context, message);
    }

    public static void setPushToken(String token) {
        Log.i(TAG, "Set push token " + token);
        Emarsys.getPush().setPushToken(token);
    }
}