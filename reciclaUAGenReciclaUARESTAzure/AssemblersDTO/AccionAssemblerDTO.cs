using System;
using System.Collections.Generic;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using reciclaUAGenReciclaUARESTAzure.DTO;

namespace reciclaUAGenReciclaUARESTAzure.AssemblersDTO
{
public class AccionAssemblerDTO {
public static IList<AccionEN> ConvertList (IList<AccionDTO> lista)
{
        IList<AccionEN> result = new List<AccionEN>();
        foreach (AccionDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static AccionEN Convert (AccionDTO dto)
{
        AccionEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new AccionEN ();



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
