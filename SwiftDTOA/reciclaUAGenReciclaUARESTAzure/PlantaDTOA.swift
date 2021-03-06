//
// PlantaDTOA.swift
// 
// Code autogenerated. Do not modify this file.
//

import Foundation
import SwiftyJSON
		
class PlantaDTOA : DTOA
{
	// MARK: - Properties

	var id: Int?;
	
	var planta: Planta?;
	
	
	
	
	
	// MARK: - Constructor
	
	init ()
	{
		// Empty constructor
	}
	
	
	
	// MARK: - JSON <-> DTOA
	
	required init (fromJSONObject json: JSON)
	{
		self.id = json["Id"].object as? Int
		
	
		if let enumValue = json["Planta"].object as? Int
		{
			self.planta = Planta(rawValue: enumValue);
		}
		
		
	}
	
	func toDictionary() -> [String : AnyObject]
	{
		var dictionary: [String : AnyObject] = [:];
		
		dictionary["Id"] = self.id;
		
	

	
		dictionary["Planta"] = self.planta?.rawValue;
	
	
		
		
		
		return dictionary;
	}
}

	