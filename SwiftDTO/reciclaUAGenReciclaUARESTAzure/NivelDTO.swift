	
		//
		// NivelDTO.swift
		// 
		// Code autogenerated. Do not modify this file.
		//
		
		import Foundation
		import SwiftyJSON
	
		 class NivelDTO 	    {
		 
				var id: Int?;
				    	 
		 
				var numero: Int?;
				    	 
		 
				var puntuacion: Int?;
				    	 
		 
				var item_oid: [Int]?;
				    	 
	   	   
			// MARK: - Constructor
			
			
		
			init ()
			{
				// Empty constructor
			}
			 func toDictionary() -> [String : AnyObject]
		
		   
			{
				var dictionary: [String : AnyObject] = [:];
				
			


				
					dictionary["id"] = self.id;
				

				
					dictionary["numero"] = self.numero;
				

				
					dictionary["puntuacion"] = self.puntuacion;
				

					dictionary["item_oid"] = self.item_oid;
			
						
				return dictionary;
			}
		}
		
	