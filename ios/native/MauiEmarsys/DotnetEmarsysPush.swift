//
//  Copyright © 2024 Emarsys. All rights reserved.
//

import Foundation
import EmarsysSDK

@objc(DotnetEmarsysPush)
public class DotnetEmarsysPush: NSObject {
    
    @objc
    public func setDelegate() {
        UNUserNotificationCenter.current().delegate = Emarsys.push
    }
    
    @objc
    public func setEventHandler(_ eventHandler: @escaping EventHandler) {
        Emarsys.push.notificationEventHandler = eventHandler
    }
    
    @objc
    public func setPushToken(_ pushToken: Data) {
        Emarsys.push.setPushToken(pushToken)
    }
    
    @objc
    public func setPushToken(_ pushToken: Data, _ completionBlock: @escaping CompletionBlock) {
        Emarsys.push.setPushToken(pushToken: pushToken, completionBlock: completionBlock)
    }
    
    @objc
    public func clearPushToken() {
        Emarsys.push.clearPushToken()
    }
    
    @objc
    public func clearPushToken(_ completionBlock: @escaping CompletionBlock) {
        Emarsys.push.clearPushToken(completionBlock: completionBlock)
    }
    
    @objc
    public func getPushToken() -> String? {
        guard let token = Emarsys.push.pushToken() else { return nil }
        return token.map { data in String(format: "%02.2hhx", data) }.joined()
    }
    
    @objc
    public func handleMessage(_ userInfo: [AnyHashable : Any]) {
        Emarsys.push.handleMessage(userInfo: userInfo)
    }
    
}
