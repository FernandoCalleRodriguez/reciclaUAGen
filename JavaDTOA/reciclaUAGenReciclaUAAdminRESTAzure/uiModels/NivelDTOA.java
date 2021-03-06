
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
public class NivelDTOA extends DTOA
{
	// region - Members, getters and setters

	private Integer id;
	public Integer getId () { return id; }
	public void setId (Integer id) { this.id = id; }

	
	private Integer numero;
	public Integer getNumero () { return numero; }
	public void setNumero (Integer numero) { this.numero = numero; }
	
	private Integer puntuacion;
	public Integer getPuntuacion () { return puntuacion; }
	public void setPuntuacion (Integer puntuacion) { this.puntuacion = puntuacion; }
	
	
	
	
	// endregion
	
	
	
	// region - Constructor and JSON <-> DTOA <-> DTO
	
	public NivelDTOA ()
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
			

			if (!JSONObject.NULL.equals(json.opt("Numero")))
			{
			 
				this.numero = (Integer) json.opt("Numero");
			 
			}

			if (!JSONObject.NULL.equals(json.opt("Puntuacion")))
			{
			 
				this.puntuacion = (Integer) json.opt("Puntuacion");
			 
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
			
		
		  if (this.numero != null)
			json.put("Numero", this.numero.intValue());
		
		
		  if (this.puntuacion != null)
			json.put("Puntuacion", this.puntuacion.intValue());
		
			
			
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
		NivelDTO dto = new NivelDTO ();
		
		// Attributes
		
	dto.setId (this.getId());

		
	dto.setNumero (this.getNumero());

	dto.setPuntuacion (this.getPuntuacion());

		
		
		// Roles
		
		
		return dto;
	}

	// endregion
}

	