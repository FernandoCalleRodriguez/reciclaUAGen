	
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
		
		
		public class TipoAccionDTO 	    implements IDTO
	    {
				private Integer id;
				public Integer getId () { return id; } 
				public void setId  (Integer value) { id = value;  } 
				    	 
				private Integer puntuacion;
				public Integer getPuntuacion () { return puntuacion; } 
				public void setPuntuacion  (Integer value) { puntuacion = value;  } 
				    	 
				private ArrayList<Integer> acciones_oid;
				public ArrayList<Integer>  getAcciones_oid () { return acciones_oid; } 
				public void setAcciones_oid (ArrayList<Integer> value) { acciones_oid = value;  } 
				    	 
				private String nombre;
				public String getNombre () { return nombre; } 
				public void setNombre  (String value) { nombre = value;  } 
				    	 
	   
			    public JSONObject toJSON ()
				{
					JSONObject json = new JSONObject();
					
					try
					{
				
						  json.put("Id", this.id.intValue());
				
				
						  json.put("Puntuacion", this.puntuacion.intValue());
				

						if (this.acciones_oid != null)
						{
							JSONArray jsonArray = new JSONArray();
							for (int i = 0; i < this.acciones_oid.size(); ++i)
							{
								jsonArray.put(this.acciones_oid.get(i));
							}
							json.put("Acciones_oid", jsonArray);
						}
		
				
						  json.put("Nombre", this.nombre);
				
						
					}
					catch (JSONException e)
					{
						e.printStackTrace();
					}
				
				return json;
			}
		
			// endregion
		}
	   
	   
	   
		
	