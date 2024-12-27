//
//  Copyright © 2024 Emarsys. All rights reserved.
//

import Foundation
import EmarsysSDK

@objc(DotnetEmarsysInbox)
public class DotnetEmarsysInbox: NSObject {
    
    @objc
    public static func addTag(_ tag: String, messageId: String, _ completionBlock: @escaping CompletionBlock) {
        Emarsys.messageInbox.addTag(tag: tag, messageId: messageId, completionBlock: completionBlock)
    }
    
    @objc
    public static func removeTag(_ tag: String, messageId: String, _ completionBlock: @escaping CompletionBlock) {
        Emarsys.messageInbox.removeTag(tag: tag, messageId: messageId, completionBlock: completionBlock)
    }
}
