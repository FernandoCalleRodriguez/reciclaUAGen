	
		//
		// DudaDTO.swift
		// 
		// Code autogenerated. Do not modify this file.
		//
		
		import Foundation
		import SwiftyJSON
	
		 class DudaDTO 	    {
		 
				var id: Int?;
				    	 
		 
				var titulo: String?;
				    	 
		 
				var cuerpo: String?;
				    	 
		 
				var usuario_oid: Int?;
				    	 
		 
				var respuestas: [RespuestaDTO]?;
				    	 
		 
				var fecha: NSDate?;
				    	 
		 
				var util: Int?;
				    	 
		 
				var tema: Tema?;
				    	 
	   	   
			// MARK: - Constructor
			
			
		
			init ()
			{
				// Empty constructor
			}
			 func toDictionary() -> [String : AnyObject]
		
		   
			{
				var dictionary: [String : AnyObject] = [:];
				
			


				
					dictionary["id"] = self.id;
				

				
					dictionary["titulo"] = self.titulo;
				

				
					dictionary["cuerpo"] = self.cuerpo;
				

					dictionary["usuario_oid"] = self.usuario_oid;
			

					dictionary["respuestas"] = NSNull();
					if (self.respuestas != nil)
					{
						var arrayOfDictionary: [[String : AnyObject]] = [];
						for item in self.respuestas!
						{
							arrayOfDictionary.append(item.toDictionary());
						}
						
						dictionary["respuestas"] = arrayOfDictionary;
					}
			

				
					dictionary["fecha"] = self.fecha?.toString();
				

				
					dictionary["util"] = self.util;
				

				
					dictionary["tema"] = self.tema?.rawValue;
				
						
				return dictionary;
			}
		}
		
	