package com.emarsys.maui;

import android.app.Application;

public class DotnetEMSConfig {
    private Application application;
    private String applicationCode;
    private String merchantId;
    private String sharedKeychainAccessGroup;
    private boolean enableLogs;

    public DotnetEMSConfig(Application application, String applicationCode, String merchantId, String sharedKeychainAccessGroup, boolean enableLogs) {
        this.application = application;
        this.applicationCode = applicationCode;
        this.merchantId = merchantId;
        this.sharedKeychainAccessGroup = sharedKeychainAccessGroup;
        this.enableLogs = enableLogs;
    }

    public Application getApplication() {
        return application;
    }

    public String getApplicationCode() {
        return applicationCode;
    }

    public String getMerchantId() {
        return merchantId;
    }

    public String getSharedKeychainAccessGroup() {
        return sharedKeychainAccessGroup;
    }

    public Boolean getEnableLogs() {
        return enableLogs;
    }
}
