//
//  Copyright © 2024 Emarsys. All rights reserved.
//

import Foundation
import EmarsysSDK

@objc(DotnetEmarsysInApp)
public class DotnetEmarsysInApp: NSObject {
    
    @objc
    public func setEventHandler(_ eventHandler: @escaping EventHandler) {
        Emarsys.inApp.eventHandler = eventHandler
    }
    
    @objc
    public func pause() {
        Emarsys.inApp.pause()
    }
    
    @objc
    public func resume() {
        Emarsys.inApp.resume()
    }
    
    @objc
    public func isPaused() -> Bool {
        return Emarsys.inApp.isPaused()
    }
    
    @objc
    public func InlineInAppView() -> UIView {
        return EMSInlineInAppView()
    }
    
    @objc
    public func setInlineInAppEventHandler(_ view: UIView, _ eventHandler: @escaping EventHandler) {
        (view as? EMSInlineInAppView)?.eventHandler = eventHandler
    }
    
    @objc
    public func setInlineInAppCompletionBlock(_ view: UIView, _ completionBlock: @escaping CompletionBlock) {
        (view as? EMSInlineInAppView)?.completionBlock = completionBlock
    }
    
    @objc
    public func setInlineInAppCloseBlock(_ view: UIView, _ closeBlock: @escaping () -> Void) {
        (view as? EMSInlineInAppView)?.closeBlock = closeBlock
    }
    
    @objc
    public func loadInlineInApp(_ view: UIView, _ viewId: String) {
        (view as? EMSInlineInAppView)?.loadInApp(viewId: viewId)
    }
    
    @objc
    public func setOnEventActionEventHandler(_ eventHandler: @escaping EventHandler) {
        Emarsys.onEventAction.eventHandler = eventHandler
    }
    
}
