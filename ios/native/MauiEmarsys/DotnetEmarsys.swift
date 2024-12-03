//
//  Copyright © 2024 Emarsys. All rights reserved.
//

import Foundation
import EmarsysSDK

@objc(DotnetEmarsys)
public class DotnetEmarsys: NSObject {
    
    @objc
    public static func config(_ applicationCode: String?, _ merchantId: String?,
                              _ sharedKeychainAccessGroup: String?, _ enableConsoleLogging: Bool = false) -> EMSConfig {
        let config = EMSConfig.make { (build) in
            if let applicationCode = applicationCode, applicationCode != "" {
                build.setMobileEngageApplicationCode(applicationCode)
            }
            if let merchantId = merchantId, merchantId != "" {
                build.setMerchantId(merchantId)
            }
            if let sharedKeychainAccessGroup = sharedKeychainAccessGroup, sharedKeychainAccessGroup != "" {
                build.setSharedKeychainAccessGroup(sharedKeychainAccessGroup)
            }
            if enableConsoleLogging {
                build.enableConsoleLogLevels([EMSLogLevel.basic, EMSLogLevel.error, EMSLogLevel.info, EMSLogLevel.debug])
            }
        }
        return config
    }
    
    @objc
    public static func setup(_ config: EMSConfig) {
        Emarsys.setup(config: config)
        Emarsys.trackCustomEvent(eventName: "wrapper:init", eventAttributes: ["type" : "maui"])
    }
    
    @objc
    public static func setContact(_ contactFieldId: Int, _ contactFieldValue: String, _ completionBlock: CompletionBlock?) {
        Emarsys.setContact(contactFieldId: contactFieldId as NSNumber, contactFieldValue: contactFieldValue, completionBlock: completionBlock)
    }
    
    @objc
    public static func clearContact(_ completionBlock: CompletionBlock?) {
        Emarsys.clearContact(completionBlock: completionBlock)
    }
    
    @objc
    public static func trackCustomEvent(_ eventName: String, _ eventAttributes: [String: String]?, _ completionBlock: CompletionBlock?) {
        Emarsys.trackCustomEvent(eventName: eventName, eventAttributes: eventAttributes, completionBlock: completionBlock)
    }
    
    @objc
    public static let push = DotnetEmarsysPush()

    @objc
    public static let inApp = DotnetEmarsysInApp()
    
}
