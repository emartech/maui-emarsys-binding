package com.emarsys.maui;

import static android.content.ContentValues.TAG;

import android.app.Application;
import android.util.Log;

import com.emarsys.Emarsys;
import com.emarsys.config.EmarsysConfig;

public class DotnetEmarsys
{
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
}
