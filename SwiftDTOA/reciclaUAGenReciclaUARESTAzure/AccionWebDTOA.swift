//
// AccionWebDTOA.swift
// 
// Code autogenerated. Do not modify this file.
//

import Foundation
import SwiftyJSON
		
class AccionWebDTOA : DTOA
{
	// MARK: - Properties

	var id: Int?;
	
	var fecha: NSDate?;
	
	/* Rol: AccionWeb o--> TipoAccion */
	var tipo: TipoAccionDTOA?;

	
	
	
	
	// MARK: - Constructor
	
	init ()
	{
		// Empty constructor
	}
	
	
	
	// MARK: - JSON <-> DTOA
	
	required init (fromJSONObject json: JSON)
	{
		self.id = json["Id"].object as? Int
		
	
	
		self.fecha = NSDate.initFromString(json["Fecha"].object as? String);
		
		if (json["Tipo"] != JSON.null)
		{
			self.tipo = TipoAccionDTOA(fromJSONObject: json["Tipo"]);
		}

		
	}
	
	func toDictionary() -> [String : AnyObject]
	{
		var dictionary: [String : AnyObject] = [:];
		
		dictionary["Id"] = self.id;
		
	

	
		dictionary["Fecha"] = self.fecha?.toString();
	
	
		
		dictionary["Tipo"] = self.tipo?.toDictionary() ?? NSNull();

		
		
		return dictionary;
	}
}

	