//
// AccionReciclarDTOA.swift
// 
// Code autogenerated. Do not modify this file.
//

import Foundation
import SwiftyJSON
		
class AccionReciclarDTOA : DTOA
{
	// MARK: - Properties

	var id: Int?;
	
	var cantidad: Int?;
	var fecha: NSDate?;
	
	/* Rol: AccionReciclar o--> Item */
	var itemAccion: ItemDTOA?;

	/* Rol: AccionReciclar o--> Contenedor */
	var contenedorAccion: ContenedorDTOA?;

	
	
	
	
	// MARK: - Constructor
	
	init ()
	{
		// Empty constructor
	}
	
	
	
	// MARK: - JSON <-> DTOA
	
	required init (fromJSONObject json: JSON)
	{
		self.id = json["Id"].object as? Int
		
	
		self.cantidad = json["Cantidad"].object as? Int;
	
		self.fecha = NSDate.initFromString(json["Fecha"].object as? String);
		
		if (json["ItemAccion"] != JSON.null)
		{
			self.itemAccion = ItemDTOA(fromJSONObject: json["ItemAccion"]);
		}

		if (json["ContenedorAccion"] != JSON.null)
		{
			self.contenedorAccion = ContenedorDTOA(fromJSONObject: json["ContenedorAccion"]);
		}

		
	}
	
	func toDictionary() -> [String : AnyObject]
	{
		var dictionary: [String : AnyObject] = [:];
		
		dictionary["Id"] = self.id;
		
	

	
		dictionary["Cantidad"] = self.cantidad;
	
	

	
		dictionary["Fecha"] = self.fecha?.toString();
	
	
		
		dictionary["ItemAccion"] = self.itemAccion?.toDictionary() ?? NSNull();

		dictionary["ContenedorAccion"] = self.contenedorAccion?.toDictionary() ?? NSNull();

		
		
		return dictionary;
	}
}

	