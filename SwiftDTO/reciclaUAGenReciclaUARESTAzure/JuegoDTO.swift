	
		//
		// JuegoDTO.swift
		// 
		// Code autogenerated. Do not modify this file.
		//
		
		import Foundation
		import SwiftyJSON
	
		 class JuegoDTO 	    {
		 
				var id: Int?;
				    	 
		 
				var itemActual: Int?;
				    	 
		 
				var aciertos: Int?;
				    	 
		 
				var fallos: Int?;
				    	 
		 
				var puntuacion: Double?;
				    	 
		 
				var usuarios_oid: [Int]?;
				    	 
		 
				var intentosItemActual: Int?;
				    	 
		 
				var finalizado: Bool?;
				    	 
		 
				var nivelActual: Int?;
				    	 
	   	   
			// MARK: - Constructor
			
			
		
			init ()
			{
				// Empty constructor
			}
			 func toDictionary() -> [String : AnyObject]
		
		   
			{
				var dictionary: [String : AnyObject] = [:];
				
			


				
					dictionary["id"] = self.id;
				

				
					dictionary["itemActual"] = self.itemActual;
				

				
					dictionary["aciertos"] = self.aciertos;
				

				
					dictionary["fallos"] = self.fallos;
				

				
					dictionary["puntuacion"] = self.puntuacion;
				

					dictionary["usuarios_oid"] = self.usuarios_oid;
			

				
					dictionary["intentosItemActual"] = self.intentosItemActual;
				

				
					dictionary["finalizado"] = self.finalizado;
				

				
					dictionary["nivelActual"] = self.nivelActual;
				
						
				return dictionary;
			}
		}
		
	