	
		package reciclaUAGenReciclaUAAdminRESTAzure.uiModels.DTO;
		
		import java.util.ArrayList;
		
		import org.json.JSONArray;
		import org.json.JSONException;
		import org.json.JSONObject;
		import  reciclaUAGenReciclaUAAdminRESTAzure.uiModels.DTO.utils.*;
		import  reciclaUAGenReciclaUAAdminRESTAzure.uiModels.DTO.enumerations.*;
		
		
		/**
		 * Code autogenerated. Do not modify this file.
		 */
		
		
		public class NivelDTO 	    implements IDTO
	    {
				private Integer id;
				public Integer getId () { return id; } 
				public void setId  (Integer value) { id = value;  } 
				    	 
				private Integer numero;
				public Integer getNumero () { return numero; } 
				public void setNumero  (Integer value) { numero = value;  } 
				    	 
				private Integer puntuacion;
				public Integer getPuntuacion () { return puntuacion; } 
				public void setPuntuacion  (Integer value) { puntuacion = value;  } 
				    	 
				private ArrayList<Integer> item_oid;
				public ArrayList<Integer>  getItem_oid () { return item_oid; } 
				public void setItem_oid (ArrayList<Integer> value) { item_oid = value;  } 
				    	 
	   
			    public JSONObject toJSON ()
				{
					JSONObject json = new JSONObject();
					
					try
					{
				
						  json.put("Id", this.id.intValue());
				
				
						  json.put("Numero", this.numero.intValue());
				
				
						  json.put("Puntuacion", this.puntuacion.intValue());
				

						if (this.item_oid != null)
						{
							JSONArray jsonArray = new JSONArray();
							for (int i = 0; i < this.item_oid.size(); ++i)
							{
								jsonArray.put(this.item_oid.get(i));
							}
							json.put("Item_oid", jsonArray);
						}
		
						
					}
					catch (JSONException e)
					{
						e.printStackTrace();
					}
				
				return json;
			}
		
			// endregion
		}
	   
	   
	   
		
	