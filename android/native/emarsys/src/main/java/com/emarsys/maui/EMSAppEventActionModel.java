package com.emarsys.maui;

import java.util.Map;

public class EMSAppEventActionModel extends EMSActionModel {
    private final String name;
    private final Map<String, Object> payload;

    public EMSAppEventActionModel(String id, String title, String type, String name, Map<String, Object> payload) {
        super(id, title, type);
        this.name = name;
        this.payload = payload;
    }

    public String getName() {
        return name;
    }

    public Map<String, Object> getPayload() {
        return payload;
    }
}
