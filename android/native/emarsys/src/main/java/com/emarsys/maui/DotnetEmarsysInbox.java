package com.emarsys.maui;

import androidx.annotation.NonNull;
import com.emarsys.Emarsys;

public class DotnetEmarsysInbox {

    public static void addTag(@NonNull String tag, @NonNull String messageId, @NonNull CompletionListener completionListener) {
        Emarsys.getMessageInbox().addTag(tag, messageId, completionListener::onCompleted);
    }

    public static void removeTag(@NonNull String tag, @NonNull String messageId, @NonNull CompletionListener completionListener) {
        Emarsys.getMessageInbox().removeTag(tag, messageId, completionListener::onCompleted);
    }
}
