package com.emarsys.maui;

import android.content.Context;
import android.view.View;
import androidx.annotation.NonNull;
import com.emarsys.Emarsys;
import com.emarsys.inapp.ui.InlineInAppView;
import org.json.JSONObject;
import kotlin.Unit;

public class DotnetEmarsysInApp {

    public static void setEventHandler(@NonNull EventHandler eventHandler) {
        Emarsys.getInApp().setEventHandler(eventHandler::handleEvent);
    }

    public static void pause() {
        Emarsys.getInApp().pause();
    }

    public static void resume() {
        Emarsys.getInApp().resume();
    }

    public static boolean isPaused() {
        return Emarsys.getInApp().isPaused();
    }

    public static @NonNull View createInlineInAppView(@NonNull Context context) {
        return new InlineInAppView(context);
    }

    public interface InlineInAppEventHandler {
        void handleEvent(String eventName, JSONObject payload);
    }

    public static void setInlineInAppEventHandler(@NonNull View view, @NonNull InlineInAppEventHandler eventHandler) {
        ((InlineInAppView) view).setOnAppEventListener((eventName, json) -> {
            eventHandler.handleEvent(eventName, json.optJSONObject("payload"));
            return Unit.INSTANCE;
        });
    }

    public static void setInlineInAppCompletionListener(@NonNull View view, @NonNull CompletionListener completionListener) {
        ((InlineInAppView) view).setOnCompletionListener(completionListener::onCompleted);
    }

    public interface InlineInAppCloseListener {
        void onClosed();
    }

    public static void setInlineInAppCloseListener(@NonNull View view, @NonNull InlineInAppCloseListener closeListener) {
        ((InlineInAppView) view).setOnCloseListener(() -> {
            closeListener.onClosed();
            return Unit.INSTANCE;
        });
    }

    public static void loadInlineInApp(@NonNull View view, @NonNull String viewId) {
        ((InlineInAppView) view).loadInApp(viewId);
    }

    public static void setOnEventActionEventHandler(@NonNull EventHandler eventHandler) {
        Emarsys.getOnEventAction().setOnEventActionEventHandler(eventHandler::handleEvent);
    }

}
