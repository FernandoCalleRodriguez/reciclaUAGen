//
// UsuarioWebDTOA.swift
// 
// Code autogenerated. Do not modify this file.
//

import Foundation
import SwiftyJSON
		
class UsuarioWebDTOA : DTOA
{
	// MARK: - Properties

	
	var nombre: String?;
	var apellidos: String?;
	var email: String?;
	var id: Int?;
	
	
	
	
	
	// MARK: - Constructor
	
	init ()
	{
		// Empty constructor
	}
	
	
	
	// MARK: - JSON <-> DTOA
	
	required init (fromJSONObject json: JSON)
	{
		
	
		self.nombre = json["Nombre"].object as? String;
		self.apellidos = json["Apellidos"].object as? String;
		self.email = json["Email"].object as? String;
		self.id = json["Id"].object as? Int;
		
		
	}
	
	func toDictionary() -> [String : AnyObject]
	{
		var dictionary: [String : AnyObject] = [:];
		
		
	

	
		dictionary["Nombre"] = self.nombre;
	
	

	
		dictionary["Apellidos"] = self.apellidos;
	
	

	
		dictionary["Email"] = self.email;
	
	

	
		dictionary["Id"] = self.id;
	
	
		
		
		
		return dictionary;
	}
}

	