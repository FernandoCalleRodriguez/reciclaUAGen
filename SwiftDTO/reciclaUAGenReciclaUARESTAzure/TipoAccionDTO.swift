	
		//
		// TipoAccionDTO.swift
		// 
		// Code autogenerated. Do not modify this file.
		//
		
		import Foundation
		import SwiftyJSON
	
		 class TipoAccionDTO 	    {
		 
				var id: Int?;
				    	 
		 
				var puntuacion: Int?;
				    	 
		 
				var acciones_oid: [Int]?;
				    	 
		 
				var nombre: String?;
				    	 
	   	   
			// MARK: - Constructor
			
			
		
			init ()
			{
				// Empty constructor
			}
			 func toDictionary() -> [String : AnyObject]
		
		   
			{
				var dictionary: [String : AnyObject] = [:];
				
			


				
					dictionary["id"] = self.id;
				

				
					dictionary["puntuacion"] = self.puntuacion;
				

					dictionary["acciones_oid"] = self.acciones_oid;
			

				
					dictionary["nombre"] = self.nombre;
				
						
				return dictionary;
			}
		}
		
	