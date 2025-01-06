package com.emarsys.maui;

import java.util.List;
import java.util.Map;

public class EMSMessage {
    private final String id;
    private final String campaignId;
    private final String collapseId;
    private final String title;
    private final String body;
    private final String imageUrl;
    private final long receivedAt;
    private final long updatedAt;
    private final long expiresAt;
    private final List<String> tags;
    private final Map<String, String> properties;
    private final List<EMSActionModel> actions;

    public EMSMessage(String id, String campaignId, String collapseId, String title, String body, String imageUrl,
                      long receivedAt, long updatedAt, long expiresAt, List<String> tags, Map<String, String> properties,
                      List<EMSActionModel> actions) {
        this.id = id;
        this.campaignId = campaignId;
        this.collapseId = collapseId;
        this.title = title;
        this.body = body;
        this.imageUrl = imageUrl;
        this.receivedAt = receivedAt;
        this.updatedAt = updatedAt;
        this.expiresAt = expiresAt;
        this.tags = tags;
        this.properties = properties;
        this.actions = actions;
    }

    public String getId() {
        return id;
    }

    public String getCampaignId() {
        return campaignId;
    }

    public String getCollapseId() {
        return collapseId;
    }

    public String getTitle() {
        return title;
    }

    public String getBody() {
        return body;
    }

    public String getImageUrl() {
        return imageUrl;
    }

    public long getReceivedAt() {
        return receivedAt;
    }

    public Long getUpdatedAt() {
        return updatedAt;
    }

    public Long getExpiresAt() {
        return expiresAt;
    }

    public List<String> getTags() {
        return tags;
    }

    public Map<String, String> getProperties() {
        return properties;
    }

    public List<EMSActionModel> getActions() {
        return actions;
    }
}

