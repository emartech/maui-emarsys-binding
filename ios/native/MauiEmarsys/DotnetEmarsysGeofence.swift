//
//  Copyright © 2024 Emarsys. All rights reserved.
//

import Foundation
import EmarsysSDK

@objc(DotnetEmarsysGeofence)
public class DotnetEmarsysGeofence: NSObject {
    
    @objc
    public static func setInitialEnterTriggerEnabled(_ initialEnterTriggerEnabled: Bool) {
        Emarsys.geofence.initialEnterTriggerEnabled = initialEnterTriggerEnabled
    }
    
    @objc
    public static func enable(_ completionBlock: @escaping CompletionBlock) {
        Emarsys.geofence.enable(completionBlock: completionBlock)
    }
    
    @objc
    public static func disable() {
        Emarsys.geofence.disable()
    }
    
    @objc
    public static func isEnabled() -> Bool {
        return Emarsys.geofence.isEnabled()
    }
    
    @objc
    public static func setEventHandler(_ eventHandler: @escaping EventHandler) {
        Emarsys.geofence.eventHandler = eventHandler
    }
    
    @objc
    public static func registeredGeofences() -> [EMSGeofence] {
        return Emarsys.geofence.registeredGeofences()
    }
    
}
