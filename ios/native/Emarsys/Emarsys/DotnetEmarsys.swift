//
//  DotnetEmarsys.swift
//  Emarsys
//
//  Created by .NET MAUI team on 6/18/24.
//

import Foundation

@objc(DotnetEmarsys)
public class DotnetEmarsys : NSObject
{

    @objc
    public static func getString(myString: String) -> String {
        return myString  + " from swift!"
    }

}
