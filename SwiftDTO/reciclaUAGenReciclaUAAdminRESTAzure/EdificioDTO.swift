	
		//
		// EdificioDTO.swift
		// 
		// Code autogenerated. Do not modify this file.
		//
		
		import Foundation
		import SwiftyJSON
	
		 class EdificioDTO 	    {
		 
				var nombre: String?;
				    	 
		 
				var id: Int?;
				    	 
		 
				var estancias_oid: [String]?;
				    	 
		 
				var plantas_oid: [Int]?;
				    	 
	   	   
			// MARK: - Constructor
			
			
		
			init ()
			{
				// Empty constructor
			}
			 func toDictionary() -> [String : AnyObject]
		
		   
			{
				var dictionary: [String : AnyObject] = [:];
				
			


				
					dictionary["nombre"] = self.nombre;
				

				
					dictionary["id"] = self.id;
				

					dictionary["estancias_oid"] = self.estancias_oid;
			

					dictionary["plantas_oid"] = self.plantas_oid;
			
						
				return dictionary;
			}
		}
		
	