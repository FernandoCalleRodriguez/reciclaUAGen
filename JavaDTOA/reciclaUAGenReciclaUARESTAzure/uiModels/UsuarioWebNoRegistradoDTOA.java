
package reciclaUAGenReciclaUARESTAzure.uiModels.DTOA;

import reciclaUAGenReciclaUARESTAzure.uiModels.DTO.*;
import reciclaUAGenReciclaUARESTAzure.uiModels.DTO.utils.*;
import reciclaUAGenReciclaUARESTAzure.uiModels.DTO.enumerations.*;

import java.util.ArrayList;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

/**
 * Code autogenerated. Do not modify this file.
 */
public class UsuarioWebNoRegistradoDTOA extends DTOA
{
	// region - Members, getters and setters

	private Integer id;
	public Integer getId () { return id; }
	public void setId (Integer id) { this.id = id; }

	
	private String email;
	public String getEmail () { return email; }
	public void setEmail (String email) { this.email = email; }
	
	
	
	
	// endregion
	
	
	
	// region - Constructor and JSON <-> DTOA <-> DTO
	
	public UsuarioWebNoRegistradoDTOA ()
	{
		// Empty constructor
	}
	
	@Override
	public void setFromJSON (JSONObject json)
	{
		try
		{
			if (!JSONObject.NULL.equals(json.opt("Id")))
			{
				this.id = (Integer) json.opt("Id");
			}
			

			if (!JSONObject.NULL.equals(json.opt("Email")))
			{
			 
				this.email = (String) json.opt("Email");
			 
			}
			
			
		}
		catch (Exception e)
		{
			e.printStackTrace();
		}
	}
	
	public JSONObject toJSON ()
	{
		JSONObject json = new JSONObject();
		
		try
		{
			if (this.id != null){
				json.put("Id", this.id);
			}
			
		
		  if (this.email != null)
			json.put("Email", this.email);
		
			
			
		}
		catch (JSONException e)
		{
			e.printStackTrace();
		}
		
		return json;
	}
	
	@Override 
	public IDTO toDTO ()
	{
		UsuarioWebDTO dto = new UsuarioWebDTO ();
		
		// Attributes
		
	dto.setId (this.getId());

		
	dto.setEmail (this.getEmail());

		
		
		// Roles
		
		
		return dto;
	}

	// endregion
}

	