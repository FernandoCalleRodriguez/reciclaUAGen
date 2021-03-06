	
		package reciclaUAGenReciclaUARESTAzure.uiModels.DTO;
		
		import java.util.ArrayList;
		
		import org.json.JSONArray;
		import org.json.JSONException;
		import org.json.JSONObject;
		import  reciclaUAGenReciclaUARESTAzure.uiModels.DTO.utils.*;
		import  reciclaUAGenReciclaUARESTAzure.uiModels.DTO.enumerations.*;
		
		
		/**
		 * Code autogenerated. Do not modify this file.
		 */
		
		
		public class NotaInformativaDTO 	    implements IDTO
	    {
				private Integer id;
				public Integer getId () { return id; } 
				public void setId  (Integer value) { id = value;  } 
				    	 
				private Integer usuarioAdministrador_oid;
				public Integer  getUsuarioAdministrador_oid () { return usuarioAdministrador_oid; } 
				public void setUsuarioAdministrador_oid (Integer value) { usuarioAdministrador_oid = value;  } 
				    	 
				private String titulo;
				public String getTitulo () { return titulo; } 
				public void setTitulo  (String value) { titulo = value;  } 
				    	 
				private String cuerpo;
				public String getCuerpo () { return cuerpo; } 
				public void setCuerpo  (String value) { cuerpo = value;  } 
				    	 
				private java.util.Date fecha;
				public java.util.Date getFecha () { return fecha; } 
				public void setFecha  (java.util.Date value) { fecha = value;  } 
				    	 
	   
			    public JSONObject toJSON ()
				{
					JSONObject json = new JSONObject();
					
					try
					{
				
						  json.put("Id", this.id.intValue());
				

						if (this.usuarioAdministrador_oid != null)
						{
							json.put("UsuarioAdministrador_oid", this.usuarioAdministrador_oid.intValue());
						}
				
						  json.put("Titulo", this.titulo);
				
				
						  json.put("Cuerpo", this.cuerpo);
				
				
						  json.put("Fecha", DateUtils.dateToFormatString(this.fecha));
				
						
					}
					catch (JSONException e)
					{
						e.printStackTrace();
					}
				
				return json;
			}
		
			// endregion
		}
	   
	   
	   
		
	