
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
public class ItemDTOA extends DTOA
{
	// region - Members, getters and setters

	private Integer id;
	public Integer getId () { return id; }
	public void setId (Integer id) { this.id = id; }

	
	private String nombre;
	public String getNombre () { return nombre; }
	public void setNombre (String nombre) { this.nombre = nombre; }
	
	private String descripcion;
	public String getDescripcion () { return descripcion; }
	public void setDescripcion (String descripcion) { this.descripcion = descripcion; }
	
	private String imagen;
	public String getImagen () { return imagen; }
	public void setImagen (String imagen) { this.imagen = imagen; }
	
	private Estado esValido;
	public Estado getEsValido () { return esValido; }
	public void setEsValido (Estado esValido) { this.esValido = esValido; }
	
	private Integer puntuacion;
	public Integer getPuntuacion () { return puntuacion; }
	public void setPuntuacion (Integer puntuacion) { this.puntuacion = puntuacion; }
	
	
	/* Rol: Item o--> Material */
	private MaterialDTOA materialItem;
	public MaterialDTOA getMaterialItem () { return materialItem; }
	public void setMaterialItem (MaterialDTOA materialItem) { this.materialItem = materialItem; }

	
	
	// endregion
	
	
	
	// region - Constructor and JSON <-> DTOA <-> DTO
	
	public ItemDTOA ()
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
			

			if (!JSONObject.NULL.equals(json.opt("Nombre")))
			{
			 
				this.nombre = (String) json.opt("Nombre");
			 
			}

			if (!JSONObject.NULL.equals(json.opt("Descripcion")))
			{
			 
				this.descripcion = (String) json.opt("Descripcion");
			 
			}

			if (!JSONObject.NULL.equals(json.opt("Imagen")))
			{
			 
				this.imagen = (String) json.opt("Imagen");
			 
			}

			if (!JSONObject.NULL.equals(json.opt("EsValido")))
			{
				int enumRawValue = (int) json.opt("EsValido");
				this.esValido = Estado.fromRawValue(enumRawValue);
			 
			}

			if (!JSONObject.NULL.equals(json.opt("Puntuacion")))
			{
			 
				this.puntuacion = (Integer) json.opt("Puntuacion");
			 
			}
			

			JSONObject jsonMaterialItem = json.optJSONObject("MaterialItem");
			if (jsonMaterialItem != null)
			{
				MaterialDTOA tmp = new MaterialDTOA();
				tmp.setFromJSON(jsonMaterialItem);
				this.materialItem = tmp;
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
			
		
		  if (this.nombre != null)
			json.put("Nombre", this.nombre);
		
		
		  if (this.descripcion != null)
			json.put("Descripcion", this.descripcion);
		
		
		  if (this.imagen != null)
			json.put("Imagen", this.imagen);
		
		
		  if (this.esValido != null)
			json.put("EsValido", this.esValido.getRawValue());
		
		
		  if (this.puntuacion != null)
			json.put("Puntuacion", this.puntuacion.intValue());
		
			

			if (this.materialItem != null)
			{
				json.put("MaterialItem", this.materialItem.toJSON());
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
		ItemDTO dto = new ItemDTO ();
		
		// Attributes
		
	dto.setId (this.getId());

		
	dto.setNombre (this.getNombre());

	dto.setDescripcion (this.getDescripcion());

	dto.setImagen (this.getImagen());

	dto.setEsValido (this.getEsValido());

	dto.setPuntuacion (this.getPuntuacion());

		
		
		// Roles
					// TODO: from DTOA [ MaterialItem ] (dataType : MaterialDTOA) to DTO [ Material ]
		
		
		return dto;
	}

	// endregion
}

	