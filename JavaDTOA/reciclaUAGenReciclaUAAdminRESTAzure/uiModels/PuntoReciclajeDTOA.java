
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
public class PuntoReciclajeDTOA extends DTOA
{
	// region - Members, getters and setters

	private Integer id;
	public Integer getId () { return id; }
	public void setId (Integer id) { this.id = id; }

	
	private Double latitud;
	public Double getLatitud () { return latitud; }
	public void setLatitud (Double latitud) { this.latitud = latitud; }
	
	private Double longitud;
	public Double getLongitud () { return longitud; }
	public void setLongitud (Double longitud) { this.longitud = longitud; }
	
	private Estado esValido;
	public Estado getEsValido () { return esValido; }
	public void setEsValido (Estado esValido) { this.esValido = esValido; }
	
	
	/* Rol: PuntoReciclaje o--> Contenedor */
	private ArrayList<ContenedorDTOA> contenedores;
	public ArrayList<ContenedorDTOA> getContenedores () { return contenedores; }
	public void setContenedores (ArrayList<ContenedorDTOA> contenedores) { this.contenedores = contenedores; }

	/* Rol: PuntoReciclaje o--> Estancia */
	private EstanciaDTOA estanciaPunto;
	public EstanciaDTOA getEstanciaPunto () { return estanciaPunto; }
	public void setEstanciaPunto (EstanciaDTOA estanciaPunto) { this.estanciaPunto = estanciaPunto; }

	
	
	// endregion
	
	
	
	// region - Constructor and JSON <-> DTOA <-> DTO
	
	public PuntoReciclajeDTOA ()
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
			

			if (!JSONObject.NULL.equals(json.opt("Latitud")))
			{
			 
			 	String stringDouble = String.valueOf(json.opt("Latitud"));
 				this.latitud = Double.parseDouble(stringDouble);
			 
			}

			if (!JSONObject.NULL.equals(json.opt("Longitud")))
			{
			 
			 	String stringDouble = String.valueOf(json.opt("Longitud"));
 				this.longitud = Double.parseDouble(stringDouble);
			 
			}

			if (!JSONObject.NULL.equals(json.opt("EsValido")))
			{
				int enumRawValue = (int) json.opt("EsValido");
				this.esValido = Estado.fromRawValue(enumRawValue);
			 
			}
			

			JSONArray arrayContenedores = json.optJSONArray("Contenedores");
			if (arrayContenedores != null)
			{
				this.contenedores = new ArrayList<ContenedorDTOA>();
				for (int i = 0; i < arrayContenedores.length(); ++i)
				{
					JSONObject subJson = (JSONObject) arrayContenedores.opt(i);
					ContenedorDTOA tmp = new ContenedorDTOA();
					tmp.setFromJSON(subJson);
					this.contenedores.add(tmp);
				}
			}


			JSONObject jsonEstanciaPunto = json.optJSONObject("EstanciaPunto");
			if (jsonEstanciaPunto != null)
			{
				EstanciaDTOA tmp = new EstanciaDTOA();
				tmp.setFromJSON(jsonEstanciaPunto);
				this.estanciaPunto = tmp;
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
			
		
		  if (this.latitud != null)
			json.put("Latitud", this.latitud);
		
		
		  if (this.longitud != null)
			json.put("Longitud", this.longitud);
		
		
		  if (this.esValido != null)
			json.put("EsValido", this.esValido.getRawValue());
		
			

			if (this.contenedores != null)
			{
				JSONArray jsonArray = new JSONArray();
				for (int i = 0; i < this.contenedores.size(); ++i)
				{
					jsonArray.put(this.contenedores.get(i).toJSON());
				}
				json.put("Contenedores", jsonArray);
			}


			if (this.estanciaPunto != null)
			{
				json.put("EstanciaPunto", this.estanciaPunto.toJSON());
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
		PuntoReciclajeDTO dto = new PuntoReciclajeDTO ();
		
		// Attributes
		
	dto.setId (this.getId());

		
	dto.setLatitud (this.getLatitud());

	dto.setLongitud (this.getLongitud());

	dto.setEsValido (this.getEsValido());

		
		
		// Roles
					// TODO: from DTOA [ Contenedores ] (dataType : ArrayList<ContenedorDTOA>) to DTO [ Contenedores ]
					// TODO: from DTOA [ EstanciaPunto ] (dataType : EstanciaDTOA) to DTO [ Estancia ]
		
		
		return dto;
	}

	// endregion
}

	