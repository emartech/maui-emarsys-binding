//
//  Copyright © 2024 Emarsys. All rights reserved.
//

import Foundation
import EmarsysSDK

@objc(DotnetEmarsysInbox)
public class DotnetEmarsysInbox: NSObject {
    
    @objc
    public static func fetchMessages(_ resultCallback: @escaping ResultCallback) {
        Emarsys.messageInbox.fetchMessages(resultBlock: { result, error in
            if error != nil {
                resultCallback(nil, error)
            } else {
                if let messages = result?.messages {
                    resultCallback(mapInbox(messages), nil)
                } else {
                    resultCallback([], nil)
                }
            }
        })
    }
    
    @objc
    public static func addTag(_ tag: String, messageId: String, _ completionBlock: @escaping CompletionBlock) {
        Emarsys.messageInbox.addTag(tag: tag, messageId: messageId, completionBlock: completionBlock)
    }
    
    @objc
    public static func removeTag(_ tag: String, messageId: String, _ completionBlock: @escaping CompletionBlock) {
        Emarsys.messageInbox.removeTag(tag: tag, messageId: messageId, completionBlock: completionBlock)
    }
    
    static func mapInbox(_ input: [EMSMessage]) -> [[String : Any]]? {
        let messageDicts: [[String: Any]]? = input.map { message in
            var messageDict = [String: Any]()
            messageDict["id"] = message.id
            messageDict["campaignId"] = message.campaignId
            messageDict["collapseId"] = message.collapseId
            messageDict["title"] = message.title
            messageDict["body"] = message.body
            messageDict["imageUrl"] = message.imageUrl
            messageDict["receivedAt"] = message.receivedAt
            messageDict["updatedAt"] = message.updatedAt
            messageDict["expiresAt"] = message.expiresAt
            messageDict["tags"] = message.tags
            messageDict["properties"] = message.properties
            if let actions = message.actions {
                let actionDicts: [[String: Any]]? = actions.map { action in
                    return dictFromAction(action: action)
                }
                messageDict["actions"] = actionDicts
            }
            return messageDict
        }
        return messageDicts
    }
    
    static func dictFromAction(action: EMSActionModelProtocol) -> [String: Any] {
        var actionDict = [String: Any]()
        if let appAction = action as? EMSAppEventActionModel {
            actionDict["id"] = appAction.id
            actionDict["title"] = appAction.title
            actionDict["type"] = appAction.type
            actionDict["name"] = appAction.name
            actionDict["payload"] = appAction.payload
        } else if let appAction = action as? EMSCustomEventActionModel {
            actionDict["id"] = appAction.id
            actionDict["title"] = appAction.title
            actionDict["type"] = appAction.type
            actionDict["name"] = appAction.name
            actionDict["payload"] = appAction.payload
        } else if let appAction = action as? EMSOpenExternalUrlActionModel {
            actionDict["id"] = appAction.id
            actionDict["title"] = appAction.title
            actionDict["type"] = appAction.type
            actionDict["url"] = appAction.url.absoluteString
        }
        return actionDict
    }
}
