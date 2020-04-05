
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
public class UsuarioWebAutenticadoDTOA extends DTOA
{
	// region - Members, getters and setters

	
	private String nombre;
	public String getNombre () { return nombre; }
	public void setNombre (String nombre) { this.nombre = nombre; }
	
	private String apellidos;
	public String getApellidos () { return apellidos; }
	public void setApellidos (String apellidos) { this.apellidos = apellidos; }
	
	private String email;
	public String getEmail () { return email; }
	public void setEmail (String email) { this.email = email; }
	
	private Integer id;
	public Integer getId () { return id; }
	public void setId (Integer id) { this.id = id; }
	
	private Integer puntuacion;
	public Integer getPuntuacion () { return puntuacion; }
	public void setPuntuacion (Integer puntuacion) { this.puntuacion = puntuacion; }
	
	private java.util.Date fecha;
	public java.util.Date getFecha () { return fecha; }
	public void setFecha (java.util.Date fecha) { this.fecha = fecha; }
	
	private Boolean borrado;
	public Boolean getBorrado () { return borrado; }
	public void setBorrado (Boolean borrado) { this.borrado = borrado; }
	
	
	
	
	// endregion
	
	
	
	// region - Constructor and JSON <-> DTOA <-> DTO
	
	public UsuarioWebAutenticadoDTOA ()
	{
		// Empty constructor
	}
	
	@Override
	public void setFromJSON (JSONObject json)
	{
		try
		{
			

			if (!JSONObject.NULL.equals(json.opt("Nombre")))
			{
			 
				this.nombre = (String) json.opt("Nombre");
			 
			}

			if (!JSONObject.NULL.equals(json.opt("Apellidos")))
			{
			 
				this.apellidos = (String) json.opt("Apellidos");
			 
			}

			if (!JSONObject.NULL.equals(json.opt("Email")))
			{
			 
				this.email = (String) json.opt("Email");
			 
			}

			if (!JSONObject.NULL.equals(json.opt("Id")))
			{
			 
				this.id = (Integer) json.opt("Id");
			 
			}

			if (!JSONObject.NULL.equals(json.opt("Puntuacion")))
			{
			 
				this.puntuacion = (Integer) json.opt("Puntuacion");
			 
			}

			if (!JSONObject.NULL.equals(json.opt("Fecha")))
			{
			 
			 	String stringDate = (String) json.opt("Fecha");
				this.fecha = DateUtils.stringToDateFormat(stringDate);
			 
			}

			if (!JSONObject.NULL.equals(json.opt("Borrado")))
			{
			 
				this.borrado = (Boolean) json.opt("Borrado");
			 
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
			
		
		  if (this.nombre != null)
			json.put("Nombre", this.nombre);
		
		
		  if (this.apellidos != null)
			json.put("Apellidos", this.apellidos);
		
		
		  if (this.email != null)
			json.put("Email", this.email);
		
		
		  if (this.id != null)
			json.put("Id", this.id.intValue());
		
		
		  if (this.puntuacion != null)
			json.put("Puntuacion", this.puntuacion.intValue());
		
		
		  if (this.fecha != null)
			json.put("Fecha", DateUtils.dateToFormatString(this.fecha));
		
		
		  if (this.borrado != null)
			json.put("Borrado", this.borrado);
		
			
			
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
		
		
	dto.setNombre (this.getNombre());

	dto.setApellidos (this.getApellidos());

	dto.setEmail (this.getEmail());

	dto.setId (this.getId());

	dto.setPuntuacion (this.getPuntuacion());

	dto.setFecha (this.getFecha());

	dto.setBorrado (this.getBorrado());

		
		
		// Roles
		
		
		return dto;
	}

	// endregion
}

	