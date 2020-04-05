using System;
using System.Collections.Generic;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using reciclaUAGenReciclaUAAdminRESTAzure.DTO;

namespace reciclaUAGenReciclaUAAdminRESTAzure.AssemblersDTO
{
public class RespuestaAssemblerDTO {
public static IList<RespuestaEN> ConvertList (IList<RespuestaDTO> lista)
{
        IList<RespuestaEN> result = new List<RespuestaEN>();
        foreach (RespuestaDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static RespuestaEN Convert (RespuestaDTO dto)
{
        RespuestaEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new RespuestaEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Cuerpo = dto.Cuerpo;
                        if (dto.Duda_oid != -1) {
                                ReciclaUAGenNHibernate.CAD.ReciclaUA.IDudaCAD dudaCAD = new ReciclaUAGenNHibernate.CAD.ReciclaUA.DudaCAD ();

                                newinstance.Duda = dudaCAD.ReadOIDDefault (dto.Duda_oid);
                        }
                        if (dto.Usuario_oid != -1) {
                                ReciclaUAGenNHibernate.CAD.ReciclaUA.IUsuarioCAD usuarioCAD = new ReciclaUAGenNHibernate.CAD.ReciclaUA.UsuarioCAD ();

                                newinstance.Usuario = usuarioCAD.ReadOIDDefault (dto.Usuario_oid);
                        }
                        newinstance.Fecha = dto.Fecha;
                        newinstance.EsCorrecta = dto.EsCorrecta;
                        newinstance.Util = dto.Util;
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
