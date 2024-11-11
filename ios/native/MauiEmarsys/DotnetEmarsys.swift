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
    }
    
    @objc
    public static func setContact(_ contactFieldId: Int, _ contactFieldValue: String) {
        Emarsys.setContact(contactFieldId: contactFieldId as NSNumber, contactFieldValue: contactFieldValue)
    }
    
    @objc
    public static func setContact(_ contactFieldId: Int, _ contactFieldValue: String, _ completionBlock: @escaping CompletionBlock) {
        Emarsys.setContact(contactFieldId: contactFieldId as NSNumber, contactFieldValue: contactFieldValue, completionBlock: completionBlock)
    }
    
    @objc
    public static func clearContact() {
        Emarsys.clearContact()
    }
    
    @objc
    public static func clearContact(_ completionBlock: @escaping CompletionBlock) {
        Emarsys.clearContact(completionBlock: completionBlock)
    }
    
    @objc
    public static func getPush() -> DotnetEmarsysPush {
        return DotnetEmarsysPush()
    }
    
}
