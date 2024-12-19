//
//  Copyright © 2024 Emarsys. All rights reserved.
//

import Foundation
import EmarsysSDK

@objc(DotnetEmarsysInApp)
public class DotnetEmarsysInApp: NSObject {
    
    @objc
    public static func setEventHandler(_ eventHandler: @escaping EventHandler) {
        Emarsys.inApp.eventHandler = eventHandler
    }
    
    @objc
    public static func pause() {
        Emarsys.inApp.pause()
    }
    
    @objc
    public static func resume() {
        Emarsys.inApp.resume()
    }
    
    @objc
    public static func isPaused() -> Bool {
        return Emarsys.inApp.isPaused()
    }
    
    @objc
    public static func createInlineInAppView() -> UIView {
        return EMSInlineInAppView()
    }
    
    @objc
    public static func setInlineInAppEventHandler(_ view: UIView, _ eventHandler: @escaping EventHandler) {
        (view as? EMSInlineInAppView)?.eventHandler = eventHandler
    }
    
    @objc
    public static func setInlineInAppCompletionListener(_ view: UIView, _ completionBlock: @escaping CompletionBlock) {
        (view as? EMSInlineInAppView)?.completionBlock = completionBlock
    }
    
    @objc
    public static func setInlineInAppCloseListener(_ view: UIView, _ closeBlock: @escaping () -> Void) {
        (view as? EMSInlineInAppView)?.closeBlock = closeBlock
    }
    
    @objc
    public static func loadInlineInApp(_ view: UIView, _ viewId: String) {
        (view as? EMSInlineInAppView)?.loadInApp(viewId: viewId)
    }
    
    @objc
    public static func setOnEventActionEventHandler(_ eventHandler: @escaping EventHandler) {
        Emarsys.onEventAction.eventHandler = eventHandler
    }
    
}
