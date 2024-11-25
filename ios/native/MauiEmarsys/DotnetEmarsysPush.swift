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
    public func setPushToken(_ pushToken: Data) {
        Emarsys.push.setPushToken(pushToken)
    }
    
    @objc
    public func setPushToken(_ pushToken: Data, _ completionBlock: @escaping CompletionBlock) {
        Emarsys.push.setPushToken(pushToken: pushToken, completionBlock: completionBlock)
    }
    
    @objc
    public func setEventHandler(_ eventHandler: @escaping EventHandler) {
        Emarsys.push.notificationEventHandler = eventHandler
    }
    
    @objc
    public func handleMessage(_ userInfo: [AnyHashable : Any]) {
        Emarsys.push.handleMessage(userInfo: userInfo)
    }
    
}
