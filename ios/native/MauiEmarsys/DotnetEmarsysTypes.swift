//
//  Copyright © 2024 Emarsys. All rights reserved.
//

import Foundation
import EmarsysSDK

public typealias CompletionBlock = (Error?) -> Void
public typealias EventHandler = (String, [String: Any]?) -> Void
public typealias ResultCallback = ([[String : Any]]?, Error?) -> Void
