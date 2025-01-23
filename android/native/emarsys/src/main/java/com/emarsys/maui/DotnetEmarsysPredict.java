package com.emarsys.maui;

import androidx.annotation.NonNull;
import com.emarsys.Emarsys;
import com.emarsys.core.api.result.ResultListener;
import com.emarsys.core.api.result.Try;
import com.emarsys.predict.api.model.Logic;
import com.emarsys.predict.api.model.PredictCartItem;
import com.emarsys.predict.api.model.Product;
import com.emarsys.predict.api.model.RecommendationFilter;
import com.emarsys.predict.api.model.RecommendationLogic;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

public class DotnetEmarsysPredict {

    public static @NonNull EMSCartItem buildCartItem(@NonNull String itemId, double price, double quantity) {
        return new EMSCartItem(itemId, price, quantity);
    }

    static @NonNull List<PredictCartItem> mapCartItems(@NonNull List<EMSCartItem> items) {
        List<PredictCartItem> _items = new ArrayList<>();
        for (int i = 0; i < items.size(); i++) {
            EMSCartItem item = items.get(i);
            _items.add(new PredictCartItem(item.getItemId(), item.getPrice(), item.getQuantity()));
        }
        return _items;
    }

    public static void trackCart(@NonNull List<EMSCartItem> items) {
        Emarsys.getPredict().trackCart(mapCartItems(items));
    }

    public static void trackPurchase(@NonNull String orderId, @NonNull List<EMSCartItem> items) {
        Emarsys.getPredict().trackPurchase(orderId, mapCartItems(items));
    }

    public static void trackItemView(@NonNull String itemId) {
        Emarsys.getPredict().trackItemView(itemId);
    }

    public static void trackCategoryView(@NonNull String categoryPath) {
        Emarsys.getPredict().trackCategoryView(categoryPath);
    }

    public static void trackSearchTerm(@NonNull String searchTerm) {
        Emarsys.getPredict().trackSearchTerm(searchTerm);
    }

    public static void trackTag(@NonNull String tag, Map<String, String> attributes) {
        Emarsys.getPredict().trackTag(tag, attributes);
    }

    public static @NonNull EMSRecommendationLogic buildLogic(@NonNull String name, String query, List<EMSCartItem> cartItems, List<String> variants) {
        return new EMSRecommendationLogic(name, query, cartItems, variants);
    }

    static @NonNull Logic mapLogic(@NonNull EMSRecommendationLogic logic) {
        switch (logic.getName()) {
            case "SEARCH":
                if (logic.getQuery() != null) { return RecommendationLogic.search(logic.getQuery()); }
                return RecommendationLogic.search();
            case "CART":
                if (logic.getCartItems() != null) { return RecommendationLogic.cart(mapCartItems(logic.getCartItems())); }
                return RecommendationLogic.cart();
            case "RELATED":
                if (logic.getQuery() != null) { return RecommendationLogic.related(logic.getQuery()); }
                return RecommendationLogic.related();
            case "CATEGORY":
                if (logic.getQuery() != null) { return RecommendationLogic.category(logic.getQuery()); }
                return RecommendationLogic.category();
            case "ALSO_BOUGHT":
                if (logic.getQuery() != null) { return RecommendationLogic.alsoBought(logic.getQuery()); }
                return RecommendationLogic.alsoBought();
            case "POPULAR":
                if (logic.getQuery() != null) { return RecommendationLogic.popular(logic.getQuery()); }
                return RecommendationLogic.popular();
            case "PERSONAL":
                if (logic.getVariants() != null) { return RecommendationLogic.personal(logic.getVariants()); }
                return RecommendationLogic.personal();
            case "HOME":
                if (logic.getVariants() != null) { return RecommendationLogic.home(logic.getVariants()); }
                return RecommendationLogic.home();
            default:
                return RecommendationLogic.search();
        }
    }

    public static @NonNull EMSRecommendationFilter buildFilter(
            @NonNull String type, @NonNull String field, @NonNull String comparison, @NonNull List<String> expectations) {
        return new EMSRecommendationFilter(type, field, comparison, expectations);
    }

    static List<RecommendationFilter> mapFilters(List<EMSRecommendationFilter> filters) {
        if (filters == null || filters.isEmpty()) { return null; }
        List<RecommendationFilter> _filters = new ArrayList<>();
        for (int i = 0; i < filters.size(); i++) {
            _filters.add(mapFilter(filters.get(i)));
        }
        return _filters;
    }

