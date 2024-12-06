package com.emarsys.maui;

import android.app.Application;
import androidx.annotation.NonNull;
import com.emarsys.Emarsys;
import com.emarsys.config.EmarsysConfig;
import java.util.List;
import java.util.Map;

public class DotnetEmarsys {

    public static @NonNull DotnetEMSConfig config(@NonNull Application application, String applicationCode, String merchantId,
                                                  List<String> sharedPackageNames, String sharedSecret, boolean enableConsoleLogging) {
        return new DotnetEMSConfig(application, applicationCode, merchantId, sharedPackageNames, sharedSecret, enableConsoleLogging);
    }

    public static void setup(@NonNull DotnetEMSConfig dotnetConfig) {
        EmarsysConfig.Builder builder = new EmarsysConfig.Builder();
        builder.application(dotnetConfig.getApplication());
        if (dotnetConfig.getApplicationCode() != null && !dotnetConfig.getApplicationCode().isEmpty()) {
            builder.applicationCode(dotnetConfig.getApplicationCode());
        }
        if (dotnetConfig.getMerchantId() != null && !dotnetConfig.getMerchantId().isEmpty()) {
            builder.merchantId(dotnetConfig.getMerchantId());
        }
        if (dotnetConfig.getSharedPackageNames() != null && !dotnetConfig.getSharedPackageNames().isEmpty()) {
            builder.sharedPackageNames(dotnetConfig.getSharedPackageNames());
        }
        if (dotnetConfig.getSharedSecret() != null && !dotnetConfig.getSharedSecret().isEmpty()) {
            builder.sharedSecret(dotnetConfig.getSharedSecret());
        }
        if (dotnetConfig.isEnableConsoleLogging()) {
            builder.enableVerboseConsoleLogging();
        }
        EmarsysConfig config = builder.build();
        Emarsys.setup(config);
        Emarsys.trackCustomEvent("wrapper:init", Map.of("type", "maui"));
    }

    public static void setContact(int contactFieldId, @NonNull String contactFieldValue, @NonNull CompletionListener completionListener) {
        Emarsys.setContact(contactFieldId, contactFieldValue, completionListener::onCompleted);
    }

    public static void clearContact(@NonNull CompletionListener completionListener) {
        Emarsys.clearContact(completionListener::onCompleted);
    }

    public static void trackCustomEvent(@NonNull String eventName, Map<String, String> eventAttributes, @NonNull CompletionListener completionListener) {
        Emarsys.trackCustomEvent(eventName, eventAttributes, completionListener::onCompleted);
    }

    public static @NonNull DotnetEmarsysPush push = new DotnetEmarsysPush();

    public static @NonNull DotnetEmarsysInApp inApp = new DotnetEmarsysInApp();

}
