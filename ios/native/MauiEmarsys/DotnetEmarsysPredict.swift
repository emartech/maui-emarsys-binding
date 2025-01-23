//
//  Copyright © 2024 Emarsys. All rights reserved.
//

import Foundation
import EmarsysSDK

@objc(DotnetEmarsysPredict)
public class DotnetEmarsysPredict: NSObject {
    
    @objc
    public static func buildCartItem(_ itemId: String, _ price: Double, _ quantity: Double) -> EMSCartItem {
        return EMSCartItem.init(itemId: itemId, price: price, quantity: quantity)
    }
    
    @objc
    public static func trackCart(_ items: [EMSCartItem]) {
        Emarsys.predict.trackCart(items: items)
    }
    
    @objc
    public static func trackPurchase(_ orderId: String, _ items: [EMSCartItem]) {
        Emarsys.predict.trackPurchase(orderId: orderId, items: items)
    }
    
    @objc
    public static func trackItemView(_ itemId: String) {
        Emarsys.predict.trackItem(itemId: itemId)
    }
    
    @objc
    public static func trackCategoryView(_ categoryPath: String) {
        Emarsys.predict.trackCategory(categoryPath: categoryPath)
    }
    
    @objc
    public static func trackSearchTerm(_ searchTerm: String) {
        Emarsys.predict.trackSearch(searchTerm: searchTerm)
    }
    
    @objc
    public static func trackTag(_ tag: String, _ attributes: [String: String]?) {
        Emarsys.predict.trackTag(tag: tag, attributes: attributes)
    }
    
    @objc
    public static func buildLogic(_ name: String, _ query: String?, _ cartItems: [EMSCartItem]?, _ variants: [String]?) -> EMSLogic {
        switch name {
        case "SEARCH":
            return EMSLogic.search(searchTerm: query)
        case "CART":
            return EMSLogic.cart(cartItems: cartItems)
        case "RELATED":
            return EMSLogic.related(itemId: query)
        case "CATEGORY":
            return EMSLogic.category(categoryPath: query)
        case "ALSO_BOUGHT":
            return EMSLogic.alsoBought(itemId: query)
        case "POPULAR":
            return EMSLogic.popular(categoryPath: query)
        case "PERSONAL":
            return EMSLogic.personal(variants: variants)
        case "HOME":
            return EMSLogic.home(variants: variants)
        default:
            return EMSLogic.search()
        }
    }
    
    @objc
    public static func buildFilter(_ type: String, _ field: String, _ comparison: String, _ expectations: [String]) -> EMSRecommendationFilterProtocol {
        switch type {
        case "INCLUDE":
            switch comparison {
            case "IS":
                return EMSRecommendationFilter.include(withField: field, isValue: expectations[0])
            case "IN":
                return EMSRecommendationFilter.include(withField: field, inValues: expectations)
            case "HAS":
                return EMSRecommendationFilter.include(withField: field, hasValue: expectations[0])
            case "OVERLAPS":
                return EMSRecommendationFilter.include(withField: field, overlapsValues: expectations)
            default:
                break
            }
        case "EXCLUDE":
            switch comparison {
            case "IS":
                return EMSRecommendationFilter.excludeFilter(withField: field, isValue: expectations[0])
            case "IN":
                return EMSRecommendationFilter.excludeFilter(withField: field, inValues: expectations)
            case "HAS":
                return EMSRecommendationFilter.excludeFilter(withField: field, hasValue: expectations[0])
            case "OVERLAPS":
                return EMSRecommendationFilter.excludeFilter(withField: field, overlapsValues: expectations)
            default:
                break
            }
        default:
            break
        }
        return EMSRecommendationFilter.include(withField: field, isValue: expectations[0])
    }
    
    @objc
    public static func recommendProducts(_ logic: EMSLogic, _ filters: [EMSRecommendationFilter]?, _ limit: NSNumber?, _ availabilityZone: String?,
                                         _ completionBlock: @escaping ([EMSProductProtocol]?, Error?) -> Void) {
        Emarsys.predict.recommendProducts(logic: logic, filters: filters, limit: limit, availabilityZone: availabilityZone, productsBlock: completionBlock)
    }
    
    @objc
    public static func trackRecommendationClick(_ product: EMSProduct) {
        Emarsys.predict.trackRecommendationClick(product: product)
    }
    
}
