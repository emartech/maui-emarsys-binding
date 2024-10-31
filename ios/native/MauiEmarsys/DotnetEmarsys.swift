//
//  Copyright © 2024 Emarsys. All rights reserved.
//

import Foundation
import EmarsysSDK

@objc(DotnetEmarsys)
public class DotnetEmarsys : NSObject {
    
    @objc
    public static func setup(applicationCode: String, merchantId: String?) {
        let config = EMSConfig.make { (build) in
            build.setMobileEngageApplicationCode(applicationCode)
            if let merchantId = merchantId, merchantId != "" {
                build.setMerchantId(merchantId)
            }
        }
        Emarsys.setup(config: config)
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
