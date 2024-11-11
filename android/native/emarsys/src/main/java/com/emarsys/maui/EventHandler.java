package com.emarsys.maui;

import android.content.Context;
import androidx.annotation.NonNull;
import org.json.JSONObject;

public interface EventHandler {
    void handleEvent(@NonNull Context context, @NonNull String eventName, JSONObject payload);
}
