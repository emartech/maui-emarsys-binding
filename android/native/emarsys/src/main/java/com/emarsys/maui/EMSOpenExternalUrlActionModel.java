package com.emarsys.maui;

import java.net.URL;

public class EMSOpenExternalUrlActionModel extends EMSActionModel {
    private final URL url;

    public EMSOpenExternalUrlActionModel(String id, String title, String type, URL url) {
        super(id, title, type);
        this.url = url;
    }

    public URL getUrl() {
        return url;
    }
}
