package com.emarsys.maui;

import android.app.Application;
import android.content.Context;
import android.util.Log;

import com.emarsys.Emarsys;
import com.emarsys.config.EmarsysConfig;
import com.emarsys.service.EmarsysFirebaseMessagingServiceUtils;
import com.google.firebase.messaging.RemoteMessage;

public class DotnetEmarsys
{
    static String TAG = "EmarsysPlugin";

    public static String getString(String myString)
    {
        return myString + " from Java!";
    }

    public static void setup(Application application, String applicationCode) {
        Log.i(TAG, "Emarsys setup with app code " + applicationCode);

        EmarsysConfig config = new EmarsysConfig.Builder()
                .application(application)
                .applicationCode(applicationCode)
                .enableVerboseConsoleLogging()
                .build();

        Emarsys.setup(config);
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
