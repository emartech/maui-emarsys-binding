package com.emarsys.maui;

import java.util.Map;

public class EMSCustomEventActionModel extends EMSActionModel {
    private final String name;
    private final Map<String, Object> payload;

    public EMSCustomEventActionModel(String id, String title, String type, String name, Map<String, Object> payload) {
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
