package com.emarsys.maui;

public abstract class EMSActionModel {
    private final String id;
    private final String title;
    private final String type;

    public EMSActionModel(String id, String title, String type) {
        this.id = id;
        this.title = title;
        this.type = type;
    }

    public String getId() {
        return id;
    }

    public String getTitle() {
        return title;
    }

    public String getType() {
        return type;
    }
}
