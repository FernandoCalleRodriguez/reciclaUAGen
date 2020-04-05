
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
public class AccionWebDTOA extends DTOA
{
	// region - Members, getters and setters

	private Integer id;
	public Integer getId () { return id; }
	public void setId (Integer id) { this.id = id; }

	
	private java.util.Date fecha;
	public java.util.Date getFecha () { return fecha; }
	public void setFecha (java.util.Date fecha) { this.fecha = fecha; }
	
	
	/* Rol: AccionWeb o--> TipoAccion */
	private TipoAccionDTOA tipo;
	public TipoAccionDTOA getTipo () { return tipo; }
	public void setTipo (TipoAccionDTOA tipo) { this.tipo = tipo; }

	
	
	// endregion
	
	
	
	// region - Constructor and JSON <-> DTOA <-> DTO
	
	public AccionWebDTOA ()
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
			

			if (!JSONObject.NULL.equals(json.opt("Fecha")))
			{
			 
			 	String stringDate = (String) json.opt("Fecha");
				this.fecha = DateUtils.stringToDateFormat(stringDate);
			 
			}
			

			JSONObject jsonTipo = json.optJSONObject("Tipo");
			if (jsonTipo != null)
			{
				TipoAccionDTOA tmp = new TipoAccionDTOA();
				tmp.setFromJSON(jsonTipo);
				this.tipo = tmp;
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
			
		
		  if (this.fecha != null)
			json.put("Fecha", DateUtils.dateToFormatString(this.fecha));
		
			

			if (this.tipo != null)
			{
				json.put("Tipo", this.tipo.toJSON());
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
		AccionWebDTO dto = new AccionWebDTO ();
		
		// Attributes
		
	dto.setId (this.getId());

		
	dto.setFecha (this.getFecha());

		
		
		// Roles
					// TODO: from DTOA [ Tipo ] (dataType : TipoAccionDTOA) to DTO [ Tipo ]
		
		
		return dto;
	}

	// endregion
}

	