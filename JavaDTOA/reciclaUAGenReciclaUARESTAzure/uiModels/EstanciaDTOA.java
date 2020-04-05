
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
public class EstanciaDTOA extends DTOA
{
	// region - Members, getters and setters

	private String id;
	public String getId () { return id; }
	public void setId (String id) { this.id = id; }

	
	private String actividad;
	public String getActividad () { return actividad; }
	public void setActividad (String actividad) { this.actividad = actividad; }
	
	private String latitud;
	public String getLatitud () { return latitud; }
	public void setLatitud (String latitud) { this.latitud = latitud; }
	
	private String longitud;
	public String getLongitud () { return longitud; }
	public void setLongitud (String longitud) { this.longitud = longitud; }
	
	private String nombre;
	public String getNombre () { return nombre; }
	public void setNombre (String nombre) { this.nombre = nombre; }
	
	
	/* Rol: Estancia o--> Edificio */
	private EdificioDTOA edificioEstancia;
	public EdificioDTOA getEdificioEstancia () { return edificioEstancia; }
	public void setEdificioEstancia (EdificioDTOA edificioEstancia) { this.edificioEstancia = edificioEstancia; }

	/* Rol: Estancia o--> Planta */
	private PlantaDTOA plantaEstancia;
	public PlantaDTOA getPlantaEstancia () { return plantaEstancia; }
	public void setPlantaEstancia (PlantaDTOA plantaEstancia) { this.plantaEstancia = plantaEstancia; }

	
	
	// endregion
	
	
	
	// region - Constructor and JSON <-> DTOA <-> DTO
	
	public EstanciaDTOA ()
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
				this.id = (String) json.opt("Id");
			}
			

			if (!JSONObject.NULL.equals(json.opt("Actividad")))
			{
			 
				this.actividad = (String) json.opt("Actividad");
			 
			}

			if (!JSONObject.NULL.equals(json.opt("Latitud")))
			{
			 
				this.latitud = (String) json.opt("Latitud");
			 
			}

			if (!JSONObject.NULL.equals(json.opt("Longitud")))
			{
			 
				this.longitud = (String) json.opt("Longitud");
			 
			}

			if (!JSONObject.NULL.equals(json.opt("Nombre")))
			{
			 
				this.nombre = (String) json.opt("Nombre");
			 
			}
			

			JSONObject jsonEdificioEstancia = json.optJSONObject("EdificioEstancia");
			if (jsonEdificioEstancia != null)
			{
				EdificioDTOA tmp = new EdificioDTOA();
				tmp.setFromJSON(jsonEdificioEstancia);
				this.edificioEstancia = tmp;
			}


			JSONObject jsonPlantaEstancia = json.optJSONObject("PlantaEstancia");
			if (jsonPlantaEstancia != null)
			{
				PlantaDTOA tmp = new PlantaDTOA();
				tmp.setFromJSON(jsonPlantaEstancia);
				this.plantaEstancia = tmp;
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
			
		
		  if (this.actividad != null)
			json.put("Actividad", this.actividad);
		
		
		  if (this.latitud != null)
			json.put("Latitud", this.latitud);
		
		
		  if (this.longitud != null)
			json.put("Longitud", this.longitud);
		
		
		  if (this.nombre != null)
			json.put("Nombre", this.nombre);
		
			

			if (this.edificioEstancia != null)
			{
				json.put("EdificioEstancia", this.edificioEstancia.toJSON());
			}


			if (this.plantaEstancia != null)
			{
				json.put("PlantaEstancia", this.plantaEstancia.toJSON());
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
		EstanciaDTO dto = new EstanciaDTO ();
		
		// Attributes
		
	dto.setId (this.getId());

		
	dto.setActividad (this.getActividad());

	dto.setLatitud (this.getLatitud());

	dto.setLongitud (this.getLongitud());

	dto.setNombre (this.getNombre());

		
		
		// Roles
					// TODO: from DTOA [ EdificioEstancia ] (dataType : EdificioDTOA) to DTO [ Edificio ]
					// TODO: from DTOA [ PlantaEstancia ] (dataType : PlantaDTOA) to DTO [ Planta ]
		
		
		return dto;
	}

	// endregion
}

	