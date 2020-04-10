
package reciclaUAGenReciclaUAAdminRESTAzure.uiModels.DTOA;

import reciclaUAGenReciclaUAAdminRESTAzure.uiModels.DTO.*;
import reciclaUAGenReciclaUAAdminRESTAzure.uiModels.DTO.utils.*;
import reciclaUAGenReciclaUAAdminRESTAzure.uiModels.DTO.enumerations.*;

import java.util.ArrayList;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

/**
 * Code autogenerated. Do not modify this file.
 */
public class UsuarioAdminRecuperarPassDTOA extends DTOA
{
	// region - Members, getters and setters

	private Integer id;
	public Integer getId () { return id; }
	public void setId (Integer id) { this.id = id; }

	
	
	
	
	// endregion
	
	
	
	// region - Constructor and JSON <-> DTOA <-> DTO
	
	public UsuarioAdminRecuperarPassDTOA ()
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
		UsuarioAdministradorDTO dto = new UsuarioAdministradorDTO ();
		
		// Attributes
		
	dto.setId (this.getId());

		
		
		
		// Roles
		
		
		return dto;
	}

	// endregion
}

	