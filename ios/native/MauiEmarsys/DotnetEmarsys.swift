//
//  Copyright © 2024 Emarsys. All rights reserved.
//

import Foundation
import EmarsysSDK

public typealias CompletionBlock = ((Error?) -> Void)
public typealias EventHandlerBlock = ((String, [String: Any]?) -> Void)

@objc(DotnetEmarsys)
public class DotnetEmarsys: NSObject {
    
    @objc public static var pushEventHandler: EventHandlerBlock?
    
    @objc
    public static func setup(_ dotnetConfig: DotnetEMSConfig) {
        let config = EMSConfig.make { (build) in
            if let applicationCode = dotnetConfig.applicationCode, applicationCode != "" {
                build.setMobileEngageApplicationCode(applicationCode)
            }
            if let merchantId = dotnetConfig.merchantId, merchantId != "" {
                build.setMerchantId(merchantId)
            }
            if let sharedKeychainAccessGroup = dotnetConfig.sharedKeychainAccessGroup, sharedKeychainAccessGroup != "" {
                build.setSharedKeychainAccessGroup(sharedKeychainAccessGroup)
            }
            if dotnetConfig.enableLogs {
                build.enableConsoleLogLevels([EMSLogLevel.basic, EMSLogLevel.error, EMSLogLevel.info, EMSLogLevel.debug])
            }
        }
        Emarsys.setup(config: config)
        
        UNUserNotificationCenter.current().delegate = Emarsys.push
        Emarsys.push.notificationEventHandler = { name, payload in
            pushEventHandler?(name, payload)
        }
    }
    
    @objc
    public static func config(_ applicationCode: String?, _ merchantId: String?, _ sharedKeychainAccessGroup: String?, _ enableLogs: Bool = false) -> DotnetEMSConfig {
        return DotnetEMSConfig(applicationCode: applicationCode, merchantId: merchantId, sharedKeychainAccessGroup: sharedKeychainAccessGroup, enableLogs: enableLogs)
    }
    
    @objc
    public static func setPushToken(_ token: Data) {
        Emarsys.push.setPushToken(token)
    }
    
    @objc
    public static func setContact(_ contactFieldId: Int, _ contactFieldValue: String) {
        Emarsys.setContact(contactFieldId: contactFieldId as NSNumber, contactFieldValue: contactFieldValue)
    }
    
    @objc
    public static func setContact(_ contactFieldId: Int, _ contactFieldValue: String, _ completionBlock: CompletionBlock?) {
        Emarsys.setContact(contactFieldId: contactFieldId as NSNumber, contactFieldValue: contactFieldValue, completionBlock: completionBlock)
    }
    
    @objc
    public static func clearContact() {
        Emarsys.clearContact()
    }
}
