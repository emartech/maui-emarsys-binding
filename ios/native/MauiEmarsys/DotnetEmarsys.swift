//
//  Copyright © 2024 Emarsys. All rights reserved.
//

import Foundation
import EmarsysSDK

@objc(DotnetEmarsys)
public class DotnetEmarsys: NSObject {
    
    @objc
    public static func setup(_ config: EMSConfig) {
        Emarsys.setup(config: config)
    }
    
    @objc
    public static func setContact(_ contactFieldId: Int, _ contactFieldValue: String, _ completionBlock: @escaping CompletionBlock) {
        Emarsys.setContact(contactFieldId: contactFieldId as NSNumber, contactFieldValue: contactFieldValue, completionBlock: completionBlock)
    }
    
    @objc
    public static func clearContact(_ completionBlock: @escaping CompletionBlock) {
        Emarsys.clearContact(completionBlock: completionBlock)
    }
    
    @objc
    public static func trackCustomEvent(_ eventName: String, _ eventAttributes: [String: String]?, _ completionBlock: @escaping CompletionBlock) {
        Emarsys.trackCustomEvent(eventName: eventName, eventAttributes: eventAttributes, completionBlock: completionBlock)
    }
    
    @objc
    public static func trackDeepLink(_ userActivity: NSUserActivity, _ sourceHandler: ((String) -> Void)?) -> Bool {
        return Emarsys.trackDeepLink(userActivity: userActivity, sourceHandler: sourceHandler)
    }
    
}
