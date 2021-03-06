//
// PuntoReciclajeDTOA.swift
// 
// Code autogenerated. Do not modify this file.
//

import Foundation
import SwiftyJSON
		
class PuntoReciclajeDTOA : DTOA
{
	// MARK: - Properties

	var id: Int?;
	
	var latitud: Double?;
	var longitud: Double?;
	var esValido: Estado?;
	
	/* Rol: PuntoReciclaje o--> Contenedor */
	var contenedores: [ContenedorDTOA]?;

	/* Rol: PuntoReciclaje o--> Estancia */
	var estanciaPunto: EstanciaDTOA?;

	
	
	
	
	// MARK: - Constructor
	
	init ()
	{
		// Empty constructor
	}
	
	
	
	// MARK: - JSON <-> DTOA
	
	required init (fromJSONObject json: JSON)
	{
		self.id = json["Id"].object as? Int
		
	
		self.latitud = json["Latitud"].object as? Double;
		self.longitud = json["Longitud"].object as? Double;
		if let enumValue = json["EsValido"].object as? Int
		{
			self.esValido = Estado(rawValue: enumValue);
		}
		
		if (json["Contenedores"] != JSON.null)
		{
			self.contenedores = [];
			for subJson in json["Contenedores"].arrayValue
			{
				self.contenedores!.append(ContenedorDTOA(fromJSONObject: subJson));
			}
		}

		if (json["EstanciaPunto"] != JSON.null)
		{
			self.estanciaPunto = EstanciaDTOA(fromJSONObject: json["EstanciaPunto"]);
		}

		
	}
	
	func toDictionary() -> [String : AnyObject]
	{
		var dictionary: [String : AnyObject] = [:];
		
		dictionary["Id"] = self.id;
		
	

	
		dictionary["Latitud"] = self.latitud;
	
	

	
		dictionary["Longitud"] = self.longitud;
	
	

	
		dictionary["EsValido"] = self.esValido?.rawValue;
	
	
		
		dictionary["Contenedores"] = NSNull();
		if (self.contenedores != nil)
		{
			var arrayOfDictionary: [[String : AnyObject]] = [];
			for item in self.contenedores!
			{
				arrayOfDictionary.append(item.toDictionary());
			}
			
			dictionary["Contenedores"] = arrayOfDictionary;
		}

		dictionary["EstanciaPunto"] = self.estanciaPunto?.toDictionary() ?? NSNull();

		
		
		return dictionary;
	}
}

	