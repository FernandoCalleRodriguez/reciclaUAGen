	
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
		
		
		public class EstanciaDTO 	    implements IDTO
	    {
				private String id;
				public String getId () { return id; } 
				public void setId  (String value) { id = value;  } 
				    	 
				private String actividad;
				public String getActividad () { return actividad; } 
				public void setActividad  (String value) { actividad = value;  } 
				    	 
				private Double latitud;
				public Double getLatitud () { return latitud; } 
				public void setLatitud  (Double value) { latitud = value;  } 
				    	 
				private Double longitud;
				public Double getLongitud () { return longitud; } 
				public void setLongitud  (Double value) { longitud = value;  } 
				    	 
				private String nombre;
				public String getNombre () { return nombre; } 
				public void setNombre  (String value) { nombre = value;  } 
				    	 
				private Integer edificio_oid;
				public Integer  getEdificio_oid () { return edificio_oid; } 
				public void setEdificio_oid (Integer value) { edificio_oid = value;  } 
				    	 
				private Integer planta_oid;
				public Integer  getPlanta_oid () { return planta_oid; } 
				public void setPlanta_oid (Integer value) { planta_oid = value;  } 
				    	 
				private ArrayList<Integer> puntos_oid;
				public ArrayList<Integer>  getPuntos_oid () { return puntos_oid; } 
				public void setPuntos_oid (ArrayList<Integer> value) { puntos_oid = value;  } 
				    	 
	   
			    public JSONObject toJSON ()
				{
					JSONObject json = new JSONObject();
					
					try
					{
				
						  json.put("Id", this.id);
				
				
						  json.put("Actividad", this.actividad);
				
				
						  json.put("Latitud", this.latitud);
				
				
						  json.put("Longitud", this.longitud);
				
				
						  json.put("Nombre", this.nombre);
				

						if (this.edificio_oid != null)
						{
							json.put("Edificio_oid", this.edificio_oid.intValue());
						}

						if (this.planta_oid != null)
						{
							json.put("Planta_oid", this.planta_oid.intValue());
						}

						if (this.puntos_oid != null)
						{
							JSONArray jsonArray = new JSONArray();
							for (int i = 0; i < this.puntos_oid.size(); ++i)
							{
								jsonArray.put(this.puntos_oid.get(i));
							}
							json.put("Puntos_oid", jsonArray);
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
	   
	   
	   
		
	