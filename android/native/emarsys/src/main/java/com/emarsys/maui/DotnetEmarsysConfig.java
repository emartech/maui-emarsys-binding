package com.emarsys.maui;

import android.app.Application;
import androidx.annotation.NonNull;
import com.emarsys.Emarsys;
import java.util.List;

public class DotnetEmarsysConfig {

    public static @NonNull EMSConfig build(@NonNull Application application, String applicationCode, String merchantId,
                                           List<String> sharedPackageNames, String sharedSecret, boolean enableConsoleLogging) {
        return new EMSConfig(application, applicationCode, merchantId, sharedPackageNames, sharedSecret, enableConsoleLogging);
    }

    public static void changeApplicationCode(String applicationCode, @NonNull CompletionListener completionListener) {
        Emarsys.getConfig().changeApplicationCode(applicationCode, completionListener::onCompleted);
    }

}
