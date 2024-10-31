//
//  Copyright © 2024 Emarsys. All rights reserved.
//

import Foundation
import EmarsysSDK

@objc
public protocol EmarsysEventListener {
    @objc(onEventWithEventName:payload:)
    func onEvent(eventName: String, payload: [String: Any]?)
}

@objc(DotnetEmarsys)
public class DotnetEmarsys: NSObject {
    
    @objc public static var eventListener: EmarsysEventListener?
    
    @objc(setEmarsysEventListener:)
    public static func setEventListener(_ listener: EmarsysEventListener) {
        eventListener = listener
    }
    
    @objc
    public static func setup(applicationCode: String, merchantId: String?) {
        let config = EMSConfig.make { (build) in
            build.setMobileEngageApplicationCode(applicationCode)
            if let merchantId = merchantId, merchantId != "" {
                build.setMerchantId(merchantId)
            }
        }
        Emarsys.setup(config: config)
        UNUserNotificationCenter.current().delegate = Emarsys.push
        Emarsys.push.notificationEventHandler = { name, payload in
             print("Received event on native side: \(name), payload: \(payload ?? [:])")
             eventListener?.onEvent(eventName: name, payload: payload)
         }
    }
    
    @objc
    public static func setPushToken(token: NSData) {
        Emarsys.push.setPushToken(token as Data)
    }
    
    @objc
    public static func setContact(contactFieldId: Int, contactFieldValue: String) {
        Emarsys.setContact(contactFieldId: contactFieldId as NSNumber, contactFieldValue: contactFieldValue)
    }
}
