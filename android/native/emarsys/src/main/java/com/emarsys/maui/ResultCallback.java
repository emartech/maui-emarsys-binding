package com.emarsys.maui;

import com.emarsys.mobileengage.api.inbox.Message;
import java.util.List;

public interface ResultCallback {
    void onResult(List<EMSMessage> messages, Throwable error);
}
