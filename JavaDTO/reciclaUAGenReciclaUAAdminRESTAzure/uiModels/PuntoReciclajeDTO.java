	
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
		
		
		public class PuntoReciclajeDTO 	    implements IDTO
	    {
				private Integer id;
				public Integer getId () { return id; } 
				public void setId  (Integer value) { id = value;  } 
				    	 
				private Double latitud;
				public Double getLatitud () { return latitud; } 
				public void setLatitud  (Double value) { latitud = value;  } 
				    	 
				private Double longitud;
				public Double getLongitud () { return longitud; } 
				public void setLongitud  (Double value) { longitud = value;  } 
				    	 
				private Estado esValido;
				public Estado getEsValido () { return esValido; } 
				public void setEsValido  (Estado value) { esValido = value;  } 
				    	 
				private Integer usuario_oid;
				public Integer  getUsuario_oid () { return usuario_oid; } 
				public void setUsuario_oid (Integer value) { usuario_oid = value;  } 
				    	 
				private ArrayList<ContenedorDTO> contenedores;
				public ArrayList<ContenedorDTO> getContenedores () { return contenedores; } 
				public void setContenedores (ArrayList<ContenedorDTO> value) { contenedores = value;  } 
				    	 
				private String estancia_oid;
				public String  getEstancia_oid () { return estancia_oid; } 
				public void setEstancia_oid (String value) { estancia_oid = value;  } 
				    	 
	   
			    public JSONObject toJSON ()
				{
					JSONObject json = new JSONObject();
					
					try
					{
				
						  json.put("Id", this.id.intValue());
				
				
						  json.put("Latitud", this.latitud);
				
				
						  json.put("Longitud", this.longitud);
				
				
						  json.put("EsValido", this.esValido.getRawValue());
				

						if (this.usuario_oid != null)
						{
							json.put("Usuario_oid", this.usuario_oid.intValue());
						}

						if (this.contenedores != null)
						{
							JSONArray jsonArray = new JSONArray();
							for (int i = 0; i < this.contenedores.size(); ++i)
							{
								jsonArray.put(this.contenedores.get(i).toJSON());
							}
							json.put("Contenedores", jsonArray);
						}

						if (this.estancia_oid != null)
						{
							json.put("Estancia_oid", this.estancia_oid);
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
	   
	   
	   
		
	