	
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
		
		
		public class UsuarioAdministradorDTO extends    		UsuarioDTO
	    implements IDTO
	    {
				private ArrayList<Integer> notas_oid;
				public ArrayList<Integer>  getNotas_oid () { return notas_oid; } 
				public void setNotas_oid (ArrayList<Integer> value) { notas_oid = value;  } 
				    	 
	   
			    public JSONObject toJSON ()
				{
					JSONObject json = new JSONObject();
					
					try
					{

						if (this.notas_oid != null)
						{
							JSONArray jsonArray = new JSONArray();
							for (int i = 0; i < this.notas_oid.size(); ++i)
							{
								jsonArray.put(this.notas_oid.get(i));
							}
							json.put("Notas_oid", jsonArray);
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
	   
	   
	   
		
	