//
//  Created by Emarsys on 06.11.2024.
//

@objc(DotnetEMSConfig)
public class DotnetEMSConfig: NSObject {
    var applicationCode: String?
    var merchantId: String?
    var sharedKeychainAccessGroup: String?
    var enableLogs: Bool = false

    init(applicationCode: String?, merchantId: String?, sharedKeychainAccessGroup: String?, enableLogs: Bool = false) {
        self.applicationCode = applicationCode
        self.merchantId = merchantId
        self.sharedKeychainAccessGroup = sharedKeychainAccessGroup
        self.enableLogs = enableLogs
    }
}
