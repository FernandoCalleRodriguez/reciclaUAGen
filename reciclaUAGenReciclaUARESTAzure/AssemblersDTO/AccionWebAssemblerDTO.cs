using System;
using System.Collections.Generic;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using reciclaUAGenReciclaUARESTAzure.DTO;

namespace reciclaUAGenReciclaUARESTAzure.AssemblersDTO
{
public class AccionWebAssemblerDTO {
public static IList<AccionWebEN> ConvertList (IList<AccionWebDTO> lista)
{
        IList<AccionWebEN> result = new List<AccionWebEN>();
        foreach (AccionWebDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static AccionWebEN Convert (AccionWebDTO dto)
{
        AccionWebEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new AccionWebEN ();



                        if (dto.Tipo_oid != -1) {
                                ReciclaUAGenNHibernate.CAD.ReciclaUA.ITipoAccionCAD tipoAccionCAD = new ReciclaUAGenNHibernate.CAD.ReciclaUA.TipoAccionCAD ();

                                newinstance.Tipo = tipoAccionCAD.ReadOIDDefault (dto.Tipo_oid);
                        }
                        newinstance.Id = dto.Id;
                        if (dto.Usuario_oid != -1) {
                                ReciclaUAGenNHibernate.CAD.ReciclaUA.IUsuarioWebCAD usuarioWebCAD = new ReciclaUAGenNHibernate.CAD.ReciclaUA.UsuarioWebCAD ();

                                newinstance.Usuario = usuarioWebCAD.ReadOIDDefault (dto.Usuario_oid);
                        }
                        newinstance.Fecha = dto.Fecha;
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
