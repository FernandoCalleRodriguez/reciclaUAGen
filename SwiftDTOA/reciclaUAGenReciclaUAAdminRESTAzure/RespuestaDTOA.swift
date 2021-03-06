//
// RespuestaDTOA.swift
// 
// Code autogenerated. Do not modify this file.
//

import Foundation
import SwiftyJSON
		
class RespuestaDTOA : DTOA
{
	// MARK: - Properties

	var id: Int?;
	
	var cuerpo: String?;
	var fecha: NSDate?;
	var esCorrecta: Bool?;
	var util: Int?;
	
	/* Rol: Respuesta o--> UsuarioAdminAutenticado */
	var usuarioRespuesta: UsuarioAdminAutenticadoDTOA?;

	
	
	
	
	// MARK: - Constructor
	
	init ()
	{
		// Empty constructor
	}
	
	
	
	// MARK: - JSON <-> DTOA
	
	required init (fromJSONObject json: JSON)
	{
		self.id = json["Id"].object as? Int
		
	
		self.cuerpo = json["Cuerpo"].object as? String;
	
		self.fecha = NSDate.initFromString(json["Fecha"].object as? String);
		self.esCorrecta = json["EsCorrecta"].object as? Bool;
		self.util = json["Util"].object as? Int;
		
		if (json["UsuarioRespuesta"] != JSON.null)
		{
			self.usuarioRespuesta = UsuarioAdminAutenticadoDTOA(fromJSONObject: json["UsuarioRespuesta"]);
		}

		
	}
	
	func toDictionary() -> [String : AnyObject]
	{
		var dictionary: [String : AnyObject] = [:];
		
		dictionary["Id"] = self.id;
		
	

	
		dictionary["Cuerpo"] = self.cuerpo;
	
	

	
		dictionary["Fecha"] = self.fecha?.toString();
	
	

	
		dictionary["EsCorrecta"] = self.esCorrecta;
	
	

	
		dictionary["Util"] = self.util;
	
	
		
		dictionary["UsuarioRespuesta"] = self.usuarioRespuesta?.toDictionary() ?? NSNull();

		
		
		return dictionary;
	}
}

	