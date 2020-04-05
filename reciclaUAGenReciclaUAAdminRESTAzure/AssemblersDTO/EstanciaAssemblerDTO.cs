using System;
using System.Collections.Generic;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using reciclaUAGenReciclaUAAdminRESTAzure.DTO;

namespace reciclaUAGenReciclaUAAdminRESTAzure.AssemblersDTO
{
public class EstanciaAssemblerDTO {
public static IList<EstanciaEN> ConvertList (IList<EstanciaDTO> lista)
{
        IList<EstanciaEN> result = new List<EstanciaEN>();
        foreach (EstanciaDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static EstanciaEN Convert (EstanciaDTO dto)
{
        EstanciaEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new EstanciaEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Actividad = dto.Actividad;
                        newinstance.Latitud = dto.Latitud;
                        newinstance.Longitud = dto.Longitud;
                        newinstance.Nombre = dto.Nombre;
                        if (dto.Edificio_oid != -1) {
                                ReciclaUAGenNHibernate.CAD.ReciclaUA.IEdificioCAD edificioCAD = new ReciclaUAGenNHibernate.CAD.ReciclaUA.EdificioCAD ();

                                newinstance.Edificio = edificioCAD.ReadOIDDefault (dto.Edificio_oid);
                        }
                        if (dto.Planta_oid != -1) {
                                ReciclaUAGenNHibernate.CAD.ReciclaUA.IPlantaCAD plantaCAD = new ReciclaUAGenNHibernate.CAD.ReciclaUA.PlantaCAD ();

                                newinstance.Planta = plantaCAD.ReadOIDDefault (dto.Planta_oid);
                        }
                        if (dto.Puntos_oid != null) {
                                ReciclaUAGenNHibernate.CAD.ReciclaUA.IPuntoReciclajeCAD puntoReciclajeCAD = new ReciclaUAGenNHibernate.CAD.ReciclaUA.PuntoReciclajeCAD ();

                                newinstance.Puntos = new System.Collections.Generic.List<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN>();
                                foreach (int entry in dto.Puntos_oid) {
                                        newinstance.Puntos.Add (puntoReciclajeCAD.ReadOIDDefault (entry));
                                }
                        }
                }
        }
        catch (Exception ex)
        {
                throw ex;
        }
        return newinstance;
}
}
}
