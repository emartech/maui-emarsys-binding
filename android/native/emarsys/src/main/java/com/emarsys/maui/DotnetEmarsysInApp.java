package com.emarsys.maui;

import android.content.Context;
import android.view.View;
import androidx.annotation.NonNull;
import com.emarsys.inapp.ui.InlineInAppView;
import org.json.JSONObject;
import kotlin.Unit;

public class DotnetEmarsysInApp {

    public @NonNull View InlineInAppView(@NonNull Context context) {
        return new InlineInAppView(context);
    }

    public interface InlineInAppEventHandler {
        void handleEvent(String eventName, JSONObject payload);
    }

    public void setInlineInAppEventHandler(@NonNull View view, @NonNull InlineInAppEventHandler eventHandler) {
        ((InlineInAppView) view).setOnAppEventListener((eventName, json) -> {
            eventHandler.handleEvent(eventName, json.optJSONObject("payload"));
            return Unit.INSTANCE;
        });
    }

    public void setInlineInAppCompletionListener(@NonNull View view, @NonNull CompletionListener completionListener) {
        ((InlineInAppView) view).setOnCompletionListener(completionListener::onCompleted);
    }

    public interface InlineInAppCloseListener {
        void onClosed();
    }

    public void setInlineInAppCloseListener(@NonNull View view, @NonNull InlineInAppCloseListener closeListener) {
        ((InlineInAppView) view).setOnCloseListener(() -> {
            closeListener.onClosed();
            return Unit.INSTANCE;
        });
    }

    public void loadInlineInApp(@NonNull View view, @NonNull String viewId) {
        ((InlineInAppView) view).loadInApp(viewId);
    }

}
