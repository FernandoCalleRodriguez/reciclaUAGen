//
// UsuarioWebAutenticadoDTOA.swift
// 
// Code autogenerated. Do not modify this file.
//

import Foundation
import SwiftyJSON
		
class UsuarioWebAutenticadoDTOA : DTOA
{
	// MARK: - Properties

	
	var nombre: String?;
	var apellidos: String?;
	var email: String?;
	var id: Int?;
	var puntuacion: Int?;
	var fecha: NSDate?;
	var borrado: Bool?;
	
	/* Rol: UsuarioWebAutenticado o--> Juego */
	var juegoUsuario: JuegoDTOA?;

	
	
	
	
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
		self.puntuacion = json["Puntuacion"].object as? Int;
	
		self.fecha = NSDate.initFromString(json["Fecha"].object as? String);
		self.borrado = json["Borrado"].object as? Bool;
		
		if (json["JuegoUsuario"] != JSON.null)
		{
			self.juegoUsuario = JuegoDTOA(fromJSONObject: json["JuegoUsuario"]);
		}

		
	}
	
	func toDictionary() -> [String : AnyObject]
	{
		var dictionary: [String : AnyObject] = [:];
		
		
	

	
		dictionary["Nombre"] = self.nombre;
	
	

	
		dictionary["Apellidos"] = self.apellidos;
	
	

	
		dictionary["Email"] = self.email;
	
	

	
		dictionary["Id"] = self.id;
	
	

	
		dictionary["Puntuacion"] = self.puntuacion;
	
	

	
		dictionary["Fecha"] = self.fecha?.toString();
	
	

	
		dictionary["Borrado"] = self.borrado;
	
	
		
		dictionary["JuegoUsuario"] = self.juegoUsuario?.toDictionary() ?? NSNull();

		
		
		return dictionary;
	}
}

	