    static RecommendationFilter mapFilter(EMSRecommendationFilter filter) {
        switch (filter.getType()) {
            case "INCLUDE":
                switch (filter.getComparison()) {
                    case "IS":
                        return RecommendationFilter.include(filter.getField()).isValue(filter.getExpectations().get(0));
                    case "IN":
                        return RecommendationFilter.include(filter.getField()).inValues(filter.getExpectations());
                    case "HAS":
                        return RecommendationFilter.include(filter.getField()).hasValue(filter.getExpectations().get(0));
                    case "OVERLAPS":
                        return RecommendationFilter.include(filter.getField()).overlapsValues(filter.getExpectations());
                    default:
                        break;
                }
            case "EXCLUDE":
                switch (filter.getComparison()) {
                    case "IS":
                        return RecommendationFilter.exclude(filter.getField()).isValue(filter.getExpectations().get(0));
                    case "IN":
                        return RecommendationFilter.exclude(filter.getField()).inValues(filter.getExpectations());
                    case "HAS":
                        return RecommendationFilter.exclude(filter.getField()).hasValue(filter.getExpectations().get(0));
                    case "OVERLAPS":
                        return RecommendationFilter.exclude(filter.getField()).overlapsValues(filter.getExpectations());
                    default:
                        break;
                }
            default:
                break;
        }
        return RecommendationFilter.include(filter.getField()).isValue(filter.getExpectations().get(0));
    }

    public interface RecommendProductsCompletionListener {
        void onCompleted(List<EMSProduct> products, Throwable errorCause);
    }

    public static void recommendProducts(@NonNull EMSRecommendationLogic logic, List<EMSRecommendationFilter> filters, Integer limit, String availabilityZone,
                                         @NonNull RecommendProductsCompletionListener completionListener) {
        Logic _logic = mapLogic(logic);
        List<RecommendationFilter> _filters = mapFilters(filters);
        ResultListener<Try<List<Product>>> resultListener = (result) -> completionListener.onCompleted(mapProducts(result.getResult()), result.getErrorCause());

        if (_filters != null && limit != null && availabilityZone != null) {
            Emarsys.getPredict().recommendProducts(_logic, _filters, limit, availabilityZone, resultListener);
        } else if (_filters != null && limit != null) {
            Emarsys.getPredict().recommendProducts(_logic, _filters, limit, resultListener);
        } else if (_filters != null && availabilityZone != null) {
            Emarsys.getPredict().recommendProducts(_logic, _filters, availabilityZone, resultListener);
        } else if (limit != null && availabilityZone != null) {
            Emarsys.getPredict().recommendProducts(_logic, limit, availabilityZone, resultListener);
        } else if (_filters != null) {
            Emarsys.getPredict().recommendProducts(_logic, _filters, resultListener);
        } else if (limit != null) {
            Emarsys.getPredict().recommendProducts(_logic, limit, resultListener);
        } else if (availabilityZone != null) {
            Emarsys.getPredict().recommendProducts(_logic, availabilityZone, resultListener);
        } else {
            Emarsys.getPredict().recommendProducts(_logic, resultListener);
        }
    }

    static List<EMSProduct> mapProducts(List<Product> products) {
        if (products == null) { return null; }
        List<EMSProduct> _products = new ArrayList<>();
        for (int i = 0; i < products.size(); i++) {
            Product p = products.get(i);
            _products.add(new EMSProduct(
                    p.getProductId(), p.getTitle(), p.getLinkUrl(), p.getFeature(), p.getCohort(), p.getCustomFields(),
                    p.getImageUrl(), p.getZoomImageUrl(), p.getCategoryPath(), p.getAvailable(),
                    p.getProductDescription(), p.getPrice(), p.getMsrp(),
                    p.getAlbum(), p.getActor(), p.getArtist(), p.getAuthor(), p.getBrand(), p.getYear()
            ));
        }
        return _products;
    }

    public static void trackRecommendationClick(@NonNull EMSProduct product) {
        Emarsys.getPredict().trackRecommendationClick(new Product(
                product.getProductId(), product.getTitle(), product.getLinkUrl(),
                product.getFeature(), product.getCohort(), product.getCustomFields(),
                // These fields are not used for tracking recommendation click
                null, null, null, null,
                null, null, null, null, null,
                null, null, null, null, null, null
        ));
    }

}
