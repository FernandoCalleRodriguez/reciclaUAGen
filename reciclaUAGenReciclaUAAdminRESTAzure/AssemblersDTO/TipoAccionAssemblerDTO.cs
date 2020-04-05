using System;
using System.Collections.Generic;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using reciclaUAGenReciclaUAAdminRESTAzure.DTO;

namespace reciclaUAGenReciclaUAAdminRESTAzure.AssemblersDTO
{
public class TipoAccionAssemblerDTO {
public static IList<TipoAccionEN> ConvertList (IList<TipoAccionDTO> lista)
{
        IList<TipoAccionEN> result = new List<TipoAccionEN>();
        foreach (TipoAccionDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static TipoAccionEN Convert (TipoAccionDTO dto)
{
        TipoAccionEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new TipoAccionEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Puntuacion = dto.Puntuacion;
                        if (dto.Acciones_oid != null) {
                                ReciclaUAGenNHibernate.CAD.ReciclaUA.IAccionWebCAD accionWebCAD = new ReciclaUAGenNHibernate.CAD.ReciclaUA.AccionWebCAD ();

                                newinstance.Acciones = new System.Collections.Generic.List<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionWebEN>();
                                foreach (int entry in dto.Acciones_oid) {
                                        newinstance.Acciones.Add (accionWebCAD.ReadOIDDefault (entry));
                                }
                        }
                        newinstance.Nombre = dto.Nombre;
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
