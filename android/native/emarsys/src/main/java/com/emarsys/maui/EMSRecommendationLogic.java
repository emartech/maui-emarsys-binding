package com.emarsys.maui;

import androidx.annotation.NonNull;
import java.util.List;

public class EMSRecommendationLogic {

    private final String name;
    private final String query;
    private final List<EMSCartItem> cartItems;
    private final List<String> variants;

    public EMSRecommendationLogic(@NonNull String name, String query, List<EMSCartItem> cartItems, List<String> variants) {
        this.name = name;
        this.query = query;
        this.cartItems = cartItems;
        this.variants = variants;
    }

    public @NonNull String getName() { return name; }

    public String getQuery() { return query; }

    public List<EMSCartItem> getCartItems() { return cartItems; }

    public List<String> getVariants() { return variants; }

}
